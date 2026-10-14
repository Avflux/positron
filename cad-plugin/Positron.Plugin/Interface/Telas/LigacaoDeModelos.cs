using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Materiais;
using Positron.Data.Modelos;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// Base comum para as **duas telas de gerenciamento de modelos** do original:
    /// <c>frmGerenciadorMascaras</c> (<c>GERMASC</c>) e <c>frmGerenciadorContatos</c> (<c>GERCONT</c>).
    ///
    /// As duas compartilham o mesmo layout de detalhe do modelo:
    /// - <c>GroupBox4</c> ("Materiais"): os slots LM1 e LM2 resolvidos contra o catálogo <c>Materiais</c>
    ///   do banco do projeto (<c>tbCodigo*</c>, <c>tbDescricaoResum*</c>, <c>tbModelo*</c>, <c>tbFabricante*</c>);
    /// - <c>GroupBox3</c> ("Simbologia"): os blocos topográfico e de layout (<c>tbBlocoTopografico</c>, <c>tbBlocoLayout</c>);
    /// - <c>GroupBox2</c> ("Modelo"): o nome do modelo (<c>TBModelo</c>);
    /// - desativação sistemática de botões de edição, gravação e interop do Excel com motivo explicativo na dica.
    /// </summary>
    internal abstract class LigacaoDeModelos : ILigacaoDeTela
    {
        private static ToolTip _dicas;

        public abstract string NomeDaTela { get; }

        public abstract void Preencher(Form janela);

        /// <summary>Lê o catálogo de materiais do banco do projeto.</summary>
        protected static List<MaterialDoCatalogo> Catalogo(ConfiguracaoPositron config)
        {
            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return new List<MaterialDoCatalogo>();
            }

            try
            {
                return new ProjectStore(config.Banco).LerMateriais();
            }
            catch (Exception erro)
            {
                Plugin.Escrever("MODELOS: o catálogo não veio do banco — " + erro.Message);
                return new List<MaterialDoCatalogo>();
            }
        }

        /// <summary>Indexa o catálogo pelo código interno para consulta rápida.</summary>
        protected static Dictionary<int, MaterialDoCatalogo> CatalogoIndexado(List<MaterialDoCatalogo> lista)
        {
            Dictionary<int, MaterialDoCatalogo> dic = new Dictionary<int, MaterialDoCatalogo>();
            if (lista == null)
            {
                return dic;
            }

            foreach (MaterialDoCatalogo mat in lista)
            {
                dic[mat.CodigoInterno] = mat;
            }

            return dic;
        }

        /// <summary>
        /// Preenche as quatro caixas de um slot de material (1 ou 2) consultando o catálogo.
        /// </summary>
        protected static void PreencherMaterial(
            Form janela,
            int codigo,
            int slot,
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo)
        {
            FormatacaoDeModelos.DetalheDoMaterial det = FormatacaoDeModelos.ResolverMaterial(codigo, catalogo);
            string sSlot = slot.ToString();
            TextoDaCaixa(janela, "tbCodigo" + sSlot, det.Codigo);
            TextoDaCaixa(janela, "tbDescricaoResum" + sSlot, det.Descricao);
            TextoDaCaixa(janela, "tbModelo" + sSlot, det.Modelo);
            TextoDaCaixa(janela, "tbFabricante" + sSlot, det.Fabricante);
        }

        /// <summary>Altera o texto de um controle pelo nome.</summary>
        protected static void Texto(Form janela, string nome, string texto)
        {
            Control controle = ControlesDaTela.Procurar(janela, nome);
            if (controle != null)
            {
                controle.Text = texto;
            }
        }

        /// <summary>Altera o texto de um TextBox pelo nome.</summary>
        protected static void TextoDaCaixa(Form janela, string nome, string valor)
        {
            TextBox caixa = ControlesDaTela.Achar<TextBox>(janela, nome);
            if (caixa != null)
            {
                caixa.Text = valor ?? string.Empty;
            }
        }

        /// <summary>Define a dica de um controle.</summary>
        protected static void Dica(Form janela, string nome, string dica)
        {
            Control controle = ControlesDaTela.Procurar(janela, nome);
            if (controle == null)
            {
                return;
            }

            if (_dicas == null)
            {
                _dicas = new ToolTip();
            }

            _dicas.SetToolTip(controle, dica);
        }

        /// <summary>Desabilita o controle com o motivo na dica e no Tag.</summary>
        protected static void Desabilitar(Form janela, string nome, string motivo)
        {
            Control controle = ControlesDaTela.Procurar(janela, nome);
            if (controle == null)
            {
                return;
            }

            controle.Enabled = false;
            controle.Tag = motivo;
            Dica(janela, nome, motivo);
        }
    }
}
