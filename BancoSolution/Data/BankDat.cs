using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class BankDat
    {
        Persistence objper = new Persistence();
 
        public DataSet showBanco()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();


            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objper.openConnection();
            objSelectCmd.CommandText = "spShowBank";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objper.closeConnection();
            return objData;
        }

        public bool saveBanco(string _nameBanco, string _direccionBanco, string _telefonoBanco)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objper.openConnection();
            objSelectCmd.CommandText = "spCreateBank";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarString).Value = _nameBanco;
            objSelectCmd.Parameters.Add("v_direccion", MySqlDbType.VarString).Value = _direccionBanco;
            objSelectCmd.Parameters.Add("v_telefono", MySqlDbType.VarString).Value = _telefonoBanco;
            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.ToString());
            }
            objper.closeConnection();
            return executed;

        }
        public bool updateBanco(int _id, string _nameBanco, string _direccionBanco, string _telefonoBanco)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objper.openConnection();
            objSelectCmd.CommandText = "spUpdateBank";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_banco", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarString).Value = _nameBanco;
            objSelectCmd.Parameters.Add("v_direccion", MySqlDbType.VarString).Value = _direccionBanco;
            objSelectCmd.Parameters.Add("v_telefono", MySqlDbType.VarString).Value = _telefonoBanco;
            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.ToString());
            }
            objper.closeConnection();
            return executed;

        }
        public bool deleteBanco(int _id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objper.openConnection();
            objSelectCmd.CommandText = "spDropBank";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_banco", MySqlDbType.Int32).Value = _id;
            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.ToString());
            }
            objper.closeConnection();
            return executed;

        }

    }
}