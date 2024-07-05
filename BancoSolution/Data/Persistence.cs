using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Data
{
    public class Persistence
    {
        //Cadena de conexion
        MySqlConnection _connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
        public MySqlConnection openConnection()
        {

            try
            {
                _connection.Open();
                return _connection;
            }
            catch (Exception e)
            {
                e.ToString();
                return null;
            }
        }

        public void closeConnection()
        {
            _connection.Close();
        }
    }
}