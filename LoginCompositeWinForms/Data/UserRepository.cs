using System;
using System.Collections.Generic;
using System.Linq;
using LoginCompositeWinForms.Domain;

namespace LoginCompositeWinForms.Data
{
    
    /*public sealed class UserRepository
    {
        private readonly List<Usuario> _usuarios = new List<Usuario>();

        public UserRepository()
        {
            Seed();
        }

        private void Seed()
        {
            // Patentes (permisos atómicos)
            var pUsuarios = new Patente("USUARIOS", "Gestión de usuarios");
            var pVentas   = new Patente("VENTAS", "Gestión de ventas");

            // Familias (roles)
            var rolAdmin = new Familia("ADMIN");
            rolAdmin.Agregar(pUsuarios);
            rolAdmin.Agregar(pVentas);

            var rolVendedor = new Familia("VENDEDOR");
            rolVendedor.Agregar(pVentas);

            // Usuarios (2 usuarios)
            var guido = new Usuario
            {
                IdUsuario = Guid.Parse("C08299F2-A818-49EE-831D-1D0335C94052"),
                UserName = "Guido",
                Password = "1234",
                Estado = 1
            };
            guido.Accesos.Add(rolAdmin);

            var moor = new Usuario
            {
                IdUsuario = Guid.NewGuid(),
                UserName = "Moor",
                Password = "1234",
                Estado = 1
            };
            moor.Accesos.Add(rolVendedor);

            _usuarios.Add(guido);
            _usuarios.Add(moor);
        }

        public Usuario ValidarLogin(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return null;

            var u = _usuarios.FirstOrDefault(x =>
                x.Estado == 1 &&
                string.Equals(x.UserName, userName, StringComparison.OrdinalIgnoreCase) &&
                x.Password == password);

            return u;
        }
    }*/

    public sealed class UserRepository
    {
        private List<Usuario> _usuarios;

        public UserRepository()
        {
            _usuarios = DataStore.CargarUsuarios();

            if (_usuarios.Count == 0)
            {
                Seed();
                DataStore.GuardarUsuarios(_usuarios);
            }
        }

        private void Seed()
        {
           
            var pUsuarios = new Patente("USUARIOS", "Gestión de usuarios");
            var pVentas = new Patente("VENTAS", "Gestión de ventas");

            
            var rolAdmin = new Familia("ADMIN");
            rolAdmin.Agregar(pUsuarios);
            rolAdmin.Agregar(pVentas);

            var rolVendedor = new Familia("VENDEDOR");
            rolVendedor.Agregar(pVentas);

         
            var guido = new Usuario
            {
                IdUsuario = Guid.Parse("C08299F2-A818-49EE-831D-1D0335C94052"),
                UserName = "LeonardoADM",
                Password = "1234",
                Estado = 1
            };

            guido.Accesos.Add(rolAdmin);

            var moor = new Usuario
            {
                IdUsuario = Guid.NewGuid(),
                UserName = "LeonardoVEN",
                Password = "1234",
                Estado = 1
            };

            moor.Accesos.Add(rolVendedor);

            _usuarios.Add(guido);
            _usuarios.Add(moor);
        }

        public Usuario ValidarLogin(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return null;

            return _usuarios.FirstOrDefault(x =>
                x.Estado == 1 &&
                string.Equals(x.UserName, userName, StringComparison.OrdinalIgnoreCase) &&
                x.Password == password);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _usuarios;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
            DataStore.GuardarUsuarios(_usuarios);
        }

        public void Guardar()
        {
            DataStore.GuardarUsuarios(_usuarios);
        }
    }
}
