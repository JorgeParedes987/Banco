using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class WFProduct : System.Web.UI.Page
    {
        ProductLog objPdt = new ProductLog();
        ClientLog objCt = new ClientLog();
        private string _montoaperturaProducto;
        private DateTime _fechaaperturaProducto;
        private char _tipoProducto;
        private int _idproducto, _saldoProducto, _numProducto, _fkclienIdCliente;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PDIdPro.Visible = false;
                showProduct();
                showClientDDL();
            }
        }

        /*
        * Metodo para mostrar todos los proveedores
        */
        private void showProduct()
        {
            DataSet objData = objPdt.showProduct();
            GVProduct.DataSource = objData;
            GVProduct.DataBind();
        }
        private void showClientDDL()
        {
            DDLClient.DataSource = objCt.showClient();
            DDLClient.DataValueField = "clien_id";//solo guarda el valor del id
            DDLClient.DataTextField = "clien_nombre";// solo muestra el nombre
            DDLClient.DataBind();
            DDLClient.Items.Insert(0, "seleccione");
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _tipoProducto = Convert.ToChar(PDTipoPro.Text);
            _numProducto = Convert.ToInt32(PDNumCta.Text);
            _montoaperturaProducto = PDMonAp.Text;
            _saldoProducto = Convert.ToInt32(PDSalCu.Text);
            _fechaaperturaProducto = Convert.ToDateTime(PDAper.Text);
            _fkclienIdCliente = Convert.ToInt32(DDLClient.SelectedValue);

            executed = objPdt.saveProduct(_tipoProducto, _numProducto, _montoaperturaProducto, _saldoProducto, _fechaaperturaProducto, _fkclienIdCliente);
            if (executed)
            {
                LblMsj.Text = "Se guardo exitosamente";
                showProduct();//Se invoca de nuevo el metodo para mostrar los productos guardados
            }
            else
            {
                LblMsj.Text = "Error al guardar";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _idproducto = Convert.ToInt32(PDIdPro.Text);
            _tipoProducto = Convert.ToChar(PDTipoPro.Text);
            _numProducto = Convert.ToInt32(PDNumCta.Text);
            _montoaperturaProducto = PDMonAp.Text;
            _saldoProducto = Convert.ToInt32(PDSalCu.Text);
            _fechaaperturaProducto = Convert.ToDateTime(PDAper.Text);
            _fkclienIdCliente = Convert.ToInt32(DDLClient.SelectedValue);
            executed = objPdt.updateProduct(_idproducto, _tipoProducto, _numProducto, _montoaperturaProducto, _saldoProducto, _fechaaperturaProducto, _fkclienIdCliente);
            if (executed)
            {
                LblMsj.Text = "Se actualizo exitosamente";
                showProduct();//Se invoca de nuevo el metodo para mostrar los proveedores actualizados
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
        protected void GVProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            PDIdPro.Text = GVProduct.SelectedRow.Cells[0].Text;
            PDTipoPro.Text = GVProduct.SelectedRow.Cells[1].Text;
            PDNumCta.Text = GVProduct.SelectedRow.Cells[2].Text;
            PDMonAp.Text = GVProduct.SelectedRow.Cells[3].Text;
            PDSalCu.Text = GVProduct.SelectedRow.Cells[4].Text;
            PDAper.Text = GVProduct.SelectedRow.Cells[5].Text;
            DDLClient.SelectedValue = GVProduct.SelectedRow.Cells[6].Text;
        }

        protected void GVProd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int _idproducto = Convert.ToInt32(GVProduct.DataKeys[e.RowIndex].Values[0]);
            executed = objPdt.dropProduct(_idproducto);


            if (executed)
            {
                LblMsj.Text = "El producto se elimino exitosamente";
                GVProduct.EditIndex = -1;//Quita la fila eliminada de la tabla
                showProduct();//Muestra los productos actualizados
            }
            else
            {
                LblMsj.Text = "Error al eliminar el producto";
            }
        }
    }
}