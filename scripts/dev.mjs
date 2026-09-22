/**
 * Bootstrap completo do ambiente de desenvolvimento.
 *
 * Etapas: instala Node deps, uv/Python, dependências nativas do Windows e Rust;
 * sincroniza o sidecar, valida o protocolo e sobe o app.
 *
 * Uso:
 *   npm run dev
 */

import { spawn, spawnSync } from "node:child_process";
import { createWriteStream, existsSync } from "node:fs";
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

function runCapture(program, args = [], options = {}) {
  return spawnSync(program, args, {
    encoding: "utf8",
    env,
    shell: process.platform === "win32",
    windowsHide: true,
    cwd: repoRoot,
    ...options,
  });
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

function ensureNode() {
  const version = process.versions.node.split(".").map(Number);
  if (version[0] >= 20) return;
  throw new Error(
    `Node.js ${process.versions.node} está instalado, mas este projeto exige Node.js 20 ou superior.\n` +
    "Instale a versão LTS em https://nodejs.org/ e execute `npm run dev` novamente."
  );
}

function refreshWindowsPath() {
  if (process.platform !== "win32") return;

  const registryPaths = [
    ["HKCU\\Environment", "Path"],
    ["HKLM\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Environment", "Path"],
  ].flatMap(([key, name]) => {
    const result = runCapture("reg.exe", ["query", key, "/v", name]);
    const value = result.stdout?.match(/\bREG_(?:EXPAND_)?SZ\s+(.+)/i)?.[1]?.trim();
    if (!value) return [];

    return [value.replace(/%([^%]+)%/g, (_, variable) => process.env[variable] ?? `%${variable}%`)];
  });

  const addedPaths = [
    path.join(process.env.LOCALAPPDATA ?? "", "Microsoft", "WinGet", "Links"),
    path.join(homedir(), ".local", "bin"),
    path.join(process.env.ProgramFiles ?? "C:\\Program Files", "CMake", "bin"),
  ];
  const paths = [...addedPaths, ...registryPaths, env.PATH ?? ""]
    .flatMap((value) => value.split(path.delimiter))
    .map((value) => value.trim())
    .filter((value) => value && existsSync(value));
  env.PATH = [...new Set(paths)].join(path.delimiter);
}

function hasCommand(program, args = ["--version"]) {
  const result = runCapture(program, args);
  return result.status === 0;
}

function hasVisualCppTools() {
  const vswhere = path.join(
    process.env["ProgramFiles(x86)"] ?? "C:\\Program Files (x86)",
    "Microsoft Visual Studio",
    "Installer",
    "vswhere.exe"
  );
  if (!existsSync(vswhere)) return false;

  const result = runCapture(vswhere, [
    "-products", "*",
    "-requires", "Microsoft.VisualStudio.Component.VC.Tools.x86.x64",
    "-property", "installationPath",
  ]);
  return result.status === 0 && Boolean(result.stdout?.trim());
}

function hasWebView2() {
  return [
    "C:\\Program Files (x86)\\Microsoft\\EdgeWebView\\Application",
    "C:\\Program Files\\Microsoft\\EdgeWebView\\Application",
  ].some(existsSync);
}

function installWingetPackage(id, label, override) {
  step(`Instalando ${label} (WinGet)`);
  console.log("A instalação pode demorar. Se o Windows pedir autorização, aprove a solicitação.");

  const args = [
    "install", "--id", id, "--exact",
    "--accept-package-agreements", "--accept-source-agreements",
  ];
  if (override) {
    args.push("--override", override);
  } else {
    args.push("--silent");
  }

  const result = spawnSync("winget", args, {
    stdio: "inherit",
    env,
    shell: true,
    cwd: repoRoot,
  });
  refreshWindowsPath();

  if (result.error || result.status !== 0) {
    const detail = result.error?.message ?? `código ${result.status}`;
    throw new Error(
      `Não foi possível instalar ${label} automaticamente (${detail}).\n` +
      "Confira a conexão com a internet e as permissões de instalação. " +
      "Instale a ferramenta manualmente seguindo docs/RUNBOOK.md e execute `npm run dev` novamente."
    );
  }
}

function ensureWinget(missingTools) {
  if (hasCommand("winget")) return;

  throw new Error(
    `Não encontrei o WinGet, necessário para instalar automaticamente: ${missingTools.join(", ")}.\n` +
    "Instale ou atualize o App Installer pela Microsoft Store " +
    "(https://aka.ms/getwinget), abra um novo terminal e execute `npm run dev` novamente.\n" +
    "Se não puder usar a Store, consulte a seção de pré-requisitos do Windows em docs/RUNBOOK.md."
  );
}

function preflightWindowsInstaller() {
  if (process.platform !== "win32") return;

  refreshWindowsPath();
  const missing = [];
  if (!hasCommand("uv")) missing.push("uv");
  if (!hasCommand("cmake")) missing.push("CMake");
  if (!hasVisualCppTools()) missing.push("Visual Studio Build Tools (C++)");
  if (!hasWebView2()) missing.push("WebView2");
  if (missing.length > 0) ensureWinget(missing);
}

function ensureUv() {
  step("uv (gerenciador do ambiente Python)");
  refreshWindowsPath();
  if (hasCommand("uv")) {
    console.log(green("OK: uv encontrado."));
    return;
  }

  if (process.platform !== "win32") {
    throw new Error(
      "uv não foi encontrado. Instale-o seguindo https://docs.astral.sh/uv/getting-started/installation/ " +
      "e execute `npm run dev` novamente."
    );
  }

  ensureWinget(["uv"]);
  installWingetPackage("astral-sh.uv", "uv");
  if (!hasCommand("uv")) {
    throw new Error(
      "O WinGet terminou, mas `uv` ainda não está disponível no PATH.\n" +
      "Feche e reabra o terminal para atualizar o PATH e execute `npm run dev` novamente. " +
      "Se persistir, instale uv em https://docs.astral.sh/uv/getting-started/installation/."
    );
  }
  console.log(green("OK: uv instalado."));
}

function ensureWindowsBuildTools() {
  if (process.platform !== "win32") {
    console.log(
      "A instalação automática de dependências nativas está configurada para Windows. " +
      "Em outros sistemas, consulte https://v2.tauri.app/start/prerequisites/."
    );
    return;
  }

  step("Pré-requisitos nativos do Tauri (Windows)");
  const missing = [];
  if (!hasCommand("cmake")) missing.push("CMake");
  if (!hasVisualCppTools()) missing.push("compilador C++ (Visual Studio Build Tools)");
  if (!hasWebView2()) missing.push("WebView2");

  if (missing.length === 0) {
    console.log(green("OK: CMake, ferramentas C++ e WebView2 encontrados."));
    return;
  }

  console.log(`Dependências ainda não instaladas: ${missing.join(", ")}.`);
  ensureWinget(missing);

  if (!hasCommand("cmake")) {
    installWingetPackage("Kitware.CMake", "CMake");
    if (!hasCommand("cmake")) {
      throw new Error(
        "O CMake foi instalado, mas ainda não está disponível no PATH. " +
        "Reabra o terminal e execute `npm run dev` novamente."
      );
    }
  }

  if (!hasVisualCppTools()) {
    installWingetPackage(
      "Microsoft.VisualStudio.2022.BuildTools",
      "Visual Studio Build Tools (compilador C++ e Windows SDK)",
      "--wait --passive --add Microsoft.VisualStudio.Workload.VCTools " +
        "--includeRecommended --add Microsoft.VisualStudio.Component.VC.CMake.Project"
    );
    if (!hasVisualCppTools()) {
      throw new Error(
        "O instalador terminou, mas não encontrei o compilador C++ do Visual Studio.\n" +
        "Abra o Visual Studio Installer, instale a carga de trabalho “Desenvolvimento para desktop com C++” " +
        "com o Windows SDK e execute `npm run dev` novamente."
      );
    }
  }

  if (!hasWebView2()) {
    installWingetPackage("Microsoft.EdgeWebView2Runtime", "WebView2 Runtime");
    if (!hasWebView2()) {
      throw new Error(
        "O instalador terminou, mas não encontrei o WebView2 Runtime.\n" +
        "Instale o Evergreen Runtime em https://developer.microsoft.com/microsoft-edge/webview2/ " +
        "e execute `npm run dev` novamente."
      );
    }
  }

  console.log(green("OK: dependências nativas do Tauri instaladas."));
}

// ─── etapas de bootstrap ───────────────────────────────────────────────────────

function stepNpmInstall() {
  step("npm install");
  try {
    runSync("npm", ["install", "--prefer-offline"]);
  } catch (error) {
    throw new Error(
      `Não foi possível instalar as dependências JavaScript.\n` +
      "Confira a conexão com a internet, permissões de escrita e o arquivo package-lock.json.\n" +
      error.message
    );
  }
  console.log(green("OK: dependências Node instaladas."));
}

function stepUvSync() {
  step("Python / uv sync (sidecar)");
  const pythonFound = runCapture("uv", ["python", "find", "3.11"]);
  if (pythonFound.status !== 0) {
    console.log("Python 3.11+ não encontrado; baixando uma versão gerenciada pelo uv...");
    try {
      runSync("uv", ["python", "install", "3.12"]);
    } catch (error) {
      throw new Error(
        "Não foi possível instalar Python automaticamente com uv.\n" +
        "Confira a conexão com a internet e o espaço em disco. Se o problema persistir, " +
        "instale Python 3.11+ em https://www.python.org/downloads/ e execute `npm run dev` novamente.\n" +
        error.message
      );
    }
  } else {
    console.log(`Python encontrado: ${pythonFound.stdout.trim()}`);
  }

  runSync("node", [path.join(repoRoot, "scripts", "check-python.mjs")]);
  try {
    runSync("uv", ["sync", "--directory", path.join(repoRoot, "services", "sidecar"), "--group", "dev"]);
  } catch (error) {
    throw new Error(
      "Não foi possível sincronizar as dependências Python do sidecar.\n" +
      "Confira a conexão com a internet e execute `npm run dev` novamente. " +
      "Para verificação manual, rode `npm run sidecar:sync`.\n" +
      error.message
    );
  }
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
  } catch (error) {
    throw new Error(
      `Não foi possível instalar o Rust automaticamente.\n` +
      "Confira a conexão com a internet e, se necessário, instale-o manualmente em https://rustup.rs/.\n" +
      error.message
    );
  } finally {
    await rm(tempDir, { recursive: true, force: true });
  }

  console.log(green("OK: Rust instalado com sucesso."));
}

// ─── ponto de entrada ──────────────────────────────────────────────────────────

console.log(bold("\n=== Positron — bootstrap de desenvolvimento ==="));

try {
  ensureNode();
  stepNpmInstall();
  preflightWindowsInstaller();
  ensureUv();
  ensureWindowsBuildTools();
  await stepEnsureRust();
  stepUvSync();
  stepProtocolGen();
} catch (error) {
  console.error(`\n${red("ERRO NO BOOTSTRAP:")} ${error.message}`);
  console.error("\nResolva a pendência indicada acima e execute `npm run dev` novamente.");
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
