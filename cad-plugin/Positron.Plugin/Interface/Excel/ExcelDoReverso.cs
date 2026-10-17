using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using Positron.Data.Paginas;
#if AUTOCAD
using AplicacaoDoCad = Autodesk.AutoCAD.ApplicationServices.Application;
#else
using AplicacaoDoCad = ZwSoft.ZwCAD.ApplicationServices.Application;
#endif

namespace Positron.Plugin.Interface.Excel
{
    /// <summary>
    /// As folhas **compartilhadas** das duas pontes com o Excel ativo do reverso — a dos títulos
    /// (`frmEditaTitulos`, o <c>VerificaExcelAtivo</c>) e a da estatística de cabos (o
    /// <c>frmEstatisticaDeCabos</c>, o <c>VerificaExcel</c>): o `ExcFuncoesExcel.ExcelAberto`
    /// (`:374-394`), a instância pelo CLSID `00024500-0000-0000-C000-000000000046`
    /// (`:45-51` e `:128-136`), o `AtivaCalculOExcel`/`DesativaCalculoExcel` (`:395-448`) e o
    /// `Geral.CADVersion()` (`Geral.cs:1525-1690`), que o quirk do cálculo consulta.
    ///
    /// As duas pontes diferem no que fazem com a **aba** (a ativa × a nomeada) e é aí que cada uma
    /// segue o seu caminho do original; o resto é o mesmo Excel.
    /// </summary>
    internal static class ExcelDoReverso
    {
        private const string NomeDoProcesso = "EXCEL";

        /// <summary>O CLSID do Excel (`00024500-0000-0000-C000-000000000046`, o `Activator` do original).</summary>
        private const string ClsidDoExcel = "00024500-0000-0000-C000-000000000046";

        private const string ProgIdDoExcel = "Excel.Application";

        /// <summary>
        /// O `ExcelAberto()` (`ExcFuncoesExcel.cs:374-394`): existe processo `EXCEL`? Um Excel
        /// **invisível** (sobra de automação) conta como **não aberto** — e o original o **mata**
        /// (`process.Kill()`), comportamento reproduzido aqui.
        /// </summary>
        internal static bool ExcelAberto()
        {
            bool aberto = false;
            foreach (Process processo in Process.GetProcesses())
            {
                if (!string.Equals(processo.ProcessName.ToUpperInvariant(), NomeDoProcesso, StringComparison.Ordinal))
                {
                    continue;
                }

                aberto = true;
                Application aplicacao = (Application)Marshal.GetActiveObject(ProgIdDoExcel);
                if (!aplicacao.Visible)
                {
                    aberto = false;
                    processo.Kill();
                }
            }

            return aberto;
        }

        /// <summary>Uma instância **nova** do Excel (o `Activator.CreateInstance` pelo CLSID) com um livro.</summary>
        internal static Application NovaInstancia(out Workbook livro)
        {
            Application aplicacao = (Application)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid(ClsidDoExcel)));
            livro = aplicacao.Workbooks.Add(Type.Missing);
            return aplicacao;
        }

        /// <summary>
        /// A instância **ativa** (`GetObject("Excel.Application")`), com um livro (o ativo, ou um novo
        /// quando não há nenhum) e desminimizada.
        /// </summary>
        internal static Application InstanciaAtiva(out Workbook livro)
        {
            Application aplicacao = (Application)Marshal.GetActiveObject(ProgIdDoExcel);
            livro = aplicacao.Workbooks.Count > 0
                ? aplicacao.ActiveWorkbook
                : aplicacao.Workbooks.Add(Type.Missing);
            if (aplicacao.WindowState == XlWindowState.xlMinimized)
            {
                aplicacao.WindowState = XlWindowState.xlMaximized;
            }

            return aplicacao;
        }

        /// <summary>
        /// O `DesativaCalculoExcel` (`ExcFuncoesExcel.cs:395-416`): `ScreenUpdating = false` e
        /// `Calculation = Manual` — **exceto** com a versão do CAD em `A_2025`/`A_2026`/`A_2027`, que
        /// no original chama o <see cref="AtivarCalculo"/> (o cálculo fica **ligado**).
        /// </summary>
        internal static void DesativarCalculo(Application aplicacao)
        {
            if (!ExcelDosTitulos.DesligaOCalculo(VersaoDoCad()))
            {
                AtivarCalculo(aplicacao);
                return;
            }

            try
            {
                aplicacao.ScreenUpdating = false;
                aplicacao.Calculation = XlCalculation.xlCalculationManual;
            }
            catch (Exception)
            {
                // O original engole a falha do Excel aqui (SetProjectError/ClearProjectError).
            }
        }

        /// <summary>O `AtivaCalculOExcel` (`ExcFuncoesExcel.cs:417-448`): visível e calculando.</summary>
        internal static void AtivarCalculo(Application aplicacao)
        {
            try
            {
                aplicacao.Visible = true;
                aplicacao.ScreenUpdating = true;
                aplicacao.Calculation = XlCalculation.xlCalculationAutomatic;
            }
            catch (Exception)
            {
                // idem: o original não deixa a falha sair daqui
            }
        }

        /// <summary>
        /// A versão do CAD na forma do `Geral.CADVersion()` (`Geral.cs:1525-1690`), que o quirk do
        /// cálculo consulta. No AutoCAD o `ACADVER` dá o `major.minor` (medido no AutoCAD 2020:
        /// `"23.1"`) e a tabela do original acha o ano; no ZWCAD o original usa o `VERNUM`.
        /// </summary>
        internal static string VersaoDoCad()
        {
#if AUTOCAD
            string versao = Convert.ToString(AplicacaoDoCad.GetSystemVariable("ACADVER"));
            return ExcelDosTitulos.VersaoDoCad(true, ExcelDosTitulos.AnoDoAutoCad(versao));
#else
            string versao = Convert.ToString(AplicacaoDoCad.GetSystemVariable("VERNUM"));
            int ano = 0;
            if (!string.IsNullOrEmpty(versao) && versao.Length >= 4)
            {
                int.TryParse(versao.Substring(0, 4), out ano);
            }

            return ExcelDosTitulos.VersaoDoCad(false, ano);
#endif
        }

        /// <summary>
        /// Solta os objetos COM que a ponte criou. **Desvio declarado:** o original não solta nenhum
        /// — o efeito para o usuário é o mesmo (o Excel que ele já tinha aberto continua aberto) e
        /// evita deixar um `EXCEL.EXE` órfão a cada exportação.
        /// </summary>
        internal static void Liberar(params object[] objetos)
        {
            foreach (object objeto in objetos)
            {
                try
                {
                    if (objeto != null)
                    {
                        Marshal.ReleaseComObject(objeto);
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
