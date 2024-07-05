using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logica
{
    public class MunicipalityLog
    {
        //Se crea una instancia de la clase MunicipalityDat de la capa Data
        MunicipalityDat objMun = new MunicipalityDat();
        /*Método de tipo DataSet, que
         * retorna un conjunto de datos con todas los municipios*/
        public DataSet showMunicipality()
        {
            return objMun.showMunicipality();
        }
        /*Método de tipo booleano, que recibe como parámetro id,nombre,_codPost,_divPost y _fkdepto y
         * retorna true si se guardo el nuevo municipio*/
        public bool saveMunicipality(string _nombre, string _codPost, string _divPost, int _fkdepto)
        {
            return objMun.saveMunicipality(_nombre, _codPost, _divPost, _fkdepto);
        }
        /*Método de tipo booleano, que recibe como parámetro llave primaria id y los 
         * otros atributos como nombre,_codPost,_divPost y _fkdepto y
         * retorna true si se actualizo el nuevo municipio*/
        public bool updateMunicipality(int _id, string _nombre, string _codPost, string _divPost, int _fkdepto)
        {
            return objMun.updateMunicipality(_id, _nombre, _codPost, _divPost, _fkdepto);
        }
        /*Método de tipo booleano, que recibe como parámetro la llave primaria id
         * y retorna true si se elimino el registro del municipio*/
        public bool deleteMunicipality(int _id)
        {
            return objMun.deleteMunicipality(_id);
        }
    }
}