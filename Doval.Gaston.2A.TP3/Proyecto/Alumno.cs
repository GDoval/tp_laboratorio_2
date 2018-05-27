using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #region Constructores
        public Alumno()
            :this(0,"","","0",ENacionalidad.Argentina, Universidad.EClases.Laboratorio, EEstadoCuenta.AlDia)
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Métodos


        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ToString());
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Estado de cuenta: ");
            sb.AppendLine(this._estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            string resp = "TOMA CLASE DE: " + this._claseQueToma.ToString();
            return resp;
        }
        #endregion

        #region Sobrecarga de operadores

        public static bool operator ==(Alumno e, Universidad.EClases clase)
        {
            bool resp = false;
            if (e._claseQueToma == clase && e._estadoCuenta != EEstadoCuenta.Deudor)
                resp = true;
            return resp;
        }

        public static bool operator !=(Alumno e, Universidad.EClases clase)
        {
            bool resp = false;
            if (e._claseQueToma != clase)
                resp = true;
            return resp;
        }
        #endregion
    }
}
