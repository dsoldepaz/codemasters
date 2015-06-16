<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormUsuario.aspx.cs" Inherits="Servicios_Reservados_2.FormRegistro" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <legend>
                <h2>Administración de usuarios</h2>
            </legend>

            <div class="well bs-component">
                <legend style="color: #7BC143">Filtro de usuarios</legend>

            </div>
            <div class="well bs-component">
                <legend style="color: #7BC143">Agregar</legend>

            </div>
            <div class="well bs-component">
                <legend style="color: #7BC143">Listado de usuarios</legend>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
