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
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor privado, inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;

            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;

            }
            set
            {
                this.instructor = value;
            }
        }



        #endregion

        #region Metodos
        /// <summary>
        /// Guarda informacion de la joranada en un archivo de texto.
        /// </summary>
        /// <param name="j">Contenido a ser guardado.</param>
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
        /// Lee la informacion de un archivo de texto de una jornada existente.
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
        /// Muestra la informacion de una clase (Asignatura, profesor y alumnos).
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
        /// <summary>
        /// Si el alumno se encuentra en la jornada retornara true.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool salida = false;

            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    salida = true;
                }
            }
            return salida;
        }
        /// <summary>
        /// Si el alumno no se encuentra en la jornada retornara true.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j==a);
        }
        /// <summary>
        /// Agrega un alumno a la jornada en caso de este no se encuentre.
        /// </summary>
        /// <param name="j">Jornada donde se agregara al alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns></returns>
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
