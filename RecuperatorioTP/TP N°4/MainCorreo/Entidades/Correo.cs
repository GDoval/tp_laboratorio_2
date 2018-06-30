using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {

        private List<Thread> mockPaquetes;

        public List<Paquete> paquetes;

        public List<Paquete> Paquetes { get; set; }

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.Paquetes = new List<Paquete>();
        }

        public void FinEntregas()
        {
            foreach (Thread t in this.mockPaquetes)
                if (t.IsAlive)
                    t.Abort();
        }


        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paq in c.Paquetes)
            {
                if (paq == p)
                    throw new TrackingIDRepetidoException("El paquete ya se encuentra cargado en la base de datos");
            }
            try
            {
                c.Paquetes.Add(p);
                Thread hilo = new Thread(p.MockCicloDeVida);
                hilo.Start();
                c.mockPaquetes.Add(hilo);
            }
            catch (Exception e)
            {
                throw e;
            }
            return c; 
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string resp = "";
            List<Paquete> paq = ((Correo)elemento).Paquetes;
            foreach (Paquete p in paq)
            {
                resp += string.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }
            return resp;
        }
    }
}
