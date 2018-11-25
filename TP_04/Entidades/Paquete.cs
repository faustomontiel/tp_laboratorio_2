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

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

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

        public void MockCicloDeVida()
        {
            while(this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado++;
                this.InformaEstado(this.Estado,EventArgs.Empty);
            }
            //Aca guardo en la base de datos.

            //...
        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", this.TrackingID, this.DireccionEntrega);
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public static bool operator ==(Paquete p1,Paquete p2)
        {
            return (p1.TrackingID == p2.TrackingID);
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }


    }
}
