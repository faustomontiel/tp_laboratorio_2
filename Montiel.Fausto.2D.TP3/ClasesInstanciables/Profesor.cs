using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Construcores
        /// <summary>
        /// constructor de clase,inicializa random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// constructor por defecto.
        /// </summary>
        public Profesor()
        {
        }
        /// <summary>
        /// constructor de instancia,inicializa las clases.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Muestra las clases que dicta en el dia.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases clases in this.clasesDelDia)
            {
                sb.AppendLine("" + clases);
            }
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga muestra los datos del profesor incluyendo sus clases.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Genera 2 clases random para asignar a las clases que dictara el profesor.
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
        }
        /// <summary>
        /// Retorna true si el profesor dicta esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool salida = false;
            foreach (Universidad.EClases a in i.clasesDelDia)
            {
                if (a == clase)
                    salida = true;
            }
            return salida;
        }
        /// <summary>
        /// Retornara true si el profesor no dicta esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
     
    }
}
