<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FormReporteCocina.aspx.cs" Inherits="Servicios_Reservados_2.FormReporteCocina" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="Content/ReporteCocina.css" />
    <nav>
        <ul>
            <li class="item-navegacion"><a href="Default.aspx" title="Página principal"><i class="glyphicon glyphicon-home"></i></a></li>
            <li class="item-navegacion"><a href="FormReservaciones.aspx" title="Reservaciones" class="seleccionado">Reservaciones</a></li>
            <li class="item-navegacion"><a href="FormEmpleado.aspx" title="Empleados">Empleados</a></li>
            <li class="item-navegacion"><a href="Notificaciones.aspx">Notificaciones <span class="notificacion" id="contador" runat="server">0</span><a /></li>
            <li class="item-navegacion"><a href="FormReportesComedor.aspx" title="Reportes">Reportes</a></li>
        </ul>
    </nav>

    <legend>
        <h2>Reportes de Cocina:</h2>
    </legend>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="well bs-component">
                <legend style="color: #7BC143">Criterios del reporte</legend>
                <table>
                    <tr>
                        <td class="auto-style6">Estación:</td>
                        <td class="auto-style7">
                            <input style="width: 150px" id="txtEstacion" runat="server"></input>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>Fechas</td>
                        <td>
                            <select id="cbxFecha" runat="server" autopostback="true" height="20px" width="120px">
                                <option value="Hoy">Hoy</option>
                                <option value="Día siguiente">Día siguiente</option>
                                <option value="Personalizado">Personalizado</option>
                            </select>
                        </td>

                        <td>Fecha Inicio</td>
                        <td>
                            <input style="width: 150px" type="date" id="txtFechaInicial" name="fechas" runat="server">
                        </td>


                        <td>Fecha Final</td>
                        <td>
                            <input style="width: 150px" type="date" id="txtFechaFinal" name="fechas" runat="server">
                        </td>

                        <td>

                            <asp:Button Text="Generar Reporte" class="btn btn-success" ID="BotonGenerar" OnClick="clickBuscar" runat="server" />

                        </td>
                    </tr>
                </table>
            </div>
            <section class="division well">
                <div class="izquierda">
                    <legend style="color: #7BC143">Total de servicios</legend>
                    <table>
                        <tr>
                            <td>

                                <asp:GridView ID="GridViewTotal" Class="Gridcontenedor" runat="server" AllowSorting="true">

                                    <SelectedRowStyle BackColor="#7BC143"
                                        ForeColor="Black"
                                        Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />

                                </asp:GridView>

                            </td>
                        </tr>
                    </table>
                </div>
                <div class="derecha">
                    <legend style="color: #7BC143">Turnos:</legend>
                    <table>
                        <tr>
                            <td>

                                <asp:GridView ID="GridViewTurnos" Class="Gridcontenedor" runat="server" AllowSorting="true">

                                    <SelectedRowStyle BackColor="#7BC143"
                                        ForeColor="Black"
                                        Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />

                                </asp:GridView>

                            </td>
                        </tr>
                    </table>
                    <legend style="color: #7BC143">Snacks:</legend>
                    <table>
                        <tr>
                            <td>

                                <asp:GridView ID="GridViewSnacks" Class="Gridcontenedor" runat="server" AllowSorting="true" AllowPaging="true" OnPageIndexChanging="GridViewSnacks_PageIndexChanging" PageSize="5">

                                    <SelectedRowStyle BackColor="#7BC143"
                                        ForeColor="Black"
                                        Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />

                                </asp:GridView>

                            </td>
                        </tr>
                    </table>
                    <legend style="color: #7BC143">Bebidas Extra:</legend>
                    <table>
                        <tr>
                            <td>

                                <asp:GridView ID="GridViewBebidas" Class="Gridcontenedor" runat="server" AllowSorting="true" AllowPaging="true" OnPageIndexChanging="GridViewBebidas_PageIndexChanging" PageSize="5">

                                    <SelectedRowStyle BackColor="#7BC143"
                                        ForeColor="Black"
                                        Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />

                                </asp:GridView>

                            </td>
                        </tr>
                    </table>

                </div>
            </section>
            <table>
                <tr>
                    <td>
                        <input type="button" class="btn-danger" value="Cancelar" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

