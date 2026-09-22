import { spawnSync } from "node:child_process";

const env = process.env;
const shell = process.platform === "win32";
const sdkList = spawnSync("dotnet", ["--list-sdks"], {
  encoding: "utf8",
  env,
  shell,
  windowsHide: true,
});
const installedSdks = sdkList.stdout?.trim();

if (sdkList.error || sdkList.status !== 0 || !installedSdks) {
  console.error(
    "ERRO: este comando requer o .NET SDK, mas nenhum SDK foi encontrado.\n" +
    "O .NET SDK é uma ferramenta de desenvolvimento, não um add-on do VS Code; o runtime sozinho não basta.\n" +
    "Instale-o em https://dotnet.microsoft.com/download/dotnet/, abra um novo terminal e confira " +
    "com `dotnet --list-sdks`."
  );
  if (sdkList.error) console.error(`Detalhe: ${sdkList.error.message}`);
  process.exit(1);
}

const dotnetArgs = process.argv.slice(2);
if (dotnetArgs.length === 0) {
  console.error("ERRO: informe o comando do .NET SDK a executar.");
  process.exit(1);
}

console.log(`.NET SDK encontrado:\n${installedSdks}`);

const result = spawnSync("dotnet", dotnetArgs, {
  stdio: "inherit",
  env,
  shell,
  windowsHide: true,
});

if (result.error) {
  console.error(`ERRO: não foi possível iniciar dotnet: ${result.error.message}`);
  process.exit(1);
}

process.exit(result.status ?? 1);
