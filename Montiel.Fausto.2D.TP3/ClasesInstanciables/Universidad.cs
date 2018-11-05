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
        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;
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

        public List<Jornada> Jornadas
        {
            get
            {
                return this._jornada;
            }

            set
            {
                this._jornada = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this._profesores;
            }

            set
            {
                this._profesores = value;
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
        /// Constructor por defecto, incializa las listas de alumnos,jornada y profesores.
        /// </summary>
        public Universidad()
        {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();
        }


        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine(MostrarDatos(this));

            return sb.ToString();
        }
        /// <summary>
        /// Muestra los datos de la universidad junto a la jornada.
        /// </summary>
        /// <param name="u"></param>
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
        
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool salida = false;

            if (g._alumnos.Contains(a))
            {
                salida = true;
            }


            return salida;
        }
       
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool salida = false;

            if (g._profesores.Contains(i))
            {
                salida = true;
            }


            return salida;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor pro in u.Instructores)
            {
                if (pro == clase)
                    return pro;
            }
            throw new SinProfesorException();
        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor pro in u.Instructores)
            {
                if (pro != clase)
                    return pro;
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Agrega un alumno a la universidad si no se encuentra.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// Agrega el profesor a la univeridad si no se encuetra.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
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
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g,EClases clase)
        {
            Jornada joranda = new Jornada(clase, g == clase);

            foreach(Alumno alum in g.Alumnos)
            {
                if (alum == clase)
                    joranda.Alumnos.Add(alum);
            }
            g.Jornadas.Add(joranda);
            return g;

        }
        /// <summary>
        /// Permite guardar los datos de la universidad en formato xml.
        /// </summary>
        /// <param name="uni"></param>
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
        /// permite deserializar los datos de la universidad en fomato xml.
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
