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
    public partial class WFMunicipality : System.Web.UI.Page
    {
        MunicipalityLog objMun = new MunicipalityLog();
        DepartmentLog objDept = new DepartmentLog();

        private int _id, _fkdepto;
        private string _nombre, _codPost, _divPost;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showMunicipality();
                showDepartmentDDL();
            }
        }
        private void showMunicipality()
        {
            DataSet objData = objMun.showMunicipality();
            GVMuni.DataSource = objData;
            GVMuni.DataBind(); //enlaza los datos con el servidor


        }
        private void showDepartmentDDL()
        {
            DDLDepartment.DataSource = objDept.showDepartment();
            DDLDepartment.DataValueField = "depto_id";
            DDLDepartment.DataValueField = "depto_nombre";
            DDLDepartment.DataBind();
            DDLDepartment.Items.Insert(0, "seleccione");

        }

        protected void BtnSaveMun_Click(object sender, EventArgs e)
        {
            _nombre = TBNombreMun.Text;
            _codPost = TBCodPostMun.Text;
            _divPost = TBDivPosMun.Text;
            _fkdepto = Convert.ToInt32(DDLDepartment.SelectedValue);

            executed = objMun.saveMunicipality(_nombre, _codPost, _divPost, _fkdepto);
            if (executed)
            {
                LblMsj.Text = "se Guardo exitosamente Municipio";
                showMunicipality();//Se invoca de nuevo el metodo para mostrar los municipios guardados
            }
            else
            {
                LblMsj.Text = "ERROR! No Guardó Municipio";
            }

        }
        protected void BtnUpdateMun_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(TBIdMun.Text);
            _nombre = TBNombreMun.Text;
            _codPost = TBCodPostMun.Text;
            _divPost = TBDivPosMun.Text;
            _fkdepto = Convert.ToInt32(DDLDepartment.SelectedValue);

            executed = objMun.updateMunicipality(_id, _nombre, _codPost, _divPost, _fkdepto);

            if (executed)
            {
                LblMsj.Text = "se Actualizó exitosamente Municipio";
                showMunicipality();

            }
            else
            {
                LblMsj.Text = "ERROR! No Actualizó Municipio";
            }
        }
        protected void GVMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBIdMun.Text = GVMuni.SelectedRow.Cells[0].Text;
            TBNombreMun.Text = GVMuni.SelectedRow.Cells[1].Text;
            TBCodPostMun.Text = GVMuni.SelectedRow.Cells[2].Text;
            TBDivPosMun.Text = GVMuni.SelectedRow.Cells[3].Text;
            DDLDepartment.SelectedValue = GVMuni.SelectedRow.Cells[4].Text;

        }

        protected void GVMuni_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //toma el valor de la columna con la llave primaria
            int _id = Convert.ToInt32(GVMuni.DataKeys[e.RowIndex].Values[0]);
            executed = objMun.deleteMunicipality(_id);
            if (executed)
            {
                LblMsj.Text = "El municipio se elimino exitosamente";
                GVMuni.EditIndex = -1;//Quita la fila eliminada de la tabla
                showMunicipality();//Muestra los deptos actualizados
            }
            else
            {
                LblMsj.Text = "ERROR! al eliminar el departamento";
            }

        }
        protected void BtnClear_Click(object sender, EventArgs e)
        {
            //limpiar textbox
            TBIdMun.Text = " ";
            TBNombreMun.Text = " ";
            TBCodPostMun.Text = " ";
            TBDivPosMun.Text = " ";

        }
    }
}