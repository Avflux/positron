import { spawnSync } from "node:child_process";

const candidates = [
  { command: "python", args: ["--version"] },
  { command: "python3", args: ["--version"] },
];

const runVersionCheck = ({ command, args }) => {
  const result = spawnSync(command, args, {
    encoding: "utf8",
    env: process.env,
    shell: process.platform === "win32",
    windowsHide: true,
  });
  const output = result.status === 0
    ? `${result.stdout ?? ""}\n${result.stderr ?? ""}`.trim()
    : "";
  const version = output.match(/(?:Python\s+)?(\d+)\.(\d+)\.(\d+)/i);

  return {
    command: [command, ...args].join(" "),
    output,
    supported: result.status === 0 && version !== null &&
      (Number(version[1]) > 3 || (Number(version[1]) === 3 && Number(version[2]) >= 11)),
  };
};

const attempts = candidates.map(runVersionCheck);
const uvPython = spawnSync("uv", ["python", "find", "3.11"], {
  encoding: "utf8",
  env: process.env,
  shell: process.platform === "win32",
  windowsHide: true,
});
if (uvPython.status === 0 && uvPython.stdout?.trim()) {
  attempts.push(runVersionCheck({
    command: uvPython.stdout.trim().replace(/^"(.*)"$/, "$1"),
    args: ["--version"],
  }));
}
if (process.platform === "win32") {
  attempts.push(runVersionCheck({ command: "py", args: ["-3", "--version"] }));
}

const available = attempts.find((attempt) => attempt.supported);

if (available) {
  console.log(`Python 3.11+ encontrado (${available.command}): ${available.output}`);
  process.exit(0);
}

const oldVersions = attempts.filter((attempt) => attempt.output);
const versionDetails = oldVersions.length > 0
  ? ` Versões encontradas: ${oldVersions.map(({ command, output }) => `${command}: ${output}`).join("; ")}.`
  : "";

console.error(
  `ERRO: Python 3.11 ou superior não foi encontrado.${versionDetails}\n` +
  "Instale Python 3.11+ ou execute `npm run dev` para preparar o ambiente automaticamente.\n" +
  "Confira com `python --version` ou `py -3 --version`. Nenhum comando do sidecar será executado."
);
process.exit(1);
