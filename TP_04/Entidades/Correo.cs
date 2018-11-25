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
        private List<Paquete> paquetes;
        private List<Thread> mockPaquetes;

        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

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
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> lista = (List<Paquete>)((Correo)elementos).paquetes;
            string salida = " ";
            foreach (Paquete paquete in lista)
            {
                salida = string.Format("{0} para {1} ({2})", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString());
            }
            return salida;
        }

        public void FinEntregas()
        {
            foreach (Thread th in this.mockPaquetes)
            {
                if (th.IsAlive)
                {
                    th.Abort();
                }
            }
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                {
                    throw new TrackingRepetidoException("Paquete con TrackinID ya existente");
                }
            }
            c.Paquetes.Add(p);
            Thread th = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(th);
            th.Start();
            return c;
        }

    }
}
