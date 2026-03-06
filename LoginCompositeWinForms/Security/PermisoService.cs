using System;
using System.Linq;
using System.Windows.Forms;
using LoginCompositeWinForms.Domain;

namespace LoginCompositeWinForms.Security
{
    public static class PermisoService
    {
        public static bool TienePermiso(Usuario usuario, string codigoPatente)
        {
            if (usuario == null || string.IsNullOrWhiteSpace(codigoPatente)) return false;

            var patentes = usuario.Accesos
                .SelectMany(a => a.GetAllPatentes())
                .Select(p => p.Codigo)
                .Distinct(StringComparer.OrdinalIgnoreCase);

            return patentes.Contains(codigoPatente, StringComparer.OrdinalIgnoreCase);
        }

      
        public static void ConfigurarMenu(MenuStrip menu, Usuario usuario)
        {
            if (menu == null) return;
            foreach (ToolStripItem item in menu.Items)
            {
                if (item is ToolStripMenuItem mi)
                    ConfigurarMenuItem(mi, usuario);
            }
        }

        private static void ConfigurarMenuItem(ToolStripMenuItem mi, Usuario usuario)
        {
            if (mi == null) return;

            if (mi.Tag is string codigo && !string.IsNullOrWhiteSpace(codigo))
            {
                mi.Enabled = TienePermiso(usuario, codigo);
                mi.Visible = mi.Enabled; 
            }

            foreach (ToolStripItem child in mi.DropDownItems)
            {
                if (child is ToolStripMenuItem childMi)
                    ConfigurarMenuItem(childMi, usuario);
            }
        }
    }
}
