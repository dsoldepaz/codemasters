<%@ Page Title="ReportesFinanciero" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormReportes.aspx.cs" Inherits="Servicios_Reservados_2.FormReportes" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <nav>
        <ul>
            <li class="item-navegacion"><a href="Default.aspx" title="Página principal"><i class="glyphicon glyphicon-home"></i></a></li>
            <li class="item-navegacion"><a href="FormReservaciones.aspx" title="Reservaciones" class="seleccionado">Reservaciones</a></li>
            <li class="item-navegacion"><a href="FormEmpleado.aspx" title="Empleados">Empleados</a></li>
            <li class="item-navegacion">Notificaciones <span class="notificacion">0</span></li>
            <li class="item-navegacion"><a href="FormReportesComedor.aspx" title="Reportes">Reportes</a></li>
        </ul>
    </nav>

    <legend>
        <h2>Reportes</h2>
    </legend>

    <ContentTemplate>
            <div class="well bs-component">
                <legend style="color: #7BC143">Criterios del reporte</legend>
                    <table>
                        <tr>
                             <td class="auto-style6">Estación:</td>
                            <td class="auto-style7">
                                <select style="width: 150px" id="cbxEstacion" runat="server"></select>
                            </td>
                            <td class="auto-style6">Anfitriona:</td>
                            <td class="auto-style7">
                                <select style="width: 150px" id="cbxAnfitriona" runat="server"></select>
                            </td>
                             <td class="auto-style6">Número Reservación:</td>
                            <td class="auto-style7">
                                <input style="width: 150px" id="Select1" runat="server"></input>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>Fechas</td>
                            <td>
                                <asp:DropDownList ID="cbxFecha" runat="server" AutoPostBack="true" Height="20px" Width="120px"></asp:DropDownList>
                            </td>

                           <td>Fecha Inicio</td>
                            <td>
                                 <input style="width: 150px" type="date" id="FechaInicial" name="fechas" runat="server">
                           </td>

                          
                           <td>Fecha Final</td>
                            <td>
                               <input style="width: 150px" type="date" id="FechaFinal" name="fechas" runat="server">
                           </td>

                            <td>
                                <asp:Button Text="Generar Reporte" class="btn btn-success" ID="BotonGenerar" runat="server" OnClick="BotonGenerar_Click" />

                            </td>
                        </tr>
                    </table>
            </div>
            <div class="well bs-component">
                <legend style="color: #7BC143">Reporte Generado</legend>
                <table>
                        <tr>
                            <td style="width: 10%">Anfitriona:</td>
                            <td>
                                <input style="width: 176px" id="txtAnfitriona" runat="server"/>
                            </td>
                            <td style="width: 10%;">Estación:</td>
                            <td>
                                <input style="width: 176px" id="txtEstacion" runat="server"/>
                            </td>
                             <td style="width: 10%;">Fecha Inicio:</td>
                            <td>
                                <input style="width: 176px" id="txtFechaInicio" runat="server"/>
                            </td>
                             <td style="width: 10%;">Fecha Final:</td>
                            <td>
                                <input style="width: 176px" id="txtFechaFinal" runat="server"/>
                            </td>
                        </tr>
                    </table>
                </div>

            <div class="well bs-component">
                <legend style="color: #7BC143">Desglose</legend>
                <table>
                    <tr>
                        <td>

                            <asp:GridView ID="GridViewReportes" Class="Gridcontenedor" runat="server" AllowPaging="true" AllowSorting="true" PageSize="20">

                                <SelectedRowStyle BackColor="#7BC143"
                                    ForeColor="Black"
                                    Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnConsultar" ToolTip="Consultar" runat="server" class="btn btn-default"><i class="glyphicon glyphicon-search"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </td>
                    </tr>
                </table>
            </div>
               <div class="well bs-component">
                <legend style="color: #7BC143">Detalle</legend>
                    <table>
                        <tr>
                            <td class="auto-style3">Tipo Servicios:</td>
                            <td class="auto-style5">
                                  <input type="button" id="btnDesayunar" class="btn btn-Naranja" value="Desayuno" runat="server"/>
                            </td>
                            <td class="auto-style1">
                                 <input type="button" id="btnAlmuerzo" class="btn btn-Naranja" value="Almuerzo" runat="server"/>
                            </td>
                             <td class="auto-style4">
                                 <input type="button" id="btnCena" class="btn btn-Naranja" value="Cena" runat="server"/>
                            </td>
                        </tr>
                    </table>
                <table>
                    <tr>
                        <td>

                            <asp:GridView ID="GridViewDetalles" Class="Gridcontenedor" runat="server" AllowPaging="true" AllowSorting="true" PageSize="20">
                                <SelectedRowStyle BackColor="#7BC143"
                                    ForeColor="Black"
                                    Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px"/>
                            </asp:GridView>

                        </td>
                    </tr>
                </table>
            </div>
         <table>
            <tr>
                <td>
                    <input type="button" id="btnImprimir" value="Imprimir" runat="server"/>
                </td>
                <td>
                    <input type="button" class="btn-danger" value="Cancelar" runat="server"/>
                </td>
            </tr>
        </table>
        </ContentTemplate>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 198px;
            height: 60px;
        }

        .auto-style3 {
            width: 13%;
            height: 60px;
        }

        .auto-style4 {
            height: 60px;
        }

        .auto-style5 {
            width: 178px;
            height: 60px;
        }
        .auto-style6 {
            width: 10%;
            height: 45px;
        }
        .auto-style7 {
            height: 45px;
        }
    </style>
</asp:Content>

