using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        
        private double numero;

        /// <summary>
        /// El constructor recibe el string que se recupera del TextBox del formulario y luego llama a la propiedad setter que valida el numero antes de setearlo
        /// </summary>
        /// <param name="Strnumero"></param>
        public Numero(string Strnumero)
        {
            this.setNumero = Strnumero;
        }

        public double getNumero()
        {
            return this.numero;
        }

        public string setNumero
        {
            set
            {
                double resp = this.ValidarNumero(value);
                this.numero = resp;
            }
        }

        /// <summary>
        /// Valida que el string que se pasa como parametro sea un numero valido. Si no lo es retorna un 0.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double resp;
            bool validar = double.TryParse(strNumero, out resp);
            if (validar)
                return resp;
            return resp = 0;
        }

        //Sobrecarga de operadores para poder realizar operaciones sobre dos objetos de tipo Numero

        public static double operator +(Numero num1, Numero num2)
        {
            double resp = num1.getNumero() + num2.getNumero();
            return resp;
        }

        public static double operator -(Numero num1, Numero num2)
        {
            double resp = num1.getNumero() - num2.getNumero();
            return resp;
        }

        public static double operator *(Numero num1, Numero num2)
        {
            double resp = num1.getNumero() * num2.getNumero();
            return resp;
        }

        public static double operator /(Numero num1, Numero num2)
        {
            double resp = num1.getNumero() / num2.getNumero();
            return resp;
        }

        /// <summary>
        /// Pasa un numero en formato decimal a binario
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string DecimalBinario(double num)
        {
            string resp = Convert.ToString((long)num, 2);
            return resp;
        }


        /// <summary>
        /// Pasa un numero en formato decimal a formato decimal
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string BinarioDecimal(string num)
        {
            bool flag = false;
            string resp = "";
            foreach (char c in num)
            {
                if (c != '0' && c != '1')
                {
                    flag = true;
                    break;
                }
            }
            if (!(flag))
            {
                resp = Convert.ToInt64(num, 2).ToString();
                return resp;
            }
            return resp;
        }

    }
}

