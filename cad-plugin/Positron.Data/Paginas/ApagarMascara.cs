using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// O estado de uma **máscara** no XData <c>Dispositivo</c> de tipo <c>M</c> — os campos que o
    /// <c>XDataDispositivosMaster.LeXDataQualquerDispositivo</c> lê e o <c>GravarXDataMascara</c>
    /// (<c>XDataDispositivosMaster.cs:502</c>) regrava (29 valores). Os índices de leitura são os do
    /// ramo `M` do <c>LeXDataQualquerDispositivo :740</c>.
    /// </summary>
    public sealed class EstadoDaMascara
    {
        public const string AppName = "Dispositivo";

        /// <summary>Menos que isto o registro não tem o campo +23 (o <c>iLM2</c>).</summary>
        public const int QuantidadeMinima = 24;

        public string Nome1 { get; set; }
        public string Nome2 { get; set; }
        public string Alternativo { get; set; }
        public short Painel { get; set; }
        public int IndexModelo { get; set; }
        public bool Complementar { get; set; }
        public string HandleMascPrincipal { get; set; }
        public string Topografico { get; set; }
        public string Layout { get; set; }
        public int ILM1 { get; set; }
        public int ILM2 { get; set; }

        public EstadoDaMascara Copia()
        {
            return (EstadoDaMascara)MemberwiseClone();
        }

        public static bool Ler(IReadOnlyList<TypedXData> valores, out EstadoDaMascara estado)
        {
            estado = null;
            if (valores == null || valores.Count < QuantidadeMinima
                || !string.Equals(Texto(valores[0].Valor), AppName, StringComparison.OrdinalIgnoreCase)
                || !string.Equals(Texto(valores[1].Valor), "M", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            estado = new EstadoDaMascara
            {
                Nome1 = Texto(valores[2].Valor),
                Nome2 = Texto(valores[3].Valor),
                Alternativo = Texto(valores[4].Valor),
                Painel = XDataNumero.Curto(valores[8].Valor),
                IndexModelo = XDataNumero.Inteiro(valores[12].Valor),
                Complementar = XDataNumero.Booleano(valores[13].Valor),
                HandleMascPrincipal = Texto(valores[14].Valor),
                Topografico = Texto(valores[16].Valor),
                Layout = Texto(valores[17].Valor),
                ILM1 = XDataNumero.Inteiro(valores[21].Valor),
                ILM2 = XDataNumero.Inteiro(valores[23].Valor),
            };
            return true;
        }

        /// <summary>
        /// O layout de 29 valores do <c>GravarXDataMascara</c>. <paramref name="origem"/> é o ponto
        /// (<c>1011</c>) em (0,0,0), que o CAD fornece (a Data não conhece o tipo do ponto).
        /// </summary>
        public IReadOnlyList<TypedXData> ParaValores(string usuario, string data, object origem)
        {
            return new List<TypedXData>
            {
                new TypedXData(1001, AppName),
                new TypedXData(1000, "M"),
                new TypedXData(1000, Nome1 ?? string.Empty),
                new TypedXData(1000, Nome2 ?? string.Empty),
                new TypedXData(1000, Alternativo ?? string.Empty),
                new TypedXData(1000, string.Empty),
                new TypedXData(1000, string.Empty),
                new TypedXData(1040, 0.0),
                new TypedXData(1070, Painel),
                new TypedXData(1070, (short)0),
                new TypedXData(1070, (short)0),
                new TypedXData(1000, string.Empty),
                new TypedXData(1071, IndexModelo),
                new TypedXData(1070, (short)(Complementar ? -1 : 0)),
                new TypedXData(1000, HandleMascPrincipal ?? string.Empty),
                new TypedXData(1000, string.Empty),
                new TypedXData(1000, Topografico ?? string.Empty),
                new TypedXData(1000, Layout ?? string.Empty),
                new TypedXData(1000, string.Empty),
                new TypedXData(1011, origem),
                new TypedXData(1040, 0.0),
                new TypedXData(1071, ILM1),
                new TypedXData(1070, (short)0),
                new TypedXData(1071, ILM2),
                new TypedXData(1000, usuario ?? string.Empty),
                new TypedXData(1000, data ?? string.Empty),
                new TypedXData(1040, 0.0),
                new TypedXData(1040, 0.0),
                new TypedXData(1040, 0.0),
            };
        }

        private static string Texto(object valor)
        {
            return valor == null || valor is DBNull ? string.Empty : Convert.ToString(valor);
        }
    }

    /// <summary>
    /// O XData de **porta** (<c>Dispositivo</c> de tipo <c>E</c>): o que o <c>LeXDataQualquerDispositivo</c>
    /// lê e o <c>GravarXDataPorta</c> (<c>XDataDispositivosMaster.cs:396</c>) regrava (18 valores).
    /// </summary>
    public sealed class EstadoDaPorta
    {
        public const int QuantidadeMinima = 18;

        public string Nome1 { get; set; }
        public string Nome2 { get; set; }
        public string HandleDaMascara { get; set; }
        public int IndiceDoModelo { get; set; }
        public int IndiceDaPorta { get; set; }
        public string HandleDaDefinicao { get; set; }
        public string ChavePrimaria { get; set; }
        public string Alternativo { get; set; }

        public static bool Ler(IReadOnlyList<TypedXData> valores, out EstadoDaPorta estado)
        {
            estado = null;
            if (valores == null || valores.Count < QuantidadeMinima
                || !string.Equals(Texto(valores[0].Valor), EstadoDaMascara.AppName, StringComparison.OrdinalIgnoreCase)
                || !string.Equals(Texto(valores[1].Valor), "E", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            estado = new EstadoDaPorta
            {
                Nome1 = Texto(valores[2].Valor),
                Nome2 = Texto(valores[3].Valor),
                HandleDaMascara = Texto(valores[4].Valor),
                IndiceDoModelo = XDataNumero.Inteiro(valores[5].Valor),
                IndiceDaPorta = XDataNumero.Inteiro(valores[6].Valor),
                HandleDaDefinicao = Texto(valores[9].Valor),
                ChavePrimaria = Texto(valores[10].Valor),
                Alternativo = Texto(valores[11].Valor),
            };
            return true;
        }

        public IReadOnlyList<TypedXData> ParaValores(string usuario, string data)
        {
            return new List<TypedXData>
            {
                new TypedXData(1001, EstadoDaMascara.AppName),
                new TypedXData(1000, "E"),
                new TypedXData(1000, Nome1 ?? string.Empty),
                new TypedXData(1000, Nome2 ?? string.Empty),
                new TypedXData(1000, HandleDaMascara ?? string.Empty),
                new TypedXData(1071, IndiceDoModelo),
                new TypedXData(1071, IndiceDaPorta),
                new TypedXData(1070, (short)0),
                new TypedXData(1070, (short)0),
                new TypedXData(1000, HandleDaDefinicao ?? string.Empty),
                new TypedXData(1000, ChavePrimaria ?? string.Empty),
                new TypedXData(1000, Alternativo ?? string.Empty),
                new TypedXData(1040, 0.0),
                new TypedXData(1040, 0.0),
                new TypedXData(1071, 0),
                new TypedXData(1071, 0),
                new TypedXData(1000, usuario ?? string.Empty),
                new TypedXData(1000, data ?? string.Empty),
            };
        }

        private static string Texto(object valor)
        {
            return valor == null || valor is DBNull ? string.Empty : Convert.ToString(valor);
        }
    }

    /// <summary>
    /// O XData <c>Definicao</c> de um texto de definição de porta: o <c>LerXDataDefinicao</c>
    /// (<c>XDataDispositivosMaster.cs:970</c>) e o <c>GravarXDataDefinicao</c> (<c>:903</c>, 5 valores).
    /// O app name pode ser <c>Definicao</c> ou o legado <c>DEFINICAO</c>.
    /// </summary>
    public sealed class EstadoDaDefinicao
    {
        public const string AppName = "Definicao";

        public const int QuantidadeMinima = 5;

        public string HandleDaMascara { get; set; }
        public int IndiceDoModelo { get; set; }
        public int IndiceDaPorta { get; set; }
        public string HandleDaPorta { get; set; }

        public static bool Ler(IReadOnlyList<TypedXData> valores, out EstadoDaDefinicao estado)
        {
            estado = null;
            if (valores == null || valores.Count < QuantidadeMinima
                || !string.Equals(Convert.ToString(valores[0].Valor), AppName, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            estado = new EstadoDaDefinicao
            {
                HandleDaMascara = Convert.ToString(valores[1].Valor) ?? string.Empty,
                IndiceDoModelo = XDataNumero.Inteiro(valores[2].Valor),
                IndiceDaPorta = XDataNumero.Inteiro(valores[3].Valor),
                HandleDaPorta = Convert.ToString(valores[4].Valor) ?? string.Empty,
            };
            return true;
        }

        public IReadOnlyList<TypedXData> ParaValores()
        {
            return new List<TypedXData>
            {
                new TypedXData(1001, AppName),
                new TypedXData(1000, HandleDaMascara ?? string.Empty),
                new TypedXData(1071, IndiceDoModelo),
                new TypedXData(1071, IndiceDaPorta),
                new TypedXData(1000, HandleDaPorta ?? string.Empty),
            };
        }
    }

    /// <summary>
    /// O **plano** do <c>clsMascara.ApagaAMascara</c> (<c>clsMascara.cs:1264</c>): ao apagar uma máscara,
    /// a **primeira** outra máscara com o mesmo painel, nomes e alternativo é promovida (recebe o estado
    /// da apagada) e as demais passam a apontar para ela; sem sucessora, as portas e definições da
    /// máscara saem junto. A entrada é o que o desenho tem; a saída, o que gravar.
    /// </summary>
    public static class ApagarMascara
    {
        public const string AtributoModelo = "MODELO";
        public const string AtributoFabricante = "FABRICANTE";
        public const string AtributoDescricao = "DESCRICAO";

        /// <summary>Uma máscara do desenho (bloco com `Dispositivo` tipo `M`), na ordem do ModelSpace.</summary>
        public sealed class Candidata
        {
            public string Handle { get; set; }
            public EstadoDaMascara Estado { get; set; }
            public string Modelo { get; set; }
            public string Fabricante { get; set; }
            public string Descricao { get; set; }
        }

        /// <summary>Um atributo a regravar (<c>EditaUmAtributoDeUmBloco</c>: texto e visibilidade).</summary>
        public sealed class EdicaoDeAtributo
        {
            public string Tag { get; set; }
            public string Valor { get; set; }
            public bool Visivel { get; set; }
        }

        /// <summary>A gravação numa outra máscara: o novo estado e os atributos.</summary>
        public sealed class Gravacao
        {
            public string Handle { get; set; }
            public EstadoDaMascara Estado { get; set; }
            public List<EdicaoDeAtributo> Atributos { get; } = new List<EdicaoDeAtributo>();
        }

        public sealed class Plano
        {
            /// <summary>O handle da sucessora (vazio quando não há).</summary>
            public string Sucessora { get; set; } = string.Empty;

            public List<Gravacao> Gravacoes { get; } = new List<Gravacao>();
        }

        /// <summary>
        /// O plano para a máscara <paramref name="handle"/> de estado <paramref name="mascara"/>, com os
        /// atributos dela (<paramref name="modelo"/>, <paramref name="fabricante"/>,
        /// <paramref name="descricao"/>). Máscara **complementar** não leva nada (o original retorna).
        /// </summary>
        public static Plano Planejar(
            string handle,
            EstadoDaMascara mascara,
            string modelo,
            string fabricante,
            string descricao,
            IReadOnlyList<Candidata> mascarasDoDesenho)
        {
            Plano plano = new Plano();
            if (mascara == null || mascara.Complementar || mascarasDoDesenho == null)
            {
                return null;
            }

            foreach (Candidata outra in mascarasDoDesenho)
            {
                if (outra == null || outra.Estado == null || !Casa(handle, mascara, outra))
                {
                    continue;
                }

                if (plano.Sucessora.Length != 0)
                {
                    // As demais: apontam para a sucessora e perdem LM, topográfico e layout. Os atributos
                    // vazios são testados no **bloco apagado** (`LeUmAtributoDeUmBloco(ref sHandle, ...)`
                    // do original), e o valor gravado é o dele.
                    EstadoDaMascara seguinte = outra.Estado.Copia();
                    seguinte.HandleMascPrincipal = plano.Sucessora;
                    seguinte.ILM1 = 0;
                    seguinte.ILM2 = 0;
                    seguinte.Topografico = string.Empty;
                    seguinte.Layout = string.Empty;

                    Gravacao gravacao = new Gravacao { Handle = outra.Handle, Estado = seguinte };
                    if (string.IsNullOrEmpty(modelo))
                    {
                        gravacao.Atributos.Add(new EdicaoDeAtributo { Tag = AtributoModelo, Valor = modelo ?? string.Empty, Visivel = false });
                    }

                    if (string.IsNullOrEmpty(fabricante))
                    {
                        gravacao.Atributos.Add(new EdicaoDeAtributo { Tag = AtributoFabricante, Valor = fabricante ?? string.Empty, Visivel = true });
                    }

                    if (string.IsNullOrEmpty(descricao))
                    {
                        gravacao.Atributos.Add(new EdicaoDeAtributo { Tag = AtributoDescricao, Valor = descricao ?? string.Empty, Visivel = false });
                    }

                    plano.Gravacoes.Add(gravacao);
                    continue;
                }

                // A primeira: vira a principal — recebe o estado da apagada; os atributos vazios dela
                // ganham os da apagada.
                plano.Sucessora = outra.Handle;
                Gravacao promovida = new Gravacao { Handle = outra.Handle, Estado = mascara.Copia() };
                if (string.IsNullOrEmpty(outra.Modelo))
                {
                    promovida.Atributos.Add(new EdicaoDeAtributo { Tag = AtributoModelo, Valor = modelo ?? string.Empty, Visivel = true });
                }

                if (string.IsNullOrEmpty(outra.Fabricante))
                {
                    promovida.Atributos.Add(new EdicaoDeAtributo { Tag = AtributoFabricante, Valor = fabricante ?? string.Empty, Visivel = true });
                }

                if (string.IsNullOrEmpty(outra.Descricao))
                {
                    promovida.Atributos.Add(new EdicaoDeAtributo { Tag = AtributoDescricao, Valor = descricao ?? string.Empty, Visivel = false });
                }

                plano.Gravacoes.Add(promovida);
            }

            return plano;
        }

        /// <summary>Mesmo painel, nome 1, nome 2 e alternativo (sem diferenciar caixa) e **outro** handle.</summary>
        private static bool Casa(string handle, EstadoDaMascara mascara, Candidata outra)
        {
            return mascara.Painel == outra.Estado.Painel
                && Igual(mascara.Nome1, outra.Estado.Nome1)
                && Igual(mascara.Nome2, outra.Estado.Nome2)
                && Igual(mascara.Alternativo, outra.Estado.Alternativo)
                && !Igual(handle, outra.Handle);
        }

        private static bool Igual(string a, string b)
        {
            return string.Equals(a ?? string.Empty, b ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// O que fazer com uma porta/definição que aponta para a máscara apagada: sem sucessora, apagar;
        /// com ela, apontar para ela. <c>null</c> quando a entidade não é da máscara.
        /// </summary>
        public static string NovoHandleDaMascara(string handleApontado, string handleApagada, string sucessora, out bool apagar)
        {
            apagar = false;
            if (!Igual(handleApontado, handleApagada) || string.IsNullOrEmpty(handleApagada))
            {
                return null;
            }

            if (string.IsNullOrEmpty(sucessora))
            {
                apagar = true;
                return null;
            }

            return sucessora;
        }
    }
}
