<#
.SYNOPSIS
  Instala (ou remove) o autoload do Positron nos DOIS CADs: ZWCAD e AutoCAD.

.DESCRIPTION
  Copia o manifesto (install/Positron.bundle/PackageContents.xml) e a DLL compilada da
  plataforma — com as dependencias — para a pasta que o CAD varre na abertura:

    ZWCAD    %APPDATA%\ZWSOFT\ZWCAD\<ano>\<idioma>\Support\Positron.bundle\
    AutoCAD  %APPDATA%\Autodesk\ApplicationPlugins\Positron.bundle\

  O PackageContents.xml tem um componente por plataforma (rodada 137): cada CAD le o seu e
  carrega a DLL daquela plataforma. Depois de instalar, o CAD carrega o plugin na abertura e o
  IExtensionApplication se apresenta — sem NETLOAD.

  MEDIDO (rodada 137): quem faz o autoload e a INTERFACE cheia do CAD. O accoreconsole.exe NAO
  carrega .bundle nenhum (sobe sem o AcAutoLoader.arx) — no harness headless a DLL entra por
  NETLOAD, como o scripts/cad-autocad-smoke.ps1 faz. Este script nao substitui o smoke.

.EXAMPLE
  powershell -ExecutionPolicy Bypass -File scripts/instala-bundle.ps1 -Cad AutoCAD

.EXAMPLE
  powershell -ExecutionPolicy Bypass -File scripts/instala-bundle.ps1 -Cad ZWCAD

.EXAMPLE
  powershell -ExecutionPolicy Bypass -File scripts/instala-bundle.ps1 -Cad AutoCAD -Remover
#>
[CmdletBinding()]
param(
    # Plataforma cuja DLL vai junto do manifesto.
    [ValidateSet('ZWCAD', 'AutoCAD')]
    [string] $Cad = 'AutoCAD',
    # Debug (o padrao dos harness) ou Release.
    [string] $Configuracao = 'Debug',
    # Sobrepõe a pasta de destino (usado pelo teste do autoload; sem ele, a pasta do CAD).
    [string] $Destino,
    # Tira o pacote da pasta do CAD em vez de instalar.
    [switch] $Remover
)

$ErrorActionPreference = "Stop"

$raiz   = Split-Path -Parent $PSScriptRoot
$pacote = Join-Path $raiz 'install\Positron.bundle'
$saida  = Join-Path $raiz ("cad-plugin\Positron.Plugin\bin\" + $Configuracao + "\" + $Cad + "\net472")
$manifesto = Join-Path $pacote 'PackageContents.xml'

if (-not (Test-Path $manifesto)) { throw "nao encontrei o manifesto em '$manifesto'." }

# --- destino ---------------------------------------------------------------
if ([string]::IsNullOrWhiteSpace($Destino)) {
    if ($Cad -eq 'AutoCAD') {
        $Destino = Join-Path $env:APPDATA 'Autodesk\ApplicationPlugins\Positron.bundle'
    } else {
        # O ZWCAD guarda o pacote na Support do perfil; o ano sai da instalacao que existir.
        $instalado = @('C:\Program Files\ZWSOFT\ZWCAD 2026', 'C:\Program Files\ZWSOFT\ZWCAD 2025') |
            Where-Object { Test-Path $_ } | Select-Object -First 1
        if (-not $instalado) {
            throw ("ZWCAD nao esta instalado nesta maquina (procurei em 'C:\Program Files\ZWSOFT\ZWCAD 2026' e 2025). " +
                   "O host verificado aqui e o AutoCAD 2020: rode com '-Cad AutoCAD'.")
        }
        $ano = ($instalado -split ' ')[-1]
        $perfil = Join-Path $env:APPDATA ("ZWSOFT\ZWCAD\" + $ano)
        $support = Get-ChildItem $perfil -Directory -ErrorAction SilentlyContinue |
            Where-Object { Test-Path (Join-Path $_.FullName 'Support') } | Select-Object -First 1
        if (-not $support) {
            throw "nao encontrei a pasta Support do ZWCAD em '$perfil' (abra o ZWCAD uma vez para o perfil existir)."
        }
        $Destino = Join-Path $support.FullName 'Support\Positron.bundle'
    }
}

if ($Remover) {
    if (Test-Path $Destino) {
        Remove-Item $Destino -Recurse -Force
        Write-Host "Positron: pacote removido de '$Destino'."
    } else {
        Write-Host "Positron: nao havia pacote em '$Destino' (nada a remover)."
    }
    exit 0
}

if (-not (Test-Path $saida)) {
    throw ("DLL do {0} nao compilada em '{1}': rode 'npm run plugin:build:{2}' antes." -f
           $Cad, $saida, $Cad.ToLower())
}

# --- copia -----------------------------------------------------------------
New-Item -ItemType Directory -Path $Destino -Force | Out-Null
Get-ChildItem $pacote -File | Copy-Item -Destination $Destino -Force
Get-ChildItem $saida -Filter *.dll | Copy-Item -Destination $Destino -Force
foreach ($nativa in @('x64', 'x86')) {
    $origem = Join-Path $saida $nativa
    if (Test-Path $origem) { Copy-Item $origem -Destination $Destino -Recurse -Force }
}

# O manifesto lista os dois componentes; so a DLL da plataforma pedida esta ao lado dele.
$dll = "Positron.Plugin." + $Cad + ".dll"
if (-not (Test-Path (Join-Path $Destino $dll))) { throw "a copia nao levou a '$dll' para '$Destino'." }

Write-Host ("Positron: autoload do {0} instalado em '{1}'." -f $Cad, $Destino)
Get-ChildItem $Destino -Recurse -File | ForEach-Object { "  " + $_.FullName.Substring($Destino.Length + 1) }
Write-Host ("  confira na ABERTURA do {0} (o plugin escreve 'Positron carregado'; com POSITRON_LOG, no arquivo)." -f $Cad)
Write-Host "  (o accoreconsole NAO faz autoload - no headless a DLL entra por NETLOAD.)"
