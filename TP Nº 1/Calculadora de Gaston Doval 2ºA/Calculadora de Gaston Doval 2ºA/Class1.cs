using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_de_Gaston_Doval_2ºA
{
    public class Calculadora
    {
        //Funciones   


        /// <summary>
        /// Valida cuál fue el operador que se ingresó. Si recibe null (el ComboBox en blanco) devuelve un "+"
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
            string resp = "+";
            if (operador == string.Empty)
            {
                return resp;
            }
            else
            {
                switch (operador)
                {
                    case "+":
                        resp = "+";
                        break;
                    case "-":
                        resp = "-";
                        break;
                    case "*":
                        resp = "*";
                        break;
                    case "/":
                        resp = "/";
                        break;
                }
            }
            return resp;
        }
        /// <summary>
        /// Hace las operaciones sobrecargadas sobre los objetos de la clase Numero
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double resp = 0;
            string ope = ValidarOperador(operador);
            switch (ope)
            {
                case "+":
                    resp = num1 + num2;
                    break;
                case "-":
                    resp = num1 - num2;
                    break;
                case "*":
                    resp = num1 * num2;
                    break;
                case "/":
                    if (num2.getNumero() != 0)
                    {
                        resp = num1 / num2;
                    }
                    else
                        resp = 0;
                    break;
            }
            return resp;
        }
    }

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
        public static string DecimalBinario(int num)
        {
            string resp = "";
            while (num > 1)
            {
                int resto = num % 2;
                resp = Convert.ToString(resto) + resp;
                num /= 2;
            }
            resp = Convert.ToString(num) + resp;
            return resp;
        }


        /// <summary>
        /// Pasa un numero en formato decimal a formato decimal
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int BinarioDecimal(string num)
        {
            int resp = Convert.ToInt32(num,2);
            return resp;

        }

    }

}