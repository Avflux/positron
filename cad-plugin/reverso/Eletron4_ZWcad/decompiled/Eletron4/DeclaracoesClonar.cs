using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

[StandardModule]
public sealed class DeclaracoesClonar
{
	public struct structureDispOrigem
	{
		public string ID;

		public string handleOrig;

		public string tipo;

		public string Nome1;

		public string Nome2;

		public string Alternativo;

		public int Painel;

		public string Pagina;

		public int IndexModelo;

		public int Material1;

		public int Material2;
	}

	public struct structureMaterial
	{
		public int CodigoInterno;

		public string CodigoCliente;

		public string DescricaoResumida;

		public string DescricaoCompleta;

		public string Modelo;

		public string Fabricante;
	}

	public struct structureRelesAuxiliares
	{
		public Declaracoes2.MModelosDeContatos modelo;

		public Declaracoes2.StructureContatosAuxiliares[] mContatos;
	}

	public struct structureMascaras
	{
		public Declaracoes2.MModeloDeMascara modelo;

		public Declaracoes2.MModeloDePortas[] mPortas;
	}

	public struct structureTagsUsados
	{
		public int Painel;

		public string Nome1;

		public string Nome2;

		public string Alternativo;
	}

	public struct structureRelacaoPaineis
	{
		public int iPainelOrigem;

		public string sPainelOrigem;

		public int iPainelDestino;

		public string sPainelDestino;
	}

	public struct structureRelacaoPaginas
	{
		public string pagOrigem;

		public string pagDestino;

		public double dx;

		public double dy;
	}

	public struct structureRelacaoModelosReles
	{
		public int indiceOrigem;

		public int indiceDestino;
	}

	public struct structureRelacaoModelosMascara
	{
		public int indiceOrigem;

		public int indiceDestino;
	}

	public struct structureRelacaoModelosRegua
	{
		public int indiceOrigem;

		public int indiceDestino;

		public bool bExistente;
	}

	public struct structureRelacaoMateriais
	{
		public int CodigoInternoOrigem;

		public int CodigoInternoDestino;
	}

	public struct structureRelacaoHandles
	{
		public string handleOrigem;

		public string handleDestino;
	}

	public struct structureRelacaoPotenciais
	{
		public int potencialOrigem;

		public int potencialDestino;
	}

	public struct structureTitulosPaginas
	{
		public string pagOrigem;

		public string Tit1;

		public string Tit2;

		public string Tit3;

		public string Tit4;
	}

	public struct structurePlaquetasClonar
	{
		public string pnOrig;

		public string pnDest;

		public Declaracoes2.StructurePlaquetas[] mPlaquetas;
	}

	public struct structureLayoutRapidoClonar
	{
		public string pnOrig;

		public string pnDest;

		public DeclaracoesEntidades.StructureLayout[] mLayout;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DeclaracoesClonar()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
