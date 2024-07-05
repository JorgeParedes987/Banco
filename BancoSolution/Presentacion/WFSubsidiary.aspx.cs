
using Logica;
using Presentacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFSubsidiary : System.Web.UI.Page
    {
        SubsidiaryLog objSubsidiary = new SubsidiaryLog();
        BankLog objBank = new BankLog();


        private string _nameSucursal, _direccionSucursal, telefonoSucursal;
        private int _id, _FkllaveBanco, _FkllaveMunicipio;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                showSucursal();
                showBancoDDL();
            }
        }
        private void showSucursal()
        {
            DataSet objData = new DataSet();
            objData = objSubsidiary.showSucursal();
            GVSubsidiary.DataSource = objData;
            GVSubsidiary.DataBind();

        }
        private void showBancoDDL()
        {
            DDLBank.DataSource = objBank.showBanco();
            DDLBank.DataValueField = "banc_id";
            DDLBank.DataValueField = "banc_nombre";
            DDLBank.DataBind();
            DDLBank.Items.Insert(0, "Seleccione");
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nameSucursal = BTNombre.Text;
            _direccionSucursal = BTDireccion.Text;
            telefonoSucursal = BTTelefono.Text;
            _FkllaveBanco = Convert.ToInt32(DDLBank.SelectedValue);
            _FkllaveMunicipio = Convert.ToInt32(DDLBank.SelectedValue);
            executed = objSubsidiary.saveSucursal(_nameSucursal, _direccionSucursal, telefonoSucursal, _FkllaveBanco, _FkllaveMunicipio);
            if (executed)
            {
                LblMsj.Text = "Se guardo exitosamente ";
                showSucursal();
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(BTId);
            _nameSucursal = BTNombre.Text;
            _direccionSucursal = BTDireccion.Text;
            telefonoSucursal = BTTelefono.Text;
            _FkllaveBanco = Convert.ToInt32(DDLBank.SelectedValue);
            _FkllaveMunicipio = Convert.ToInt32(DDLBank.SelectedValue);
            executed = objSubsidiary.saveSucursal(_nameSucursal, _direccionSucursal, telefonoSucursal, _FkllaveBanco, _FkllaveMunicipio);
            if (executed)
            {
                LblMsj.Text = "Se actualizo correctamente";
                showSucursal();
            }
            else
            {
                LblMsj.Text = "Error al Actualizar";
            }

        }
        protected void GVSubsidiary_SelectedIndexChanged(object sender, EventArgs e)
        {
            BTId.Text = GVSubsidiary.SelectedRow.Cells[1].Text;
            BTNombre.Text = GVSubsidiary.SelectedRow.Cells[2].Text;
            BTDireccion.Text = GVSubsidiary.SelectedRow.Cells[3].Text;
            BTTelefono.Text = GVSubsidiary.SelectedRow.Cells[4].Text;
            DDLBank.SelectedValue = GVSubsidiary.SelectedRow.Cells[5].Text;
            DDLMnicipality.SelectedValue = GVSubsidiary.SelectedRow.Cells[6].Text;

        }

        protected void DDLBank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}