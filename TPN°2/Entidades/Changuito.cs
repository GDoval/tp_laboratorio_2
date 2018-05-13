using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Changuito
    {
        private int _espacioDisponible;
        private List<Producto> _productos;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        private Changuito()
        {
            this._productos = new List<Producto>();
        }

        public Changuito(int espacioDisponible) :this()
        {
            this._espacioDisponible = espacioDisponible;
        }


        public override string ToString()
        {
            return this.Mostrar(this, ETipo.Todos);
        }

                
        public string Mostrar(Changuito concencionaria, ETipo tipoDeChanguito)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", concencionaria._productos.Count, concencionaria._espacioDisponible);
            sb.AppendLine("");
            int flag = 0;
            switch (tipoDeChanguito)
            {
                case ETipo.Snacks:
                    flag = 1;
                    break;
                case ETipo.Dulce:
                    flag = 2;
                    break;
                case ETipo.Leche:
                    flag = 3;
                    break;
                case ETipo.Todos:
                    flag = 4;
                    break;
            }
            foreach (Producto v in concencionaria._productos)
            {
                if (flag == 1 && v is Snacks)
                    sb.Append(((Snacks)v).Mostrar());
                else
                    if (flag == 2 && v is Dulce)
                        sb.Append(((Dulce)v).Mostrar());
                    else
                        if (flag == 3 && v is Leche)
                            sb.Append(((Leche)v).Mostrar());
                        else
                            if (flag == 4)
                                sb.Append(v.Mostrar());

            }
            return sb.ToString();
        }

        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            foreach (Producto v in c._productos)
            {
                if (v == p)
                    return c;
            }
            if (c._productos.Count < c._espacioDisponible)
                c._productos.Add(p);
            return c;
        }

        public static Changuito operator -(Changuito c, Producto p)
        {
            bool resp = false;
            foreach (Producto v in c._productos)
            {
                if (v == p)
                {
                    resp = true;
                    break;
                }
            }
            if (resp)
                c._productos.Remove(p);
           return c;
        }
    }
}
