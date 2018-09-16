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
            double numero = 0, numeroValido;
            bool validar = false;

            validar = double.TryParse(strNumero, out numeroValido);
            if (validar)
            {
                numero = numeroValido;
            }
            return numero;
        }
        public string BinarioDecimal(string binary)
        {
            int exponente = binary.Length - 1;
            int num_decimal = 0;

            for (int i = 0; i < binary.Length; i++)
            {
                if (int.Parse(binary.Substring(i, 1)) == 1)
                {
                    num_decimal = num_decimal + int.Parse(System.Math.Pow(2, double.Parse(exponente.ToString())).ToString());
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
              binario ="Valor Invalido";
            }
            return binario;
        }
        public string DecimalBinario(string numero)
        {
            string binario = "";
            double numeroParse = 0;
            double.TryParse(numero, out numeroParse);

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

