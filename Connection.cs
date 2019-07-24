using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_SoapListeProduits
{
    class Connection
    {

        public static OracleConnection GetConnection() {
            string cs =
            "Data Source = (DESCRIPTION = (ADDRESS_LIST=(ADDRESS = (PROTOCOL = TCP)" +
            "(HOST = 207.180.227.26)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = XE) ));" +
            "User Id=yuni;Password=yuni2019;";

            OracleConnection connection = new OracleConnection();
            connection.ConnectionString = cs;

            try{
                Console.WriteLine("Connexion vers Oracle ...");

                connection.Open();
                return connection;
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static void CloseConnection (OracleConnection connection){
            connection.Close();
        }
    }
}
