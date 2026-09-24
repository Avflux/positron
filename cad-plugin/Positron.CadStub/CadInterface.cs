using System.Drawing;

// O build AutoCAD (Positron.CadStub) compila o mesmo código do plugin: aqui ficam os tipos de
// interface do ZWCAD (o ribbon e a paleta) como no-ops, só para o gate de compilação.
namespace ZwSoft.Windows
{
    public class RibbonControl
    {
        public System.Collections.Generic.List<RibbonTab> Tabs { get; } =
            new System.Collections.Generic.List<RibbonTab>();
    }

    public class RibbonTab
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }

        public System.Collections.Generic.List<RibbonPanel> Panels { get; } =
            new System.Collections.Generic.List<RibbonPanel>();
    }

    public class RibbonPanel
    {
        public RibbonPanelSource Source { get; set; }
    }

    public class RibbonPanelSource
    {
        public string Title { get; set; }
    }

    public class RibbonButton
    {
        public string Text { get; set; }

        public string Name { get; set; }

        public object Image { get; set; }

        public object LargeImage { get; set; }

        public object CommandHandler { get; set; }

        public string ShowText { get; set; }
    }

    public static class ComponentManager
    {
        public static RibbonControl Ribbon { get; } = new RibbonControl();
    }
}

namespace ZwSoft.ZwCAD.Windows
{
    public enum DockSides
    {
        None = 0,
        Left = 1,
        Right = 2,
        Top = 4,
        Bottom = 8,
    }

    public class PaletteSet
    {
        public PaletteSet(string titulo, string nome, System.Guid id)
        {
            Title = titulo;
            Name = nome;
            Id = id;
        }

        public string Title { get; set; }

        public string Name { get; set; }

        public System.Guid Id { get; set; }

        public bool Visible { get; set; }

        public bool KeepFocus { get; set; }

        public DockSides DockEnabled { get; set; }

        public DockSides Dock { get; set; }

        public Size MinimumSize { get; set; }

        private readonly System.Collections.Generic.List<object> _controles =
            new System.Collections.Generic.List<object>();

        public void Add(string nome, object controle)
        {
            _controles.Add(controle);
        }
    }
}
