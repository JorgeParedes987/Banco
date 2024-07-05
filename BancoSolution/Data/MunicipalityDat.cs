using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class MunicipalityDat

    {
        public DataSet showMunicipalyDDl()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet(); //clase que contiene una colección de tablas
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            /*CommandText Es una propiedad que establece la
            instrucción SQL para ejecutar en el origen de datos.*/
            objSelectCmd.CommandText = "spShowMunicipalyDDL";//nombre del procedimiento 
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

        Persistence objPer = new Persistence();

        //metodo mostrar depto
        //MySqlDataAdapter Es una clase que proporciona un medio para leer
        /*MySqlCommand Es una clase que representa una
                instrucción SQL para ejecutar en una base de datos MySQL*/
        public DataSet showMunicipality()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet(); //clase que contiene una colección de tablas
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            /*CommandText Es una propiedad que establece la
            instrucción SQL para ejecutar en el origen de datos.*/
            objSelectCmd.CommandText = "spShowMunicipality";//nombre del procedimiento 
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

        //metodo agregar municipio
        public bool saveMunicipality(string _nombre, string _codPost, string _divPost, int _fkdepto)

        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spCreateMunicipality";//nombre del procedimiento
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            //add agrega el nombre del parametro y tipo de dato
            //MySqlDbType especifica el tipo de dato de un campo.
            objSelectCmd.Parameters.Add("nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("codigo_postal", MySqlDbType.VarString).Value = _codPost;
            objSelectCmd.Parameters.Add("division_postal", MySqlDbType.VarString).Value = _divPost;
            objSelectCmd.Parameters.Add("fk_dpto", MySqlDbType.Int32).Value = _fkdepto;

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

        //metodo actualizar municipio
        public bool updateMunicipality(int _id, string _nombre, string _codPost, string _divPost, int _fkdepto)


        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateMunicipaly";//nombre del procedimiento
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            //add agrega el nombre del parametro y tipo de dato
            //MySqlDbType especifica el tipo de dato de un campo.
            objSelectCmd.Parameters.Add("id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("codigo_postal", MySqlDbType.VarString).Value = _codPost;
            objSelectCmd.Parameters.Add("division_postal", MySqlDbType.VarString).Value = _divPost;
            objSelectCmd.Parameters.Add("fk_dpto", MySqlDbType.Int32).Value = _fkdepto;
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

        //metodo borrar municipio

        public bool deleteMunicipality(int _id)

        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spDropMunicipaly";//nombre del procedimiento
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