using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
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
        public string Nombre { get { return this._nombre; } set { this._nombre = this.ValidarNombreApellido(value); } }
        public string Apellido { get { return this._apellido; } set { this._apellido = this.ValidarNombreApellido(value);} }
        public ENacionalidad Nacionalidad { get { return this._nacionalidad; } set { this._nacionalidad = value; } }

        /// <summary>
        /// Setea el atributo _dni despues de validar si está en rango según la nacionalidad de la instacia
        /// </summary>
        public int Dni
        {
            set
            {
                int dni = 0;
                try
                {
                    dni = this.ValidarDni(this.Nacionalidad, value);
                }
                catch (NacionalidadInvalidaException e)
                {
                    Console.Write(e.Message);
                }
                catch (DniInvalidoException b)
                {
                    Console.WriteLine(b.Message);
                }
                this._dni = dni;
            }
            get { return this._dni; }
        }
      
        /// <summary>
        /// Setea el atributo _dni después de validar si se puede parsear el string a int y de validar si está dentro del rango adecuado
        /// </summary>
        public string StringToDNI 
        {
            set
            {
                int dni = 0;
                try
                { dni = this.ValidarDni(this.Nacionalidad, value); }
                catch (NacionalidadInvalidaException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (DniInvalidoException b)
                {
                    Console.WriteLine(b.Message);
                }
                this._dni = dni;
            }
        }
        #endregion

        #region Constructores
        public Persona()
            :this("","",0,ENacionalidad.Argentina)
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._apellido = apellido;
            this._nombre = nombre;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.Dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("NOMBRE COMPLETO: ");
            sb.AppendLine(this.Apellido + "," + this.Nombre);
            sb.Append("NACIONALIDAD: ");
            sb.AppendLine(this.Nacionalidad.ToString());
            sb.Append("DNI: ");
            sb.AppendLine(Convert.ToString(this.Dni));
            return sb.ToString();
        }
        /// <summary>
        /// Valida que el entero pasado como parametro esté dentro de los rangos correspondientes para cada instancia del enum ENacionalidad
        /// </summary>
        /// <param name="nacionalidad">Criterio a partir del cual se valida el numero entero</param>
        /// <param name="dato">Entero a validar</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int resp = -1;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentina:
                    if (dato >= 1 && dato < 90000000)
                        resp = dato;
                    else
                        throw new NacionalidadInvalidaException("DNI invalido para un argentino");
                    break;
                case ENacionalidad.Extranjero:
                    if (dato > 89999999)
                        resp = dato;
                    else
                        throw new NacionalidadInvalidaException("DNI invalido para un extranjero");
                    break;
            }
            return resp;
        }

        /// <summary>
        /// Valida que el string que se pasa como parametro se pueda parsear a INT. Devuelve -1 si no pudo
        /// </summary>
        /// <param name="nacionalidad">Criterio a partir del cual se valida la cadena recibida</param>
        /// <param name="dato">Cadena a validar</param>
        /// <returns></returns>
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

        /// <summary>
        /// Corrobora que la cadena pasada como parametro tenga sólo letras. De no ser así, devuelve una cadena vacía
        /// </summary>
        /// <param name="dato">Cadena a validar</param>
        /// <returns></returns>
        public string ValidarNombreApellido(string dato)
        {
            bool resp = dato.All(Char.IsLetter);
            if (resp)
                return dato;
            else
                return dato = "";
        }
        #endregion

    }
}