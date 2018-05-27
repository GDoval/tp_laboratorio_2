using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesInstanciables;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        #region Constructores
        public Universitario()
            :this(0,"","","0",ENacionalidad.Argentina)
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }
        #endregion 

        #region Metodos y Sobrecargas


        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("LEGAJO: ");
            sb.AppendLine(Convert.ToString(this._legajo));
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool valida = pg1.Equals(pg2), resp = false;
            if (valida)
            {
                if (pg1.Dni == pg2.Dni || pg1._legajo == pg2._legajo)
                    resp = true;
            }
            return resp; 
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        { return false; }

        public override bool Equals(object obj)
        {
 	        bool resp = false;
            if (obj is Alumno && this is Alumno)
                resp = true;
            else if (obj is Profesor && this is Profesor)
                resp = true;
            return resp;
        }
        #endregion
    }
}
