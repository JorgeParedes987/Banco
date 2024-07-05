<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFProduct.aspx.cs" Inherits="Presentacion.WFProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <br />
        <br />
        <h1>Registro Producto</h1>

        <asp:Label ID="Label4" runat="server" Text="Id producto : "></asp:Label>
        <asp:TextBox ID="PDIdPro" runat="server" Visible="true" Enabled="false"></asp:TextBox>  
        <asp:Label ID="Label1" runat="server" Text="Tipo de producto: "></asp:Label>
        <asp:TextBox ID="PDTipoPro" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Ingrese numero de cuenta: "></asp:Label>
        <asp:TextBox ID="PDNumCta" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Monto de la apertura: "></asp:Label>
        <asp:TextBox ID="PDMonAp" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Saldo de la cuenta: "></asp:Label>
        <asp:TextBox ID="PDSalCu" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Fecha de apertura: "></asp:Label>
        <asp:TextBox ID="PDAper" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label ID="Label5" runat="server" Text="Sals: Seleccione cliente: "></asp:Label>
        <asp:DropDownList ID="DDLClient" runat="server" CssClass="form-control"></asp:DropDownList>
        <br />
        <br />

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
        <asp:GridView ID="GVProduct" runat="server" CssClass="table table-hover" 
            OnSelectedIndexChanged="GVProduct_SelectedIndexChanged" AutoGenerateColumns="false"
            DataKeyNames="prod_id" OnRowDeleting="GVProd_RowDeleting">
            <columns>
                <asp:BoundField DataField="prod_id" HeaderText="Id" />
                <asp:BoundField DataField="prod_tipo" HeaderText="Tipo" />
                <asp:BoundField DataField="prod_num_cuenta" HeaderText="Numero de cuenta" />
                <asp:BoundField DataField="prod_monto_apertura" HeaderText="Monto apertura" />
                <asp:BoundField DataField="prod_saldo" HeaderText="Saldo" />
                <asp:BoundField DataField="prod_fecha_apertura" HeaderText="Fecha de apertura" />
                <asp:BoundField DataField="Cliente_clien_id" HeaderText="fkclienIdCliente" />
                <asp:BoundField DataField="clien_nombre" HeaderText="clien" />
                 <asp:CommandField ShowSelectButton="true" />
                <asp:CommandField ShowDeleteButton="true" />

             </Columns>
             </asp:GridView>
         </div>
</asp:Content>
