using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }
        public double Operar(Numero num, Numero num1, string operador)
        {
            double resultado =0;

            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                    resultado = num + num1;
                    break;
                case "-":
                    resultado = num - num1;
                    break;
                case "*":
                    resultado = num * num1;
                    break;
                case "/":
                    resultado = num / num1;
                    break;
                default:
                    resultado = 0;
                    break;
            }
            return resultado;
        }

    }
}
