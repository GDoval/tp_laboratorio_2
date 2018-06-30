using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
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
}

