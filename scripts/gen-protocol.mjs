#!/usr/bin/env node
/**
 * Verifica que o contrato do Python e o espelho em TypeScript concordam.
 *
 * A fonte da verdade é services/sidecar/src/sidecar/protocol.py. O arquivo
 * packages/protocol/src/index.ts é um espelho manual, e nada impede alguém de
 * adicionar um método no `Handlers` e esquecer do TS.
 *
 * Este script compara:
 *   - a lista de métodos do `Handlers` com as chaves de `interface MethodMap`;
 *   - PROTOCOL_VERSION (Python) com o `v: <n>` do envelope (TS).
 *
 * Sai com código 1 e mostra o diff quando divergem, para o erro aparecer aqui e
 * não no meio de um `invoke()` em runtime.
 *
 * Ele NÃO reescreve o TypeScript: um gerador produziria um arquivo que ninguém
 * consegue comentar, e parte do contrato é escrita à mão de propósito
 * (`SidecarStatus` vem do Rust, por exemplo). Comparar já resolve o problema.
 *
 * Em Node e não em PowerShell de propósito: assim roda igual no Windows, no
 * Linux e no CI, sem BOM, sem política de execução e sem codepage.
 *
 *   npm run protocol:gen
 */
import { execFileSync } from "node:child_process";
import { readFileSync } from "node:fs";
import { dirname, join, resolve } from "node:path";
import { fileURLToPath } from "node:url";

const repoRoot = resolve(dirname(fileURLToPath(import.meta.url)), "..");
const sidecarDir = join(repoRoot, "services", "sidecar");
const tsPath = join(repoRoot, "packages", "protocol", "src", "index.ts");

const red = (text) => `\u001b[31m${text}\u001b[0m`;
const green = (text) => `\u001b[32m${text}\u001b[0m`;

/** Lê o contrato do Python pelo `uv`, para valer o ambiente do pyproject.toml. */
function readPythonContract() {
  const args = [
    "run",
    "--directory",
    sidecarDir,
    "--no-progress",
    "python",
    "tools/dump_contract.py",
  ];
  try {
    // stdio explícito porque o padrão das funções *Sync é herdar o stderr: sem
    // isto o aviso de VIRTUAL_ENV do uv poluiria a saída. Com stderr capturado,
    // ele só aparece se o comando realmente falhar.
    return JSON.parse(
      execFileSync("uv", args, { encoding: "utf8", stdio: ["ignore", "pipe", "pipe"] }),
    );
  } catch (error) {
    const stderr = String(error.stderr ?? "").trim();
    throw new Error(
      `falha ao executar "uv ${args.join(" ")}"${stderr ? `:\n${stderr}` : ""}`,
    );
  }
}

/** Chaves de `export interface MethodMap { ... }`. */
function readTsMethods(source) {
  // Um `[^}]*` ingênuo pararia no primeiro `}` — o do `Record<string, never>` de
  // um método — e só o primeiro método seria visto.
  const block = source.match(/export interface MethodMap\s*\{([\s\S]*?)\r?\n\}/);
  if (!block) throw new Error(`não encontrei "export interface MethodMap" em ${tsPath}`);
  return [...block[1].matchAll(/^ {2}([a-z_][a-z0-9_]*)\s*:/gm)].map((match) => match[1]);
}

function main() {
  console.log("==> Contrato do Python");
  const contract = readPythonContract();
  if (typeof contract.version !== "number") {
    throw new Error("o contrato do Python não trouxe `version` numérico");
  }
  const pyMethods = [...new Set(contract.methods ?? [])].sort();
  console.log(`    v${contract.version}, ${pyMethods.length} método(s): ${pyMethods.join(", ")}`);

  console.log("==> Espelho TypeScript");
  const source = readFileSync(tsPath, "utf8");
  const tsMethods = [...new Set(readTsMethods(source))].sort();
  console.log(`    ${tsMethods.length} método(s): ${tsMethods.join(", ")}`);

  const failures = [];
  const onlyInPy = pyMethods.filter((method) => !tsMethods.includes(method));
  const onlyInTs = tsMethods.filter((method) => !pyMethods.includes(method));
  if (onlyInPy.length > 0) failures.push(`existe no Python e falta no TS: ${onlyInPy.join(", ")}`);
  if (onlyInTs.length > 0) failures.push(`existe no TS e falta no Python: ${onlyInTs.join(", ")}`);

  // O primeiro `v: <n>;` do arquivo é o do RequestEnvelope.
  const versionMatch = source.match(/v:\s*(\d+)\s*;/);
  if (!versionMatch) {
    failures.push(`não encontrei "v: <n>;" em ${tsPath}`);
  } else if (Number(versionMatch[1]) !== contract.version) {
    failures.push(
      `versão do protocolo: ${contract.version} no Python, ${versionMatch[1]} no TS`,
    );
  }

  if (failures.length > 0) {
    console.log("");
    console.log(red("CONTRATO DIVERGENTE"));
    for (const failure of failures) console.log(red(`  - ${failure}`));
    console.log("");
    console.log("Ajuste packages/protocol/src/index.ts — ou protocol.py, se o Python é que está errado.");
    return 1;
  }

  console.log(green(`OK: contrato em sincronia (v${contract.version}, ${pyMethods.length} método(s)).`));
  return 0;
}

try {
  process.exitCode = main();
} catch (error) {
  console.error(red(`ERRO: ${error.message}`));
  process.exitCode = 1;
}
