using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
using Excepciones;

namespace ClasesInstanciables
{

    public class Universidad
    {
        
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
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

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Jornadas.Count)
                    return this.Jornadas[i];
                else
                    return null;

            }
            set
            {
                if (i > 0 && i < this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;
                }
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor incializa las listas de alumnos,jornada y profesores.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }


        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de la universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Metodo estatico muestra los datos de la universidad junto a la jornada.
        /// </summary>
        /// <param name="u">Universidad a la que se le mostrara los datos</param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad u)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada jornada in u.Jornadas)
            {
                sb.AppendLine(jornada.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Si un alumno se encuentra en la unversidad retornara true.
        /// </summary>
        /// <param name="g">Universidad donde buscar</param>
        /// <param name="a">Alumno a encontrar</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool salida = false;

            foreach (Alumno alumno in g.alumnos)
            {

                if (alumno == a)
                {
                    salida = true;
                }
            }

            return salida;
        }
        /// <summary>
        /// Si un alumno no se encuentra en la unversidad retornara true.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Si un profesor es parte en la unversidad retornara true.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool salida = false;
            foreach (Profesor profesor in g.profesores)
            {

                if (profesor == i)
                {
                    salida = true;
                }
            }

            return salida;
        }
        /// <summary>
        /// Si un profesor no es parte de la unversidad retornara true.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Devuelve que profesor dara la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.profesores)
            {
                if (profesor == clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Devuelve el profesor que no da esa clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Agrega un alumno a la universidad si no se encuentra.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }    
        }

        /// <summary>
        /// Agrega el profesor a la univeridad si no se encuetra.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor a agregar</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u,Profesor i)
        {
            if(u!=i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }
        /// <summary>
        /// agrega una nueva jornada a la universidad.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g,EClases clase)
        {
            Jornada joranda = new Jornada(clase, g == clase);

            foreach(Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                    joranda+=alumno;
            }
            g.Jornadas.Add(joranda);
            return g;

        }
        /// <summary>
        /// Permite guardar los datos de la universidad en formato xml.
        /// </summary>
        /// <param name="uni">Universidad cuyos datos se serializaran</param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            try
            {
                xml.Guardar("Universidad.xml",uni);
                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Permite deserializar los datos de la universidad en fomato xml.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad salida;
            Xml<Universidad> xml = new Xml<Universidad>();
            try
            {
                xml.Leer("Universidad.xml", out salida);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return salida;

        }
        

        #endregion     
    }
}
