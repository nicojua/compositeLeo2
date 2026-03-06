using System;
using System.Collections.Generic;

namespace LoginCompositeWinForms.Domain
{
    [Serializable]
  
    public sealed class Patente : Acceso
    {
        public string Codigo { get; private set; }

        public Patente(string codigo, string nombre = null) : base(nombre ?? codigo)
        {
            Codigo = codigo;
        }

        public override IEnumerable<Patente> GetAllPatentes()
        {
            yield return this;
        }

        public override string ToString() => $"{Codigo}";
    }
}
