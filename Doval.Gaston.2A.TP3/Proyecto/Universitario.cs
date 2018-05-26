using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        {return "" ;}

        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario pg1, Universitario pg2)
        { return false; }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        { return false; }

        public override bool Equals(object obj)
        {
 	        return base.Equals(obj);
        }
        #endregion
    }
}
