using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    

    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Atributos
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;
        #endregion

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = ValidarNombreApellido(value);
            }
        }       
        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = ValidarDni(this.Nacionalidad,value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = ValidarNombreApellido(value);
            }
        }
        public string StringToDNI
        {          
            set
            {
                this._dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {
        }
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad):this()
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor de instancia con set dni entero.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Constructor de instancia con set de dni string.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Validacion de dni entre argentinos y extranjeros. 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException();
            }
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato > 89999999)
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                    break;
                case ENacionalidad.Extranjero:
                    if (dato <= 89999999)
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                    break;
            }
            return dato;
        }
        /// <summary>
        /// Sobrecarga ToString con datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}",this.Nacionalidad);


            return sb.ToString();
        }
        /// <summary>
        /// Validacion de dni a partir de un string.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dniEntero;
            if(int.TryParse(dato,out dniEntero))
            {
                return ValidarDni(nacionalidad, dniEntero);
            }
            else
            {
                throw new DniInvalidoException("Dni con caracteres invalidos");
            }
        }
        /// <summary>
        /// Validacion del Nombre y apellido utilizando expreciones regulares.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string salida = "";
            if (Regex.IsMatch(dato, @"^[a-zA-Z]+$/"))
            {
                salida = dato;
            }
            return salida;
        }

        #endregion 





    }
}
