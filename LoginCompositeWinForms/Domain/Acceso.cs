using System;
using System.Collections.Generic;

namespace LoginCompositeWinForms.Domain
{
    [Serializable]
   
    public abstract class Acceso
    {
        public string Nombre { get; protected set; }

        protected Acceso(string nombre)
        {
            Nombre = nombre;
        }

        public abstract IEnumerable<Patente> GetAllPatentes();
    }
}
