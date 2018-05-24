using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Leche : Producto
    {
        public enum ETipo
        {
            Entera, Descremada
        }

        private ETipo _tipo;

        protected override short CantidadCalorias { get { return 20; } }

        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        { 
        }

        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            : this(marca, codigo, color)
        {
            this._tipo = tipo;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("LECHE");
            sb.Append(base.Mostrar());
            sb.Append("\nCALORIAS : ");
            sb.Append(Convert.ToString(this.CantidadCalorias));
            sb.Append("\nTIPO: ");
            sb.Append(Convert.ToString(this._tipo));
            sb.AppendLine("\n---------------------\n");
            return sb.ToString();
        }
    
    }
}
