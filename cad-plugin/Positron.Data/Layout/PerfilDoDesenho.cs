using System;
using System.Collections.Generic;
using System.Text;

namespace Positron.Data.Layout
{
    /// <summary>Que tipo de desenho é este, pelo XData que ele carrega.</summary>
    public enum TipoDeDesenho
    {
        /// <summary>Sem XData do produto: nada a projetar.</summary>
        Desconhecido,
        /// <summary>Diagrama funcional: tem <c>CONEXAO</c>/<c>INTERLIGACAO</c> — o insumo dos comandos.</summary>
        DiagramaFuncional,

        /// <summary>Documento de interligação: tem <c>DINTERLIG</c> nos bornes (fluxo ArqNet/DI, fora do recorte).</summary>
        DocumentoInterligacao,

        /// <summary>Documento do produto (tem <c>Eletron</c>/<c>DiagLog</c>) sem os XData do diagrama.</summary>
        Documento,
    }

    /// <summary>
    /// Perfil de XData do desenho — o que o desenho **tem**, para o comando explicar
    /// por que não achou nada.
    ///
    /// Motivo: rodando `FIA` no desenho errado, a resposta era só "nenhuma LWPOLYLINE
    /// com XData CONEXAO", sem dizer o que o desenho tem. Medido com os três DWGs
    /// reais do projeto: <c>Funcional.dwg</c> é o **diagrama** (CONEXAO/INTERLIGACAO),
    /// <c>Interligação.dwg</c> é o **documento** de interligação (XData
    /// <c>DINTERLIG</c> nos bornes, fluxo ArqNet/DI) e <c>Fiação.dwg</c> é o
    /// **documento** de fiação (só <c>Eletron</c>/<c>DiagLog</c>/<c>LAYOUT</c>).
    /// </summary>
    public sealed class PerfilDoDesenho
    {
        public const string AppConexao = "CONEXAO";
        public const string AppInterligacao = "INTERLIGACAO";
        public const string AppDInterlig = "DINTERLIG";
        public const string AppEletron = "Eletron";

        private readonly Dictionary<string, int> _porApp = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        /// <summary>Quantos XData de cada app name o desenho tem.</summary>
        public IReadOnlyDictionary<string, int> PorApp
        {
            get { return _porApp; }
        }

        public void Registrar(string app)
        {
            if (string.IsNullOrWhiteSpace(app)) return;
            int quantos;
            _porApp.TryGetValue(app.Trim(), out quantos);
            _porApp[app.Trim()] = quantos + 1;
        }

        public int Quantos(string app)
        {
            int quantos;
            return _porApp.TryGetValue(app, out quantos) ? quantos : 0;
        }

        public TipoDeDesenho Veredito()
        {
            if (Quantos(AppConexao) > 0 || Quantos(AppInterligacao) > 0) return TipoDeDesenho.DiagramaFuncional;
            if (Quantos(AppDInterlig) > 0) return TipoDeDesenho.DocumentoInterligacao;
            if (_porApp.Count > 0) return TipoDeDesenho.Documento;
            return TipoDeDesenho.Desconhecido;
        }

        /// <summary>Explicação curta para o log do comando.</summary>
        public string Explicacao()
        {
            StringBuilder texto = new StringBuilder();
            texto.Append("perfil do desenho: ");
            if (_porApp.Count == 0)
            {
                texto.Append("sem XData do produto");
                return texto.ToString();
            }

            List<string> partes = new List<string>();
            foreach (KeyValuePair<string, int> par in _porApp)
            {
                partes.Add(par.Key + "=" + par.Value);
            }

            partes.Sort(StringComparer.OrdinalIgnoreCase);
            texto.Append(string.Join(", ", partes.ToArray()));
            texto.Append(" — ");

            switch (Veredito())
            {
                case TipoDeDesenho.DiagramaFuncional:
                    texto.Append("diagrama funcional");
                    break;
                case TipoDeDesenho.DocumentoInterligacao:
                    texto.Append("documento de interligação (DINTERLIG; o fluxo ArqNet/DI está fora do recorte destes comandos)");
                    break;
                case TipoDeDesenho.Documento:
                    texto.Append("documento do produto, sem os XData do diagrama (CONEXAO/INTERLIGACAO)");
                    break;
                default:
                    texto.Append("sem dados reconhecidos");
                    break;
            }

            return texto.ToString();
        }
    }
}
