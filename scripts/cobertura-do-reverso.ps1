# O painel de cobertura do reverso - responde "o que ja cobrimos e o que falta" com numero medido
# agora, nao com memoria. Cruza tres fontes que ja existem no repo:
#
#   1. docs/reverso-comandos.txt          os 216 comandos do original e a tela que cada um abre;
#   2. os [CommandMethod] do plugin       o que o recoder responde hoje, separando o que foi escrito
#                                         A MAO do que veio do gerado da rodada 128 (que so abre a
#                                         tela, sem regra);
#   3. os frm*.cs do decompilado          as 127 telas e o tamanho de cada uma (proxy do custo).
#
# O reverso e lido da copia que vive **no repo** (`cad-plugin\reverso\Eletron4_ZWcad\decompiled-cleaned`,
# a que o dono do produto adicionou na rodada 134) - o painel imprime de onde leu, para nao haver
# duvida sobre qual copia respondeu. `-Decomp` continua aceitando outra pasta (a de fora do repo,
# por exemplo).
#
# Uso:
#   powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1
#   powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1 -Listas        (as listas nominais)
#   powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1 -Acoplamento  (quanto do
#       ambiente do original cada corpo carrega: o termometro de "traduzir 1:1 ou virar regra")
#
# A leitura dos numeros e o que fazer com eles: docs/AUDITORIA.md, secao 0.
[CmdletBinding()]
param(
  [string] $Mapa   = "docs\reverso-comandos.txt",
  [string] $Plugin = "cad-plugin\Positron.Plugin",
  [string] $Decomp = "cad-plugin\reverso\Eletron4_ZWcad\decompiled-cleaned\Eletron4",
  # Imprime tambem as listas nominais (telas e comandos), que sao o que decide a proxima rodada.
  [switch] $Listas,
  # Imprime, por comando, o que o CORPO dele carrega do ambiente do original (runtime VB, Access,
  # MsgBox, estado global, Editor). E o termometro de "da para traduzir 1:1 ou tem de virar regra?"
  [switch] $Acoplamento
)

$ErrorActionPreference = 'Stop'
if (-not (Test-Path $Mapa)) { throw "mapa nao encontrado: $Mapa (rode scripts/extrair-comandos-do-reverso.ps1)" }

# ---------------------------------------------------------------- 1. o mapa dos 216 comandos
$comandos = @{}
foreach ($linha in [System.IO.File]::ReadAllLines((Join-Path (Get-Location) $Mapa))) {
  $m = [regex]::Match($linha, '^\| `([^`]+)` \| ([^|]*) \| ([^|]*) \| ([^|]*) \| ([^|]*) \|')
  if (-not $m.Success) { continue }
  $janelas = @()
  foreach ($j in [regex]::Matches($m.Groups[2].Value, '`([^`]+)`')) { $janelas += $j.Groups[1].Value }
  $comandos[$m.Groups[1].Value] = [pscustomobject]@{
    Nome       = $m.Groups[1].Value
    Janelas    = $janelas
    Construcao = $m.Groups[3].Value.Trim()
    SoAbre     = ($m.Groups[4].Value.Trim() -eq 'sim')
    Variante   = ($m.Groups[5].Value.Trim() -eq 'sim')
  }
}

# ---------------------------------------------------------------- 2. o que o plugin responde
$escritos = @{}   # regra escrita a mao
$gerados  = @{}   # gerado da rodada 128: so abre a tela
foreach ($arquivo in Get-ChildItem -Path $Plugin -Recurse -Filter *.cs) {
  $texto = [System.IO.File]::ReadAllText($arquivo.FullName)
  $destino = $(if ($arquivo.Name -like '*.Gerado.cs') { $gerados } else { $escritos })
  foreach ($m in [regex]::Matches($texto, '\[CommandMethod\("([^"]+)"\)\]')) { $destino[$m.Groups[1].Value] = $arquivo.Name }
}

# ---------------------------------------------------------------- 3. as telas e o tamanho delas
# `-Filter` do PowerShell casa sem diferenciar maiuscula de minuscula, e **3 das 127** telas comecam
# com `Frm*` (`FrmBuscaNuvem`, `FrmImportarCabosExcel`, `FrmTrocaUsuario`): contar `frm*.cs` com glob
# de shell (que diferencia) da **124**, nao 127.
$telas = @{}
if (Test-Path $Decomp) {
  foreach ($arquivo in Get-ChildItem -Path $Decomp -Filter 'frm*.cs') {
    $telas[$arquivo.BaseName] = ([System.IO.File]::ReadAllLines($arquivo.FullName)).Count
  }
} else {
  Write-Warning ("reverso nao encontrado em '{0}': o painel segue SEM as telas. Passe -Decomp <pasta do decompilado>." -f $Decomp)
}
$porTela = @{}
foreach ($c in $comandos.Values) {
  foreach ($j in $c.Janelas) {
    if (-not $telas.ContainsKey($j)) { continue }
    if (-not $porTela.ContainsKey($j)) { $porTela[$j] = New-Object System.Collections.ArrayList }
    [void]$porTela[$j].Add($c)
  }
}

# ---------------------------------------------------------------- os agrupamentos
$semNada     = @($comandos.Values | Where-Object { -not $escritos.ContainsKey($_.Nome) -and -not $gerados.ContainsKey($_.Nome) })
$semNadaJan  = @($semNada | Where-Object { $_.Janelas.Count -gt 0 })
$semNadaReg  = @($semNada | Where-Object { $_.Janelas.Count -eq 0 })

$telaComRegra = New-Object System.Collections.ArrayList   # a regra existe: falta so a ligacao
$telaSoCasca  = New-Object System.Collections.ArrayList   # a tela abre, a regra nao existe
foreach ($tela in ($porTela.Keys | Sort-Object)) {
  $comRegra  = @($porTela[$tela] | Where-Object { $escritos.ContainsKey($_.Nome) })
  $noGerado  = @($porTela[$tela] | Where-Object { $gerados.ContainsKey($_.Nome) })
  $tamanho   = $(if ($telas.ContainsKey($tela)) { $telas[$tela] } else { 0 })
  if ($comRegra.Count -gt 0) {
    [void]$telaComRegra.Add([pscustomobject]@{ Tela = $tela; Linhas = $tamanho; Comandos = (($comRegra | ForEach-Object { $_.Nome }) -join ', ') })
  } elseif ($noGerado.Count -gt 0) {
    [void]$telaSoCasca.Add([pscustomobject]@{ Tela = $tela; Linhas = $tamanho; Comandos = (($noGerado | ForEach-Object { $_.Nome }) -join ', ') })
  }
}
$telaSemComando = @($telas.Keys | Where-Object { -not $porTela.ContainsKey($_) })

# ---------------------------------------------------------------- o painel
Write-Output ('=' * 78)
Write-Output 'COMANDOS DO REVERSO'
Write-Output ("  total                          : {0}" -f $comandos.Count)
Write-Output ("  abrem alguma janela            : {0}" -f @($comandos.Values | Where-Object { $_.Janelas.Count -gt 0 }).Count)
Write-Output ("  regra de desenho pura (sem tela): {0}" -f @($comandos.Values | Where-Object { $_.Janelas.Count -eq 0 }).Count)
Write-Output ("  com variante (argumento)       : {0}" -f @($comandos.Values | Where-Object { $_.Variante }).Count)
Write-Output ''
Write-Output 'O QUE O PLUGIN RESPONDE'
Write-Output ("  escritos a mao                 : {0}  (do reverso: {1}; so nossos: {2})" -f $escritos.Count,
  @($comandos.Keys | Where-Object { $escritos.ContainsKey($_) }).Count,
  @($escritos.Keys | Where-Object { -not $comandos.ContainsKey($_) }).Count)
Write-Output ("  gerados (so abrem a tela)      : {0}" -f $gerados.Count)
Write-Output ("  do reverso SEM NADA no plugin  : {0}  (abrem janela: {1}; regra pura: {2})" -f $semNada.Count, $semNadaJan.Count, $semNadaReg.Count)
Write-Output ''
Write-Output 'TELAS'
Write-Output ("  reverso lido de                : {0}" -f $Decomp)
Write-Output ("  telas frm* no decompilado      : {0}" -f $telas.Count)
Write-Output ("  alcancadas por algum comando   : {0}  (COM regra ja escrita: {1}; so casca: {2})" -f ($telaComRegra.Count + $telaSoCasca.Count), $telaComRegra.Count, $telaSoCasca.Count)
Write-Output ("  nenhum comando abre (sub-janela): {0}" -f $telaSemComando.Count)
Write-Output ('=' * 78)
Write-Output 'PROXIMAS DA FILA: telas cuja REGRA ja existe no plugin (falta so a ligacao)'
foreach ($t in ($telaComRegra | Sort-Object Linhas)) {
  Write-Output ("  {0,-30} {1,6} linhas no reverso   comando(s): {2}" -f $t.Tela, $t.Linhas, $t.Comandos)
}

# O CORPO do metodo que segue a linha do `[CommandMethod]`: acha a chave de abertura e vai ate ela
# fechar (strings fora da conta). E o recorte que vale para o tamanho E para o acoplamento - contar
# "tudo ate o proximo comando" pegava os outros metodos da mesma classe e inflava os dois numeros.
function CorpoDoMetodo([string] $texto, [int] $inicioDoAtributo) {
  $resto = $texto.Substring($inicioDoAtributo)
  $abre = $resto.IndexOf('{')
  if ($abre -lt 0) { return $resto }

  $nivel = 0
  for ($i = $abre; $i -lt $resto.Length; $i++) {
    $c = $resto[$i]
    if ($c -eq '"') {
      $i++
      while ($i -lt $resto.Length -and $resto[$i] -ne '"') {
        if ($resto[$i] -eq '\') { $i++ }
        $i++
      }
      continue
    }
    if ($c -eq '{') { $nivel++ }
    if ($c -eq '}') {
      $nivel--
      if ($nivel -eq 0) { return $resto.Substring(0, $i + 1) }
    }
  }

  return $resto
}

# ---------------------------------------------------------------- o acoplamento do corpo de cada comando
if ($Acoplamento) {
  Write-Output ''
  Write-Output 'ACOPLAMENTO DO CORPO DE CADA COMANDO DO REVERSO (quanto do ambiente do original ele carrega)'
  Write-Output '  legenda: VB = runtime VB (Conversions/Operators) · ACESSO = cDados* (Access/MDB) · MSGBOX · ESTADO = DeclaracoesGeral · EDITOR = interativo · LIC = hardlock/licenca'
  if (-not (Test-Path $Decomp)) { Write-Output '  (sem o decompilado: passe -Decomp)' }
  else {
    $marcas = @(
      @{ Sigla = 'VB';     Padrao = 'Conversions\.|Operators\.' },
      @{ Sigla = 'ACESSO'; Padrao = 'cDados[A-Za-z]*' },
      @{ Sigla = 'MSGBOX'; Padrao = 'Interaction\.MsgBox' },
      @{ Sigla = 'ESTADO'; Padrao = 'DeclaracoesGeral\.' },
      @{ Sigla = 'EDITOR'; Padrao = '\.GetPoint\(|Editor editor' },
      @{ Sigla = 'LIC';    Padrao = 'hardlock|Hardlock|Rockey|ElecKey|CheckLic' }
    )

    # Os totais no decompilado inteiro (nao so no corpo dos comandos): e o numero que a tabela do
    # AUDITORIA cita, e por isso tem de sair daqui - medido, nao lembrado.
    $totais     = @{}
    $comandosCom = @{}
    foreach ($m in $marcas) { $totais[$m.Sigla] = 0; $comandosCom[$m.Sigla] = 0 }

    $porComando = New-Object System.Collections.ArrayList
    foreach ($arquivo in (Get-ChildItem -Path (Join-Path $Decomp '..') -Recurse -Filter *.cs)) {
      $texto = [System.IO.File]::ReadAllText($arquivo.FullName)
      foreach ($m in $marcas) { $totais[$m.Sigla] += ([regex]::Matches($texto, $m.Padrao)).Count }
      $achados = [regex]::Matches($texto, '\[CommandMethod\("([^"]+)"\)\]')
      for ($i = 0; $i -lt $achados.Count; $i++) {
        $nome = $achados[$i].Groups[1].Value
        $inicio = $achados[$i].Index
        # O corpo do METODO (chaves balanceadas), nao "tudo ate o proximo comando": e o numero que
        # o AUDITORIA usa (CorrigeInterligacao 216, PreencheNovosAtributos 21).
        $corpo = CorpoDoMetodo $texto $inicio
        $linhasCorpo = ($corpo -split "`n").Count
        $marcados = New-Object System.Collections.ArrayList
        foreach ($m in $marcas) {
          $n = ([regex]::Matches($corpo, $m.Padrao)).Count
          if ($n -gt 0) {
            [void]$marcados.Add(($(if ($n -gt 9) { '9+' } else { [string]$n }) + $m.Sigla))
            $comandosCom[$m.Sigla]++
          }
        }
        [void]$porComando.Add([pscustomobject]@{
          Comando = $nome; Linhas = $linhasCorpo; Marcas = ($marcados -join ' ')
          Peso = $marcados.Count
        })
      }
    }

    Write-Output ''
    Write-Output ('  comando do recoder?  comando           corpo  acoplamento')
    foreach ($c in ($porComando | Sort-Object -Descending Peso, Linhas | Select-Object -First 30)) {
      $tem = $(if ($escritos.ContainsKey($c.Comando) -or $gerados.ContainsKey($c.Comando)) { 'sim' } else { '-' })
      Write-Output ('  {0,-20} {1,-18} {2,6}  {3}' -f $tem, $c.Comando, $c.Linhas, $c.Marcas)
    }
    Write-Output ''
    Write-Output ('  resumo: {0} comandos com corpo curto (<=8 linhas: so abrem a tela) e {1} com corpo grande (>60 linhas)' -f
      @($porComando | Where-Object { $_.Linhas -le 8 }).Count, @($porComando | Where-Object { $_.Linhas -gt 60 }).Count)
    Write-Output ''
    Write-Output '  TOTAIS NO DECOMPILADO INTEIRO (o que a tabela do AUDITORIA cita)'
    Write-Output ('  {0,-8} {1,12}   {2}' -f 'marca', 'ocorrencias', 'comandos que carregam')
    foreach ($m in $marcas) {
      Write-Output ('  {0,-8} {1,12}   {2}' -f $m.Sigla, $totais[$m.Sigla], $comandosCom[$m.Sigla])
    }
  }
}

if ($Listas) {
  Write-Output ''
  Write-Output ("COMANDOS DO REVERSO QUE ABREM JANELA E NAO TEM NADA NO PLUGIN ({0})" -f $semNadaJan.Count)
  foreach ($c in ($semNadaJan | Sort-Object Nome)) {
    Write-Output ("  {0,-16} -> {1,-26} {2} {3}" -f $c.Nome, ($c.Janelas -join ','), $c.Construcao, $(if ($c.Variante) { '[variante]' } else { '' }))
  }

  Write-Output ''
  Write-Output ("COMANDOS DO REVERSO SEM TELA E SEM NADA NO PLUGIN ({0}) - ler a triagem do plano (7.6) antes de tratar como pendencia" -f $semNadaReg.Count)
  $nomes = @($semNadaReg | Sort-Object Nome | ForEach-Object { $_.Nome })
  for ($i = 0; $i -lt $nomes.Count; $i += 6) {
    Write-Output ('  ' + (($nomes[$i..([Math]::Min($i + 5, $nomes.Count - 1))]) -join '  '))
  }

  Write-Output ''
  Write-Output ("AS TELAS MAIS BARATAS QUE SO TEM CASCA ({0} no total; as 15 menores)" -f $telaSoCasca.Count)
  foreach ($t in ($telaSoCasca | Sort-Object Linhas | Select-Object -First 15)) {
    Write-Output ("  {0,-30} {1,6} linhas   comando(s): {2}" -f $t.Tela, $t.Linhas, $t.Comandos)
  }

  Write-Output ''
  Write-Output ("TELAS QUE NENHUM COMANDO ABRE ({0}) - relatorios DWG/Excel e editores abertos por outra tela" -f $telaSemComando.Count)
  foreach ($t in ($telaSemComando | Sort-Object { $telas[$_] })) {
    Write-Output ("  {0,-42} {1,6} linhas" -f $t, $telas[$t])
  }
}
