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
        public static bool Guardar(this string texto,string archivo)
        {
            StreamWriter sw = null;
            bool salida = false;
            try
            {
                if (File.Exists(archivo))
                {
                    sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo, true);
                    sw.WriteLine(texto);
                    salida = true;

                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if(!(sw is null))
                {
                    sw.Close();
                }
            }
            return salida;
        }
        
    }
}
