using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logica
{
    public class BankLog
    {
        BankDat objBank = new BankDat();
        public DataSet showBanco()
        {
            return objBank.showBanco();
        }
        public bool saveBanco(string _nameBanco, string _direccionBanco, string _telefonoBanco)
        {
            return objBank.saveBanco(_nameBanco, _direccionBanco, _telefonoBanco);
        }
        public bool updateBanco(int _id, string _nameBanco, string _direccionBanco, string _telefonoBanco)
        {
            return objBank.updateBanco(_id, _nameBanco, _direccionBanco, _telefonoBanco);
        }
        public bool deleteBanco(int _id)
        {
            return objBank.deleteBanco(_id);
        }

    }
}