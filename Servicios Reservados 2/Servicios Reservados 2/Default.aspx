<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Servicios_Reservados_2._Default" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="jumbotron">
        <div class="container">
            <h1>Sistema de servicios reservados</h1>
            <p>Con este sistema podrá llevar un control de los servicios consumidos dentro de la organización</p>
        </div>
    </div>

    <div class="well bs-component">

        <h2>Recepcionista:</h2>
        <p>
            <a href="FormReservaciones.aspx">Reservaciones</a>
        </p>
        <p>
            <a href="FormEmpleado.aspx">Empleados</a>
        </p>

    </div>
    <div class="well bs-component">
        <h2>Encargado de Cocina:</h2>
        <p>
            <a href="FormServirPlatos.aspx">Servir platos</a>
        </p>

    </div>

</asp:Content>
