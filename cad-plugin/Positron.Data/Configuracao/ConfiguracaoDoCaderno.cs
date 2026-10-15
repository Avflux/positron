using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Configuracao
{
    /// <summary>
    /// A **configuração geral que mora no desenho**, no formato do reverso: o
    /// <c>DeclaracoesGeral.ConfigCaderno</c> gravado como XData do ModelSpace pelo
    /// <c>XDataGeral.GravarXDataConfiguracao</c> (app <c>Eletron</c>, marcador
    /// <c>Config</c>) e pelo <c>GravarXDataConfiguracao2</c> (app <c>EletronProj</c>,
    /// marcador <c>Projeto</c>).
    ///
    /// A tela <c>frmConfiguracaoGeral</c> do original **não grava no banco**: o
    /// <c>btSalvar</c> preenche o <c>Conf</c> e manda esses dois XData para o
    /// ModelSpace; o <c>IniciarDWG</c> relê os dois ao abrir o desenho. Aqui esta
    /// classe é a regra pura (o <c>Positron.Plugin</c> faz o I/O), para o adapter do
    /// CAD ser fino e o formato ser testável sem o ZWCAD.
    ///
    /// O buffer do <c>Config</c> é o mesmo, campo a campo, na ordem e nos códigos
    /// DXF do reverso — inclusive os campos que o recoder ainda não usa
    /// (<c>SCapa</c>, <c>Norma</c>, <c>DataSource</c>): eles são **preservados** no
    /// round-trip para o desenho do original não perder dado ao ser regravado.
    ///
    /// O layout do buffer <c>Config</c> (índice = posição no <c>ResultBuffer</c>):
    /// 0 <c>1001</c> app, 1 <c>1000</c> <c>Config</c>, 2 <c>1000</c> vazio, 3 <c>1000</c> Banco,
    /// 4 SeparadorCarimbo, 5 PrefixoCruzFF, 6 SufixoCruzFF, 7 <c>1070</c> PassoPagina,
    /// 8 Local, 9 PrefixoCruzInterno, 10 SufixoCruzInterno, 11 <c>1070</c> CorConexao,
    /// 12 CorTextoCircuito, 13 InterligacaoLayout, 14 CorInterligacao,
    /// 15 CorTextoInterligacao, 16 SeparadorCaboVeia, 17 <c>1070</c> SCapa, 18 SCorpo,
    /// 19 CCapa, 20 CCorpo, 21 maxCapa, 22 maxCorpo, 23 PrefixoCruzExterno,
    /// 24 SufixoCruzExterno, 25 CaracterTerminalIndefinido, 26 <c>1070</c> incluirColuna,
    /// 27 SeparadorPainelRegua, 28 <c>1070</c> Norma, 29 EstiloLinha,
    /// 30 SeparadorCruzamento, 31 <c>1040</c> FonteCircuito, 32 FonteCabos,
    /// 33 <c>1070</c> ModeloBobina, 34 LarguraFixaPaginas, 35 <c>1040</c> FonteCruzamento,
    /// 36 <c>1040</c> EstiloLinhaEscala, 37 DataSource, 38 BancoDeDados, 39 User, 40 Senha.
    /// </summary>
    public sealed class ConfiguracaoDoCaderno
    {
        /// <summary>O app name do XData da configuração (o <c>Eletron</c> do reverso).</summary>
        public const string AppNameConfig = "Eletron";

        /// <summary>O marcador da configuração no buffer (o segundo valor).</summary>
        public const string MarcadorConfig = "Config";

        /// <summary>O app name do XData do projeto (o <c>EletronProj</c> do reverso).</summary>
        public const string AppNameProjeto = "EletronProj";

        /// <summary>O marcador do projeto no buffer (o segundo valor).</summary>
        public const string MarcadorProjeto = "Projeto";

        /// <summary>Código do tipo de banco: <c>A</c> (Access), <c>S</c> (SQLite) ou <c>SV</c> (SQL Server).</summary>
        public const string BancoAccess = "A";

        public const string BancoSqlite = "S";

        public const string BancoSqlServer = "SV";

        // Projeto (o XData `EletronProj`/`Projeto`).
        public string DirProjeto { get; set; }

        public string DirSimbologiaEletrica { get; set; }

        public string DirSimbologiaTopografico { get; set; }

        public string DirSimbologiaLayout { get; set; }

        public string DirSimbologiaRelatorios { get; set; }

        // Configuração (o XData `Eletron`/`Config`).
        /// <summary>Tipo do banco (o <c>Conf.Banco</c> do original): <c>A</c>/<c>S</c>/<c>SV</c>.</summary>
        public string Banco { get; set; }

        public string SeparadorCarimbo { get; set; }

        public string PrefixoCruzFuncFunc { get; set; }

        public string SufixoCruzFuncFunc { get; set; }

        public int PassoPagina { get; set; }

        public string Local { get; set; }

        public string PrefixoCruzInterno { get; set; }

        public string SufixoCruzInterno { get; set; }

        public int CorConexao { get; set; }

        public int CorTextoCircuito { get; set; }

        public int InterligacaoLayout { get; set; }

        public int CorInterligacao { get; set; }

        public int CorTextoInterligacao { get; set; }

        public string SeparadorCaboVeia { get; set; }

        public bool SCapa { get; set; }

        public bool SCorpo { get; set; }

        public bool CCapa { get; set; }

        public bool CCorpo { get; set; }

        public int MaxCapa { get; set; }

        public int MaxCorpo { get; set; }

        public string PrefixoCruzExterno { get; set; }

        public string SufixoCruzExterno { get; set; }

        public string CaracterTerminalIndefinido { get; set; }

        public int IncluirColuna { get; set; }

        public string SeparadorPainelRegua { get; set; }

        public int Norma { get; set; }

        public string EstiloLinha { get; set; }

        public string SeparadorCruzamento { get; set; }

        public double FonteCircuito { get; set; }

        public double FonteCabos { get; set; }

        public int ModeloBobina { get; set; }

        public int LarguraFixaPaginas { get; set; }

        public double FonteCruzamento { get; set; }

        public double EstiloLinhaEscala { get; set; }

        public string DataSource { get; set; }

        public string BancoDeDados { get; set; }

        public string User { get; set; }

        public string Senha { get; set; }

        /// <summary>
        /// Os valores padrão do ramo em que o desenho **não** tem o XData (o <c>else</c> do
        /// <c>LerXDataConfiguracao</c> do original).
        /// </summary>
        public static ConfiguracaoDoCaderno Padrao()
        {
            return new ConfiguracaoDoCaderno
            {
                DirProjeto = string.Empty,
                DirSimbologiaEletrica = string.Empty,
                DirSimbologiaTopografico = string.Empty,
                DirSimbologiaLayout = string.Empty,
                DirSimbologiaRelatorios = string.Empty,
                Banco = BancoAccess,
                SeparadorCarimbo = "-",
                PrefixoCruzFuncFunc = "(",
                SufixoCruzFuncFunc = ")",
                PassoPagina = 1,
                Local = "???",
                PrefixoCruzInterno = "(",
                SufixoCruzInterno = ")",
                CorConexao = 7,
                CorTextoCircuito = 7,
                InterligacaoLayout = 0,
                CorInterligacao = 7,
                CorTextoInterligacao = 7,
                SeparadorCaboVeia = "/",
                SCapa = false,
                SCorpo = false,
                CCapa = false,
                CCorpo = false,
                MaxCapa = 0,
                MaxCorpo = 0,
                PrefixoCruzExterno = "[",
                SufixoCruzExterno = "]",
                CaracterTerminalIndefinido = "?",
                IncluirColuna = 1,
                SeparadorPainelRegua = "/",
                Norma = 0,
                EstiloLinha = "Continuous",
                SeparadorCruzamento = "/",
                FonteCircuito = 1.5,
                FonteCabos = 1.5,
                ModeloBobina = 0,
                LarguraFixaPaginas = 0,
                FonteCruzamento = 1.5,
                EstiloLinhaEscala = 1.0,
                DataSource = string.Empty,
                BancoDeDados = string.Empty,
                User = string.Empty,
                Senha = string.Empty,
            };
        }

        /// <summary>O código do tipo de banco do original a partir do tipo do recoder.</summary>
        public static string CodigoDoTipo(string tipo)
        {
            if (string.Equals(tipo, "SQLite", StringComparison.OrdinalIgnoreCase))
            {
                return BancoSqlite;
            }

            if (string.Equals(tipo, "SQL Server", StringComparison.OrdinalIgnoreCase))
            {
                return BancoSqlServer;
            }

            return BancoAccess;
        }

        /// <summary>O tipo do recoder a partir do código do original.</summary>
        public static string TipoDoCodigo(string codigo)
        {
            if (string.Equals(codigo, BancoSqlServer, StringComparison.OrdinalIgnoreCase))
            {
                return "SQL Server";
            }

            if (string.Equals(codigo, BancoSqlite, StringComparison.OrdinalIgnoreCase))
            {
                return "SQLite";
            }

            return "Access";
        }

        /// <summary>O caderno a partir do arquivo do plugin (só os campos que os dois têm).</summary>
        public static ConfiguracaoDoCaderno De(ConfiguracaoPositron origem)
        {
            ConfiguracaoDoCaderno caderno = Padrao();
            if (origem != null)
            {
                caderno.AplicarDe(origem);
            }

            return caderno;
        }

        /// <summary>
        /// Sobrepõe no caderno os campos que o arquivo do plugin carrega — sem tocar nos
        /// campos que só existem no desenho (o que o original gravou e o recoder ainda não usa).
        /// </summary>
        public void AplicarDe(ConfiguracaoPositron origem)
        {
            if (origem == null)
            {
                return;
            }

            DirProjeto = origem.Banco;
            DirSimbologiaEletrica = origem.SimbologiaEletrica;
            DirSimbologiaTopografico = origem.SimbologiaTopografico;
            DirSimbologiaLayout = origem.SimbologiaLayout;
            DirSimbologiaRelatorios = origem.SimbologiaRelatorios;

            Banco = CodigoDoTipo(origem.TipoBanco);
            SeparadorCarimbo = origem.SeparadorCarimbo;
            PrefixoCruzFuncFunc = origem.PrefixoCruzFuncFunc;
            SufixoCruzFuncFunc = origem.SufixoCruzFuncFunc;
            PassoPagina = origem.PassoPagina;
            Local = origem.Local;
            PrefixoCruzInterno = origem.PrefixoCruzInterno;
            SufixoCruzInterno = origem.SufixoCruzInterno;
            CorConexao = origem.CorFiacaoConexao;
            CorTextoCircuito = origem.CorFiacaoTextoCircuito;
            InterligacaoLayout = origem.InterligacaoLayout;
            CorInterligacao = origem.CorInterligacao;
            CorTextoInterligacao = origem.CorTextoInterligacao;
            SeparadorCaboVeia = origem.SeparadorCaboVeia;
            CaracterTerminalIndefinido = origem.TerminalIndefinido;
            IncluirColuna = origem.IncluirColuna;
            SeparadorPainelRegua = origem.SeparadorPainelRegua;
            EstiloLinha = origem.EstiloLinha;
            SeparadorCruzamento = origem.SeparadorCruzamento;
            FonteCircuito = origem.AlturaCircuitos;
            FonteCabos = origem.FonteCabos;
            ModeloBobina = origem.VisualizacaoModelosRele;
            LarguraFixaPaginas = origem.LarguraFixaPaginas;
            FonteCruzamento = origem.AlturaReferenciaCruzada;
            EstiloLinhaEscala = origem.EstiloLinhaEscala;
        }

        /// <summary>
        /// Escreve no arquivo do plugin os campos que o desenho carrega (o inverso do
        /// <see cref="AplicarDe"/>). Campos ausentes no desenho não apagam o que a tela deixou.
        /// </summary>
        public void AplicarEm(ConfiguracaoPositron destino)
        {
            if (destino == null)
            {
                return;
            }

            destino.Banco = Vazio(DirProjeto);
            destino.TipoBanco = TipoDoCodigo(Banco);
            destino.SimbologiaEletrica = Vazio(DirSimbologiaEletrica);
            destino.SimbologiaTopografico = Vazio(DirSimbologiaTopografico);
            destino.SimbologiaLayout = Vazio(DirSimbologiaLayout);
            destino.SimbologiaRelatorios = Vazio(DirSimbologiaRelatorios);

            destino.SeparadorCarimbo = Vazio(SeparadorCarimbo);
            destino.PrefixoCruzFuncFunc = Vazio(PrefixoCruzFuncFunc);
            destino.SufixoCruzFuncFunc = Vazio(SufixoCruzFuncFunc);
            destino.PassoPagina = PassoPagina;
            destino.Local = Vazio(Local);
            destino.PrefixoCruzInterno = Vazio(PrefixoCruzInterno);
            destino.SufixoCruzInterno = Vazio(SufixoCruzInterno);
            destino.CorFiacaoConexao = CorConexao;
            destino.CorFiacaoTextoCircuito = CorTextoCircuito;
            destino.InterligacaoLayout = InterligacaoLayout;
            destino.CorInterligacao = CorInterligacao;
            destino.CorTextoInterligacao = CorTextoInterligacao;
            destino.SeparadorCaboVeia = Vazio(SeparadorCaboVeia);
            destino.TerminalIndefinido = Vazio(CaracterTerminalIndefinido);
            destino.IncluirColuna = IncluirColuna;
            destino.SeparadorPainelRegua = Vazio(SeparadorPainelRegua);
            destino.EstiloLinha = Vazio(EstiloLinha);
            destino.SeparadorCruzamento = Vazio(SeparadorCruzamento);
            destino.AlturaCircuitos = FonteCircuito;
            destino.FonteCabos = FonteCabos;
            destino.VisualizacaoModelosRele = ModeloBobina;
            destino.LarguraFixaPaginas = LarguraFixaPaginas;
            destino.AlturaReferenciaCruzada = FonteCruzamento;
            destino.EstiloLinhaEscala = EstiloLinhaEscala;
        }

        /// <summary>O buffer <c>Eletron</c>/<c>Config</c> — o mesmo do <c>GravarXDataConfiguracao</c>.</summary>
        public IReadOnlyList<TypedXData> ParaValores()
        {
            return new List<TypedXData>(41)
            {
                new TypedXData(1001, AppNameConfig),
                new TypedXData(1000, MarcadorConfig),
                new TypedXData(1000, string.Empty),
                new TypedXData(1000, Texto(Banco)),
                new TypedXData(1000, Texto(SeparadorCarimbo)),
                new TypedXData(1000, Texto(PrefixoCruzFuncFunc)),
                new TypedXData(1000, Texto(SufixoCruzFuncFunc)),
                new TypedXData(1070, (short)PassoPagina),
                new TypedXData(1000, Texto(Local)),
                new TypedXData(1000, Texto(PrefixoCruzInterno)),
                new TypedXData(1000, Texto(SufixoCruzInterno)),
                new TypedXData(1070, (short)CorConexao),
                new TypedXData(1070, (short)CorTextoCircuito),
                new TypedXData(1070, (short)InterligacaoLayout),
                new TypedXData(1070, (short)CorInterligacao),
                new TypedXData(1070, (short)CorTextoInterligacao),
                new TypedXData(1000, Texto(SeparadorCaboVeia)),
                new TypedXData(1070, SCapa),
                new TypedXData(1070, SCorpo),
                new TypedXData(1070, CCapa),
                new TypedXData(1070, CCorpo),
                new TypedXData(1070, (short)MaxCapa),
                new TypedXData(1070, (short)MaxCorpo),
                new TypedXData(1000, Texto(PrefixoCruzExterno)),
                new TypedXData(1000, Texto(SufixoCruzExterno)),
                new TypedXData(1000, Texto(CaracterTerminalIndefinido)),
                new TypedXData(1070, (short)IncluirColuna),
                new TypedXData(1000, Texto(SeparadorPainelRegua)),
                new TypedXData(1070, (short)Norma),
                new TypedXData(1000, Texto(EstiloLinha)),
                new TypedXData(1000, Texto(SeparadorCruzamento)),
                new TypedXData(1040, FonteCircuito),
                new TypedXData(1040, FonteCabos),
                new TypedXData(1070, (short)ModeloBobina),
                new TypedXData(1070, (short)LarguraFixaPaginas),
                new TypedXData(1040, FonteCruzamento),
                new TypedXData(1040, EstiloLinhaEscala),
                new TypedXData(1000, Texto(DataSource)),
                new TypedXData(1000, Texto(BancoDeDados)),
                new TypedXData(1000, Texto(User)),
                new TypedXData(1000, Texto(Senha)),
            };
        }

        /// <summary>O buffer <c>EletronProj</c>/<c>Projeto</c> — o mesmo do <c>GravarXDataConfiguracao2</c>.</summary>
        public IReadOnlyList<TypedXData> ParaValoresProjeto()
        {
            return new List<TypedXData>(8)
            {
                new TypedXData(1001, AppNameProjeto),
                new TypedXData(1000, MarcadorProjeto),
                new TypedXData(1000, Texto(DirProjeto)),
                new TypedXData(1000, Texto(DirSimbologiaEletrica)),
                new TypedXData(1000, Texto(DirSimbologiaRelatorios)),
                new TypedXData(1000, Texto(DirSimbologiaTopografico)),
                new TypedXData(1000, string.Empty),
                new TypedXData(1000, Texto(DirSimbologiaLayout)),
            };
        }

        /// <summary>
        /// Lê o caderno do buffer <c>Config</c>, com a tolerância do <c>LerXDataConfiguracao</c>
        /// do original. Devolve <c>null</c> quando o buffer não é o nosso (app/marcador
        /// diferentes) — o comando segue com o padrão.
        /// </summary>
        public static ConfiguracaoDoCaderno Ler(IReadOnlyList<TypedXData> valores)
        {
            if (!TemMarcador(valores, AppNameConfig, MarcadorConfig) || valores.Count < 41)
            {
                return null;
            }

            ConfiguracaoDoCaderno caderno = Padrao();

            caderno.Banco = Vazio(Texto(valores[3])) ?? BancoAccess;
            caderno.SeparadorCarimbo = Vazio(Texto(valores[4])) ?? "-";
            caderno.PrefixoCruzFuncFunc = Texto(valores[5]);
            caderno.SufixoCruzFuncFunc = Texto(valores[6]);
            caderno.PassoPagina = XDataNumero.Inteiro(valores[7].Valor);
            caderno.Local = Texto(valores[8]);
            caderno.PrefixoCruzInterno = Texto(valores[9]);
            caderno.SufixoCruzInterno = Texto(valores[10]);
            caderno.CorConexao = XDataNumero.Inteiro(valores[11].Valor);
            caderno.CorTextoCircuito = XDataNumero.Inteiro(valores[12].Valor);
            caderno.InterligacaoLayout = XDataNumero.Inteiro(valores[13].Valor);
            caderno.CorInterligacao = XDataNumero.Inteiro(valores[14].Valor);
            caderno.CorTextoInterligacao = XDataNumero.Inteiro(valores[15].Valor);
            caderno.SeparadorCaboVeia = Texto(valores[16]);
            caderno.SCapa = XDataNumero.Booleano(valores[17].Valor);
            caderno.SCorpo = XDataNumero.Booleano(valores[18].Valor);
            caderno.CCapa = XDataNumero.Booleano(valores[19].Valor);
            caderno.CCorpo = XDataNumero.Booleano(valores[20].Valor);
            caderno.MaxCapa = XDataNumero.Inteiro(valores[21].Valor);
            caderno.MaxCorpo = XDataNumero.Inteiro(valores[22].Valor);
            caderno.PrefixoCruzExterno = Texto(valores[23]);
            caderno.SufixoCruzExterno = Texto(valores[24]);
            caderno.CaracterTerminalIndefinido = Texto(valores[25]);
            caderno.IncluirColuna = XDataNumero.Inteiro(valores[26].Valor);
            caderno.SeparadorPainelRegua = Texto(valores[27]);
            caderno.Norma = XDataNumero.Inteiro(valores[28].Valor);
            caderno.EstiloLinha = Vazio(Texto(valores[29])) ?? "Continuous";
            caderno.SeparadorCruzamento = Texto(valores[30]);
            caderno.FonteCircuito = XDataNumero.Real(valores[31].Valor);
            caderno.FonteCabos = XDataNumero.Real(valores[32].Valor);
            caderno.ModeloBobina = XDataNumero.Inteiro(valores[33].Valor);
            caderno.LarguraFixaPaginas = XDataNumero.Inteiro(valores[34].Valor);
            caderno.FonteCruzamento = XDataNumero.Real(valores[35].Valor);
            caderno.EstiloLinhaEscala = XDataNumero.Real(valores[36].Valor);
            caderno.DataSource = TextoNumerico(valores[37]);
            caderno.BancoDeDados = TextoNumerico(valores[38]);
            caderno.User = TextoNumerico(valores[39]);
            caderno.Senha = EhNumeroZero(valores[40]) ? string.Empty : Texto(valores[40]);

            // As guardas do original.
            if (caderno.EstiloLinhaEscala == 0.0)
            {
                caderno.EstiloLinhaEscala = 1.0;
            }

            if (caderno.FonteCruzamento == 0.0)
            {
                caderno.FonteCruzamento = caderno.FonteCircuito;
            }

            if (string.Equals((caderno.SeparadorPainelRegua ?? string.Empty).Trim(), string.Empty, StringComparison.Ordinal))
            {
                caderno.SeparadorPainelRegua = "/";
            }
            else if (string.Equals(caderno.SeparadorPainelRegua.Trim(), "1", StringComparison.Ordinal))
            {
                caderno.SeparadorPainelRegua = "/";
            }

            if (string.Equals((caderno.SeparadorCruzamento ?? string.Empty).Trim(), string.Empty, StringComparison.Ordinal))
            {
                caderno.SeparadorCruzamento = "/";
            }

            return caderno;
        }

        /// <summary>
        /// Lê as pastas do buffer <c>Projeto</c>. Devolve <c>null</c> quando o buffer não é o
        /// nosso — as pastas ficam as do <paramref name="base"/>.
        /// </summary>
        public static ConfiguracaoDoCaderno LerProjeto(IReadOnlyList<TypedXData> valores, ConfiguracaoDoCaderno baseCaderno)
        {
            if (!TemMarcador(valores, AppNameProjeto, MarcadorProjeto) || valores.Count < 8)
            {
                return null;
            }

            ConfiguracaoDoCaderno caderno = baseCaderno ?? Padrao();
            caderno.DirProjeto = Texto(valores[2]);
            caderno.DirSimbologiaEletrica = Texto(valores[3]);
            caderno.DirSimbologiaRelatorios = Texto(valores[4]);
            caderno.DirSimbologiaTopografico = Texto(valores[5]);
            caderno.DirSimbologiaLayout = Texto(valores[7]);
            return caderno;
        }

        /// <summary>O buffer tem o app name e o marcador pedidos (os dois primeiros valores).</summary>
        private static bool TemMarcador(IReadOnlyList<TypedXData> valores, string appName, string marcador)
        {
            if (valores == null || valores.Count < 2)
            {
                return false;
            }

            return string.Equals(Convert.ToString(valores[0].Valor), appName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(Convert.ToString(valores[1].Valor), marcador, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>O valor como string, ou vazio quando nulo.</summary>
        private static string Texto(TypedXData valor)
        {
            return Texto(valor.Valor);
        }

        private static string Texto(object valor)
        {
            return valor == null || valor is DBNull ? string.Empty : Convert.ToString(valor) ?? string.Empty;
        }

        /// <summary>
        /// Os campos `DataSource`/`BancoDeDados`/`User` do original guardam um valor
        /// **numérico** (o vbNullString que vira 0) que significa "vazio".
        /// </summary>
        private static string TextoNumerico(TypedXData valor)
        {
            return EhNumeroZero(valor) ? string.Empty : Texto(valor);
        }

        private static bool EhNumeroZero(TypedXData valor)
        {
            object bruto = valor.Valor;
            if (bruto == null || bruto is DBNull)
            {
                return true;
            }

            string texto = Convert.ToString(bruto);
            if (string.IsNullOrEmpty(texto))
            {
                return true;
            }

            double numero;
            return double.TryParse(texto.Trim(), System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture, out numero) && numero == 0.0;
        }

        private static string Vazio(string valor)
        {
            return string.IsNullOrEmpty(valor) ? null : valor;
        }
    }
}
