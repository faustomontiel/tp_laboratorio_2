using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos

        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor privado, inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;

            }
            set
            {
                this._alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this._clase;
            }

            set
            {
                this._clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this._instructor;

            }
            set
            {
                this._instructor = value;
            }
        }



        #endregion

        #region Metodos
        /// <summary>
        /// Guarda informacion de la joranada.
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada j)
        {
            Texto texto = new Texto();
            bool salida = false;
            try
            {
                texto.Guardar("Jornada.txt", j.ToString());
                salida = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);

            }
            return salida;
        }
        /// <summary>
        /// Lee la informacion ya obtenida de una jornada.
        /// </summary>
        /// <returns></returns>

        public static string Leer()
        {
            Texto texto = new Texto();

            string salida = "";

            try
            {
                texto.Leer("Jornada.txt", out salida);

            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }


            return salida;

        }
        /// <summary>
        /// Sobrecarga muestra los datos de la jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE: {0} POR: {1}", this.Clase, Instructor.ToString());

            sb.AppendLine("ALUMNOS: ");

            foreach (Alumno alum in this.Alumnos)
            {
                sb.AppendLine(alum.ToString());
            }
            return sb.ToString();
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool salida = false;
            if (j.Alumnos.Contains(a))
            {
                salida = true;
            }
            return salida;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j==a);
        }
        public static Jornada operator +(Jornada j,Alumno a)
        {
            if(j!=a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

            #endregion
        }
}
