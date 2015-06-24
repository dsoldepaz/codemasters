<%@ Page Title="Reestablecer Contraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormReestablecer.aspx.cs" Inherits="Servicios_Reservados_2.FormReestablecer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="well bs-component" >
            <legend style="color: #7BC143">Reestablecer contraseña</legend>
            <p>Su nueva contraseña debe contener: al menos una letra mayúscula, al menos 8 caracteres y al menos un numero. Ej: codeMasters9001</p>
                    <h5>Nueva contraseña:</h5>           
                    <asp:TextBox ID="txtContraseña" TextMode="Password" runat="server"></asp:TextBox>           
                    <asp:Button id="btnReestablecer" class="btn btn-success" runat="server" Text="Aceptar" OnClick="clickReestablecer"/> 
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="#996600"></asp:Label>
             </div>
</asp:Content>
