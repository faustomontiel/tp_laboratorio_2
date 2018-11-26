
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atribustos
        private List<Paquete> paquetes;
        private List<Thread> mockPaquetes;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor inicializa las listas de paquetes e hilos.
        /// </summary>
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        #endregion 

        #region Propiedades
        /// <summary>
        /// Propiedad asignara la lista de paquetes y retornara la misma.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion 

        #region Metodos
        /// <summary>
        /// Mostrara los datos de los paquetes de la lista.
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            //Asigno los elementos ingresados a una lista.
            List<Paquete> l = (List<Paquete>)((Correo)elementos).paquetes;
            string salida = " ";
            //Para todos los paquetes de la lista los muestro urilizando sting format.
            foreach (Paquete paquete in l)
            {
                salida = string.Format("{0} para {1} ({2})", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString());
            }
            return salida;
        }

        /// <summary>
        /// Cierra todos los hilos.
        /// </summary>
        public void FinEntregas()
        {
            //Para todos los hilos de la lista de hilos,
            //verifica que esten activos y los cierra.
            foreach (Thread th in this.mockPaquetes)
            {
                if (th.IsAlive)
                {
                    th.Abort();
                }
            }
        }

        /// <summary>
        /// Agrega un paquete a la lista de paquetes que seran eviados.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            //Me aseguro que no exista el paquete en la lista.
            foreach (Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                {
                    //si existe lanzara la excepcion.
                    throw new TrackingRepetidoException("Paquete con TrackinID ya existente");
                }
            }

            //Lo agrego.
            c.Paquetes.Add(p);
            //Creo el hilo con el metodo que movera el ciclo del paquete en el correo.
            Thread th = new Thread(p.MockCicloDeVida);
            //Agregara el hilo a la lista de hilos.  
            c.mockPaquetes.Add(th);
            //Inicio el hilo.
            th.Start();
            return c;
        }
        #endregion 

    }
}
