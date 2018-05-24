using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public  class Persona
    {
        public enum ENacionalidad
        {
            Argentina, Extranjero
        }

        #region Atributos
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;
        #endregion

        #region Propiedades
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni
        {
            set
            {
                bool valida = true;
                try
                {
                    this.ValidarDni(this.Nacionalidad, value);
                }
                catch (DniInvalidoException e)
                {
                    Console.Write(e.Message);
                    Console.ReadLine();
                    valida = false;
                }
                if (valida)
                    this._dni = value;
                else
                    this._dni = -1;
            }
            get { return this._dni; }
        }
        public ENacionalidad Nacionalidad { get; set; }


        public string StringToDNI 
        {
            set
            {
                
                this.Dni = value;
            }
        }
        #endregion

        #region Constructores
        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        { }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        { }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        { }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return base.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int resp = 0;
            if (nacionalidad == ENacionalidad.Argentina && dato > 1 && dato < 90000000)
                resp = dato;
            else
                throw new DniInvalidoException("DNI invalido para un argentino");
            if (nacionalidad == ENacionalidad.Extranjero && dato > 89999999)
                resp = dato;
            else
                throw new DniInvalidoException("DNI invalido para un extranjero");
            return resp;

        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni = -1;
            bool resp = int.TryParse(dato, out dni);
            if (resp)
                dni = this.ValidarDni(nacionalidad, dni);
            else
                throw new DniInvalidoException("El DNI ingresado no es válido");
            return dni;
        }

        private string ValidarNombreApellido(string dato)
        { return ""; }
        #endregion

    }
}