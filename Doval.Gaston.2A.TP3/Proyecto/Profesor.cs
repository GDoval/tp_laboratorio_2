using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace ClasesInstanciables
{
    public sealed class Profesor :Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random random;

        #region Constructores
        public Profesor()
            :this(0,"","","0",ENacionalidad.Argentina)
        {
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            Profesor.random = new Random();
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
        }
        #endregion

        #region Métodos
        private void _randomClase()
        {
            Universidad.EClases[] array = (Universidad.EClases[])Enum.GetValues(typeof(Universidad.EClases));
            int num;
            for(int i = 0; i < 2; i++)
            {
                num = Profesor.random.Next(array.GetLength(0));
                this._clasesDelDia.Enqueue(array[num]);
            }           
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ToString());
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Universidad.EClases c in this._clasesDelDia)
            {
                sb.Append("CLASES DEL DIA: ");
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        #endregion

        #region Sobrecarga de Operadores
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool resp = false;
            foreach (Universidad.EClases c in i._clasesDelDia)
            {
                if (c == clase)
                    resp = true;
            }
            return resp;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        { return !(i == clase); }
        #endregion
    }
}
