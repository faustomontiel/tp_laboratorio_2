using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {

        private int _legajo;

        #region Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universitario()
        {
        }
        /// <summary>
        /// constructor de instancia.
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido,dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos del universitario, incluyendo su legajo.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendFormat("LEGAJO NUMERO: {0}", this._legajo);

            return sb.ToString();
        }
        /// <summary>
        /// Metodo abstracto sin implementar.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Dos universitarios seran iguales cuando posean el mismo legajo y dni.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!ReferenceEquals(obj, null) && obj is Universitario)
            {
                Universitario objeto = (Universitario)obj;
                if (objeto._legajo == this._legajo && objeto.DNI == this.DNI)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Comparacion entre dos universitarios.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }


        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
