using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }
       
        /// <summary>
        /// Sera el manejador del evento para poder actualizar los estados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
                ActualizarEstados();
        }

        /// <summary>
        /// Limpia los listBox y asigna los paquetes a su estado correspondiente.
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresado.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete paquete in this.correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                }
            }
        }
        
        /// <summary>
        /// Agrega el paquete al correo generado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtDireccion.Text,mtxtTrackingID.Text);
            paquete.InformaEstado += this.paq_InformaEstado;

            try
            {
                correo += paquete;
            }
            catch(TrackingRepetidoException exc)
            {
                MessageBox.Show(exc.Message);
            }

            this.ActualizarEstados();
        }
        /// <summary>
        /// Muestra la informacion de los paquetes y los guarda en archivo de texto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemnto"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemnto)
        {
            if(!ReferenceEquals(elemnto,null))
            {
                rtbMostrar.Text = elemnto.MostrarDatos(elemnto);
                try
                {
                    GuardaString.Guardar(rtbMostrar.Text,"salida.txt");
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }

        }
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        } 
        /// <summary>
        /// Mostrara la informacion del paquete seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
        /// <summary>
        /// Mostrara los paquetes con su informacion y estado actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

     

        
    }
}
