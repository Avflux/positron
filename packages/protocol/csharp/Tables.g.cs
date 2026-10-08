// GERADO POR scripts/gen-schema.mjs a partir de db/schema.sql — NÃO EDITE.
// Rode `npm run schema:sync` para regravar; `npm run protocol:gen` falha se estiver velho.
//
// Contrato de dados do frontend ZWCAD (plugin .NET). O plugin lê/escreve estas
// tabelas direto no SQLite do projeto — o schema é a interface (docs/POSITRON.md).
//
// Classes simples (get/set), deliberadamente compatíveis com o net472/C# 7.3 do
// plugin: nada de records, init-only ou anotações de nulidade de referência (todas
// exigiriam C# 8+). Colunas de tipo-valor anuláveis viram T?; o NULL de colunas
// string/byte[] não é expresso em tipo.
//
// As classes levam o sufixo Row porque o C# proíbe um membro com o nome do tipo
// delimitador: a tabela Cabos tem uma coluna Cabos (erro CS0542).

namespace Positron.Contract
{
    /// <summary>Linha da tabela <c>Fiacao</c>.</summary>
    public sealed class FiacaoRow
    {
        public long Indice { get; set; }
        public string Revisao { get; set; }
        public long? DWG { get; set; }
        public long? Painel { get; set; }
        public long? Potencial { get; set; }
        public long? Ordem { get; set; }
        public string Pagina { get; set; }
        public string Tag { get; set; }
        public string Alternativo { get; set; }
        public string NRegua { get; set; }
        public string Terminal { get; set; }
        public double? TerminalNum { get; set; }
        public string Tipo { get; set; }
        public string Secao { get; set; }
        public string Cor { get; set; }
        public long? PosicaoNum { get; set; }
        public long? TipoBorne { get; set; }
        public bool BJumper { get; set; }
        public bool BLink { get; set; }
        public string Handle { get; set; }
        public long? IndexModelo { get; set; }
        public string Criador { get; set; }
        public System.DateTime? Data { get; set; }
        public long? Aplicacao { get; set; }
        public string Orientacao { get; set; }
    }

    /// <summary>Linha da tabela <c>Jumper4</c>.</summary>
    public sealed class Jumper4Row
    {
        public long Indice { get; set; }
        public string Revisao { get; set; }
        public long? DWG { get; set; }
        public long? Painel { get; set; }
        public long? Potencial { get; set; }
        public long? Ordem { get; set; }
        public string Pagina { get; set; }
        public string Tag { get; set; }
        public string Alternativo { get; set; }
        public string NRegua { get; set; }
        public string Terminal { get; set; }
        public double? TerminalNum { get; set; }
        public string Tipo { get; set; }
        public string Secao { get; set; }
        public string Cor { get; set; }
        public long? PosicaoNum { get; set; }
        public long? TipoBorne { get; set; }
        public bool BJumper { get; set; }
        public bool BLink { get; set; }
        public string Handle { get; set; }
        public long? IndexModelo { get; set; }
        public string Criador { get; set; }
        public System.DateTime? Data { get; set; }
    }

    /// <summary>Linha da tabela <c>Interligacao4</c>.</summary>
    public sealed class Interligacao4Row
    {
        public long Indice { get; set; }
        public string Revisao { get; set; }
        public long? DWG { get; set; }
        public string Tag_Cabo { get; set; }
        public long? Num_Veia { get; set; }
        public string Nome_Veia { get; set; }
        public long? DWG1 { get; set; }
        public string Documento1 { get; set; }
        public long? Painel1 { get; set; }
        public string Tag1 { get; set; }
        public string Alternativo1 { get; set; }
        public string NRegua1 { get; set; }
        public string Terminal1 { get; set; }
        public double? TerminalNum1 { get; set; }
        public long? TipoBorne1 { get; set; }
        public string Handle1 { get; set; }
        public string Pagina1 { get; set; }
        public string Posicao1 { get; set; }
        public long? IndexModelo1 { get; set; }
        public long? DWG2 { get; set; }
        public string Documento2 { get; set; }
        public long? Painel2 { get; set; }
        public string Tag2 { get; set; }
        public string Alternativo2 { get; set; }
        public string NRegua2 { get; set; }
        public string Terminal2 { get; set; }
        public double? TerminalNum2 { get; set; }
        public long? TipoBorne2 { get; set; }
        public string Handle2 { get; set; }
        public string Pagina2 { get; set; }
        public string Posicao2 { get; set; }
        public long? IndexModelo2 { get; set; }
        public string Criador { get; set; }
        public System.DateTime? Data { get; set; }
    }

    /// <summary>Linha da tabela <c>Bornes4F</c>.</summary>
    public sealed class Bornes4FRow
    {
        public long Indice { get; set; }
        public string Revisao { get; set; }
        public long? DWG { get; set; }
        public long? Painel { get; set; }
        public long? IndexRegua { get; set; }
        public string Regua { get; set; }
        public string Alternativo { get; set; }
        public string Handle { get; set; }
        public string Borne { get; set; }
        public double? Ordem { get; set; }
        public long? Tipo { get; set; }
        public string Pagina { get; set; }
        public bool bReserva { get; set; }
        public long? LM { get; set; }
        public string Orientacao { get; set; }
        public string BlocoLayout { get; set; }
    }

    /// <summary>Linha da tabela <c>Bornes4I</c>.</summary>
    public sealed class Bornes4IRow
    {
        public long Indice { get; set; }
        public string Revisao { get; set; }
        public long? DWG { get; set; }
        public long? Painel { get; set; }
        public long? IndexRegua { get; set; }
        public string Regua { get; set; }
        public string Alternativo { get; set; }
        public string Handle { get; set; }
        public string Borne { get; set; }
        public double? Ordem { get; set; }
        public long? Tipo { get; set; }
        public string Pagina { get; set; }
        public bool bReserva { get; set; }
    }

    /// <summary>Linha da tabela <c>Portas4F</c>.</summary>
    public sealed class Portas4FRow
    {
        public long Indice { get; set; }
        public string Revisao { get; set; }
        public long? DWG { get; set; }
        public long? IndexModelo { get; set; }
        public string NomeModelo { get; set; }
        public string Regua { get; set; }
        public string Borne { get; set; }
        public string Terminal { get; set; }
        public double? TerminalNum { get; set; }
        public string Tipo { get; set; }
        public string Orientacao { get; set; }
    }

    /// <summary>Linha da tabela <c>Portas4I</c>.</summary>
    public sealed class Portas4IRow
    {
        public long Indice { get; set; }
        public string Revisao { get; set; }
        public long? DWG { get; set; }
        public long? IndexModelo { get; set; }
        public string NomeModelo { get; set; }
        public string Regua { get; set; }
        public string Borne { get; set; }
        public string Terminal { get; set; }
        public double? TerminalNum { get; set; }
        public string Tipo { get; set; }
    }

    /// <summary>Linha da tabela <c>Contatos4F</c>.</summary>
    public sealed class Contatos4FRow
    {
        public long Indice { get; set; }
        public string Revisao { get; set; }
        public long? DWG { get; set; }
        public long? IndexModelo { get; set; }
        public string NomeModelo { get; set; }
        public string Terminal { get; set; }
        public double? TerminalNum { get; set; }
        public string Orientacao { get; set; }
    }

    /// <summary>Linha da tabela <c>Dispositivos4F</c>.</summary>
    public sealed class Dispositivos4FRow
    {
        public long Indice { get; set; }
        public string Revisao { get; set; }
        public long? DWG { get; set; }
        public long? Painel { get; set; }
        public string Tag { get; set; }
        public string Alternativo { get; set; }
        public string Tipo { get; set; }
        public string Handle { get; set; }
        public string Pagina { get; set; }
        public string BlocoTopografico { get; set; }
        public string BlocoLayout { get; set; }
        public long? PosicaoNum { get; set; }
        public long? Ordem { get; set; }
    }

    /// <summary>Linha da tabela <c>Aranha4</c>.</summary>
    public sealed class Aranha4Row
    {
        public long Indice { get; set; }
        public string Revisao { get; set; }
        public string Tag_Cabo { get; set; }
        public long? Painel { get; set; }
        public string Caderno { get; set; }
        public string Folha { get; set; }
        public long? Coluna { get; set; }
    }

    /// <summary>Linha da tabela <c>Circuitos4F</c>.</summary>
    public sealed class Circuitos4FRow
    {
        public long Indice { get; set; }
        public string Revisao { get; set; }
        public long? DWG { get; set; }
        public long? Painel { get; set; }
        public string Circuito { get; set; }
        public long? Potencial { get; set; }
    }

    /// <summary>Linha da tabela <c>Aplicacao4F</c>.</summary>
    public sealed class Aplicacao4FRow
    {
        public long Indice { get; set; }
        public string Revisao { get; set; }
        public long? DWG { get; set; }
        public long? Numero { get; set; }
        public string Nome { get; set; }
        public string Secao { get; set; }
        public string Cor { get; set; }
        public string TipoCabo { get; set; }
        public string Isolacao { get; set; }
    }

    /// <summary>Linha da tabela <c>Atributos</c>.</summary>
    public sealed class AtributosRow
    {
        public long Indice { get; set; }
        public long? DWG { get; set; }
        public string Handle { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
    }

    /// <summary>Linha da tabela <c>Exportados</c>.</summary>
    public sealed class ExportadosRow
    {
        public long Indice { get; set; }
        public long? Codigo { get; set; }
        public string Tipo { get; set; }
        public long? DWG { get; set; }
        public string Caderno { get; set; }
        public string Handle { get; set; }
        public string Pagina { get; set; }
        public string Posicao { get; set; }
        public long? Painel { get; set; }
        public string Texto { get; set; }
        public long? DWGDest { get; set; }
        public string CadernoDest { get; set; }
        public string PaginaDest { get; set; }
        public string PosicaoDest { get; set; }
        public string NomeRegua { get; set; }
        public long? IndexModelo { get; set; }
        public bool Atualizado { get; set; }
    }

    /// <summary>Linha da tabela <c>Cabos4</c>.</summary>
    public sealed class Cabos4Row
    {
        public long Indice { get; set; }
        public string Revisao { get; set; }
        public string Tag { get; set; }
        public string Formacao { get; set; }
        public bool Blindagem { get; set; }
        public long? Pn1 { get; set; }
        public long? Pn2 { get; set; }
        public string Codigo { get; set; }
        public string Funcao { get; set; }
        public long? Aterrar { get; set; }
        public double? Comprimento { get; set; }
        public string Trajeto { get; set; }
        public string Instrucao { get; set; }
        public double? Diametro { get; set; }
        public string Grupo { get; set; }
        public long? Cabos { get; set; }
        public string Criador { get; set; }
        public System.DateTime? Data { get; set; }
    }

    /// <summary>Linha da tabela <c>Veias4</c>.</summary>
    public sealed class Veias4Row
    {
        public long Indice { get; set; }
        public string Revisao { get; set; }
        public string Tag { get; set; }
        public long? Num_Veia { get; set; }
        public string Nome_Veia { get; set; }
        public bool Uso { get; set; }
        public string Funcao { get; set; }
    }

    /// <summary>Linha da tabela <c>Materiais</c>.</summary>
    public sealed class MateriaisRow
    {
        public long? CodigoInterno { get; set; }
        public string CodigoCliente { get; set; }
        public string DescricaoResumida { get; set; }
        public string DescricaoCompleta { get; set; }
        public string Modelo { get; set; }
        public string Fabricante { get; set; }
        public long Indice { get; set; }
    }

    /// <summary>Linha da tabela <c>ListaMateriais</c>.</summary>
    public sealed class ListaMateriaisRow
    {
        public long Indice { get; set; }
        public long? DWG { get; set; }
        public long? Painel { get; set; }
        public string Tag { get; set; }
        public long? IndiceMaterial { get; set; }
        public long? Quantidade { get; set; }
        public long? Ordem { get; set; }
        public bool Avulso { get; set; }
        public string Destino { get; set; }
        public string DescDestino { get; set; }
        public string Alternativo { get; set; }
        public string Handle { get; set; }
        public long? IndiceLM { get; set; }
        public long? OrdemLay { get; set; }
    }

    /// <summary>Linha da tabela <c>ModelosCabos</c>.</summary>
    public sealed class ModelosCabosRow
    {
        public long Indice { get; set; }
        public string CodigoCliente { get; set; }
        public string Descricao { get; set; }
        public string Prefixo { get; set; }
        public string Conector1 { get; set; }
        public string BlocoConector1 { get; set; }
        public string Conector2 { get; set; }
        public string BlocoConector2 { get; set; }
        public string EstiloLinha { get; set; }
        public long? CorLinha { get; set; }
        public double? PesoLinha { get; set; }
        public double? EscalaLinha { get; set; }
    }

    /// <summary>Linha da tabela <c>Cabos</c>.</summary>
    public sealed class CabosRow
    {
        public string Tag { get; set; }
        public string Formacao { get; set; }
        public bool Blindagem { get; set; }
        public long? Pn1 { get; set; }
        public long? Pn2 { get; set; }
        public string Codigo { get; set; }
        public string Funcao { get; set; }
        public long? Alarme { get; set; }
        public long? Aterrar { get; set; }
        public double? Comprimento { get; set; }
        public string Trajeto { get; set; }
        public string Instrucao { get; set; }
        public double? Diametro { get; set; }
        public string Grupo { get; set; }
        public long? Cabos { get; set; }
    }

    /// <summary>Linha da tabela <c>Veias</c>.</summary>
    public sealed class VeiasRow
    {
        public string Tag { get; set; }
        public long? Indice { get; set; }
        public string Nome_Veia { get; set; }
        public bool Uso { get; set; }
        public string Handle { get; set; }
        public long? Arquivo { get; set; }
        public string Pagina { get; set; }
        public long Chave { get; set; }
        public string Funcao { get; set; }
    }

    /// <summary>Linha da tabela <c>Paineis</c>.</summary>
    public sealed class PaineisRow
    {
        public long Indice { get; set; }
        public string Nome { get; set; }
        public string Criador { get; set; }
        public string Editor { get; set; }
        public System.DateTime? Data { get; set; }
    }

    /// <summary>Linha da tabela <c>PaineisH</c>.</summary>
    public sealed class PaineisHRow
    {
        public long? Indice { get; set; }
        public string Nome { get; set; }
        public string Criador { get; set; }
        public string Editor { get; set; }
        public System.DateTime? Data { get; set; }
    }

    /// <summary>Linha da tabela <c>Plaquetas4</c>.</summary>
    public sealed class Plaquetas4Row
    {
        public long Indice { get; set; }
        public long? DWG { get; set; }
        public long? Painel { get; set; }
        public string Tag { get; set; }
        public string Modelo { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public string Desc3 { get; set; }
        public long? Quantidade { get; set; }
    }

    /// <summary>Linha da tabela <c>DWG</c>.</summary>
    public sealed class DWGRow
    {
        public long Indice { get; set; }
        public string Tipo { get; set; }
        public string Caminho { get; set; }
        public string Nome { get; set; }
        public string Criador { get; set; }
        public string Editor { get; set; }
        public System.DateTime? Data { get; set; }
    }

    /// <summary>Linha da tabela <c>DWGH</c>.</summary>
    public sealed class DWGHRow
    {
        public long? Indice { get; set; }
        public string Tipo { get; set; }
        public string Caminho { get; set; }
        public string Nome { get; set; }
        public string Criador { get; set; }
        public string Editor { get; set; }
        public System.DateTime? Data { get; set; }
    }

    /// <summary>Linha da tabela <c>Sinais</c>.</summary>
    public sealed class SinaisRow
    {
        public long Indice { get; set; }
        public string ChavePrimaria { get; set; }
        public long? IndiceOrigem { get; set; }
        public long? IndiceDestino { get; set; }
        public long? TipoTag { get; set; }
        public string Tipo { get; set; }
        public string Tag { get; set; }
        public string Tag61850 { get; set; }
        public string Enderecos61850 { get; set; }
        public string TagAlternativoEntrada { get; set; }
        public string Descricao { get; set; }
        public string Caderno { get; set; }
        public string Vao { get; set; }
        public string Painel { get; set; }
        public string Unidade { get; set; }
        public string Pagina { get; set; }
    }

    /// <summary>Linha da tabela <c>Configuracoes</c>.</summary>
    public sealed class ConfiguracoesRow
    {
        public long? Indice { get; set; }
        public string Tipo { get; set; }
        public string Comando { get; set; }
        public string Valor { get; set; }
    }

    /// <summary>Linha da tabela <c>Preferencias</c>.</summary>
    public sealed class PreferenciasRow
    {
        public long Indice { get; set; }
        public long? DWG { get; set; }
        public long? Painel { get; set; }
        public string Campo { get; set; }
        public string Valor { get; set; }
    }

    /// <summary>Linha da tabela <c>Comandos</c>.</summary>
    public sealed class ComandosRow
    {
        public string Comando { get; set; }
        public string Usuario { get; set; }
        public long? DWG { get; set; }
    }

    /// <summary>Linha da tabela <c>Correcao</c>.</summary>
    public sealed class CorrecaoRow
    {
        public long? Numero { get; set; }
    }
}
