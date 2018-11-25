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

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }

        }
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string numero)
        {
            SetNumero = numero;
        }

        private double ValidarNumero(string strNumero)
        {
            double numero = 0;

            if (double.TryParse(strNumero, out double numeroValido))
            {
                numero = numeroValido;
            }
            return numero;
        }
        public string BinarioDecimal(string binario)
        {
            int exponente = binario.Length - 1;
            double num_decimal = 0;

            for (int i = 0; i < binario.Length; i++)
            {
                if (double.Parse(binario.Substring(i, 1)) == 1)
                {
                    num_decimal = num_decimal + double.Parse(System.Math.Pow(2, double.Parse(exponente.ToString())).ToString());
                }
                exponente--;
            }
            return Convert.ToString(num_decimal);

        }
        public string DecimalBinario(double numero)
        {
            string binario = "";
            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        binario = "0" + binario;
                    }
                    else
                    {
                        binario = "1" + binario;
                    }
                    numero = (int)numero / 2;
                }
            }
            else if (numero == 0)
            {
                binario = "0";
            }
            else
            {
                binario = "Valor Invalido";
            }
            return binario;
        }
        public string DecimalBinario(string numero)
        {
            string binario = "";
            double.TryParse(numero, out double numeroParse);

            binario = DecimalBinario(numeroParse);
            return binario;


        }


        public static double operator +(Numero num, Numero num1)
        {
            return num.numero + num1.numero;
        }
        public static double operator *(Numero num, Numero num1)
        {
            return num.numero * num1.numero;
        }
        public static double operator /(Numero num, Numero num1)
        {
            return num.numero / num1.numero;
        }
        public static double operator -(Numero num, Numero num1)
        {
            return num.numero - num1.numero;
        }
       
    }
}

