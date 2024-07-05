using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logica
{
    public class DepartmentLog
    {
        //Se crea una instancia de la clase DepartmentDat de la capa Data
        DepartmentDat objDept = new DepartmentDat();
        /*Método de tipo DataSet, que
         * retorna un conjunto de datos con todas los dptos*/
        public DataSet showDepartment()
        {
            return objDept.showDepartment();
        }
        /*Método de tipo booleano, que recibe como parámetro id,nombre,vod_post,poblacion y
         * retorna true si se guardo el nuevo depto*/
        public bool saveDepartment(string _nombre, string _codPost, int _poblacion)
        {
            return objDept.saveDepartment(_nombre, _codPost, _poblacion);
        }
        /*Método de tipo booleano, que recibe como parámetro llave primaria id y los 
         * otros atributos como nombre,vod_post,poblacion y
         * retorna true si se actualizo el nuevo depto*/
        public bool updateDepartment(int _id, string _nombre, string _codPost, int _poblacion)
        {
            return objDept.updateDepartment(_id, _nombre, _codPost, _poblacion);
        }
        /*Método de tipo booleano, que recibe como parámetro la llave primaria id
         * y retorna true si se elimino el registro del depto*/
        public bool deleteDepartment(int _id)
        {
            return objDept.deleteDepartment(_id);
        }
    }
}