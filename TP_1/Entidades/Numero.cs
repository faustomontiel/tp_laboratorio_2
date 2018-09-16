using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string setNumero
        {
            set
            {
                this.numero = ValidarNumero(value);              
            }
           
        }
        public Numero()
        {

        }

        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string numero)
        {
            setNumero = numero;
        }

        private double ValidarNumero(string strNumero)
        {
            double numero = 0,numeroValido;
            bool validar = false;

            validar = double.TryParse(strNumero, out numeroValido);
            if (validar)
            {
                numero = numeroValido;
            }
            return numero;        
        }
        public static double operator -(Numero num,Numero num1)
        {
            return num.numero - num.numero;
        }
        public static double operator +(Numero num, Numero num1)
        {
            return num.numero + num.numero;
        }
        public static double operator *(Numero num, Numero num1)
        {
            return num.numero * num.numero;
        }
        public static double operator /(Numero num, Numero num1)
        {
            return num.numero / num.numero;
        }

    }
}

