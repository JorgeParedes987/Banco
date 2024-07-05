using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Data
{
    /*
    * Mostrar categoria producto
     */
    public class ProductDat
    {
        Persistence objPer = new Persistence();

        //Metodo para mostrar los clientes
        public DataSet showProduct()
        {
            MySqlDataAdapter objAdater = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spShowProduct";
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

        //Metodo para guardar un nuevo clientes
        public bool saveProduct(char _tipoProducto, int _numProducto, string _montoaperturaProducto, int _saldoProducto, DateTime _fechaaperturaProducto, int _fkclienIdCliente)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spCreateProduct";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_prod_tipo", MySqlDbType.VarChar).Value = _tipoProducto;
            objSelectCmd.Parameters.Add("v_prod_num_cuenta", MySqlDbType.Int32).Value = _numProducto;
            objSelectCmd.Parameters.Add("v_prod_monto_apertura", MySqlDbType.VarString).Value = _montoaperturaProducto;
            objSelectCmd.Parameters.Add("v_prod_saldo", MySqlDbType.Int32).Value = _saldoProducto;
            objSelectCmd.Parameters.Add("v_prod_fecha_apertura", MySqlDbType.Date).Value = _fechaaperturaProducto;
            objSelectCmd.Parameters.Add("fk_cliente", MySqlDbType.Int32).Value = _fkclienIdCliente;


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

        //Metodo para actualizar un cliente
        public bool updateProduct(int _idproducto, char _tipoProducto, int _numProducto, string _montoaperturaProducto, int _saldoProducto, DateTime _fechaaperturaProducto, int _fkclienIdCliente)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpadteProduct";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idproducto;
            objSelectCmd.Parameters.Add("v_prod_tipo", MySqlDbType.VarChar).Value = _tipoProducto;
            objSelectCmd.Parameters.Add("v_prod_num_cuenta", MySqlDbType.Int32).Value = _numProducto;
            objSelectCmd.Parameters.Add("v_prod_monto_apertura", MySqlDbType.VarString).Value = _montoaperturaProducto;
            objSelectCmd.Parameters.Add("v_prod_saldo", MySqlDbType.Int32).Value = _saldoProducto;
            objSelectCmd.Parameters.Add("v_prod_fecha_apertura", MySqlDbType.Date).Value = _fechaaperturaProducto;
            objSelectCmd.Parameters.Add("fk_cliente", MySqlDbType.Int32).Value = _fkclienIdCliente;

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
       *  eliminar categoría prodcuto
       */
        public bool dropProduct(int _idproducto)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spDropProduct";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = _idproducto;
       
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