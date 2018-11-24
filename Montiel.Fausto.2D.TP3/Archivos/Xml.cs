using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa datos en formato xml.
        /// </summary>
        /// <param name="archivo">Path</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlWriter writer = null;
            bool salida = true;
            try
            {
                writer = new XmlTextWriter(archivo, null);
                ser.Serialize(writer, datos);
            }
            catch (Exception)
            {
                salida = false;
            }
            finally
            {
                writer.Close();
            }
            return salida;

        }
        /// <summary>
        /// Deserializa datos en formato xml.
        /// </summary>
        /// <param name="archivo">Path</param>
        /// <param name="datos">Objeto donde se guardara</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextReader reader = null;
            bool salida = true; 

            try
            {
                reader = new XmlTextReader(archivo);
                datos = (T)ser.Deserialize(reader);
            }
            catch (Exception)
            {
                datos = default(T); 
                salida = false; 
            }
            finally
            {
                reader.Close();
            }
            return salida;
        }
    }


}

