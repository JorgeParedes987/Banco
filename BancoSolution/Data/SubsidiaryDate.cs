using Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Data
{
    public class SubsidiaryDate
    {
        Persistence objper = new Persistence();
        public DataSet showSucursal()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();


            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objper.openConnection();
            objSelectCmd.CommandText = "spShowSucursal";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objper.closeConnection();
            return objData;
        }
        public DataSet showSucursalDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();


            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objper.openConnection();
            objSelectCmd.CommandText = "spShowSucursalDDL";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objper.closeConnection();
            return objData;
        }

        public bool saveSucursal(string _nameSucursal, string _direccionSucursal, string telefonoSucursal, int _FkllaveBanco, int _FkllaveMunicipio)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objper.openConnection();
            objSelectCmd.CommandText = "spCreateSucursal";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarString).Value = _nameSucursal;
            objSelectCmd.Parameters.Add("v_direccion", MySqlDbType.VarString).Value = _direccionSucursal;
            objSelectCmd.Parameters.Add("v_telefono", MySqlDbType.VarString).Value = telefonoSucursal;
            objSelectCmd.Parameters.Add("fk_banco", MySqlDbType.Int32).Value = _FkllaveBanco;
            objSelectCmd.Parameters.Add("fk_municipio", MySqlDbType.Int32).Value = _FkllaveMunicipio;
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
        public bool updateSucursal(int _id, string _nameSucursal, string _direccionSucursal, string telefonoSucursal, int _FkllaveBanco, int _FkllaveMunicipio)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objper.openConnection();
            objSelectCmd.CommandText = "spUpdateSucursal";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_sucursal", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("v_nombre", MySqlDbType.VarString).Value = _nameSucursal;
            objSelectCmd.Parameters.Add("v_direccion", MySqlDbType.VarString).Value = _direccionSucursal;
            objSelectCmd.Parameters.Add("v_telefono", MySqlDbType.VarString).Value = telefonoSucursal;
            objSelectCmd.Parameters.Add("fk_banco", MySqlDbType.Int32).Value = _FkllaveBanco;
            objSelectCmd.Parameters.Add("fk_municipio", MySqlDbType.Int32).Value = _FkllaveMunicipio;
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
        public bool deleteSucursal(int _id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objper.openConnection();
            objSelectCmd.CommandText = "spDropSucursal";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_sucursal", MySqlDbType.Int32).Value = _id;
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