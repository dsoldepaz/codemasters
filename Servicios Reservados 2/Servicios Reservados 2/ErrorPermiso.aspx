<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorPermiso.aspx.cs" Inherits="Servicios_Reservados_2.ErrorPermiso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <nav>
        <ul>
            <li class="item-navegacion"><a href="Default.aspx" title="Página principal"><i class="glyphicon glyphicon-home"></i></a></li>           
            <li class="item-navegacion"><a href="Notificaciones.aspx" title="Notificaciones">Notificaciones <span class="notificacion" id="contador" runat="server">0</span></a></li>
        </ul>
    </nav>
     <div class="jumbotron">
        <div class="container">
            <h1>Oops! no deberías estar aquí</h1>
            <p>Redireccionando a la página principal...</p>
        </div>
    </div>
    

</asp:Content>
