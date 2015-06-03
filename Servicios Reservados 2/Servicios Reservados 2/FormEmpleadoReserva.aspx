﻿<%@ Page Language="C#" Title="Empleados" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="FormEmpleadoReserva.aspx.cs" Inherits="Servicios_Reservados_2.FormEmpleadoReserva" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="Content/EmpleadoReserva.css"/>
        <nav>
            <ul>
                <li class="item-navegacion"><a href="FormReservaciones.aspx">Reservaciones</a></li>
                <li class="item-navegacion"><a href="FormEmpleado.aspx"  class="seleccionado">Empleados</a></li>
                <li class="item-navegacion">Notificaciones <span class="notificacion">0</span></li>
                <li class="item-navegacion"><a href="FormReportesComedor.aspx">Reportes</a></li>

            </ul>
        </nav>
        <div>
            <h2>Empleados</h2>
            <h3>Reservaciones del empleado:<span id="lblNombre" runat="server"></span> </h3>
            <div class="well">
                <h4>
                    Agregar Servicios
                </h4>
                <input type="button"  class="btn btn-success comida" value="Nueva Comida Regular" runat="server" onserverclick="btnAgregarCR_Click"/>
                <input type="button"  class="btn btn-success comida" value="Nueva Comida Campo" runat="server" onserverclick="btnAgregarCC_Click"/>
            </div>
             <asp:UpdatePanel ID="UpdatePanel1"  class="well" runat="server">
            <ContentTemplate>
            <fieldset>
                 <h4>
                        Comidas desde el ultimo mes del empleado
                    </h4>
                <section id="comidasReservadas">
                    <asp:GridView ID="GridComidasReservadas" Class="Gridcontenedor" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="seleccionarComida" Width="100%">
                     <SelectedRowStyle BackColor="#7BC143" />
                     </asp:GridView>
                    <section id="seccionBotones" class="btn-group-vertical" runat="server">
                        <input id="tiquetesBtn" type="button" class="btn btn-success tiquete" value="Activar Tiquete" runat="server" onserverclick="clickActivarTiquetes" />
                        <input id="btnVer" type="button" class="btn btn-success" value="Consultar" runat="server" onserverclick="btnVer_Click" />
                        <input id="btnEditar" type="button" class="btn btn-success" value="Modificar" runat="server" onserverclick="btnEditar_Click"/>
                        <input id="btnCancelar" type="button" class="btn btn-success cancelar" value="Cancelar" runat="server" onserverclick="btnCancelar_Click"/>
                    </section>
                    

                </section>
              
            </fieldset>
                 </ContentTemplate>
        </asp:UpdatePanel>

        </div>
    </asp:Content>
