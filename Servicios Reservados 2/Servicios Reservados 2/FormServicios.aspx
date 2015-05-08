<%@ Page Title="Servicios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormServicios.aspx.cs" Inherits="Servicios_Reservados_2.FormServicios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <nav>
        <ul>
            <li class="item-navegacion"><a href="FormReservaciones.aspx">Reservaciones</a></li>
            <li class="item-navegacion"><a href="FormEmpleadoReserva.aspx">Empleados</a></li>
            <li class="item-navegacion">Notificaciones <span class="notificacion">0</span></li>
        </ul>
    </nav>
    <legend>
        <h2>Reservaciones del Servicio</h2>
    </legend>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="well bs-component">
                <fieldset>
                    <legend style="color: #7BC143">Información de reservación</legend>

                    <table>
                        <tr>
                            <td>Anfitriona:</td>
                            <td>
                                <input id="txtAnfitriona" runat="server" /></td>
                            <td>Estacion:</td>
                            <td>
                                <input id="txtEstacion" runat="server" />
                            </td>
                            <td>Solicitante:</td>
                            <td>
                                <input id="txtNombre" runat="server" /></td>

                        </tr>
                        <tr>
                            <td>Fecha De Entrada:</td>
                            <td>
                                <input id="fechaInicio" runat="server" /></select>
                            </td>
                            <td>Fecha De Salida:</td>
                            <td>
                                <input id="fechaFinal" runat="server" /></select>
                            </td>
                            <td>Numero de PAX:</td>
                            <td>
                                <input id="txtPax" runat="server" /></select>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            <div class="well bs-component">
                <fieldset>
                    <legend style="color: #7BC143">Agregar Servicios extra</legend>
                    <table>
                        <tr>
                            <td>
                                <input type="button" class="btn btn-success" value="Comida Extra" runat="server" onserverclick="clickAgregarServicio"/></a></td>
                            <td>
                                <input type="button" class="btn btn-success" value="Comida De Campo" />
                            </td>
                            <td>
                                <input type="button" class="btn btn-success" value="Servicio de Guías" /></td>
                        </tr>
                    </table>
            </div>
            <div class="well bs-component">
                <fieldset>

                    <legend style="color: #7BC143">Listado de servicios</legend>

                        <div class="well bs-component" style="background-color: white">
                            <table>
                                <tr>
                                    <td style="width: 95%">
                                        <asp:GridView ID="GridServicios" runat="server" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="seleccionarServicio">
                                            <SelectedRowStyle BackColor="#7BC143" />
                                        </asp:GridView>

                                    </td>
                                    <td>
                                        <div class="btn-group-vertical">
                                            <input type="button" class="btn btn-success" value="Consultar" />
                                            <input type="button" class="btn btn-success" value="Modificar" runat="server" onserverclick="modificarServicio" />
                                            <input type="button" class="btn btn-success" value="Elimnar" runat="server" onserverclick="clickEliminarServicio"/>

                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>

                </fieldset>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
