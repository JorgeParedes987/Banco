    using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class DepartmentDat
    {
        Persistence objPer = new Persistence();

        //metodo mostrar depto
        //MySqlDataAdapter Es una clase que proporciona un medio para leer
        /*MySqlCommand Es una clase que representa una
                instrucción SQL para ejecutar en una base de datos MySQL*/
        public DataSet showDepartment()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet(); //clase que contiene una colección de tablas
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            /*CommandText Es una propiedad que establece la
            instrucción SQL para ejecutar en el origen de datos.*/
            objSelectCmd.CommandText = "spShowDepartment";//nombre del procedimiento 
            /*CommandType Es una propiedad que obtiene un valor que indica cómo se interpretará
                la propiedad CommandText */
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            /*SelectCommand Es una propiedad que obtiene un procedimiento almacenado que se usara para 
             * seleccionar registros en el origen de datos*/
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);//Método que agrega o actualiza filas en el DataSet.
            objPer.closeConnection();
            return objData;


        }

        //metodo agregar depto
        public bool saveDepartment(string _nombre, string _codPost, int _poblacion)

        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spCreateDepartment";//nombre del procedimiento
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            //add agrega el nombre del parametro y tipo de dato
            //MySqlDbType especifica el tipo de dato de un campo.
            objSelectCmd.Parameters.Add("nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("codigo_postal", MySqlDbType.VarString).Value = _codPost;
            objSelectCmd.Parameters.Add("poblacion", MySqlDbType.Int32).Value = _poblacion;
            /*Método que se usa para
             * ejecutar sentencias que no devuelven conjuntos de resultados*/
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

        //metodo actualizar depto
        public bool updateDepartment(int _id, string _nombre, string _codPost, int _poblacion)

        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateDepartment";//nombre del procedimiento
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            //add agrega el nombre del parametro y tipo de dato
            //MySqlDbType especifica el tipo de dato de un campo.
            objSelectCmd.Parameters.Add("id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("codigo_postal", MySqlDbType.VarString).Value = _codPost;
            objSelectCmd.Parameters.Add("poblacion", MySqlDbType.Int32).Value = _poblacion;
            /*Método que se usa para
            * ejecutar sentencias que no devuelven conjuntos de resultados*/

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

        //metodo borrar depto

        public bool deleteDepartment(int _id)

        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spDropDepartment";//nombre del procedimiento
            /*CommandType Es una propiedad que obtiene un valor que indica cómo se interpretará
              la propiedad CommandText */
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            //add agrega el nombre del parametro y tipo de dato
            //MySqlDbType especifica el tipo de dato de un campo.
            objSelectCmd.Parameters.Add("id", MySqlDbType.Int32).Value = _id;

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