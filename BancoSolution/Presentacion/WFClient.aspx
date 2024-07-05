<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFClient.aspx.cs" Inherits="Presentacion.WFClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <br />
        <br />
        <br />
        <h1>Registro Cliente</h1>

        <asp:Label ID="Label4" runat="server" Text="Id cliente : "></asp:Label>
        <asp:TextBox ID="CTIdClien" runat="server" Visible="true" Enabled="false"></asp:TextBox>  
        <asp:Label ID="Label1" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="CTNom" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="CTApe" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Fecha de nacimiento: "></asp:Label>
        <asp:TextBox ID="CTFecna" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="telefono: "></asp:Label>
        <asp:TextBox ID="CTTel" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="correo: "></asp:Label>
        <asp:TextBox ID="CTCorr" runat="server" CssClass="form-control"></asp:TextBox>

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
        <asp:GridView ID="GVClient" runat="server" CssClass="table table-hover" 
            OnSelectedIndexChanged="GVClient_SelectedIndexChanged" AutoGenerateColumns="false"
            DataKeyNames="clien_id" OnRowDeleting="GVClien_RowDeleting">
            <columns>
                <asp:BoundField DataField="clien_id" HeaderText="Id" />
                <asp:BoundField DataField="clien_nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="clien_apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="clien_fecha_nacimiento" HeaderText="Fecha de nacimiento" />
                <asp:BoundField DataField="clien_tel" HeaderText="Telefono" />
                <asp:BoundField DataField="clien_correo" HeaderText="Correo" />
  
                 <asp:CommandField ShowSelectButton="true" />
                <asp:CommandField ShowDeleteButton="true" />

             </Columns>
             </asp:GridView>
         </div>
</asp:Content>
