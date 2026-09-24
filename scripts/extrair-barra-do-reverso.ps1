# Extrai a BARRA DE FERRAMENTAS do reverso (o Ribbon.cs) na estrutura de verdade: a aba, os
# paineis na ordem em que o original os cria (CreateRibbon + CreateRibbon2) e, dentro de cada
# painel, cada item na ordem do designer - botao com rotulo, comando, icone e dica.
#
# Por que estrutural: a primeira versao deste script pegava os pares (rotulo, comando) por
# expressao regular solta no arquivo e achava 42 - os 9 paineis do original criam 121 botoes, e
# quem le a lista achatada nao ve a que painel cada botao pertence nem a ordem deles.
#
# O original monta cada botao por um dos quatro ajudantes (o nome deles ficou ofuscado, mas o
# corpo nao), e e isso que diz o que o botao e:
#   Nowp1LGUQxQ(ref b, texto, "CMD ", icone, dica)  -> botao grande, com texto
#   IsVp1wK9F5x(ref b, texto, "CMD ", icone, dica)  -> botao pequeno de icone (o texto vai na dica)
#   PVGp1btLkXV(ref b, "CMD ", icone, dica, texto)  -> botao de icone com texto
#   UCHp1xnMtMs(ref b, "CMD ", icone, dica)         -> icone 16x16 (o "Configurar" do painel)
#
# Coberto: se o recoder tem aquele comando ([CommandMethod] em qualquer .cs do plugin, inclusive
# os gerados). E o que deixa a barra chamar as janelas do mapa sem chutar o que ja funciona.
#
# Uso: powershell -File scripts/extrair-barra-do-reverso.ps1
[CmdletBinding()]
param(
  # o reverso vive dentro do repo desde a rodada 134 (cad-plugin/reverso); os caminhos sao
  # relativos a raiz do repo, como os outros parametros destes extratores.
  [string] $Ribbon    = "cad-plugin\reverso\Eletron4_ZWcad\decompiled-cleaned\Eletron4\Ribbon.cs",
  [string] $Mensagens = "cad-plugin\Positron.Data\Interface\Mapas\mensagens-pt.txt",
  [string] $Plugins   = "cad-plugin\Positron.Plugin",
  [string] $Mapa      = "docs\reverso-barra-do-original.txt",
  [string] $Dados     = "cad-plugin\Positron.Data\Interface\Mapas\BarraDoReverso.Dados.cs",
  # O mapa dos comandos (do extrair-comandos-do-reverso.ps1): diz quais botoes da barra abrem
  # janela. A barra e o mapa de telas se cruzam por aqui, sem ninguem ler o outro por acaso.
  [string] $Comandos  = "cad-plugin\Positron.Data\Interface\Mapas\ComandosDoReverso.Dados.cs"
)

if (-not (Test-Path $Ribbon)) { throw "Ribbon.cs nao encontrado: $Ribbon" }
if (-not (Test-Path $Mensagens)) { throw "mensagens nao encontradas: $Mensagens" }

# ---------------------------------------------------------------- a mMensagem (indice -> texto)
$mm = @{}
foreach ($m in [regex]::Matches([System.IO.File]::ReadAllText($Mensagens), '\{(\d+)=([^}]*)\}')) {
  $mm[[int]$m.Groups[1].Value] = $m.Groups[2].Value
}

function TextoMensagem([int] $indice) {
  if ($mm.ContainsKey($indice)) { return $mm[$indice] }
  return ""
}

# ---------------------------------------------------------------- o que o plugin ja tem
$cobertos = @{}
foreach ($arquivo in Get-ChildItem -Path $Plugins -Recurse -Filter *.cs) {
  $texto = [System.IO.File]::ReadAllText($arquivo.FullName)
  foreach ($m in [regex]::Matches($texto, '\[CommandMethod\("([^"]+)"\)\]')) {
    $cobertos[$m.Groups[1].Value] = $arquivo.Name
  }
}

# ---------------------------------------------------------------- quem abre janela (o mapa 128)
$abremJanela = @{}
if (Test-Path $Comandos) {
  $textoDosComandos = [System.IO.File]::ReadAllText($Comandos)
  # O `new Janela[] { ... }` (com a chave) e o comando que abre; o `new Janela[]` seco e o que nao
  # abre nenhuma. Procurar so o prefixo contava os dois como vazios e o cruzamento dava zero.
  foreach ($m in [regex]::Matches($textoDosComandos, 'new Comando\("([^"]+)", "[^"]*", \d+, (?:true|false), (?:true|false), (?:true|false), new Janela\[\](\s*\{)?')) {
    if (-not $m.Groups[2].Success) { continue }
    $abremJanela[$m.Groups[1].Value] = $true
  }
}

$linhas = [System.IO.File]::ReadAllLines($Ribbon)

# ---------------------------------------------------------------- chaves (o corpo de um metodo)
function FimDoCorpo([string[]] $texto, [int] $inicio) {
  $nivel = 0
  for ($i = $inicio; $i -lt $texto.Count; $i++) {
    $limpa = [regex]::Replace($texto[$i], '"(\\.|[^"\\])*"', '""')
    $nivel += ([regex]::Matches($limpa, '\{')).Count
    $nivel -= ([regex]::Matches($limpa, '\}')).Count
    if ($nivel -le 0 -and $i -gt $inicio -or ($nivel -le 0 -and ([regex]::Matches($limpa, '\{')).Count -gt 0)) {
      return $i
    }
  }
  return $texto.Count - 1
}

# ---------------------------------------------------------------- os argumentos de uma chamada
# Devolve os argumentos de nivel 1 da chamada `NOME(` que estiver na linha (ou $null).
function Argumentos([string] $linha, [string] $nome) {
  $achado = [regex]::Match($linha, [regex]::Escape($nome) + '\s*\(')
  if (-not $achado.Success) { return $null }

  $i = $achado.Index + $achado.Length
  $nivel = 1
  $texto = $false
  $atual = New-Object System.Text.StringBuilder
  $saida = New-Object System.Collections.ArrayList
  while ($i -lt $linha.Length) {
    $c = $linha[$i]
    if ($c -eq '"' -and ($i -eq 0 -or $linha[$i - 1] -ne '\')) { $texto = -not $texto }
    if (-not $texto) {
      if ($c -eq '(') { $nivel++ }
      if ($c -eq ')') {
        $nivel--
        if ($nivel -eq 0) { break }
      }
      if ($c -eq ',' -and $nivel -eq 1) {
        [void]$saida.Add($atual.ToString().Trim())
        [void]$atual.Clear()
        $i++
        continue
      }
    }

    [void]$atual.Append($c)
    $i++
  }

  [void]$saida.Add($atual.ToString().Trim())
  return $saida
}

# O texto de um argumento: literal entre aspas, ou a mMensagem por indice (o `Conversions.ToString`).
function TextoDoArgumento([string] $arg) {
  if ([string]::IsNullOrEmpty($arg)) { return "" }
  $literal = [regex]::Match($arg, '^\s*"((\\.|[^"\\])*)"\s*$')
  if ($literal.Success) {
    return [regex]::Replace($literal.Groups[1].Value, '\\r\\n', ' ').Trim()
  }

  $indice = [regex]::Match($arg, 'mMensagem\[1,\s*(\d+)\]')
  if ($indice.Success) {
    return (TextoMensagem ([int]$indice.Groups[1].Value)).Trim()
  }

  return ""
}

# Escapa o que o literal do C# nao aceita cru (a barra invertida e a aspa do rotulo do original).
function EscC([string] $texto) {
  if ($null -eq $texto) { return "" }
  return $texto.Replace('\', '\\').Replace('"', '\"')
}

function IconeDoArgumento([string] $arg, [string] $ultimo) {
  $direto = [regex]::Match($arg, 'Resources\.([A-Za-z0-9_]+)')
  if ($direto.Success) { return $direto.Groups[1].Value }
  if ($arg -match '\bimage\b') { return $ultimo }
  return ""
}

# ---------------------------------------------------------------- a ordem dos paineis
# O CreateRibbon adiciona dois e o CreateRibbon2 mais sete; a ordem das chamadas e a ordem deles.
$ordem = New-Object System.Collections.ArrayList
$dentro = $false
foreach ($linha in $linhas) {
  if ($linha -match 'public void CreateRibbon') { $dentro = $true; continue }
  if (-not $dentro) { continue }
  if ($linha -match 'PointMonitorToolTips\.StartMonitor') { break }
  $chamada = [regex]::Match($linha, '^\s*([A-Za-z0-9_]+)\(val\);')
  if ($chamada.Success -and -not ($chamada.Groups[1].Value -match 'StartMonitor')) {
    [void]$ordem.Add($chamada.Groups[1].Value)
  }
}

# ---------------------------------------------------------------- cada painel
$paineis = New-Object System.Collections.ArrayList
$ordemDoPainel = 0
foreach ($metodo in $ordem) {
  # A assinatura: `private void NOME(RibbonTab P_0)` OU `private RibbonPanelSource NOME(RibbonTab P_0)`
  # - cinco dos nove paineis retornam a fonte do painel em vez de void, e exigir `void` na
  # assinatura deixava exatamente esses cinco de fora (a barra saia com 4 paineis e 33 botoes).
  $declaracao = -1
  for ($i = 0; $i -lt $linhas.Count; $i++) {
    if ($linhas[$i] -match ('\b' + [regex]::Escape($metodo) + '\s*\(RibbonTab')) { $declaracao = $i; break }
  }
  if ($declaracao -lt 0) { continue }

  $fim = FimDoCorpo $linhas $declaracao
  $ordemDoPainel++

  # o titulo do painel e a PRIMEIRA mMensagem do corpo dele
  $indiceTitulo = -1
  $tituloLiteral = ""
  for ($i = $declaracao; $i -le $fim; $i++) {
    $titulo = [regex]::Match($linhas[$i], '\.Title\s*=\s*Conversions\.ToString\(DeclaracoesGeral\.mMensagem\[1,\s*(\d+)\]\)')
    if ($titulo.Success) { $indiceTitulo = [int]$titulo.Groups[1].Value; break }

    # Um painel tem o titulo literal (o ultimo, o "Help"): sem este ramo ele saia sem nome.
    $literal = [regex]::Match($linhas[$i], '\.Title\s*=\s*"([^"]+)"')
    if ($literal.Success) { $tituloLiteral = $literal.Groups[1].Value; break }
  }

  $botoes = New-Object System.Collections.ArrayList
  $ultimoIcone = ""
  for ($i = $declaracao; $i -le $fim; $i++) {
    $linha = $linhas[$i]

    $icone = [regex]::Match($linha, '\bimage = Resources\.([A-Za-z0-9_]+)')
    if ($icone.Success) { $ultimoIcone = $icone.Groups[1].Value }

    # A chamada do ajudante pode estar partida em varias linhas; junta ate fechar o parenteses da
    # chamada (senao o `Argumentos` nao acha o fim e o botao se perde).
    foreach ($nomeDeAjudante in @('Nowp1LGUQxQ', 'IsVp1wK9F5x', 'PVGp1btLkXV', 'UCHp1xnMtMs')) {
      if ($linha -notmatch [regex]::Escape($nomeDeAjudante) + '\s*\(ref') { continue }
      $j = $i
      $abre = 0
      $fecha = 0
      while ($j -le $fim) {
        $pedaco = [regex]::Replace($linhas[$j], '"(\\.|[^"\\])*"', '""')
        $abre += ([regex]::Matches($pedaco, '\(')).Count
        $fecha += ([regex]::Matches($pedaco, '\)')).Count
        if ($j -gt $i) { $linha += ' ' + $linhas[$j].Trim() }
        if ($fecha -ge $abre) { break }
        $j++
      }
    }

    $botoesDoAjudante = @(
      @{ Nome = 'Nowp1LGUQxQ'; Grau = 'Grande';     Rotulo = 1; Comando = 2; Icone = 3; Dica = 4; Texto = -1 },
      @{ Nome = 'IsVp1wK9F5x'; Grau = 'Pequeno';    Rotulo = 1; Comando = 2; Icone = 3; Dica = 4; Texto = -1 },
      @{ Nome = 'PVGp1btLkXV'; Grau = 'IconeTexto'; Rotulo = 4; Comando = 1; Icone = 2; Dica = 3; Texto = 4 },
      @{ Nome = 'UCHp1xnMtMs'; Grau = 'Icone';      Rotulo = -1; Comando = 1; Icone = 2; Dica = 3; Texto = -1 }
    )

    foreach ($ajudante in $botoesDoAjudante) {
      $argumentos = Argumentos $linha $ajudante.Nome
      if ($argumentos -eq $null) { continue }
      if ($argumentos.Count -le [Math]::Max($ajudante.Icone, $ajudante.Comando)) { continue }

      $comando = (TextoDoArgumento $argumentos[$ajudante.Comando])
      if ($comando.Length -eq 0) { $comando = '' }
      $comando = $comando.Trim()

      $rotulo = ""
      if ($ajudante.Rotulo -ge 0 -and $argumentos.Count -gt $ajudante.Rotulo) {
        $rotulo = (TextoDoArgumento $argumentos[$ajudante.Rotulo])
      }

      $dica = ""
      if ($argumentos.Count -gt $ajudante.Dica) { $dica = (TextoDoArgumento $argumentos[$ajudante.Dica]) }

      $iconeDoBotao = ""
      if ($argumentos.Count -gt $ajudante.Icone) {
        $iconeDoBotao = IconeDoArgumento $argumentos[$ajudante.Icone] $ultimoIcone
      }

      $textoDoBotao = ""
      if ($ajudante.Texto -ge 0 -and $argumentos.Count -gt $ajudante.Texto) {
        $textoDoBotao = (TextoDoArgumento $argumentos[$ajudante.Texto])
      }

      [void]$botoes.Add([pscustomobject]@{
        Rotulo     = $(if ($textoDoBotao.Length -gt 0) { $textoDoBotao } else { $rotulo })
        Comando    = $comando
        Icone      = $iconeDoBotao
        Dica       = $(if ($dica.Length -gt 0) { $dica } else { $rotulo })
        Grau       = $ajudante.Grau
        Linha      = $i + 1
        Coberto    = ($comando.Length -gt 0 -and $cobertos.ContainsKey($comando))
        AbreJanela = ($comando.Length -gt 0 -and $abremJanela.ContainsKey($comando))
      })
    }
  }

  # O `DialogLauncher` (o iconezinho do canto do painel - no original e o `CFG` da Configuracao e
  # o `MOSTRAR` dos Utilitarios). Ele tambem e um botao, so que fora dos `Items`.
  $variaveisDeComando = @{}
  for ($i = $declaracao; $i -le $fim; $i++) {
    $atribuicao = [regex]::Match($linhas[$i], '\)(\w+)\)\.CommandParameter = "([^"]*)"')
    if ($atribuicao.Success) { $variaveisDeComando[$atribuicao.Groups[1].Value] = $atribuicao.Groups[2].Value }
  }

  for ($i = $declaracao; $i -le $fim; $i++) {
    $lancador = [regex]::Match($linhas[$i], '\.DialogLauncher = \(RibbonCommandItem\)\(object\)(\w+)')
    if (-not $lancador.Success) { continue }
    $variavel = $lancador.Groups[1].Value
    if (-not $variaveisDeComando.ContainsKey($variavel)) { continue }
    $comandoDoLancador = $variaveisDeComando[$variavel].Trim()
    [void]$botoes.Add([pscustomobject]@{
      Rotulo     = $comandoDoLancador
      Comando    = $comandoDoLancador
      Icone      = ""
      Dica       = "Configurar o painel " + $(if ($indiceTitulo -ge 0) { TextoMensagem $indiceTitulo } else { "" })
      Grau       = 'Dialogo'
      Linha      = $i + 1
      Coberto    = ($comandoDoLancador.Length -gt 0 -and $cobertos.ContainsKey($comandoDoLancador))
      AbreJanela = ($comandoDoLancador.Length -gt 0 -and $abremJanela.ContainsKey($comandoDoLancador))
    })
  }

  [void]$paineis.Add([pscustomobject]@{
    Ordem          = $ordemDoPainel
    Metodo         = $metodo
    Materia        = $indiceTitulo
    Titulo         = $(if ($indiceTitulo -ge 0) { TextoMensagem $indiceTitulo } else { $tituloLiteral })
    Linha          = $declaracao + 1
    Botoes         = $botoes
  })
}

$todos = @($paineis | ForEach-Object { $_.Botoes } | ForEach-Object { $_ })
$cobertosNaBarra = @($todos | Where-Object { $_.Coberto })
$chamamJanela = @($todos | Where-Object { $_.Coberto -and $_.AbreJanela })

# Conferencia: cada chamada de ajudante no arquivo tem de virar um botao aqui. Se os numeros
# divergirem, o mapa esta perdendo botao - e isso vai escrito no proprio mapa.
#
# As QUATRO ASSINATURAS dos ajudantes (no fim do arquivo, `private void Nowp1LGUQxQ(ref RibbonButton
# P_0, ...)`) casam com o mesmo padrao das chamadas: contar por ele dava 124 para 121 botoes e a
# diferenca ficava sem explicacao. Declaracao nao e chamada - a linha com o tipo do parametro sai.
$chamadas = 0
foreach ($linha in $linhas) {
  if ($linha -match '\b(ref)\s+RibbonButton\b') { continue }
  if ($linha -match ('\b(Nowp1LGUQxQ|IsVp1wK9F5x|PVGp1btLkXV|UCHp1xnMtMs)\s*\(ref')) { $chamadas++ }
}

# O unico `DialogLauncher` do arquivo (o iconezinho do canto de um painel): ele nao passa pelos
# ajudantes, entao entra na conta do mapa por fora deles.
$launchers = ([regex]::Matches(($linhas -join "`n"), '\.DialogLauncher\s*=')).Count
$abaId = ([regex]::Match(($linhas -join "`n"), 'val\.Id = "([^"]+)"')).Groups[1].Value
$abaTitulo = ([regex]::Match(($linhas -join "`n"), 'val\.Title = "([^"]+)"')).Groups[1].Value

# ---------------------------------------------------------------- o mapa legivel
$doc = New-Object System.Collections.ArrayList
[void]$doc.Add('# A barra de ferramentas do reverso (o `Ribbon.cs`)')
[void]$doc.Add('')
[void]$doc.Add('Gerado por `scripts/extrair-barra-do-reverso.ps1` a partir do descompilado')
[void]$doc.Add('(`cad-plugin\reverso\Eletron4_ZWcad\decompiled-cleaned\Eletron4\Ribbon.cs`).')
[void]$doc.Add('')
[void]$doc.Add('A aba do original e `' + $abaId + '` (**' + $abaTitulo + '**); os paineis saem na ordem em que o')
[void]$doc.Add('`CreateRibbon()` (dois) e o `CreateRibbon2()` (sete) os criam, e os botoes na ordem do corpo de')
[void]$doc.Add('cada painel. O titulo do painel e o **indice** da `mMensagem` que o corpo usa, resolvido aqui.')
[void]$doc.Add('')
[void]$doc.Add('`coberto` = o recoder responde a esse comando hoje (qualquer `[CommandMethod]` do plugin,')
[void]$doc.Add('inclusive os gerados da rodada 128) - e o que a barra usa para saber o que ja funciona.')
[void]$doc.Add('')
[void]$doc.Add('## A aba')
[void]$doc.Add('')
[void]$doc.Add('| id | titulo | paineis | botoes | cobertos |')
[void]$doc.Add('|---|---|---|---|---|')
[void]$doc.Add('| `' + $abaId + '` | ' + $abaTitulo + ' | ' + $paineis.Count + ' | ' + $todos.Count + ' | ' + $cobertosNaBarra.Count + ' |')
[void]$doc.Add('')
[void]$doc.Add('## Os paineis')
[void]$doc.Add('')
[void]$doc.Add('| # | painel | mMensagem | botoes | cobertos | metodo | linha |')
[void]$doc.Add('|---|---|---|---|---|---|---|')
foreach ($p in $paineis) {
  [void]$doc.Add('| ' + $p.Ordem + ' | ' + $p.Titulo + ' | ' + $p.Materia + ' | ' + $p.Botoes.Count + ' | ' + @($p.Botoes | Where-Object { $_.Coberto }).Count + ' | `' + $p.Metodo + '` | ' + $p.Linha + ' |')
}
[void]$doc.Add('')
[void]$doc.Add('## Os botoes, na ordem da barra')
[void]$doc.Add('')
foreach ($p in $paineis) {
  [void]$doc.Add('### ' + $p.Ordem + '. ' + $p.Titulo + ' (`mMensagem[1, ' + $p.Materia + ']`, linha ' + $p.Linha + ')')
  [void]$doc.Add('')
  [void]$doc.Add('| rotulo | comando | icone | grau | coberto | abre janela | dica | linha |')
  [void]$doc.Add('|---|---|---|---|---|---|---|---|')
  foreach ($b in $P.Botoes) {
    [void]$doc.Add('| ' + $b.Rotulo + ' | `' + $b.Comando + '` | `' + $b.Icone + '` | ' + $b.Grau + ' | ' + $(if ($b.Coberto) { 'sim' } else { 'nao' }) + ' | ' + $(if ($b.AbreJanela) { 'sim' } else { 'nao' }) + ' | ' + $b.Dica + ' | ' + $b.Linha + ' |')
  }
  [void]$doc.Add('')
}
[void]$doc.Add('## O que a barra ja chama hoje')
[void]$doc.Add('')
[void]$doc.Add('Os botoes cujo comando o recoder responde, **na ordem da barra** - e esta a lista que a')
[void]$doc.Add('barra ativa. Os que **abrem janela** sao os do mapa `docs/reverso-comandos.txt` (rodada 128):')
[void]$doc.Add('viraram botao de verdade sem nenhum codigo novo, porque o comando ja existe no CAD.')
[void]$doc.Add('')
[void]$doc.Add('| # | painel | rotulo | comando | icone | abre janela |')
[void]$doc.Add('|---|---|---|---|---|---|')
$indice = 0
foreach ($p in $paineis) {
  foreach ($b in ($p.Botoes | Where-Object { $_.Coberto })) {
    $indice++
    [void]$doc.Add('| ' + $indice + ' | ' + $p.Titulo + ' | ' + $b.Rotulo + ' | `' + $b.Comando + '` | `' + $b.Icone + '` | ' + $(if ($b.AbreJanela) { 'sim' } else { 'nao' }) + ' |')
  }
}
[void]$doc.Add('')
[void]$doc.Add('## Contagens')
[void]$doc.Add('')
[void]$doc.Add('- Paineis: **' + $paineis.Count + '**.')
[void]$doc.Add('- Botoes: **' + $todos.Count + '** (o recoder responde a **' + $cobertosNaBarra.Count + '**).')
[void]$doc.Add('- Botoes que o recoder responde **e** abrem janela: **' + $chamamJanela.Count + '**.')
[void]$doc.Add('- Comandos distintos na barra: **' + @($todos | ForEach-Object { $_.Comando } | Sort-Object -Unique).Count + '**.')
[void]$doc.Add('- Icones distintos: **' + @($todos | ForEach-Object { $_.Icone } | Sort-Object -Unique).Count + '** (sem os vazios).')
[void]$doc.Add('- Chamadas dos ajudantes no `Ribbon.cs`: **' + $chamadas + '** + **' + $launchers + '** `DialogLauncher` = **' + ($chamadas + $launchers) + '** (contra **' + $todos.Count + '** botoes extraidos: as quatro assinaturas dos ajudantes no fim do arquivo nao contam).')
[void]$doc.Add('')

[System.IO.File]::WriteAllLines((Join-Path (Get-Location) $Mapa), $doc)

# ---------------------------------------------------------------- a tabela compilada
$cs = New-Object System.Collections.ArrayList
[void]$cs.Add('// <auto-generated>')
[void]$cs.Add('//     Gerado por scripts/extrair-barra-do-reverso.ps1 - nao edite a mao.')
[void]$cs.Add('//     O mapa legivel e a evidencia ficam em docs/reverso-barra-do-original.txt.')
[void]$cs.Add('// </auto-generated>')
[void]$cs.Add('')
[void]$cs.Add('namespace Positron.Data.Interface.Mapas')
[void]$cs.Add('{')
[void]$cs.Add('    public static partial class BarraDoReverso')
[void]$cs.Add('    {')
[void]$cs.Add('        private const string IdDaAba = "' + (EscC $abaId) + '";')
[void]$cs.Add('')
[void]$cs.Add('        private const string TituloDaAba = "' + (EscC $abaTitulo) + '";')
[void]$cs.Add('')
[void]$cs.Add('        private static PainelDaBarra[] MontarOsPaineis()')
[void]$cs.Add('        {')
[void]$cs.Add('            return new PainelDaBarra[]')
[void]$cs.Add('            {')
foreach ($p in $paineis) {
  [void]$cs.Add('                new PainelDaBarra(' + $p.Ordem + ', "' + (EscC $p.Titulo) + '", ' + $p.Materia + ', "' + (EscC $p.Metodo) + '", ' + $p.Linha + ', new BotaoDaBarra[]')
  [void]$cs.Add('                {')
  foreach ($b in $p.Botoes) {
    [void]$cs.Add('                    new BotaoDaBarra("' + (EscC $b.Rotulo) + '", "' + (EscC $b.Comando) + '", "' + (EscC $b.Icone) + '", "' + (EscC $b.Dica) + '", "' + (EscC $b.Grau) + '", ' + $b.Linha + ', ' + $(if ($b.Coberto) { 'true' } else { 'false' }) + ', ' + $(if ($b.AbreJanela) { 'true' } else { 'false' }) + '),')
  }
  [void]$cs.Add('                }),')
}
[void]$cs.Add('            };')
[void]$cs.Add('        }')
[void]$cs.Add('    }')
[void]$cs.Add('}')
[void]$cs.Add('')

[System.IO.File]::WriteAllLines((Join-Path (Get-Location) $Dados), $cs)

Write-Output ("aba: " + $abaId + " (" + $abaTitulo + ")")
Write-Output ("paineis: " + $paineis.Count)
Write-Output ("botoes: " + $todos.Count)
Write-Output ("cobertos pelo plugin: " + $cobertosNaBarra.Count)
Write-Output ("cobertos que abrem janela: " + $chamamJanela.Count)
Write-Output ("chamadas de ajudante no Ribbon.cs: " + $chamadas + " + " + $launchers + " launcher(s) = " + ($chamadas + $launchers))
Write-Output ("mapa: " + (Join-Path (Get-Location) $Mapa))
Write-Output ("dados: " + (Join-Path (Get-Location) $Dados))
