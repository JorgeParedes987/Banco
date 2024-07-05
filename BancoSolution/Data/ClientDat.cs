using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{

    /*
     * Mostrar categoria Cliente
      */
    public class ClientDat
    {
        Persistence objPer = new Persistence();

        //Metodo para mostrar unicamente el id y la descripcion de los clientes, en el DropDownList
        public DataSet showClientDDL()
        {
            MySqlDataAdapter objAdater = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spShowClientDDL";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdater.SelectCommand = objSelectCmd;
            objAdater.Fill(objData);
            objPer.closeConnection();
            return objData;
        }
            public DataSet showClient()
        {
            MySqlDataAdapter objAdater = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spShowClient";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdater.SelectCommand = objSelectCmd;
            objAdater.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        public DataSet selectClient()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet(); //clase que contiene una colección de tablas
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();

            objSelectCmd.CommandText = "spselectClient";//nombre del procedimiento 

            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);//Método que agrega o actualiza filas en el DataSet.
            objPer.closeConnection();
            return objData;

          
        }
             /*
              * insertar categoria Cliente
              */
        public bool saveClient(string _nombreCliente, string _apellidoCliente, DateTime _fechanacimientoCliente, string _telefonoCliete, string _correoCliente, int _fkSucIdSucursal)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spCreateClient";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_clien_nombre", MySqlDbType.VarString).Value = _nombreCliente;
            objSelectCmd.Parameters.Add("v_clien_apellido", MySqlDbType.VarString).Value = _apellidoCliente;
            objSelectCmd.Parameters.Add("v_clien_fecha_nacimiento", MySqlDbType.Date).Value = _fechanacimientoCliente;
            objSelectCmd.Parameters.Add("v_clien_tel", MySqlDbType.VarString).Value = _telefonoCliete;
            objSelectCmd.Parameters.Add("v_clien_correo", MySqlDbType.VarString).Value = _correoCliente;
            objSelectCmd.Parameters.Add("fk_sucursal", MySqlDbType.Int32).Value = _fkSucIdSucursal;

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
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        /*
        * actualizar categoría Cliente.
        */
        public bool updateClient(int _idCliente, string _nombreCliente, string _apellidoCliente, DateTime _fechanacimientoCliente, string _telefonoCliete, string _correoCliente, int _fkSucIdSucursal)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpadteClient";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idCliente;
            objSelectCmd.Parameters.Add("v_clien_nombre", MySqlDbType.VarString).Value = _nombreCliente;
            objSelectCmd.Parameters.Add("v_clien_apellido", MySqlDbType.VarString).Value = _apellidoCliente;
            objSelectCmd.Parameters.Add("v_clien_fecha_nacimiento", MySqlDbType.Date).Value = _fechanacimientoCliente;
            objSelectCmd.Parameters.Add("v_clien_tel", MySqlDbType.VarString).Value = _telefonoCliete;
            objSelectCmd.Parameters.Add("v_clien_correo", MySqlDbType.VarString).Value = _correoCliente;
            objSelectCmd.Parameters.Add("fk_sucursal", MySqlDbType.Int32).Value = _fkSucIdSucursal;

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
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;

        }

        /*
       *  eliminar categoría Cliente
       */
        public bool dropClient(int _idCliente)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spDropClient";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idCliente;
          
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
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }
    }
}