using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Paquete paq = new Paquete("Calle False123", "999");
            try
            {
                PaqueteDAO.Insertar(paq);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }
            
        }
    }
}
