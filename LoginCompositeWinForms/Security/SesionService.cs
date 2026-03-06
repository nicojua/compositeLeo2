using LoginCompositeWinForms.Domain;

namespace LoginCompositeWinForms.Security
{
    public static class SesionService
    {
        public static Usuario UsuarioLogueado { get; private set; }

        public static void Login(Usuario u) => UsuarioLogueado = u;
        public static void Logout() => UsuarioLogueado = null;
    }
}
