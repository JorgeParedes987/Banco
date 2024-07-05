using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Logica
{
    public class ProductLog
    {
        ProductDat objPt = new ProductDat();

        /*
        * Mostrar categoria Cliente
        */
        public DataSet showProduct()
        {
            return objPt.showProduct();
        }

        public DataSet selectClient()
        {
            return objPt.selectClient();
        }
        /*
        * insertar categoria Cliente
        */
        public bool saveProduct(char _tipoProducto, int _numProducto, string _montoaperturaProducto, int _saldoProducto, DateTime _fechaaperturaProducto, int _fkclienIdCliente)
        {
            return objPt.saveProduct(_tipoProducto, _numProducto, _montoaperturaProducto, _saldoProducto, _fechaaperturaProducto, _fkclienIdCliente);
        }

        /*
        * actualizar categoría Cliente.
        */
        public bool updateProduct(int _idproducto, char _tipoProducto, int _numProducto, string _montoaperturaProducto, int _saldoProducto, DateTime _fechaaperturaProducto, int _fkclienIdCliente)
        {
            return objPt.updateProduct(_idproducto, _tipoProducto, _numProducto, _montoaperturaProducto, _saldoProducto, _fechaaperturaProducto, _fkclienIdCliente);
        }

        /*
        * eliminar categoría Cliente
        */
        public bool dropProduct(int _idproducto)
        {
            return objPt.dropProduct(_idproducto);
        }

    }
}