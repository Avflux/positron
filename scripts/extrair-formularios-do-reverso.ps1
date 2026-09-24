# Extrai o LAYOUT dos formularios (frm*) do reverso: nome, titulo, ClientSize e cada
# controle (tipo, nome, pai, caixa x/y/l/a, texto, icone e as propriedades que mudam o
# visual), resolvendo os textos que vem da mMensagem.
#
# De onde sai: o .cs descompilado guarda o metodo do designer inteiro (o `[DebuggerStepThrough]`
# com `SuspendLayout()`), e o de4dot NAO ofuscou os nomes de controle nem os valores das
# propriedades - so os campos privados e os nomes de metodo. Ou seja: a formatacao correta
# das janelas esta no arquivo.
#
# Uso: powershell -File scripts/extrair-formularios-do-reverso.ps1
[CmdletBinding()]
param(
  # o reverso vive dentro do repo desde a rodada 134 (cad-plugin/reverso)
  [string] $Reverso   = "cad-plugin\reverso\Eletron4_ZWcad\decompiled-cleaned\Eletron4",
  [string] $Mensagens = "cad-plugin\Positron.Data\Interface\Mapas\mensagens-pt.txt",
  [string] $Mapa      = "docs\reverso-formularios.txt",
  [string] $Dados     = "cad-plugin\Positron.Data\Interface\Mapas\FormulariosDoReverso.Dados.cs"
)

if (-not (Test-Path $Reverso)) { throw "reverso nao encontrado: $Reverso" }
if (-not (Test-Path $Mensagens)) { throw "mensagens nao encontradas: $Mensagens" }

# ---------------------------------------------------------------- a mMensagem (indice -> texto)
$mm = @{}
foreach ($m in [regex]::Matches([System.IO.File]::ReadAllText($Mensagens), '\{(\d+)=([^}]*)\}')) {
  $mm[[int]$m.Groups[1].Value] = $m.Groups[2].Value
}

# ---------------------------------------------------------------- o que a tela renderiza
$renderizaveis = @(
  'Button', 'CheckBox', 'CheckedListBox', 'ComboBox', 'DataGridView', 'DateTimePicker',
  'FlowLayoutPanel', 'GroupBox', 'Label', 'LinkLabel', 'ListBox', 'ListView', 'MaskedTextBox',
  'MonthCalendar', 'NumericUpDown', 'Panel', 'PictureBox', 'ProgressBar', 'RadioButton',
  'RichTextBox', 'SplitContainer', 'TabControl', 'TabPage', 'TableLayoutPanel', 'TextBox',
  'TreeView', 'MenuStrip', 'ContextMenuStrip', 'StatusStrip', 'ToolStrip', 'ToolStripButton',
  'ToolStripComboBox', 'ToolStripDropDownButton', 'ToolStripLabel', 'ToolStripMenuItem',
  'ToolStripSeparator', 'ToolStripTextBox', 'ToolStripStatusLabel'
)
$tiposDeColuna = @(
  'DataGridViewTextBoxColumn', 'DataGridViewComboBoxColumn', 'DataGridViewCheckBoxColumn',
  'DataGridViewButtonColumn', 'DataGridViewImageColumn', 'DataGridViewLinkColumn'
)

# Propriedades que mudam o visual (as outras ficam so no mapa, como evidencia).
$uteis = @(
  'Anchor', 'AutoSize', 'BackColor', 'BackgroundColor', 'BorderStyle', 'CheckBoxes', 'Checked',
  'DecimalPlaces', 'Dock', 'DropDownStyle', 'Enabled', 'FlatStyle', 'Font', 'ForeColor',
  'ImageAlign', 'ItemHeight', 'Maximum', 'MaxLength', 'Minimum', 'MultiSelect', 'Multiline',
  'Orientation', 'PasswordChar', 'ReadOnly', 'RowHeadersVisible', 'ScrollBars', 'SelectionMode',
  'ShowLines', 'SplitterDistance', 'TextAlign', 'UseVisualStyleBackColor', 'View', 'Visible',
  'WordWrap', 'AllowUserToAddRows', 'ContextMenuStrip'
)

# Propriedades da propria janela (a moldura): so valem no formulario, nao em controle.
$uteisJanela = @(
  'BackColor', 'BackgroundImage', 'BackgroundImageLayout', 'ControlBox', 'FormBorderStyle',
  'Icon', 'MaximizeBox', 'MinimizeBox', 'ShowIcon', 'ShowInTaskbar', 'StartPosition', 'TopMost',
  'TransparencyKey', 'WindowState', 'DoubleBuffered', 'KeyPreview'
)

function Esc([string]$s) {
  if ($null -eq $s) { return '' }
  return $s.Replace('\', '\\').Replace('"', '\"').Replace("`r", '\r').Replace("`n", '\n')
}

# Quebra `a, b` no nivel de fora, respeitando parenteses e aspas.
function Dividir-Argumentos([string]$s) {
  $partes = New-Object System.Collections.Generic.List[string]
  $nivel = 0; $aspas = $false; $atual = ''
  for ($i = 0; $i -lt $s.Length; $i++) {
    $c = $s[$i]
    if ($c -eq '"') { $aspas = -not $aspas; $atual += $c; continue }
    if (-not $aspas) {
      # parenteses E colchetes contam: `mMensagem[1, 1251]` tem virgula dentro
      if ($c -eq '(' -or $c -eq '[' -or $c -eq '{') { $nivel++ }
      elseif ($c -eq ')' -or $c -eq ']' -or $c -eq '}') { $nivel-- }
      elseif ($c -eq ',' -and $nivel -eq 0) { $partes.Add($atual); $atual = ''; continue }
    }
    $atual += $c
  }
  $partes.Add($atual)
  return $partes
}

# Tenta resolver uma expressao como TEXTO; devolve $null quando ela so existe em tempo de execucao.
function ResolverTexto([string]$e) {
  $e = $e.Trim()
  if ($e -match '^Conversions\.ToString\((.+)\)$') { return ResolverTexto $Matches[1] }
  if ($e -match '^Operators\.(ConcatenateObject|AddObject)\((.+)\)$') {
    # cuidado: `$args` e automatico do PowerShell - nao pode ser o nome da variavel
    $pedacos = Dividir-Argumentos $Matches[2]
    if ($pedacos.Count -eq 2) {
      $a = ResolverTexto $pedacos[0]
      $b = ResolverTexto $pedacos[1]
      if ($null -ne $a -and $null -ne $b) { return $a + $b }
    }
    return $null
  }
  if ($e -match '^"(.*)"$') { return $Matches[1].Replace('\"', '"').Replace('\\', '\') }
  if ($e -match '^DeclaracoesGeral\.mMensagem\[1,\s*(\d+)\]$') {
    $i = [int]$Matches[1]
    if ($mm.ContainsKey($i)) { return $mm[$i] }
    return "?$i"
  }
  if ($e -match '^Application\.ProductName$') { return 'Positron' }
  if ($e -match '^Operators\.(AddObject|ConcatenateObject)\(') { return $null }
  # o que so existe em tempo de execucao vira um marcador explicito
  return '{' + $e + '}'
}

# Resolve o lado direito de uma atribuicao para o que a tela precisa guardar.
function Resolver([string]$expr) {
  $e = $expr.Trim().TrimEnd(';').Trim()

  # texto: literal, mMensagem[N] ou a soma dos dois (inclusive a concatenacao do VB)
  if ($e -match '^"' -or $e -match '^Conversions\.ToString\(' -or $e -match '^DeclaracoesGeral\.mMensagem') {
    $t = ResolverTexto $e
    if ($null -ne $t) { return @{ Tipo = 'texto'; Valor = $t } }
  }
  $pedacos = $e -split '\s*\+\s*'
  if ($pedacos.Count -gt 1) {
    $soma = ''; $ok = $true
    foreach ($p in $pedacos) { $t = ResolverTexto $p; if ($null -eq $t) { $ok = $false; break }; $soma += $t }
    if ($ok) { return @{ Tipo = 'texto'; Valor = $soma } }
  }

  if ($e -match '^Resources\.(\w+)$') { return @{ Tipo = 'imagem'; Valor = $Matches[1] } }
  # a imagem do resx do proprio formulario: `(Image)componentResourceManager.GetObject("X.Image")`
  # (extraida pelo scripts/extrair-imagens-dos-formularios.ps1 para lib/Icons)
  if ($e -match '^\(?\w*\)?componentResourceManager\.GetObject\("([^"]+)"\)$') {
    $chaveDoResx = $Matches[1]
    if ($chaveDoResx -match '\.(Image|BackgroundImage)$') {
      return @{ Tipo = 'imagem'; Valor = ($chaveDoResx -replace '\.(Image|BackgroundImage)$', '') }
    }

    return @{ Tipo = 'bruto'; Valor = $e }
  }
  if ($e -match '^new Size\((-?\d+),\s*(-?\d+)\)$') { return @{ Tipo = 'size'; Valor = "$($Matches[1]), $($Matches[2])" } }
  if ($e -match '^new Point\((-?\d+),\s*(-?\d+)\)$') { return @{ Tipo = 'point'; Valor = "$($Matches[1]), $($Matches[2])" } }
  if ($e -match '^new SizeF\(([\d.]+)f?,\s*([\d.]+)f?\)$') { return @{ Tipo = 'bruto'; Valor = "$($Matches[1]), $($Matches[2])" } }
  if ($e -match '^AnchorStyles\.(.+)$') {
    $partes = ($Matches[1] -split '\s*\|\s*') | ForEach-Object { $_ -replace 'AnchorStyles\.', '' }
    return @{ Tipo = 'bruto'; Valor = ($partes -join ', ') }
  }
  if ($e -match '^[A-Za-z][\w.]*\.(\w+)$') { return @{ Tipo = 'bruto'; Valor = $Matches[1] } }   # FlatStyle.Flat -> Flat
  if ($e -match '^new Font\((.+)\)$') { return @{ Tipo = 'bruto'; Valor = $Matches[1] } }
  if ($e -match '^(true|false)$') { return @{ Tipo = 'bruto'; Valor = (Get-Culture).TextInfo.ToTitleCase($Matches[1]) } }
  if ($e -match '^(\d+)$') { return @{ Tipo = 'bruto'; Valor = $Matches[1] } }

  return @{ Tipo = 'bruto'; Valor = $e }
}

# ---------------------------------------------------------------- disseca um frm
function Ler-Formulario([string]$caminho) {
  $txt = [System.IO.File]::ReadAllText($caminho)
  $linhas = $txt -split "`r?`n"

  # o metodo do designer: o ultimo `void X()` antes do SuspendLayout
  $iSus = $txt.IndexOf('SuspendLayout();')
  if ($iSus -lt 0) { return $null }
  $antes = $txt.Substring(0, $iSus)
  $assinatura = [regex]::Matches($antes, '(?m)^\t(?:private|public|internal|protected) void (\w+)\(\)\s*$')
  if ($assinatura.Count -eq 0) { return $null }
  $ini = $assinatura[$assinatura.Count - 1].Index
  $linhaIni = ($txt.Substring(0, $ini) -split "`n").Count
  $fim = $txt.IndexOf("`r`n`t}", $iSus)
  if ($fim -lt 0) { return $null }
  $corpo = $txt.Substring($ini, $fim - $ini)
  $linhaFim = ($txt.Substring(0, $fim) -split "`n").Count

  $nomeArquivo = [System.IO.Path]::GetFileNameWithoutExtension($caminho)

  # 1) as criacoes: var -> tipo
  $tipoDe = @{}
  foreach ($l in ($corpo -split "`r?`n")) {
    if ($l -match '^\t\t(\w+) = new ([\w.]+)\(.*\);$') {
      $t = $Matches[2]; if ($t.Contains('.')) { $t = $t.Split('.')[-1] }
      $tipoDe[$Matches[1]] = $t
    }
  }

  # 2) as propriedades, na ordem em que o designer as escreve
  $propsDe = @{}
  $propsForm = New-Object System.Collections.Generic.List[object]
  $paisDe = @{}
  $ordem = 0
  foreach ($l in ($corpo -split "`r?`n")) {
    if ($l -match '^\t\t(\w+)\.Controls\.Add\((\w+)\);$') { $ordem++; $paisDe[$Matches[2]] = @{ Pai = $Matches[1]; Ordem = $ordem }; continue }
    if ($l -match '^\t\tControls\.Add\((\w+)\);$') { $ordem++; $paisDe[$Matches[1]] = @{ Pai = ''; Ordem = $ordem }; continue }
    if ($l -match '^\t\t(\w+)\.(Columns|Items|DropDownItems|TabPages)\.Add\((\w+)\);$') {
      $ordem++; $paisDe[$Matches[3]] = @{ Pai = $Matches[1]; Ordem = $ordem }
      $extra = @{ }
      if (-not $propsDe.ContainsKey($Matches[3])) { $propsDe[$Matches[3]] = New-Object System.Collections.Generic.List[object] }
      continue
    }
    # um item literal de ComboBox/ListBox (nao ha controle por tras)
    if ($l -match '^\t\t(\w+)\.(Items|DropDownItems)\.Add\((.+)\);$') {
      $ordem++
      $v = Resolver $Matches[3]
      $chave = "$($Matches[1])~item~$ordem"
      $propsDe[$chave] = New-Object System.Collections.Generic.List[object]
      $propsDe[$chave].Add(@{ Nome = 'Texto'; Valor = $(if ($v.Tipo -eq 'texto') { $v.Valor } else { $v.Valor }) })
      $paisDe[$chave] = @{ Pai = $Matches[1]; Ordem = $ordem; Literal = $true }
      continue
    }
    if ($l -match '^\t\t(\w+)\.([\w]+) = (.*);$') {
      $var = $Matches[1]
      if (-not $propsDe.ContainsKey($var)) { $propsDe[$var] = New-Object System.Collections.Generic.List[object] }
      $v = Resolver $Matches[3]
      $propsDe[$var].Add(@{ Nome = $Matches[2]; Tipo = $v.Tipo; Valor = $v.Valor })
      continue
    }
    if ($l -match '^\t\t([\w.]+) = (.*);$') {
      $v = Resolver $Matches[2]
      $propsForm.Add(@{ Nome = $Matches[1]; Tipo = $v.Tipo; Valor = $v.Valor })
      continue
    }
  }

  # 3) os campos (controles, colunas e itens), com o nome do designer
  $nomeDe = @{}
  foreach ($var in $propsDe.Keys) {
    $nomeDe[$var] = $var
    foreach ($p in $propsDe[$var]) { if ($p.Nome -eq 'Name') { $nomeDe[$var] = $p.Valor } }
  }

  $campos = New-Object System.Collections.Generic.List[object]
  foreach ($var in $propsDe.Keys) {
    $tipo = $tipoDe[$var]
    if (-not $tipo) { if ($var -like '*~item~*') { $tipo = 'Item' } else { continue } }
    $ehColuna = $tiposDeColuna -contains $tipo
    if (-not ($renderizaveis -contains $tipo) -and -not $ehColuna -and $tipo -ne 'Item') { continue }

    $props = $propsDe[$var]
    $nome = $var
    foreach ($p in $props) { if ($p.Nome -eq 'Name') { $nome = $p.Valor } }
    $texto = ''
    foreach ($p in $props) { if ($p.Nome -eq 'Text' -or ($tipo -eq 'Item' -and $p.Nome -eq 'Texto')) { $texto = $p.Valor } }
    if ($tipo -eq 'Item') { $texto = $props[0].Valor; $nome = '' }
    if ($ehColuna) { foreach ($p in $props) { if ($p.Nome -eq 'HeaderText') { $texto = $p.Valor } } }

    $imagem = ''
    foreach ($p in $props) { if ($p.Nome -eq 'Image') { $imagem = $p.Valor } }

    # `-2147483648` = o `Campo.NaoDefinido` do modelo: o designer nao poe a propriedade.
    # (Nao pode ser -1: o designer do original tem controle em coordenada negativa, ex. -18.)
    $x = [int]::MinValue; $y = [int]::MinValue; $l = [int]::MinValue; $a = [int]::MinValue
    foreach ($p in $props) {
      if ($p.Nome -eq 'Location') { $par = $p.Valor -split ',\s*'; $x = [int]$par[0]; $y = [int]$par[1] }
      if ($p.Nome -eq 'Size') { $par = $p.Valor -split ',\s*'; $l = [int]$par[0]; $a = [int]$par[1] }
      if ($ehColuna -and $p.Nome -eq 'Width') { $l = [int]$p.Valor }
    }

    $pai = ''
    $ord = 0
    if ($paisDe.ContainsKey($var)) { $pai = $paisDe[$var].Pai; $ord = $paisDe[$var].Ordem }
    if ($ehColuna -and $pai -and $tipoDe[$pai] -eq 'DataGridView') { } else { }

    $extras = New-Object System.Collections.Generic.List[string]
    foreach ($p in $props) {
      if ($uteis -notcontains $p.Nome) { continue }
      $valorDaProp = $p.Valor
      # a referencia a outro controle (o menu de contexto da grade) vira o nome do designer
      if ($valorDaProp -match '^\{(.+)\}$' -and $nomeDe.ContainsKey($Matches[1])) { $valorDaProp = $nomeDe[$Matches[1]] }
      $extras.Add($p.Nome); $extras.Add($valorDaProp)
    }

    $campos.Add(@{
      Tipo = $(if ($ehColuna) { 'Coluna' } else { $tipo })
      Nome = $nome; Pai = $pai; Ordem = $ord
      X = $x; Y = $y; L = $l; A = $a
      Texto = $texto; Imagem = $imagem; Extras = $extras
      Propriedades = $props
      ColunaReal = $(if ($ehColuna) { $tipo } else { '' })
    })
  }

  # 3c) o texto que o designer deixa como PLACEHOLDER (igual ao nome do controle - o `Label1`
  #     com texto "Label1") e o original preenche nas rotinas de carga com a `mMensagem`.
  #     So entram atribuicoes que resolvem para TEXTO (literal ou mMensagem): o que so existe
  #     em execucao fica como o designer deixou, e o placeholder nunca sobrescreve nada.
  $varDoNome = @{}
  foreach ($var in $nomeDe.Keys) {
    if (-not $varDoNome.ContainsKey($nomeDe[$var])) { $varDoNome[$nomeDe[$var]] = $var }
  }

  foreach ($campo in $campos) {
    if ($campo.Tipo -eq 'Coluna' -or $campo.Tipo -eq 'Item') { continue }
    if ($campo.Texto -ne '' -and $campo.Texto -ne $campo.Nome) { continue }
    if (-not $campo.Nome -or -not $varDoNome.ContainsKey($campo.Nome)) { continue }

    $var = $varDoNome[$campo.Nome]
    foreach ($l in $linhas) {
      if ($l -notmatch ('^\s*' + [regex]::Escape($var) + '\.Text = (.*);$')) { continue }
      $achado = Resolver $Matches[1]
      if ($achado.Tipo -ne 'texto') { continue }
      if ($achado.Valor -eq $campo.Nome) { continue }
      $campo.Texto = $achado.Valor
      break
    }
  }

  # 3b) as colunas das grades: o designer NAO as cria - quem as cria sao as rotinas de carga
  #     (`dg.Columns.Add("nome", "cabecalho")`), em qualquer metodo do arquivo. So entram as
  #     chamadas de duas strings resolviveis; o ajuste de largura em tempo de execucao (`Columns[0].Width`)
  #     fica de fora (nao ha como reproduzir sem os dados).
  $vistas = @{}
  foreach ($l in $linhas) {
    if ($l -notmatch '^\s*(\w+)\.Columns\.Add\((.+)\);$') { continue }
    $grade = $Matches[1]
    if (-not $tipoDe.ContainsKey($grade) -or $tipoDe[$grade] -ne 'DataGridView') { continue }
    $args = Dividir-Argumentos $Matches[2]
    if ($args.Count -ne 2) { continue }
    $nome = ResolverTexto $args[0]
    $rotulo = ResolverTexto $args[1]
    if ($null -eq $rotulo) { $rotulo = $args[1].Trim() }
    if ($nome -and $nome -match '^\{') { $nome = '' }
    # a mesma coluna aparece em varias rotinas de carga (com espacos sobrando as vezes): dedup
    $rotulo = $rotulo.Trim()
    $chave = $grade + '|' + $nome + '|' + $rotulo
    if ($vistas.ContainsKey($chave)) { continue }
    $vistas[$chave] = $true
    $ordem++
    $campos.Add(@{
      Tipo = 'Coluna'; Nome = $nome; Pai = $grade; Ordem = $ordem
      X = [int]::MinValue; Y = [int]::MinValue; L = [int]::MinValue; A = [int]::MinValue
      Texto = $rotulo; Imagem = ''; Extras = New-Object System.Collections.Generic.List[string]
      Propriedades = New-Object System.Collections.Generic.List[object]
      ColunaReal = 'Coluna (da rotina de carga)'
    })
  }

  # 4) o titulo: o designer escreve, mas o construtor sobrescreve (o caso do frmPesquisaXdatas)
  $titulo = ''
  $iCtor = [regex]::Match($txt, "(?m)^\tpublic $nomeArquivo\(")
  if ($iCtor.Success) {
    $fimCtor = $txt.IndexOf("`r`n`t}", $iCtor.Index)
    $corpoCtor = $txt.Substring($iCtor.Index, $fimCtor - $iCtor.Index)
    foreach ($l in ($corpoCtor -split "`r?`n")) { if ($l -match '^\s*Text = (.*);$') { $titulo = (Resolver $Matches[1]).Valor } }
  }
  if (-not $titulo) { foreach ($p in $propsForm) { if ($p.Nome -eq 'Text') { $titulo = $p.Valor } } }
  if (-not $titulo) { $titulo = $nomeArquivo }

  $larg = 0; $alt = 0
  foreach ($p in $propsForm) { if ($p.Nome -eq 'ClientSize') { $par = $p.Valor -split ',\s*'; $larg = [int]$par[0]; $alt = [int]$par[1] } }
  if ($larg -eq 0) { foreach ($p in $propsForm) { if ($p.Nome -eq 'Width') { $larg = [int]$p.Valor } ; if ($p.Nome -eq 'Height') { $alt = [int]$p.Valor } } }
  if ($larg -eq 0) { $larg = 300 }
  if ($alt -eq 0) { $alt = 300 }

  return @{
    Nome = $nomeArquivo; Titulo = $titulo; Largura = $larg; Altura = $alt
    Arquivo = [System.IO.Path]::GetFileName($caminho)
    LinhaIni = $linhaIni; LinhaFim = $linhaFim
    PropsForm = $propsForm; Campos = $campos
  }
}

# ---------------------------------------------------------------- todos os formularios
$formularios = New-Object System.Collections.Generic.List[object]
foreach ($f in (Get-ChildItem -Path $Reverso -Filter 'frm*.cs' | Sort-Object Name)) {
  $form = Ler-Formulario $f.FullName
  if ($form) { $formularios.Add($form) }
}

# ---------------------------------------------------------------- o mapa humano
$doc = New-Object System.Collections.Generic.List[string]
$doc.Add('# O mapa das janelas do reverso (os frm*)')
$doc.Add('')
$doc.Add('Gerado por `scripts/extrair-formularios-do-reverso.ps1` a partir do decompilado')
$doc.Add('(`cad-plugin\reverso\Eletron4_ZWcad\decompiled-cleaned`). O `.cs` guarda o metodo do designer')
$doc.Add('inteiro e o de4dot nao ofuscou os nomes de controle nem os valores das propriedades:')
$doc.Add('a formatacao das janelas esta no arquivo, nao foi perdida.')
$doc.Add('')
$doc.Add("Formularios: **$($formularios.Count)**. Controles mapeados: **$(($formularios | ForEach-Object { $_.Campos.Count } | Measure-Object -Sum).Sum)**.")
$doc.Add('')
$doc.Add('Os textos vem da `mMensagem` do original (resolvidos pelo indice) ou de literal;')
$doc.Add('os icones, do nome do recurso (`Resources.X`), extraidos em `cad-plugin/lib/Icons`.')
$doc.Add('')
$doc.Add('| formulario | titulo | client | controles | arquivo |')
$doc.Add('|---|---|---|---|---|')
foreach ($f in ($formularios | Sort-Object Nome)) {
  $doc.Add("| ``$($f.Nome)`` | $($f.Titulo) | $($f.Largura) x $($f.Altura) | $($f.Campos.Count) | ``$($f.Arquivo)`` |")
}
$doc.Add('')
$doc.Add('---')
$doc.Add('')
foreach ($f in ($formularios | Sort-Object Nome)) {
  $doc.Add('## ' + $f.Nome + ' - "' + $f.Titulo + '"')
  $doc.Add('')
  $doc.Add("Arquivo do reverso: ``$($f.Arquivo)`` (designer nas linhas $($f.LinhaIni)-$($f.LinhaFim)). ClientSize: **$($f.Largura) x $($f.Altura)**.")
  $doc.Add('')
  $doc.Add('| controle | tipo | pai | texto | x | y | l | a | icone |')
  $doc.Add('|---|---|---|---|---|---|---|---|---|')
  foreach ($c in ($f.Campos | Sort-Object Ordem)) {
    $t = $c.Texto; if ($t.Length -gt 60) { $t = $t.Substring(0, 57) + '...' }
    $tipoMostrado = if ($c.ColunaReal) { $c.ColunaReal } else { $c.Tipo }
    $doc.Add("| ``$($c.Nome)`` | $tipoMostrado | $($c.Pai) | $t | $(if ($c.X -ne [int]::MinValue) { $c.X }) | $(if ($c.Y -ne [int]::MinValue) { $c.Y }) | $(if ($c.L -ne [int]::MinValue) { $c.L }) | $(if ($c.A -ne [int]::MinValue) { $c.A }) | $($c.Imagem) |")
  }
  $doc.Add('')
}
[System.IO.File]::WriteAllLines((Join-Path (Get-Location) $Mapa), $doc)

# ---------------------------------------------------------------- a tabela compilada
$cs = New-Object System.Collections.Generic.List[string]
$cs.Add('// <auto-generated>')
$cs.Add('// GERADO por scripts/extrair-formularios-do-reverso.ps1 a partir do designer dos frm* do')
$cs.Add('// reverso (decompiled-cleaned). Nao editar a mao: rode o script.')
$cs.Add('//')
$cs.Add('// Cada `Campo` e (tipo, nome, pai, x, y, largura, altura, texto, imagem, ordem, extras).')
$cs.Add('// O que o designer nao poe sai como `Campo.NaoDefinido` (-2147483648), nao como 0: ha')
$cs.Add('// controle em coordenada negativa no original (-18, por exemplo).')
$cs.Add('// As extras vao em pares nome/valor e so trazem o que muda o visual; o resto da')
$cs.Add('// formatacao do original fica no mapa docs/reverso-formularios.txt.')
$cs.Add('// </auto-generated>')
$cs.Add('namespace Positron.Data.Interface.Mapas')
$cs.Add('{')
$cs.Add('    public static partial class FormulariosDoReverso')
$cs.Add('    {')
$cs.Add('        private static Tela[] MontarAsTelas()')
$cs.Add('        {')
$cs.Add('            return new[]')
$cs.Add('            {')
$nCampos = 0
foreach ($f in ($formularios | Sort-Object Nome)) {
  $formProps = New-Object System.Collections.Generic.List[string]
  foreach ($p in $f.PropsForm) {
    if ($p.Nome -in @('Text', 'ClientSize', 'Name', 'AutoScaleDimensions', 'AutoScaleMode', 'Width', 'Height')) { continue }
    if ($uteisJanela -contains $p.Nome) { $formProps.Add($p.Nome); $formProps.Add($p.Valor) }
  }
  $linhaProps = if ($formProps.Count -eq 0) { 'new string[0]' } else { 'new[] { ' + (($formProps | ForEach-Object { '"' + (Esc $_) + '"' }) -join ', ') + ' }' }
  $cs.Add("                new Tela(`"$(Esc $f.Nome)`", `"$(Esc $f.Titulo)`", $($f.Largura), $($f.Altura), $($f.LinhaIni),")
  $cs.Add("                    $linhaProps,")
  if ($f.Campos.Count -eq 0) {
    $cs.Add('                    new Campo[0]),')
  }
  else {
    $cs.Add('                    new[]')
    $cs.Add('                    {')
    foreach ($c in ($f.Campos | Sort-Object Ordem)) {
      $nCampos++
      $ex = ($c.Extras | ForEach-Object { '"' + (Esc $_) + '"' }) -join ', '
      $linhaEx = if ($c.Extras.Count -eq 0) { 'new string[0]' } else { 'new[] { ' + $ex + ' }' }
      $cs.Add("                        new Campo(`"$(Esc $c.Tipo)`", `"$(Esc $c.Nome)`", `"$(Esc $c.Pai)`", $($c.X), $($c.Y), $($c.L), $($c.A), `"$(Esc $c.Texto)`", `"$(Esc $c.Imagem)`", $($c.Ordem), $linhaEx),")
    }
    $cs.Add('                    }),')
  }
}
$cs.Add('            };')
$cs.Add('        }')
$cs.Add('    }')
$cs.Add('}')
[System.IO.File]::WriteAllLines((Join-Path (Get-Location) $Dados), $cs)

"formularios: $($formularios.Count)"
"campos: $nCampos"
"mapa: $(Join-Path (Get-Location) $Mapa)"
"dados: $(Join-Path (Get-Location) $Dados)"
