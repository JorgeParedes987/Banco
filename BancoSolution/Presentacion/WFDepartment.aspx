<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeFile="WFDepartment.aspx.cs" Inherits="Presentacion.WFDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br /><br /><br />
        <h1>Registro Departamentos</h1>
       
         <asp:Label ID="Label4" runat="server" Text="Id depto : "></asp:Label>
        <asp:TextBox ID="TBId" runat="server" Visible="true" Enabled="false"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="Ingrese el Nombre : "></asp:Label>
        <asp:TextBox ID="TBNombreDep" runat="server" CssClass="form-control"> </asp:TextBox>
        <br /><br />
        <asp:Label ID="Label2" runat="server" Text="Ingrese codigo postal : "></asp:Label>
        <asp:TextBox ID="TBCodPostDepto" runat="server" CssClass="form-control"> </asp:TextBox>
        <br /><br />
        <asp:Label ID="Label3" runat="server" Text="Ingrese la población : "></asp:Label>
        <asp:TextBox ID="TBPoblaDepto" runat="server" CssClass="form-control"> </asp:TextBox>
        <br /><br />

        <asp:Button ID="BtnSaveDepto" runat="server" Text="Guardar"  OnClick="BtnSaveDepto_Click" /><br />
        <br />
        <asp:Button ID="BtnUpdateDepto" runat="server" Text="Actualizar"  OnClick="BtnUpdateDepto_Click" />
        <br /><br />
         <asp:Button ID="BtnClear" runat="server" Text="Limpiar"  OnClick="BtnClear_Click" />
        <br /> <br />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br /><br /><br />
        </div>
    <div>
        <asp:GridView ID="GVDepto" runat="server" CssClass=" table table-hover" AutoGenerateColumns="False" 
            OnSelectedIndexChanged="GVDepto_SelectedIndexChanged" DataKeyNames="depto_id"
            OnRowDeleting="GVDepto_RowDeleting">
           <columns>
                <asp:BoundField DataField="depto_id" HeaderText="Id" />
                <asp:BoundField DataField="depto_nombre" HeaderText="Depto" />
                <asp:BoundField DataField="depto_cod_post" HeaderText="Cod Postal" />
                <asp:BoundField DataField="depto_poblacion" HeaderText="poblacion" />

               <asp:CommandField ShowSelectButton="true" />
                <asp:CommandField ShowDeleteButton="true" />

            </columns>
        </asp:GridView>
    </div>
</asp:Content>
