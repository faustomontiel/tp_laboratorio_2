using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlConnection conexion;
        static SqlCommand comando;

        static PaqueteDAO()
        {
            conexion = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");
        }

        public static bool Insertar(Paquete p)
        {
            bool salida = false;
            try
            {
                comando = new SqlCommand("INSERT INTO dbo.Paquetes (direccionEntrega,trackingID,alumno) VALUES ('" + p.DireccionEntrega + "','" + p.TrackingID + "','Fausto Montiel')", conexion);
                conexion.Open();
                comando.ExecuteNonQuery();            
                salida = true;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
              
            }
            return salida;
        }

    }
}
