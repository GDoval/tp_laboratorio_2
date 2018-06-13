using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<Paquete>
    {

        private List<Thread> mockPaquetes;
        
        public List<Paquete> Paquetes { get; set; }

        public Correo()
        { }

        public void FinEntregas()
        { }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        { return ""; }

        public static Correo operator +(Correo c, Paquete p)
        { return c; }

    }
}
