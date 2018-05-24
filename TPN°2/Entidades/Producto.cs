using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        protected EMarca _marca;
        protected string _codigoDeBarras;
        protected ConsoleColor _colorPrimarioEmpaque;

        protected virtual short CantidadCalorias { get {return 0;}}

        public Producto(string codigoDeBarras, EMarca marca, ConsoleColor color)
        {
            this._codigoDeBarras = codigoDeBarras;
            this._colorPrimarioEmpaque = color;
            this._marca = marca;
        }

        public virtual string Mostrar()
        {
            return (string)this;
        }

        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CODIGO DE BARRAS: ");
            sb.Append(p._codigoDeBarras);
            sb.Append("\nMARCA: ");
            sb.Append(p._marca.ToString());
            sb.Append("\nCOLOR EMPAQUE: ");
            sb.Append(p._colorPrimarioEmpaque.ToString());
            return sb.ToString();
        }


        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }

        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1._codigoDeBarras == v2._codigoDeBarras);
        }


           

    }
}
