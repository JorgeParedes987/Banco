<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeFile="WFBank.aspx.cs" Inherits="Presentacion.WFBank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <br />
        <br />
        <h1>Registro Banco</h1>

        <asp:Label ID="Label4" runat="server" Text="Id banco : "></asp:Label>
        <asp:TextBox ID="BkIdBan" runat="server" Visible="true" Enabled="false"></asp:TextBox>  
        <asp:Label ID="Label1" runat="server" Text="Nombre del banco: "></asp:Label>
        <asp:TextBox ID="BkNom" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="direccion: "></asp:Label>
        <asp:TextBox ID="BkDire" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="telefono del banco: "></asp:Label>
        <asp:TextBox ID="BkTel" runat="server" CssClass="form-control"></asp:TextBox>
     
        <asp:Button ID="BtnSaveMun" runat="server" Text="Guardar" />
        <br />
        <br />
        <asp:Button ID="BtnUpdateMun" runat="server" Text="Actualizar"/>
        <br />
        <br />
        <asp:Button ID="BtnClear" runat="server" Text="Limpiar"/>
        <br /> <br />
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        </div>
    <div>
        <asp:GridView ID="GVBank" runat="server" CssClass="table table-hover" 
            OnSelectedIndexChanged="GVBank_SelectedIndexChanged" AutoGenerateColumns="false"
            DataKeyNames="banc_id" OnRowDeleting="GVBanc_RowDeleting">
            <columns>
                <asp:BoundField DataField="banc_id" HeaderText="Id" />
                <asp:BoundField DataField="banc_nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="banc_direccion" HeaderText="direccion" />
                <asp:BoundField DataField="banc_telefono" HeaderText="Telefono" />
  
                 <asp:CommandField ShowSelectButton="true" />
                <asp:CommandField ShowDeleteButton="true" />

             </Columns>
             </asp:GridView>
         </div>
</asp:Content>
