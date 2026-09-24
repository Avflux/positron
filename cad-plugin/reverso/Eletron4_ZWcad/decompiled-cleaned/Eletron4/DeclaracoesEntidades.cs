using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

[StandardModule]
public sealed class DeclaracoesEntidades
{
	public struct StructureDispositivo
	{
		public string Handle;

		public string Nome1;

		public string Nome2;

		public string Alternativo;

		public short Painel;

		public string ChavePrimaria;

		public int indexModelo;

		public string Modelo;

		public double dAlturaModelo;

		public bool Complementar;

		public double posX;

		public double posY;

		public int iLM1;

		public int iLM2;

		public short tipoContatoAux;

		public double distContAux;

		public bool NomeVisivel;

		public bool AlternativoVisivel;

		public string Topografico;

		public string Layout;

		public string Usuario;

		public string Data;
	}

	public struct StructureAuxiliar
	{
		public string Nome1;

		public string Nome2;

		public string Alternativo;

		public string HandleBob;

		public int IndexModelo;

		public int IndexContato;

		public short TipoDoContato;

		public short TipoDoComportamento;

		public string Usuario;

		public string Data;
	}

	public struct StructurePortas
	{
		public string Tipo;

		public string Nome1;

		public string Nome2;

		public string Alternativo;

		public string HandleDaMascara;

		public int indiceDoModelo;

		public int indiceDaPorta;

		public string handleDaDefinicao;

		public string chavePrimaria;

		public string HandleBloco;

		public string Usuario;

		public string Data;
	}

	public struct StructureDefinicaoPortas
	{
		public string Nome;

		public string HandleDaMascara;

		public int indiceDoModelo;

		public int indiceDaPorta;

		public string handleDaPorta;
	}

	public struct StructureMascara
	{
		public string Nome1;

		public string Nome2;

		public string Modelo;

		public string Fabricante;

		public string Descricao;

		public string Alternativo;

		public short Painel;

		public int indexModelo;

		public bool Complementar;

		public string HandleMascPrincipal;

		public string Topografico;

		public string Layout;

		public string Plaquetas;

		public int iLM1;

		public int iLM2;

		public string Usuario;

		public string Data;
	}

	public struct StructureBorne
	{
		public string Numero;

		public string NumeroComplem;

		public string Alternativo;

		public double Ordem;

		public int IndiceRegua;

		public string NomeRegua;

		public int indexPainel;

		public string NomePainel;

		public string conector;

		public int tipo;

		public int Visivel;

		public int lm;

		public bool reserva;

		public string pagina;

		public string Handle;

		public string user;

		public string data;

		public long Potencial;

		public string CaboOrigem;

		public int VeiaOrigem;

		public string sPagina;

		public int iLinha;

		public int iColuna;

		public bool bPnApagado;

		public string Orientacao;

		public string BlocoLayout;

		public string PosInt_Jumper;
	}

	public struct StructureConexao
	{
		public short Tipo;

		public int Potencial;

		public string Handle;

		public short Painel;

		public int Aplicacao;

		public string Pagina;

		public string Nome;

		public string Funcao;

		public string Tensao;

		public string Secao;

		public string Cor;

		public bool Disp1;

		public bool Disp2;

		public string Jumper;

		public int Enderecamento;

		public string Usuario;

		public string Data;
	}

	public struct StructureInterligacao
	{
		public short Tipo;

		public string handle;

		public string Handle1;

		public string Handle2;

		public string THandle1;

		public string THandle2;

		public string Tag_Cabo;

		public int NumVeia;

		public string NomeVeia;

		public int iModeloVeiaFuncao;

		public short Painel1;

		public short Painel2;

		public int ocultaTag;

		public double X;

		public double Y;

		public string Usuario;

		public string Data;
	}

	public struct StructureLayout
	{
		public string Tag;

		public string Alternativo;

		public double X;

		public double Y;
	}

	public struct StructureExportar
	{
		public int indice;

		public int Codigo;

		public string Tipo;

		public int DWG;

		public string Caderno;

		public string Handle;

		public string Pagina;

		public string posicao;

		public int Painel;

		public string Texto;

		public int DWGDest;

		public string CadernoDest;

		public string PaginaDest;

		public string PosicaoDest;

		public string NomeRegua;

		public int indexModelo;

		public bool Atualizado;

		public string nomePainel;

		public string tag;

		public string numero;

		public string efc;
	}
}
