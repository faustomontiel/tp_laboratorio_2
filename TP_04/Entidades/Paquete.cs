using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete:IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,EnViaje,Entregado
        }

        public delegate void DelegadoEstado(object sender,EventArgs e);
        public event DelegadoEstado InformaEstado;

        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Constructores
        public Paquete(string direccionEntrega,string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad asignara DireccionEntrega y retornara la misma. 
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;

            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        /// <summary>
        /// Propiedad asignara EEstado y retornara el misma. 
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        /// <summary>
        /// Propiedad asignara TrackingID y retornara el misma. 
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Permite controlar el ciclo de vida de un paquete en el correo. Guardara el paquete 
        /// en la base de datos.
        /// </summary>
        public void MockCicloDeVida()
        {
            while(this.Estado != EEstado.Entregado)
            {
                //Duermo el hilo 4 segundos.
                Thread.Sleep(4000);
                //Cambiara al siguiente estado luego de pasado el tiempo del hilo.
                this.Estado++;
                //Muestro en que estado esta actualmente.
                this.InformaEstado(this.Estado,EventArgs.Empty);
            }
            //Aca guardo en la base de datos.
            PaqueteDAO.Insertar(this);
            //
        }
        /// <summary>
        /// Mostrara el TrackingID y la direccion de un paquete.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", this.TrackingID, this.DireccionEntrega);         
        }

        /// <summary>
        /// Sobrecarga utiliza el metodo MostrarDatos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Dos paquetes seran iguales si tienen el mismo TrackinID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1,Paquete p2)
        {
            return (p1.TrackingID == p2.TrackingID);
        }
        /// <summary>
        /// Sobrecarga verifica desigualdad entre paquetes.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

    }
}
