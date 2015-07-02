<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FormReporteCocina.aspx.cs" Inherits="Servicios_Reservados_2.FormReporteCocina" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="Content/ReporteCocina.css" />
    <nav>
        <ul>
            <li class="item-navegacion"><a href="Default.aspx" title="Página principal"><i class="glyphicon glyphicon-home"></i></a></li>
             <li class="item-navegacion"><a href="FormServirPlatos.aspx" title="Servir platos">Servir platos</a></li>
            <li class="item-navegacion"><a href="FormReportesCocina.aspx" title="Reportes" class="seleccionado">Reportes de cocina</a></li>
            <li class="item-navegacion"><a href="Notificaciones.aspx" title="Notificaciones">Notificaciones <span class="notificacion" id="contador" runat="server">0</span></a></li>
        </ul>
    </nav>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <legend>
                            <h2>Reportes de Cocina:</h2>
                        </legend>
                    </td>
                    <td>
                        <a href="">
                            <div id="alertAlerta" class="alert alert-danger fade in" runat="server" hidden="hidden">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                <strong>
                                    <asp:Label ID="labelTipoAlerta" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="labelAlerta" runat="server" Text="Mensaje de alerta"></asp:Label>
                            </div>
                        </a>
                    </td>
                </tr>
            </table>
            <div class="well bs-component">
                <legend style="color: #7BC143">Criterios del reporte</legend>
                <table>
                    <tr>
                        <td class="auto-style6">Estación:</td>
                        <td class="auto-style7">
                            <select style="width: 150px" id="cbxEstacion" runat="server"></select>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>Fechas</td>
                        <td>
                            <asp:DropDownList ID="cbxFecha" runat="server" OnSelectedIndexChanged="fecha_SelectedIndexChanged" AutoPostBack="true" Height="20px" Width="120px">
                            </asp:DropDownList>
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

                                <asp:GridView ID="GridViewSnacks" Class="Gridcontenedor" AutoGenerateColumns="True" ViewStateMode="Enabled" runat="server" AllowSorting="true" AllowPaging="true" OnPageIndexChanging="GridViewSnacks_PageIndexChanging" PageSize="5">

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
                        <a href="Default.aspx">
                            <input type="button" class="btn-danger" value="Cancelar" runat="server" />
                        </a>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

