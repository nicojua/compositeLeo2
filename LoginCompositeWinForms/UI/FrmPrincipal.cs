using System;
using System.Windows.Forms;
using LoginCompositeWinForms.Security;

namespace LoginCompositeWinForms.UI
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            var u = SesionService.UsuarioLogueado;
            lblUsuario.Text = u != null ? $"Logueado como: {u.UserName}" : "Sin sesión";

            PermisoService.ConfigurarMenu(menuStrip1, u);
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pantalla de Usuario", "Usuarios");
        }

        private void mnuVentas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pantalla de Ventas", "Ventas");
        }
    }
}
