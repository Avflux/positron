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
    }

    public class Xrecord : DBObject
    {
        public ResultBuffer Data { get; set; }
    }

    public class DBDictionary : DBObject
    {
        public bool Contains(string nome)
        {
            return false;
        }

        public ObjectId GetAt(string nome)
        {
            return default(ObjectId);
        }
    }

    public class SymbolTable : DBObject, IEnumerable
    {
        public bool Has(string nome)
        {
            return false;
        }

        public IEnumerator GetEnumerator()
        {
            return new List<ObjectId>().GetEnumerator();
        }
    }

    public class BlockTable : SymbolTable
    {
        public ObjectId this[string nome]
        {
            get { return default(ObjectId); }
        }
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

    public class Transaction : IDisposable
    {
        public DBObject GetObject(ObjectId id, OpenMode modo)
        {
            return null;
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

        public ObjectId LayerTableId
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
