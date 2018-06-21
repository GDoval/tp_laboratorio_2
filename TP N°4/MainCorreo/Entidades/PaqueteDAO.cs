using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion; 
        
        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.Conexion);
        }

        public static bool Insertar(Paquete p)
        {
            bool resp = true;
            try
            {
                conexion.Open();
                comando = new SqlCommand("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES(' " + p.DireccionEntrega + "','" + p.TrackingID + "','Gaston Doval')", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (System.Data.SqlClient.SqlException  e)
            {
                resp = false;
                throw e;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return resp; 
        }
    }
}
