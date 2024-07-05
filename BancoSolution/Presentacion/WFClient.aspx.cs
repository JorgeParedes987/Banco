using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class WFClient : System.Web.UI.Page
    {
        ProductLog objPdt = new ProductLog();
        ClientLog objCt = new ClientLog();
        private string _nombreCliente, _apellidoCliente, _telefonoCliete, _correoCliente;
        private DateTime _fechanacimientoCliente;
        private int _idCliente, _fkSucIdSucursal;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CTIdClien.Visible = false;
                showClient();
            }
        }

        /*
        * Metodo para mostrar todos los proveedores
        */
        private void showClient()
        {

            DataSet objData = new DataSet();
            objData = objCt.showClient();
            GVClient.DataSource = objData;
            GVClient.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _nombreCliente = CTNom.Text;
            _apellidoCliente = CTApe.Text;
            _fechanacimientoCliente = Convert.ToDateTime(CTFecna.Text);
            _telefonoCliete = CTTel.Text;
            _correoCliente = CTCorr.Text;
            _fkSucIdSucursal = Convert.ToInt32(DDLClient.Text);

            executed = objCt.saveClient(_nombreCliente, _apellidoCliente, _fechanacimientoCliente, _telefonoCliete, _correoCliente, _fkSucIdSucursal);
            if (executed)
            {
                LblMsj.Text = "Se guardo exitosamente";
                showClient();//Se invoca de nuevo el metodo para mostrar los productos guardados
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idCliente = Convert.ToInt32(CTIdClien.Text);
            _nombreCliente = CTNom.Text;
            _apellidoCliente = CTApe.Text;
            _fechanacimientoCliente = Convert.ToDateTime(CTFecna.Text);
            _telefonoCliete = CTTel.Text;
            _correoCliente = CTCorr.Text;
            _fkSucIdSucursal = Convert.ToInt32(DDLClient.Text);

            executed = objCt.updateClient(_idCliente, _nombreCliente, _apellidoCliente, _fechanacimientoCliente, _telefonoCliete, _correoCliente, _fkSucIdSucursal);
            if (executed)
            {
                LblMsj.Text = "Se actualizo exitosamente";
                showClient();//Se invoca de nuevo el metodo para mostrar los proveedores actualizados
            }
            else
            {
                LblMsj.Text = "Error al actualizar";
            }
        }

        /*
        * Evento que se ejecuta cuando se presiona el link seleccionar.
        * Toma el valor de cada celda de una fila de la tabla, comenzando en 0
        */
        protected void GVClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            CTIdClien.Text = GVClient.SelectedRow.Cells[0].Text;
            CTNom.Text = GVClient.SelectedRow.Cells[1].Text;
            CTApe.Text = GVClient.SelectedRow.Cells[2].Text;
            CTFecna.Text = GVClient.SelectedRow.Cells[3].Text;
            CTTel.Text = GVClient.SelectedRow.Cells[4].Text;
            CTCorr.Text = GVClient.SelectedRow.Cells[5].Text;
            DDLClient.SelectedValue = GVClient.SelectedRow.Cells[6].Text;
        }

        protected void GVClien_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idproducto = Convert.ToInt32(GVClient.DataKeys[e.RowIndex].Values[0]);
            executed = objPdt.dropProduct(_idproducto);


            if (executed)
            {
                LblMsj.Text = "El producto se elimino exitosamente";
                GVClient.EditIndex = -1;//Quita la fila eliminada de la tabla
                showClient();//Muestra los productos actualizados
            }
            else
            {
                LblMsj.Text = "Error al eliminar el producto";
            }
        }
    }
}