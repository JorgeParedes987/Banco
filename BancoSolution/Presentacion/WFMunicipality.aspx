<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFMunicipality.aspx.cs" Inherits="Presentacion.WFMunicipality" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <br />
        <br />
        <h1>Registro Municipio</h1>

        <asp:Label ID="Label4" runat="server" Text="Id Municipio : "></asp:Label>
        <asp:TextBox ID="TBIdMun" runat="server" Visible="true" Enabled="false"></asp:TextBox>  
        <asp:Label ID="Label1" runat="server" Text="Ingrese el Nombre : "></asp:Label>
        <asp:TextBox ID="TBNombreMun" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Ingrese codigo postal : "></asp:Label>
        <asp:TextBox ID="TBCodPostMun" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Ingrese la división postal : "></asp:Label>
        <asp:TextBox ID="TBDivPosMun" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Seleccione Departamento: "></asp:Label>
        <asp:DropDownList ID="DDLDepartment" runat="server" CssClass="form-control"></asp:DropDownList>
        <br />
        <br />

        <asp:Button ID="BtnSaveMun" runat="server" Text="Guardar" OnClick="BtnSaveMun_Click" />
        <br />
        <br />
        <asp:Button ID="BtnUpdateMun" runat="server" Text="Actualizar" OnClick="BtnUpdateMun_Click" />
        <br />
        <br />
        <asp:Button ID="BtnClear" runat="server" Text="Limpiar"  OnClick="BtnClear_Click" />
        <br /> <br />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        </div>
    <div>
        <asp:GridView ID="GVMuni" runat="server" CssClass="table table-hover" 
            OnSelectedIndexChanged="GVMunicipio_SelectedIndexChanged" AutoGenerateColumns="false"
            DataKeyNames="muni_id" OnRowDeleting="GVMuni_RowDeleting">
            <columns>
                <asp:BoundField DataField="muni_id" HeaderText="Id" />
                <asp:BoundField DataField="muni_nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="muni_cod_post" HeaderText="Cod Postal Municipio" />
                <asp:BoundField DataField="muni_division_post" HeaderText="División Postal" />
                <asp:BoundField DataField="Departamento_depto_id" HeaderText="fkDepto" />


                 <asp:CommandField ShowSelectButton="true" />
                <asp:CommandField ShowDeleteButton="true" />


            </columns>
        </asp:GridView>
    </div>
</asp:Content>
