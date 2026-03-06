using System;
using System.Collections.Generic;

namespace LoginCompositeWinForms.Domain
{
    [Serializable]
    public sealed class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string UserName { get; set; }
       
        public string Password { get; set; }
        public int Estado { get; set; } 

        public List<Acceso> Accesos { get; } = new List<Acceso>();

        public override string ToString() => $"{UserName} ({IdUsuario})";
    }
}
