using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace WcfServiceCoordinador
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public static SqlConnection connect()
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "Server=tcp:hads21-17.database.windows.net,1433;Initial Catalog=HADS21-17;Persist Security Info=False;User ID=pfadarraga@gmail.com@hads21-17;Password=Hohm-4548;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR DE CONEXIÓN: " + ex.Message);
                return null;
            }
        }

        public int getHorasMedia(String codAsig)
        {
            SqlConnection connection = connect();
            String sql = "SELECT AVG(et.HReales) FROM TareasGenericas as tg JOIN EstudiantesTareas as et ON  tg.Codigo = et.CodTarea WHERE tg.CodAsig = '" + codAsig + "'";
            SqlCommand comando = new SqlCommand();
            comando = new SqlCommand(sql, connection);

            int numconfir = (Int32)comando.ExecuteScalar();
            connection.Close();
            return numconfir;
        }

    }
}
