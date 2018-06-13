using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades

        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }
        public List<Jornada> Jornada { get { return this.jornada; } set { this.jornada = value; } }
        public List<Profesor> Profesores { get { return this.profesores; } set { this.profesores = value; } }
       // public this[int i] Jornada {get; set;} ???
        #endregion

        #region Constructores
        public Universidad()
        {
            this.Profesores = new List<Profesor>();
            this.Jornada = new List<Jornada>();
            this.Alumnos = new List<Alumno>();
        }
        #endregion

        #region Métodos

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada j in this.Jornada)
            {
                sb.AppendLine(j.ToString());
            }
            return sb.ToString();
        }

        public bool Guardar(Universidad gim)
        { return false; }

        private string MostrarDatos(Universidad gim)
        { return ""; }

        #endregion

        #region Sobrecarga de Operadores

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool resp = true;
            foreach (Alumno al in g.Alumnos)
            {
                if (al == a)
                {
                    resp = false;
                    break;
                }
            }
            return resp;
        }

        public static bool operator !=(Universidad g, Alumno a)
        { return !(g == a); }

        /*public static Profesor operator ==(Universidad g, EClases clase)
        { return Profesor Jor = new Profesor(); }

        public static bool operator !=(Universidad g, EClases clase)
        { return !(g == clase); }*/

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool resp = true;
            foreach (Profesor p in g.Profesores)
            {
                if (p == i)
                {
                    resp = false;
                    break;
                }
            }
            return resp;
        }

        public static bool operator !=(Universidad g, Profesor i)
        { return !(g == i); }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g == a)
                g.Alumnos.Add(a);
            return g;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor disponible = new Profesor();
            foreach (Profesor p in g.Profesores)
            {
                if (p == clase)
                {
                    disponible = p;
                    break;
                }
            }
            Jornada nuevaJornada = new Jornada(clase, disponible);
            List<Alumno> buffer = new List<Alumno>();
            foreach (Alumno a in g.Alumnos)
            {
                if (a == clase)
                    buffer.Add(a);
            }
            nuevaJornada.Alumnos = buffer;
            g.Jornada.Add(nuevaJornada);
            return g; 
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g == i)
                g.Profesores.Add(i);
            return g; 
        }
        #endregion
    }
}
