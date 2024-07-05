using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class WFBank : System.Web.UI.Page
    {
        BankLog objBak = new BankLog();
        private int _id;
        private string _nameBanco, _direccionBanco, _telefonoBanco;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BkIdBan.Visible = false;
                showBanco();

            }
        }
        private void showBanco()
        {
            DataSet objData = objBak.showBanco();
            GVBank.DataSource = objData;
            GVBank.DataBind();
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nameBanco = BkNom.Text;
            _direccionBanco = BkDire.Text;
            _telefonoBanco = BkTel.Text;

            executed = objBak.saveBanco(_nameBanco, _direccionBanco, _telefonoBanco);
            if (executed)
            {
                LblMsj.Text = "Se guardo exitosamente";
                showBanco();//Se invoca de nuevo el metodo para mostrar los productos guardados
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(BkIdBan.Text);
            _nameBanco = BkNom.Text;
            _direccionBanco = BkDire.Text;
            _telefonoBanco = BkTel.Text;
            executed = objBak.updateBanco(_id, _nameBanco, _direccionBanco, _telefonoBanco);
            if (executed)
            {
                LblMsj.Text = "Se actualizo exitosamente";
                showBanco();//Se invoca de nuevo el metodo para mostrar los proveedores actualizados
            }
            else
            {
                LblMsj.Text = "Error al actualizar";
            }
        }
        protected void GVBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            BkIdBan.Text = GVBank.SelectedRow.Cells[0].Text;
            BkNom.Text = GVBank.SelectedRow.Cells[1].Text;
            BkDire.Text = GVBank.SelectedRow.Cells[2].Text;
            BkTel.Text = GVBank.SelectedRow.Cells[3].Text;
        }
        protected void GVBanc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _id = Convert.ToInt32(GVBank.DataKeys[e.RowIndex].Values[0]);
            executed = objBak.deleteBanco(_id);


            if (executed)
            {
                LblMsj.Text = "El producto se elimino exitosamente";
                GVBank.EditIndex = -1;//Quita la fila eliminada de la tabla
                showBanco();//Muestra los productos actualizados
            }
            else
            {
                LblMsj.Text = "Error al eliminar el producto";
            }
        }
    }
}
