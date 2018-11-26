using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo de extension creara un archivo de texto lo guardara en el escritorio.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter file = null;
            bool retorno = false;
            try
            {
                file = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/" + archivo, true);
                file.WriteLine(texto);
                retorno = true;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }

            return retorno;
        }
    }
}
