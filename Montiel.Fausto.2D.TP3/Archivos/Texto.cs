﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto :IArchivo<string>
    {
        /// <summary>
        ///Guardara datos en un archivo.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo,string datos)
        {
            StreamWriter file = null;
            bool salida = true;

            try
            {
                file = new StreamWriter(archivo,false);
                file.Write(datos);
            }
            catch(Exception)
            {
                salida = false;
            }
            finally
            {
                file.Close();

            }
            return salida;
        }
        /// <summary>
        /// Obtendra los datos de un achivo y los guardara.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo,out string datos)
        {
            StreamReader file = null;
            bool salida = true;

            try
            {
                file = new StreamReader(archivo);
                datos = file.ReadToEnd();
            }
            catch(Exception)
            {
                datos = null;
                salida = false;
            }
            finally
            {
                file.Close();
            }
            return salida;
        }
    }
}
