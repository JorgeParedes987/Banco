<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeFile="WFSubsidiary.aspx.cs" Inherits="Presentation.WFSubsidiary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>INGRESO DE DATOS DE SUCURSAL</h1>
<div>
    <%--ID de sucursal--%>
    <asp:TextBox ID="BTId" runat="server" Visible="false"></asp:TextBox><br />
<%--    Nombre de sucursal--%>
    <asp:Label ID="Label1" runat="server" Text="Ingrese el nombre de la sucursal"></asp:Label>
    <asp:TextBox ID="BTNombre" runat="server"></asp:TextBox><br />
  
    <%--    Direcion de sucursal--%>
    <asp:Label ID="Label2" runat="server" Text="Ingrese la direccion de la sucursal"></asp:Label>
    <asp:TextBox ID="BTDireccion" runat="server"></asp:TextBox><br />
 
    <%-- Telefono de sucursal--%>
    <asp:Label ID="Label3" runat="server" Text="Ingrese el telefono de la sucursal"></asp:Label>
    <asp:TextBox ID="BTTelefono" runat="server"></asp:TextBox><br />

<%--    llave foranea de banco--%>
     <asp:Label ID="Label4" runat="server" Text="Seleccione el  banco"></asp:Label>
      <asp:DropDownList ID="DDLBank" runat="server"  CssClass="form-control"></asp:DropDownList><br />
     <%--llave foranea de Municipio--%>
     <asp:Label ID="Label5" runat="server" Text="Ingrese el  Id del Municipio"></asp:Label>
    <asp:DropDownList ID="DDLMnicipality" runat="server"  CssClass="form-control"></asp:DropDownList><br />

</div> 
    <div>
<%--        Se coloca los botones de guardar y actualizar--%>
        <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" /><br />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        
    </div> 
    <div>
        <asp:GridView ID="GVSubsidiary" runat="server" CssClass="table table-hover" OnRowDataBound="GVSubsidiary_RowDataBound"
            OnSelectedIndexChanged="GVSubsidiary_SelectedIndexChanged" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="suc_id" HeaderText="id" />
                  <asp:BoundField DataField="suc_nombre" HeaderText="Nombre" />
                  <asp:BoundField DataField="suc_direccion" HeaderText="Direccion" />
                  <asp:BoundField DataField="suc_tel" HeaderText="Telefono" />
                <asp:BoundField DataField="Banco_banc_id" HeaderText="Id de Banco" />
                <asp:BoundField DataField="Municipio_muni_id" HeaderText="Id de Municipio" />
                <asp:CommandField ShowSelectButton="true" />

            </Columns>

        </asp:GridView>
    </div>
</asp:Content>
