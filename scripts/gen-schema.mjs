#!/usr/bin/env node
/**
 * Gera os tipos do contrato de dados a partir de
 * `services/sidecar/src/sidecar/db/schema.sql` (FONTE DA VERDADE do schema).
 *
 * Produz dois artefatos, um por frontend (ver docs/POSITRON.md):
 *   - packages/protocol/src/schema.generated.ts   (frontend APP, TS)
 *   - packages/protocol/csharp/Tables.g.cs        (frontend ZWCAD, C#)
 *
 * Mesmo princípio do `gen-protocol.mjs`: o contrato é único e o build falha
 * quando um espelho diverge. Aqui, porém, os espelhos são mecânicos, então o
 * gerador os ESCREVE:
 *
 *     node scripts/gen-schema.mjs --write   # regrava os dois artefatos
 *     node scripts/gen-schema.mjs           # só CONFERE; sai 1 se estiver velho
 *
 * `npm run protocol:gen` roda o modo conferência; `npm run schema:sync` regrava.
 *
 * Em Node (e não PowerShell) para rodar igual no Windows, Linux e CI, sem BOM e
 * sem codepage — igual ao gen-protocol.
 */
import { mkdirSync, readFileSync, writeFileSync } from "node:fs";
import { dirname, join, resolve } from "node:path";
import { fileURLToPath } from "node:url";

const repoRoot = resolve(dirname(fileURLToPath(import.meta.url)), "..");
const schemaPath = join(repoRoot, "services", "sidecar", "src", "sidecar", "db", "schema.sql");
const tsPath = join(repoRoot, "packages", "protocol", "src", "schema.generated.ts");
const csPath = join(repoRoot, "packages", "protocol", "csharp", "Tables.g.cs");

const write = process.argv.includes("--write");
const red = (t) => `\u001b[31m${t}\u001b[0m`;
const green = (t) => `\u001b[32m${t}\u001b[0m`;

/* ------------------------------------------------------------------ */
/* Parsing do DDL                                                      */
/* ------------------------------------------------------------------ */

/** Divide a lista de colunas por vírgula respeitando parênteses (ex.: `PRIMARY KEY (a, b)`). */
function splitTopLevel(source) {
  const out = [];
  let depth = 0;
  let current = "";
  for (const ch of source) {
    if (ch === "," && depth === 0) {
      out.push(current);
      current = "";
      continue;
    }
    current += ch;
    if (ch === "(") depth += 1;
    else if (ch === ")") depth -= 1;
  }
  if (current.trim()) out.push(current);
  return out;
}

/** Tipo SQL -> categoria da linguagem. SQLite é frouxo, então normalizamos. */
function kindOf(sqlType) {
  const type = sqlType.toUpperCase();
  if (/^(INT|INTEGER|SMALLINT|BIGINT|TINYINT|MEDIUMINT)$/.test(type)) return "int";
  if (/^(BOOL|BOOLEAN)$/.test(type)) return "bool";
  if (/^(REAL|DOUBLE|FLOAT|NUMERIC|DECIMAL)$/.test(type)) return "real";
  if (/^(DATE|DATETIME|TIMESTAMP)$/.test(type)) return "datetime";
  if (/^BLOB$/.test(type)) return "blob";
  return "text";
}

function parseSchema(sql) {
  // Remove comentários de linha antes de tokenizar.
  const stripped = sql.replace(/--[^\n]*/g, "");
  const tables = [];
  const re = /CREATE\s+TABLE\s+(?:IF\s+NOT\s+EXISTS\s+)?["`[]?(\w+)["`\]]?\s*\(([\s\S]*?)\)\s*;/gi;
  for (const match of stripped.matchAll(re)) {
    const [, name, body] = match;
    const columns = [];
    for (const raw of splitTopLevel(body)) {
      const def = raw.trim();
      if (!def) continue;
      const col = def.match(/^["`[]?(\w+)["`\]]?\s+([A-Za-z][A-Za-z0-9_]*)\s*(?:\([^)]*\))?\s*([\s\S]*)$/);
      if (!col) continue;
      const [, columnName, sqlType] = col;
      // Linhas de restrição da tabela não são colunas.
      if (/^(PRIMARY|UNIQUE|FOREIGN|CHECK|CONSTRAINT|KEY)$/i.test(columnName)) continue;
      const nullable = !/NOT\s+NULL|PRIMARY\s+KEY/i.test(def);
      columns.push({ name: columnName, kind: kindOf(sqlType), sqlType: sqlType.toUpperCase(), nullable });
    }
    if (columns.length === 0) throw new Error(`tabela ${name} sem colunas legíveis`);
    tables.push({ name, columns });
  }
  if (tables.length === 0) throw new Error(`nenhum CREATE TABLE encontrado em ${schemaPath}`);
  return tables;
}

/* ------------------------------------------------------------------ */
/* Geradores                                                           */
/* ------------------------------------------------------------------ */

const tsType = (column) => {
  const base = { int: "number", real: "number", bool: "boolean", datetime: "string", text: "string", blob: "Uint8Array" }[column.kind];
  return column.nullable ? `${base} | null` : base;
};

// C#: só tipos-valor ganham `?`. Tipos de referência ficam sem anotação de
// nulidade de propósito — a anotação (`string?`) exige C# 8 e o plugin é
// net472 (C# 7.3), onde ela nem é válida.
const csType = (column) => {
  const base = { int: "long", real: "double", bool: "bool", datetime: "System.DateTime", text: "string", blob: "byte[]" }[column.kind];
  const isValueType = column.kind !== "text" && column.kind !== "blob";
  return column.nullable && isValueType ? `${base}?` : base;
};

function generateTs(tables) {
  const header = [
    "// GERADO POR scripts/gen-schema.mjs a partir de db/schema.sql — NÃO EDITE.",
    "// Rode `npm run schema:sync` para regravar; `npm run protocol:gen` falha se estiver velho.",
    "//",
    "// Tipos do contrato de dados compartilhado entre os dois frontends",
    "// (ver docs/POSITRON.md). Colunas anuláveis aparecem como `T | null`.",
  ].join("\n");
  const blocks = tables.map((table) => {
    const lines = table.columns.map((c) => `  ${c.name}: ${tsType(c)};`);
    return `export interface ${table.name} {\n${lines.join("\n")}\n}`;
  });
  const mapLines = tables.map((t) => `  ${t.name}: ${t.name};`);
  return `${header}\n\n${blocks.join("\n\n")}\n\n/** Mapa tabela -> tipo da linha. */\nexport interface TableMap {\n${mapLines.join("\n")}\n}\n\nexport type TableName = keyof TableMap;\nexport type Row<T extends TableName> = TableMap[T];\n`;
}

function generateCs(tables) {
  const header = [
    "// GERADO POR scripts/gen-schema.mjs a partir de db/schema.sql — NÃO EDITE.",
    "// Rode `npm run schema:sync` para regravar; `npm run protocol:gen` falha se estiver velho.",
    "//",
    "// Contrato de dados do frontend ZWCAD (plugin .NET). O plugin lê/escreve estas",
    "// tabelas direto no SQLite do projeto — o schema é a interface (docs/POSITRON.md).",
    "//",
    "// Classes simples (get/set), deliberadamente compatíveis com o net472/C# 7.3 do",
    "// plugin: nada de records, init-only ou anotações de nulidade de referência (todas",
    "// exigiriam C# 8+). Colunas de tipo-valor anuláveis viram T?; o NULL de colunas",
    "// string/byte[] não é expresso em tipo.",
    "//",
    "// As classes levam o sufixo Row porque o C# proíbe um membro com o nome do tipo",
    "// delimitador: a tabela Cabos tem uma coluna Cabos (erro CS0542).",
  ].join("\n");
  const blocks = tables.map((table) => {
    const lines = table.columns.map((c) => `        public ${csType(c)} ${c.name} { get; set; }`);
    return [
      `    /// <summary>Linha da tabela <c>${table.name}</c>.</summary>`,
      `    public sealed class ${table.name}Row`,
      "    {",
      lines.join("\n"),
      "    }",
    ].join("\n");
  });
  return `${header}\n\nnamespace Positron.Contract\n{\n${blocks.join("\n\n")}\n}\n`;
}

/* ------------------------------------------------------------------ */
/* Conferência / escrita                                               */
/* ------------------------------------------------------------------ */

function normalize(text) {
  return text.replace(/\r\n/g, "\n");
}

function compare(file, generated) {
  let current = "";
  try {
    current = readFileSync(file, "utf8");
  } catch {
    return "não existe";
  }
  return normalize(current) === normalize(generated) ? null : "desatualizado";
}

function main() {
  const sql = readFileSync(schemaPath, "utf8");
  const tables = parseSchema(sql);
  const totalColumns = tables.reduce((sum, t) => sum + t.columns.length, 0);
  console.log(
    `==> ${tables.length} tabela(s), ${totalColumns} coluna(s) em ${schemaPath.replace(repoRoot, ".")}`,
  );

  const artifacts = [
    { file: tsPath, content: generateTs(tables), label: "TS" },
    { file: csPath, content: generateCs(tables), label: "C#" },
  ];

  if (write) {
    for (const artifact of artifacts) {
      mkdirSync(dirname(artifact.file), { recursive: true });
      writeFileSync(artifact.file, artifact.content);
      console.log(`    ${artifact.label}: ${artifact.file.replace(repoRoot, ".")} regravado`);
    }
    console.log(green(`OK: tipos do schema sincronizados (${tables.length} tabela(s)).`));
    return 0;
  }

  const failures = artifacts
    .map((artifact) => ({ ...artifact, status: compare(artifact.file, artifact.content) }))
    .filter((artifact) => artifact.status);

  if (failures.length > 0) {
    console.log("");
    console.log(red("TIPOS DO SCHEMA DIVERGENTES"));
    for (const failure of failures) {
      console.log(red(`  - ${failure.label} ${failure.status}: ${failure.file.replace(repoRoot, ".")}`));
    }
    console.log("");
    console.log("Rode `npm run schema:sync` para regravar a partir de db/schema.sql.");
    return 1;
  }

  console.log(green(`OK: tipos do schema em sincronia (${tables.length} tabela(s)).`));
  return 0;
}

try {
  process.exitCode = main();
} catch (error) {
  console.error(red(`ERRO: ${error.message}`));
  process.exitCode = 1;
}
