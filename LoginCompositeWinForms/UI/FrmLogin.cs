using System;
using System.Windows.Forms;
using LoginCompositeWinForms.Data;
using LoginCompositeWinForms.Security;

namespace LoginCompositeWinForms.UI
{
    public partial class FrmLogin : Form
    {
        private readonly UserRepository _repo = new UserRepository();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var user = txtUser.Text?.Trim();
            var pass = txtPass.Text ?? string.Empty;

            var u = _repo.ValidarLogin(user, pass);

            if (u == null)
            {
                MessageBox.Show("Usuario o contraseña inválidos, o usuario deshabilitado.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SesionService.Login(u);

            Hide();
            using (var frm = new FrmPrincipal())
            {
                frm.ShowDialog();
            }
            SesionService.Logout();
            Show();
            txtPass.Clear();
            txtPass.Focus();
        }

      
    }
}
