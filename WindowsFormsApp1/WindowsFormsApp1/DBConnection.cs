using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public abstract class DBConnection
    {
        public static MySqlConnection Conn() {
            MySqlConnectionStringBuilder stringConnection = new MySqlConnectionStringBuilder();

            stringConnection.Server = "localhost";
            stringConnection.UserID = "root";
            stringConnection.Password = "centralito";
            stringConnection.Database = "net";

            MySqlConnection con = new MySqlConnection(stringConnection.ToString());


            return con;
        }

        public static void ExectNonQuery(String consulta){
            try
            {
                MySqlConnection connection = Conn();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = consulta;

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("SE HA GUARDADO CON EXITO");
                connection.Close();
            }
            catch (MySqlException e) {
                Console.WriteLine(e);
            }

        }

        /*public static MySqlDataReader Execute_Reader(String consulta) {
            try
            {
                MySqlConnection connection = Conn();
                MySqlCommand command = connection.CreateCommand();
                MySqlDataReader reader;
                command.CommandText = consulta;

                connection.Open();
                reader = command.ExecuteReader();
                
                return reader;
            }
            catch (MySqlException e) {
                Console.WriteLine(e);
                return null;
            }
        }*/
        
    }
}
