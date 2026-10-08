/**
 * Bootstrap completo do ambiente de desenvolvimento.
 *
 * Etapas (executadas em sequência, falha para tudo se qualquer uma falhar):
 *   1. npm install          — garante node_modules atualizado
 *   2. uv sync             — ambiente Python do sidecar
 *   3. protocol:gen        — confere que TS e Python estão em sincronia
 *   4. verifica/instala Rust (rustup) — pré-requisito do Tauri
 *   5. Sobe em paralelo: dev:web  +  dev:desktop
 *
 * Uso:
 *   npm run dev
 */

import { spawn, spawnSync } from "node:child_process";
import { createWriteStream } from "node:fs";
import { chmod, mkdtemp, rm } from "node:fs/promises";
import { homedir, tmpdir } from "node:os";
import path from "node:path";
import { get } from "node:https";
import { pipeline } from "node:stream/promises";
import { fileURLToPath } from "node:url";

// ─── constantes ────────────────────────────────────────────────────────────────

const repoRoot = path.resolve(path.dirname(fileURLToPath(import.meta.url)), "..");

const installerTargets = {
  "win32-x64":   "x86_64-pc-windows-msvc",
  "win32-arm64": "aarch64-pc-windows-msvc",
  "darwin-x64":  "x86_64-apple-darwin",
  "darwin-arm64":"aarch64-apple-darwin",
  "linux-x64":   "x86_64-unknown-linux-gnu",
  "linux-arm64": "aarch64-unknown-linux-gnu",
};

const cargoHome = path.resolve(process.env.CARGO_HOME || path.join(homedir(), ".cargo"));
const cargoBin  = path.join(cargoHome, "bin");
const env = {
  ...Object.fromEntries(
    Object.entries(process.env).filter(([key]) => key.toLowerCase() !== "npm_config_allow_scripts")
  ),
  PATH: `${cargoBin}${path.delimiter}${process.env.PATH || ""}`,
};

// ─── helpers ───────────────────────────────────────────────────────────────────

const bold  = (t) => `\u001b[1m${t}\u001b[0m`;
const cyan  = (t) => `\u001b[36m${t}\u001b[0m`;
const green = (t) => `\u001b[32m${t}\u001b[0m`;
const red   = (t) => `\u001b[31m${t}\u001b[0m`;

function step(label) {
  console.log(`\n${cyan("==>")} ${bold(label)}`);
}

/**
 * Roda um comando de forma síncrona com saída visível.
 * Lança erro se o processo terminar com código ≠ 0.
 */
function runSync(program, args = [], opts = {}) {
  const result = spawnSync(program, args, {
    stdio: "inherit",
    env,
    shell: process.platform === "win32",
    cwd: repoRoot,
    ...opts,
  });
  if (result.error) throw result.error;
  if (result.status !== 0) {
    throw new Error(`"${program} ${args.join(" ")}" terminou com código ${result.status}.`);
  }
}

// ─── etapas de bootstrap ───────────────────────────────────────────────────────

function stepNpmInstall() {
  step("npm install");
  runSync("npm", ["install", "--prefer-offline"]);
  console.log(green("OK: dependências Node instaladas."));
}

function stepUvSync() {
  step("uv sync (sidecar Python)");
  runSync("uv", ["sync", "--directory", path.join(repoRoot, "services", "sidecar"), "--group", "dev"]);
  console.log(green("OK: ambiente Python sincronizado."));
}

function stepProtocolGen() {
  step("protocol:gen (confere contrato TS ↔ Python)");
  runSync("node", [path.join(repoRoot, "scripts", "gen-protocol.mjs")]);
  runSync("node", [path.join(repoRoot, "scripts", "gen-schema.mjs")]);
  console.log(green("OK: contrato em sincronia."));
}

// ─── Rust / Cargo ──────────────────────────────────────────────────────────────

function cargoAvailable() {
  return spawnSync("cargo", ["--version"], { encoding: "utf8", env }).status === 0;
}

function download(url, destination, redirects = 0) {
  return new Promise((resolve, reject) => {
    const request = get(url, (response) => {
      if (response.statusCode >= 300 && response.statusCode < 400 && response.headers.location) {
        response.resume();
        if (redirects >= 5) { reject(new Error("O instalador redirecionou muitas vezes.")); return; }
        const redirectUrl = new URL(response.headers.location, url);
        if (redirectUrl.protocol !== "https:") { reject(new Error("O instalador redirecionou para uma conexão não segura.")); return; }
        download(redirectUrl, destination, redirects + 1).then(resolve, reject);
        return;
      }
      if (response.statusCode !== 200) {
        response.resume();
        reject(new Error(`Falha ao baixar o instalador do Rust (HTTP ${response.statusCode}).`));
        return;
      }
      pipeline(response, createWriteStream(destination)).then(resolve, reject);
    });
    request.on("error", reject);
  });
}

async function stepEnsureRust() {
  step("Rust / Cargo");
  if (cargoAvailable()) {
    console.log(green("OK: Rust/Cargo encontrado."));
    return;
  }

  console.log("Rust/Cargo não encontrado. Baixando o instalador oficial do Rust...");
  const target = installerTargets[`${process.platform}-${process.arch}`];
  if (!target) {
    throw new Error(
      `Instalação automática do Rust não suportada nesta plataforma: ${process.platform}-${process.arch}. ` +
      "Instale o Rust via rustup e tente novamente."
    );
  }

  const extension = process.platform === "win32" ? ".exe" : "";
  const url       = `https://static.rust-lang.org/rustup/dist/${target}/rustup-init${extension}`;
  const tempDir   = await mkdtemp(path.join(tmpdir(), "positron-rustup-"));
  const installer = path.join(tempDir, `rustup-init${extension}`);

  try {
    await download(url, installer);
    if (process.platform !== "win32") await chmod(installer, 0o755);

    const result = spawnSync(installer, ["-y", "--default-toolchain", "stable"], { stdio: "inherit", env });
    if (result.error) throw result.error;
    if (result.status !== 0) throw new Error(`O instalador do Rust terminou com código ${result.status}.`);
    if (!cargoAvailable()) throw new Error(`O Rust foi instalado, mas o Cargo não foi encontrado em ${cargoBin}.`);
  } finally {
    await rm(tempDir, { recursive: true, force: true });
  }

  console.log(green("OK: Rust instalado com sucesso."));
}

// ─── ponto de entrada ──────────────────────────────────────────────────────────

console.log(bold("\n=== Positron — bootstrap de desenvolvimento ==="));

try {
  stepNpmInstall();
  stepUvSync();
  stepProtocolGen();
  await stepEnsureRust();
} catch (error) {
  console.error(`\n${red("ERRO:")} ${error.message}`);
  process.exit(1);
}

step("Subindo ambiente (web + desktop em paralelo)");

const child = spawn("npm", ["run", "dev:parallel"], {
  stdio: "inherit",
  env,
  shell: process.platform === "win32",
  cwd: repoRoot,
});

child.on("error", (error) => {
  console.error(red(`Não foi possível iniciar o ambiente de desenvolvimento: ${error.message}`));
  process.exitCode = 1;
});
child.on("exit", (code, signal) => {
  process.exitCode = code ?? (signal ? 1 : 0);
});
