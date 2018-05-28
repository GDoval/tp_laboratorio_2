using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #region Constructores
        private Jornada()
        {
            this.Alumnos= new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion


        #region Propiedades
        public List<Alumno> Alumnos { get { return this._alumnos; } set { this._alumnos = value; } }
        public Universidad.EClases Clase { get { return this._clase; } set { this._clase = value; } }
        public Profesor Instructor { get { return this._instructor; } set { this._instructor = value; } }
        #endregion


        #region Métodos
        public bool Guardar(Jornada jornada)
        {
            return false; 
        }

        public string Leer()
        { return ""; }


        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("PROFESOR: ");
            sb.AppendLine(this.Instructor.ToString());
            sb.Append("CLASE: ");
            sb.AppendLine(this.Clase.ToString());
            foreach (Alumno a in this.Alumnos)
            {
                sb.Append("ALUMNO: ");
                sb.AppendLine(a.ToString());
            }
            return sb.ToString();
        }
        #endregion


        #region Sobrecarga de Operadores
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool resp = false;
            foreach (Alumno al in j.Alumnos)
            {
                if (al == a)
                {
                    resp = true;
                    break;
                }
            }
            return resp;
        }

        public static bool operator !=(Jornada j, Alumno a)
        { return !(j == a); }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
            {
                return j;
            }
            else
                j.Alumnos.Add(a);
            return j;
        }
        #endregion

    }

}
