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

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
            this.lblResultado.Text = "0";
            this.lblResultado.Font = new Font("Arial", 25, FontStyle.Bold);
        }
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.ResetText();
            this.lblResultado.Text = "0";
        }

        private static double Operar(string numero1,string numero2,string operador)
        {
            Numero numeroUno = new Numero(numero1);
            Numero numeroDos = new Numero(numero2);
            Calculadora calculadora = new Calculadora();

            return calculadora.Operar(numeroUno, numeroDos, operador);

        }
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            string resultado = "0";
            resultado=Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
            this.lblResultado.Text = resultado;

        }
        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            this.lblResultado.Text = numero.DecimalBinario(this.lblResultado.Text);
        }
        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            this.lblResultado.Text = numero.BinarioDecimal(this.lblResultado.Text);
        }
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
