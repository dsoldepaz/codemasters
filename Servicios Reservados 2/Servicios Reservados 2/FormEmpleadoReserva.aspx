﻿<%@ Page Language="C#" Title="Empleados" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="FormEmpleadoReserva.aspx.cs" Inherits="Servicios_Reservados_2.FormEmpleadoReserva" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="Content/EmpleadoReserva.css"/>
        <nav>
            <ul>
                <li class="item-navegacion"><a href="FormReservaciones.aspx">Reservaciones</a></li>
                <li class="item-navegacion"><a href="FormEmpleadoReserva.aspx"  class="seleccionado">Empleados</a></li>
                <li class="item-navegacion">Notificaciones <span class="notificacion">0</span></li>
                <li class="item-navegacion"><a href="FormReportesComedor.aspx">Reportes</a></li>

            </ul>
        </nav>
        <div>
            <h2>Empleados</h2>
            <h3>Reservaciones del empleado:<span id="lblNombre" runat="server"></span> </h3>
            <fieldset>
                <section id="comidasReservadas">
                    <h4>
                        Comidas desde el ultimo mes del empleado
                    </h4>
                    <section id="seccionBotones" visible="false" class="panelDeBotones" runat="server">
                        <input class="btn btn-success" value="Ver" runat="server" onserverclick="btnVer_Click" />
                        <input class="btn btn-success comida" value="Nueva Comida Regular" runat="server" onserverclick="btnAgregarCR_Click"/>
                        <input class="btn btn-success comida" value="Nueva Comida Campo" runat="server" onserverclick="btnAgregarCC_Click"/>
                        <input class="btn btn-success" value="Editar" runat="server" onserverclick="btnEditar_Click"/>
                        <input class="btn btn-success cancelar" value="Cancelar Comida" runat="server" onserverclick="btnCancelar_Click"/>
                    </section>
                     <asp:GridView ID="GridComidasReservadas" runat="server" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="seleccionarComida">
                     <SelectedRowStyle BackColor="#7BC143" />
                     </asp:GridView>

                </section>
              
            </fieldset>

        </div>
    </asp:Content>
