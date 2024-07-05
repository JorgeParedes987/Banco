using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logica
{
    public class ClientLog
    {
        ClientDat objCt = new ClientDat();

        /*
        * Mostrar categoria Cliente
        */
        public DataSet showClient()
        {
            return objCt.showClient();
        }
        public DataSet showClientDDL()
        {
            return objCt.showClientDDL();
        }
        public DataSet selectClient()
        {
            return objCt.selectClient();
        }

        /*
        * insertar categoria Cliente
        */
        public bool saveClient(string _nombreCliente, string _apellidoCliente, DateTime _fechanacimientoCliente, string _telefonoCliete, string _correoCliente, int _fkSucIdSucursal)
        {
            return objCt.saveClient(_nombreCliente, _apellidoCliente, _fechanacimientoCliente, _telefonoCliete, _correoCliente, _fkSucIdSucursal);
        }

        /*
        * actualizar categoría Cliente.
        */
        public bool updateClient(int _idCliente, string _nombreCliente, string _apellidoCliente, DateTime _fechanacimientoCliente, string _telefonoCliete, string _correoCliente, int _fkSucIdSucursal)
        {
            return objCt.updateClient(_idCliente, _nombreCliente, _apellidoCliente, _fechanacimientoCliente, _telefonoCliete, _correoCliente, _fkSucIdSucursal); 
        }

        /*
        * eliminar categoría Cliente
        */
        public bool dropClient(int _idCliente)
        {
            return objCt.dropClient(_idCliente);
        }

    }
}