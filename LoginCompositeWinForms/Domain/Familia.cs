using System;
using System.Collections.Generic;
using System.Linq;

namespace LoginCompositeWinForms.Domain
{
    [Serializable]
   
    public sealed class Familia : Acceso
    {
        private readonly List<Acceso> _hijos = new List<Acceso>();

        public Familia(string nombre) : base(nombre) { }

        public void Agregar(Acceso acceso)
        {
            if (acceso == null) return;
            _hijos.Add(acceso);
        }

        public void Quitar(Acceso acceso)
        {
            if (acceso == null) return;
            _hijos.Remove(acceso);
        }

        public override IEnumerable<Patente> GetAllPatentes()
        {
            foreach (var h in _hijos)
            {
                foreach (var p in h.GetAllPatentes())
                    yield return p;
            }
        }

        public override string ToString() => $"{Nombre} ({_hijos.Count} accesos)";
    }
}
