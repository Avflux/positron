# Relatório de Verificação de Decompilação

## Data de análise
2026-10-08

## 1. Visão geral da estrutura

| Item | Conteúdo |
|------|----------|
| Arquivo de projeto | `Eletron4Z-cleaned.csproj` |
| SDK | `Microsoft.NET.Sdk` |
| Target framework | `net472` (.NET Framework 4.7.2) |
| Plataforma | `x64` (`PlatformTarget`) |
| WinForms | `UseWindowsForms=True` |
| WPF | `UseWPF=True` |
| Versão da linguagem | `LangVersion=14.0` |
| Unsafe blocks | `AllowUnsafeBlocks=True` |
| RootNamespace | vazio (propriedade `<RootNamespace />` sem valor) |

## 2. Referências no .csproj

- `Microsoft.VisualBasic`
- `System.Data`
- `System.Data.SQLite`
- `ZwDatabaseMgd`
- `ZwManaged`
- `KeyLib`
- `ZdWindows`
- `System.Core`
- `itextsharp`

## 3. Recursos sem extensão

| Arquivo | Tipo (`file`) | LogicalName no .csproj |
|---------|---------------|--------------------------|
| `f0QEEDDabf39S0voTp.46YA9RvZWrgMIlCI9i` | data | `f0QEEDDabf39S0voTp.46YA9RvZWrgMIlCI9i` |
| `lQO5NCp2fwKETZ8xnu.tMh5WiTT3J9QauOTrX` | data | `lQO5NCp2fwKETZ8xnu.tMh5WiTT3J9QauOTrX` |
| `V9DgpHoXKSwaPCP9VK.jXfy7RGBZouLOqht38` | data | `V9DgpHoXKSwaPCP9VK.jXfy7RGBZouLOqht38` |

Conteúdo binário não textual (bytes não imprimíveis; sem assinatura de `static void Main`, `Application.Run` ou `STAThread` legível nos primeiros 2000 bytes).

## 4. Conteúdo do .csproj (extraído)

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <AssemblyName>Eletron4Z</AssemblyName>
    <GenerateAssemblyInfo>False</GenerateAssemblyInfo>
    <UseWPF>True</UseWPF>
    <UseWindowsForms>True</UseWindowsForms>
    <TargetFramework>net472</TargetFramework>
    <PlatformTarget>x64</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup>
    <LangVersion>14.0</LangVersion>
    <AllowUnsafeBlocks>True</AllowUnsafeBlocks>
    <CheckForOverflowUnderflow>False</CheckForOverflowUnderflow>
  </PropertyGroup>
  <PropertyGroup>
    <RootNamespace />
  </PropertyGroup>
  <ItemGroup>
    <None Remove="f0QEEDDabf39S0voTp.46YA9RvZWrgMIlCI9i" />
    <None Remove="V9DgpHoXKSwaPCP9VK.jXfy7RGBZouLOqht38" />
    <None Remove="lQO5NCp2fwKETZ8xnu.tMh5WiTT3J9QauOTrX" />
    <EmbeddedResource Include="f0QEEDDabf39S0voTp.46YA9RvZWrgMIlCI9i" LogicalName="f0QEEDDabf39S0voTp.46YA9RvZWrgMIlCI9i" />
    <EmbeddedResource Include="V9DgpHoXKSwaPCP9VK.jXfy7RGBZouLOqht38" LogicalName="V9DgpHoXKSwaPCP9VK.jXfy7RGBZouLOqht38" />
    <EmbeddedResource Include="lQO5NCp2fwKETZ8xnu.tMh5WiTT3J9QauOTrX" LogicalName="lQO5NCp2fwKETZ8xnu.tMh5WiTT3J9QauOTrX" />
  </ItemGroup>
  <ItemGroup>
    <Reference Include="Microsoft.VisualBasic" />
    <Reference Include="System.Data" />
    <Reference Include="System.Data.SQLite" />
    <Reference Include="ZwDatabaseMgd" />
    <Reference Include="ZwManaged" />
    <Reference Include="KeyLib" />
    <Reference Include="ZdWindows" />
    <Reference Include="System.Core" />
    <Reference Include="itextsharp" />
  </ItemGroup>
</Project>
```

## 5. Forms e recursos

| Contagem | Valor |
|----------|-------|
| `frm*.cs` totais (excluindo `obj/`) | 127 |
| `.Designer.cs` | 0 |
| `.resx` na raiz com prefixo `Eletron4.frm*.resx` | 28 |
| `Eletron4.Resources.resx` | presente na raiz |
| `frm*.resx` mapeados como stem de form | 28 |
| `frm.cs` sem `.resx` correspondente | 99 |
| `.resx` sem `.cs` correspondente | 0 (após ajuste de prefixo) |

Ressalte:
- Os 28 `Eletron4.frm*.resx` correspondem a `frm*.cs` existentes.
- 99 formulários não têm `.resx` respectivo; isso é plausível se muitos recursos estiverem embutidos no assembly original e/ou forms forem totalmente em código ou ifdefs.
- Não há `.Designer.cs` — os forms são `[DesignerGenerated]` e têm o código do designer embutido no próprio `.cs`.

## 6. Módulo

Arquivo: `-Module--09D611C0-FB7B-E958-B628-0ADDCF2E3E7D-.cs`

Conteúdo:

```csharp
internal class _003CModule_003E_007B09D611C0_002DFB7B_002DE958_002DB628_002D0ADDCF2E3E7D_007D
{
}
```

Classe interna vazia — artefato de módulo do .NET/decompilador, sem código de negócio relevante.

## 7. Void Main / entry point

- `grep -rH "static void Main" --include="*.cs"` → **nenhum resultado**.
- `grep -rH "Application.Run" --include="*.cs"` → **nenhum resultado**.
- `grep -rHnl "STAThread" --include="*.cs"` → **nenhum resultado**.
- Não há `Program.cs`, `Program.vb`, `.vbproj`, ou `App.xaml`/`App.xaml.cs`.
- Não há `.sln`/`.user`/`.suo` verificáveis na árvore informada.

## 8. Form principal e bootstrap encontrados

### `Eletron4/frmSplash.cs`
```csharp
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;

namespace Eletron4;

[DesignerGenerated]
public class frmSplash : Form
{
    private IContainer BZupKDcYxWJ;

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && BZupKDcYxWJ != null)
            {
                BZupKDcYxWJ.Dispose();
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    [DebuggerStepThrough]
    private void tV0pKdvZnaa()
    {
        SuspendLayout();
        AutoScaleDimensions = new SizeF(6f, 13f);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Blue;
        BackgroundImage = Resources.SplashEL26;
        BackgroundImageLayout = ImageLayout.Center;
        ClientSize = new Size(625, 506);
        DoubleBuffered = true;
        FormBorderStyle = FormBorderStyle.None;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "frmSplash";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterScreen;
        TopMost = true;
        TransparencyKey = Color.Blue;
        ResumeLayout(performLayout: false);
    }

    public frmSplash()
    {
        Load += QBSpKfO7uUV;
        tV0pKdvZnaa();
        Application.ShowModelessDialog((Form)this);
        if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
        {
            Left = 200;
            StartPosition = FormStartPosition.CenterScreen;
        }
    }

    private void QBSpKfO7uUV(object P_0, EventArgs P_1)
    {
    }
}
```

### `Eletron4/frmDispPrincipal.cs`
```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using YhamV21aratNE3b4GFK;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmDispPrincipal : Form
{
    private IContainer YwbEkZDUVA;
    ... (controles ofuscados)
}
```

### `Eletron4/Iniciar.cs`
Parte relevante:

```csharp
namespace Eletron4;

public class Iniciar
{
    private static EventosDB eMBpn50TGKV;

    public static void IniciarApp()
    {
        frmSplash frmSplash2 = new frmSplash();
        Application.DoEvents();
        Thread.Sleep(2000);
        try
        {
            Geral.IniciaStringCollectionAtt();
            Geral.IniciaStringCollectionBitolas();
            Ribbon ribbon = new Ribbon();
            ribbon.CreateRibbon();
            ribbon.CreateRibbon2();
            DeclaracoesGeral.lDwgRegen.Clear();
            string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\Cadgraph\Eletron4\\";
            if (!Directory.Exists(text))
            {
                Directory.CreateDirectory(text);
            }
            BinaryWriter binaryWriter = new BinaryWriter(File.Create(text + "MascaraM.dwg"));
            binaryWriter.Write(Resources.MascaraM);
            binaryWriter.Close();
            BinaryWriter binaryWriter2 = new BinaryWriter(File.Create(t
