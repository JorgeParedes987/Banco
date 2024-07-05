using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logica
{
    public class SubsidiaryLog
    {
        SubsidiaryDate objSucur = new SubsidiaryDate();
        public DataSet showSucursal()
        {
            return objSucur.showSucursal();
        }
        public bool saveSucursal(string _nameSucursal, string _direccionSucursal, string telefonoSucursal, int _FkllaveBanco, int _FkllaveMunicipio)
        {
            return objSucur.saveSucursal(_nameSucursal, _direccionSucursal, telefonoSucursal, _FkllaveBanco, _FkllaveMunicipio);
        }
        public bool updateSucursal(int _id, string _nameSucursal, string _direccionSucursal, string telefonoSucursal, int _FkllaveBanco, int _FkllaveMunicipio)
        {
            return objSucur.updateSucursal(_id, _nameSucursal, _direccionSucursal, telefonoSucursal, _FkllaveBanco, _FkllaveMunicipio);
        }
        public bool deleteSucursal(int _id)
        {
            return objSucur.deleteSucursal(_id);
        }
        public DataSet showSucursalDDL()
        {
            return objSucur.showSucursalDDL();
        }
    }
}