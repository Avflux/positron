import { spawn, spawnSync } from "node:child_process";
import { createWriteStream } from "node:fs";
import { chmod, mkdtemp, rm } from "node:fs/promises";
import { homedir, tmpdir } from "node:os";
import path from "node:path";
import { get } from "node:https";
import { pipeline } from "node:stream/promises";

const installerTargets = {
  "win32-x64": "x86_64-pc-windows-msvc",
  "win32-arm64": "aarch64-pc-windows-msvc",
  "darwin-x64": "x86_64-apple-darwin",
  "darwin-arm64": "aarch64-apple-darwin",
  "linux-x64": "x86_64-unknown-linux-gnu",
  "linux-arm64": "aarch64-unknown-linux-gnu",
};

const cargoHome = path.resolve(process.env.CARGO_HOME || path.join(homedir(), ".cargo"));
const cargoBin = path.join(cargoHome, "bin");
const env = {
  ...process.env,
  PATH: `${cargoBin}${path.delimiter}${process.env.PATH || ""}`,
};

function cargoAvailable() {
  return spawnSync("cargo", ["--version"], { encoding: "utf8", env }).status === 0;
}

function download(url, destination, redirects = 0) {
  return new Promise((resolve, reject) => {
    const request = get(url, (response) => {
      if (response.statusCode >= 300 && response.statusCode < 400 && response.headers.location) {
        response.resume();
        if (redirects >= 5) {
          reject(new Error("O instalador redirecionou muitas vezes."));
          return;
        }
        const redirectUrl = new URL(response.headers.location, url);
        if (redirectUrl.protocol !== "https:") {
          reject(new Error("O instalador redirecionou para uma conexão não segura."));
          return;
        }
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

async function installRust() {
  const target = installerTargets[`${process.platform}-${process.arch}`];
  if (!target) {
    throw new Error(`Instalação automática do Rust não suportada nesta plataforma: ${process.platform}-${process.arch}. Instale o Rust via rustup e tente novamente.`);
  }

  const extension = process.platform === "win32" ? ".exe" : "";
  const url = `https://static.rust-lang.org/rustup/dist/${target}/rustup-init${extension}`;
  const tempDir = await mkdtemp(path.join(tmpdir(), "positron-rustup-"));
  const installer = path.join(tempDir, `rustup-init${extension}`);

  try {
    console.log("Rust/Cargo não encontrado. Baixando o instalador oficial do Rust...");
    await download(url, installer);
    if (process.platform !== "win32") {
      await chmod(installer, 0o755);
    }

    const result = spawnSync(installer, ["-y", "--default-toolchain", "stable"], {
      stdio: "inherit",
      env,
    });
    if (result.error) {
      throw result.error;
    }
    if (result.status !== 0) {
      throw new Error(`O instalador do Rust terminou com código ${result.status}.`);
    }

    if (!cargoAvailable()) {
      throw new Error(`O Rust foi instalado, mas o Cargo não foi encontrado em ${cargoBin}. Verifique a instalação do rustup e tente novamente.`);
    }
  } finally {
    await rm(tempDir, { recursive: true, force: true });
  }
}

if (!cargoAvailable()) {
  await installRust();
} else {
  console.log("Rust/Cargo encontrado.");
}

const child = spawn("npm", ["run", "dev:parallel"], {
  stdio: "inherit",
  env,
  shell: process.platform === "win32",
});

child.on("error", (error) => {
  console.error(`Não foi possível iniciar o ambiente de desenvolvimento: ${error.message}`);
  process.exitCode = 1;
});
child.on("exit", (code, signal) => {
  process.exitCode = code ?? (signal ? 1 : 0);
});
