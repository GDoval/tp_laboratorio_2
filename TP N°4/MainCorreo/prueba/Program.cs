using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Entidades;
namespace prueba
{
    class Program
    {
        static void Main(string[] args)
        {
           Paquete paq = new Paquete("Calle False123", "999");
           PaqueteDAO.Insertar(paq);        
        }
    }
}
