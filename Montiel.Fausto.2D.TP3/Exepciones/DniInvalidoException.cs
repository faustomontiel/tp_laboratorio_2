using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public const string mensajeBase = "DNI INVALIDO";

        public DniInvalidoException()
        {

        }
        public DniInvalidoException(Exception e)
            : this(mensajeBase, e)
        {

        }
        public DniInvalidoException(string message)
            : this(message, null)
        {

        }
        public DniInvalidoException(string message, Exception e) 
            : base(message, e)
        {

        }

    }
}
