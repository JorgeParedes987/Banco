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
    public partial class WFDepartment : System.Web.UI.Page
    {
        DepartmentLog objDept = new DepartmentLog();
        private string _nombre, _codPost;
        private int _id, _poblacion;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showDepartment();//Se invoca el metodo mostrar depto
            }
        }

        private void showDepartment()
        {
            DataSet objData = new DataSet();
            objData = objDept.showDepartment();
            GVDepto.DataSource = objData;
            GVDepto.DataBind();

        }

        protected void BtnSaveDepto_Click(object sender, EventArgs e)
        {
            _nombre = TBNombreDep.Text;
            _codPost = TBCodPostDepto.Text;
            _poblacion = Convert.ToInt32(TBPoblaDepto.Text);

            executed = objDept.saveDepartment(_nombre, _codPost, _poblacion);
            if (executed)
            {
                LblMsj.Text = "se Guardo exitosamente Depto";
                showDepartment();

            }
            else
            {
                LblMsj.Text = "ERROR! No Guardo Depto";
            }

        }
        protected void BtnUpdateDepto_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(TBId.Text);
            _nombre = TBNombreDep.Text;
            _codPost = TBCodPostDepto.Text;
            _poblacion = Convert.ToInt32(TBPoblaDepto.Text);

            executed = objDept.updateDepartment(_id, _nombre, _codPost, _poblacion);

            if (executed)
            {
                LblMsj.Text = "se Actualizó exitosamente Depto";
                showDepartment();

            }
            else
            {
                LblMsj.Text = "ERROR! No Actualizó Depto";
            }
        }
        protected void GVDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBId.Text = GVDepto.SelectedRow.Cells[0].Text;
            TBNombreDep.Text = GVDepto.SelectedRow.Cells[1].Text;
            TBCodPostDepto.Text = GVDepto.SelectedRow.Cells[2].Text;
            TBPoblaDepto.Text = GVDepto.SelectedRow.Cells[3].Text;

        }
        protected void GVDepto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int _id = Convert.ToInt32(GVDepto.DataKeys[e.RowIndex].Values[0]);
            executed = objDept.deleteDepartment(_id);
            if (executed)
            {
                LblMsj.Text = "El departamento se elimino exitosamente";
                GVDepto.EditIndex = -1;//Quita la fila eliminada de la tabla
                showDepartment();//Muestra los deptos actualizados
            }
            else
            {
                LblMsj.Text = "ERROR! al eliminar el departamento";
            }

        }
        protected void BtnClear_Click(object sender, EventArgs e)
        {
            //limpiar textbox
            TBId.Text = " ";
            TBNombreDep.Text = " ";
            TBCodPostDepto.Text = " ";
            TBPoblaDepto.Text = " ";

        }
    }
}