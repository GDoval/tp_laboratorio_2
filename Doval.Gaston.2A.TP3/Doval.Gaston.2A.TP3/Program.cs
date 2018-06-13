using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using ClasesInstanciables;

namespace Doval.Gaston._2A.TP3
{
    class Program
    {
        static void Main(string[] args)
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Gaston", "Doval", "87", Persona.ENacionalidad.Argentina, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Alumno a2 = new Alumno(2, "Juana", "Lalaala", "878787", Persona.ENacionalidad.Argentina, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Profesor p1 = new Profesor(1, "Cristian", "Bauss", "12", Persona.ENacionalidad.Argentina);
            uni += a1;
            uni += a2;
            uni += p1;
            uni += Universidad.EClases.Laboratorio;
            Console.WriteLine(uni.ToString());
            Console.ReadLine();
        }
    }
}
