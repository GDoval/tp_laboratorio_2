using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using Excepciones;

namespace Doval.Gaston._2A.TP3
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p = new Persona();
            p.Dni = 90000000;
            Console.Write("\n {0}", p.Dni);
            Console.ReadLine();
        }
    }
}
