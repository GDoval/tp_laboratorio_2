using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Dulce : Producto
    {
        protected override short CantidadCalorias { get { return 80; } }

        public Dulce(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
        }

        public override  string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DULCE");
            sb.Append(base.Mostrar());
            sb.Append("\nCALORIAS : ");
            sb.Append(Convert.ToString(this.CantidadCalorias));
            sb.AppendLine("\n---------------------\n");
            return sb.ToString();
        }
    }
}
