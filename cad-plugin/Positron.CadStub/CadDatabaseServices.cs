// STUB DE COMPILAÇÃO — NÃO É A API DO ZWCAD. Ver ZwcadApi.cs para o porquê.
//
// Aqui vai a fatia de `ZwSoft.ZwCAD.DatabaseServices` que o plugin usa para
// varrer o ModelSpace atrás de LWPOLYLINE com XData: os mesmos tipos e a mesma
// forma de uso do código reverso (Transaction + BlockTable + BlockTableRecord +
// DBObject.GetXDataForApplication).

using System;
using System.Collections;
using System.Collections.Generic;
#if AUTOCAD
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
#else
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
#endif

// Os tipos de geometria vivem em `*.Geometry` na API real (é de lá que o
// código reverso os importa). O stub precisa espelhar isso: com Point2d,
// Point3d e Extents3d dentro de `*.DatabaseServices`, ele aceitava código que
// só ele compilava — e o build contra a API de verdade quebrava.
#if AUTOCAD
namespace Autodesk.AutoCAD.Geometry
#else
namespace ZwSoft.ZwCAD.Geometry
#endif
{
    public struct Point2d
    {
        public double X;
        public double Y;
    }

    public struct Point3d
    {
        public double X;
        public double Y;
        public double Z;
    }

    public struct Extents3d
    {
        public Point3d MinPoint;
        public Point3d MaxPoint;
    }
}

// `Drawable` também não é de `*.DatabaseServices`: é de `*.GraphicsInterface`
// (o código reverso importa `ZwSoft.ZwCAD.GraphicsInterface` para usá-lo).
#if AUTOCAD
namespace Autodesk.AutoCAD.GraphicsInterface
#else
namespace ZwSoft.ZwCAD.GraphicsInterface
#endif
{
    /// <summary>Base do que tem geometria; <c>Bounds</c> pode não existir (desenho vazio).</summary>
    public class Drawable : DBObject
    {
        public Extents3d? Bounds
        {
            get { return null; }
        }
    }

    /// <summary>
    /// Descritor da fonte do estilo de texto. O stub só precisa que o tipo exista e
    /// seja atribuível: o <c>CorrigeStyle</c> **copia** a fonte da referência
    /// (<c>alvo.Font = fonteReferencia</c>) e nunca nomeia um membro dela. Os campos
    /// espelham a forma da API real para quem for ler o stub não se enganar.
    /// </summary>
    public struct FontDescriptor
    {
        public string TypeFace;

        public bool Bold;

        public bool Italic;

        public int CharacterSet;

        public byte PitchAndFamily;
    }
}

#if AUTOCAD
namespace Autodesk.AutoCAD.DatabaseServices
#else
namespace ZwSoft.ZwCAD.DatabaseServices
#endif
{
    public enum OpenMode
    {
        ForRead = 0,
        ForWrite = 1,
        ForNotify = 2,
    }

    public struct ObjectId
    {
    }

    /// <summary>
    /// Handle da entidade. A API real expõe só o construtor por <c>long</c>
    /// (handles são hexadecimais convertidos): o stub segue a mesma forma, senão
    /// aceitaria código que não compila de verdade.
    /// </summary>
    public struct Handle
    {
        private readonly long _valor;

        public Handle(long valor)
        {
            _valor = valor;
        }

        public override string ToString()
        {
            return _valor.ToString("X");
        }
    }

    public class TypedValue
    {
        public TypedValue(short typeCode, object value)
        {
            TypeCode = typeCode;
            Value = value;
        }

        public TypedValue(int typeCode, object value)
        {
            TypeCode = (short)typeCode;
            Value = value;
        }

        public short TypeCode { get; private set; }

        public object Value { get; private set; }
    }

    public class ResultBuffer : IDisposable
    {
        private readonly TypedValue[] _valores;

        public ResultBuffer(TypedValue[] valores)
        {
            _valores = valores ?? new TypedValue[0];
        }

        public TypedValue[] AsArray()
        {
            return _valores;
        }

        public void Dispose()
        {
        }
    }

    public class DBObject
    {
        public Handle Handle { get; set; }

        public ResultBuffer GetXDataForApplication(string appName)
        {
            // Sem desenho de verdade não há XData: devolve null, que é o caminho
            // "sem XData" do chamador.
            return null;
        }

        public ResultBuffer XData { get; set; }

        public virtual void UpgradeOpen()
        {
        }

        /// <summary>
        /// Existe nos dois CADs (<c>DBObject.Erase()</c>) e é o que as ações de
        /// limpeza do §7.6 usam: apagar texto em branco e apagar os dicionários
        /// <c>CENG_LAYOUT</c>/<c>CENG_PLAQUETA</c>.
        /// </summary>
        public virtual void Erase()
        {
        }

        /// <summary>Volta a entidade aberta para leitura depois da escrita (<c>DBObject.DowngradeOpen()</c>).</summary>
        public void DowngradeOpen()
        {
        }
    }

    public class Entity : Drawable
    {
        public string Layer { get; set; }
    }

    public class DBPoint : Entity
    {
        public Point3d Position { get; set; }
    }

    public class Line : Entity
    {
        public Point3d StartPoint { get; set; }

        public Point3d EndPoint { get; set; }
    }

    public class Polyline : Entity
    {
        public int NumberOfVertices
        {
            get { return 0; }
        }

        public Point2d GetPoint2dAt(int indice)
        {
            return default(Point2d);
        }
    }

    /// <summary>
    /// Círculo (centro + raio). O stub só precisa da superfície que o plugin usa —
    /// os quadrantes e as extensões do símbolo de borne
    /// (<c>DeslocamentosDoDesenho</c> / <c>PontosDeLigacao</c>).
    /// </summary>
    public class Circle : Entity
    {
        public Point3d Center { get; set; }

        public double Radius { get; set; }
    }

    public class BlockReference : Entity
    {
        public Point3d Position { get; set; }

        public string Name { get; set; }

        public IEnumerable<ObjectId> AttributeCollection
        {
            get { return new List<ObjectId>(); }
        }
    }

    public class AttributeReference : Entity
    {
        public string Tag { get; set; }

        public string TextString { get; set; }

        /// <summary>Justificação horizontal do texto do atributo (o original compara com 10).</summary>
        public int Justify { get; set; }

        /// <summary>Ponto de alinhamento — usado quando <see cref="Justify"/> não é 10.</summary>
        public Point3d AlignmentPoint { get; set; }

        /// <summary>Ponto de inserção do texto.</summary>
        public Point3d Position { get; set; }

        /// <summary>Atributo invisível (o `bt14PortasDiscrepantes` usa no ramo da régua).</summary>
        public bool Invisible { get; set; }
    }

    /// <summary>
    /// Texto simples (o <c>DBText</c> da definição de porta, lida na checagem de
    /// duplicados, <c>bt12AMao</c>). O stub só precisa da superfície que o plugin
    /// usa: a identidade de objeto (handle/layer) e o XData.
    /// </summary>
    public class DBText : Entity
    {
        /// <summary>O texto do rótulo (o `IndefineCabosNaoExistentes` regrava o do cabo).</summary>
        public string TextString { get; set; }
    }

    public class Xrecord : DBObject
    {
        public ResultBuffer Data { get; set; }
    }

    /// <summary>
    /// Dicionário de objetos nomeados (o <c>NamedObjectsDictionary</c> e os que
    /// pendem dele). A API real o enumera como <c>DictionaryEntry</c> (chave =
    /// nome, valor = <c>ObjectId</c>) — é assim que o `EPLQ` percorre o
    /// <c>CENG_PLAQUETA</c>.
    /// </summary>
    public class DBDictionary : DBObject, IEnumerable
    {
        public int Count
        {
            get { return 0; }
        }

        public bool Contains(string nome)
        {
            return false;
        }

        public ObjectId GetAt(string nome)
        {
            return default(ObjectId);
        }

        public void SetAt(string nome, DBObject objeto)
        {
        }

        public IEnumerator GetEnumerator()
        {
            return new List<DictionaryEntry>().GetEnumerator();
        }
    }

    public class SymbolTableRecord : DBObject
    {
        public string Name { get; set; }
    }

    public class SymbolTable : DBObject, IEnumerable
    {
        /// <summary>
        /// Índice por nome (<c>SymbolTable[string]</c> da API real) — o
        /// <c>CorrigeDisp</c> o usa para abrir o registro e renomear o app name.
        /// </summary>
        public ObjectId this[string nome]
        {
            get { return default(ObjectId); }
        }

        public bool Has(string nome)
        {
            return false;
        }

        /// <summary>
        /// `<c>Add</c>` da API real é o do tipo concreto (BlockTable/LayerTable/
        /// RegAppTable) e é acessível pela base <c>SymbolTable</c> — é o que o
        /// código reverso usa para registrar o app name do XData.
        /// </summary>
        public void Add(SymbolTableRecord registro)
        {
        }

        public IEnumerator GetEnumerator()
        {
            return new List<ObjectId>().GetEnumerator();
        }
    }

    /// <summary>Tabela de app names do XData (o `RegAppTable` da API real).</summary>
    public class RegAppTable : SymbolTable
    {
    }

    public class RegAppTableRecord : SymbolTableRecord
    {
    }

    // O índice por nome sai da base (`SymbolTable`), como na API real — não
    // redeclarar aqui: escondia o membro herdado e o build do stub reprovava.
    public class BlockTable : SymbolTable
    {
    }

    public class BlockTableRecord : DBObject, IEnumerable
    {
        public const string ModelSpace = "*ModelSpace";

        public string Name { get; set; }

        public IEnumerator GetEnumerator()
        {
            return new List<ObjectId>().GetEnumerator();
        }
    }

    public class LayerTable : SymbolTable
    {
    }

    public class LayerTableRecord : DBObject
    {
        public string Name { get; set; }
    }

    /// <summary>Tabela de estilos de texto (o `TextStyleTable` da API real), lida pelo `CorrigeStyle`.</summary>
    public class TextStyleTable : SymbolTable
    {
    }

    /// <summary>
    /// Registro de estilo de texto. Só a fatia que o `CorrigeStyle` usa: o arquivo da
    /// fonte (`FileName`), a escala horizontal (`XScale`, o width factor do DXF 41), a
    /// altura fixa (`TextSize`, o DXF 40) e a fonte (`Font`).
    /// </summary>
    public class TextStyleTableRecord : SymbolTableRecord
    {
        public string FileName { get; set; }

        public double XScale { get; set; }

        public double TextSize { get; set; }

        public FontDescriptor Font { get; set; }
    }

    public class Transaction : IDisposable
    {
        public DBObject GetObject(ObjectId id, OpenMode modo)
        {
            return null;
        }

        public void AddNewlyCreatedDBObject(DBObject objeto, bool adicionado)
        {
        }

        public void Commit()
        {
        }

        public void Abort()
        {
        }

        public void Dispose()
        {
        }
    }

    public class TransactionManager
    {
        public Transaction StartTransaction()
        {
            return new Transaction();
        }
    }

    public class Database
    {
        public TransactionManager TransactionManager
        {
            get { return new TransactionManager(); }
        }

        public ObjectId BlockTableId
        {
            get { return default(ObjectId); }
        }

        public ObjectId NamedObjectsDictionaryId
        {
            get { return default(ObjectId); }
        }

        public ObjectId RegAppTableId
        {
            get { return default(ObjectId); }
        }

        public ObjectId LayerTableId
        {
            get { return default(ObjectId); }
        }

        public ObjectId TextStyleTableId
        {
            get { return default(ObjectId); }
        }

        /// <summary>Sem desenho de verdade todo handle é inválido — caminho "não achou" do chamador.</summary>
        public bool TryGetObjectId(Handle handle, out ObjectId id)
        {
            id = default(ObjectId);
            return false;
        }
    }
}
