<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Servicios_Reservados_2._Default" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="jumbotron">
        <div class="container">
            <h1>Sistema de servicios reservados</h1>
            <p>Con este sistema podrá llevar un control de los servicios consumidos dentro de la organización</p>
        </div>
    </div>
    <table>
        <tr>
            <td>
                <div class="well bs-component" id="Recepcionista" runat="server">

                    <h2>Recepcionista</h2>
                    <p>Reserve servicios de alimentación</p>
                    <h4>
                        <a href="FormReservaciones.aspx">Reservaciones</a>
                    </h4>
                    <h4>
                        <a href="FormEmpleado.aspx">Empleados</a>
                    </h4>

                </div>
            </td>
            <td>
                <div class="well bs-component" id="Cocina" runat="server">
                    <h2>Encargado de Cocina</h2>
                    <p>Lleve el control de los servicios consumidos</p>
                    <h4>
                        <a href="FormServirPlatos.aspx">Servir platos</a>

                    </h4>

                </div>
            </td>
            <td>
                <div class="well bs-component" id="Admin" runat="server">
                    <h2>Administrador del Sistema</h2>
                    <p>Maneje los perfiles de usuario y  sus roles</p>
                    <h4>
                        <a href="FormRegistro.aspx">Administración de usuarios</a>
                    </h4>

                </div>

            </td>
        </tr>
    </table>




</asp:Content>
