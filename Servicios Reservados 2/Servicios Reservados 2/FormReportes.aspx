﻿<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormReportes.aspx.cs" Inherits="Servicios_Reservados_2.FormReportes" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <nav>
        <ul>
            <li class="item-navegacion"><a href="Default.aspx" title="Página principal"><i class="glyphicon glyphicon-home"></i></a></li>
            <li class="item-navegacion"><a href="FormReservaciones.aspx" title="Reservaciones">Reservaciones</a></li>
            <li class="item-navegacion"><a href="FormEmpleado.aspx" title="Empleados">Empleados</a></li>
            <li class="item-navegacion"><a href="FormReportes.aspx" title="Reportes" class="seleccionado">Reportes</a></li>
            <li class="item-navegacion"><a href="Notificaciones.aspx" title="Notificaciones">Notificaciones <span class="notificacion" id="contador" runat="server">0</span></a></li>
        </ul>
    </nav>
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <legend>
                            <h2>Reportes</h2>
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
                        <td class="auto-style6">Anfitriona:</td>
                        <td class="auto-style7">
                            <asp:DropDownList ID="listAnfitriona" runat="server"></asp:DropDownList>
                        </td>  
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>Fechas</td>
                        <td>
                            <asp:DropDownList ID="cbxFecha" runat="server" AutoPostBack="true" OnSelectedIndexChanged="mostrarFechas"></asp:DropDownList>
                        </td>
                        <td>Fecha Inicio</td>
                        <td>
                            <input id="dateFechaInicio" type="date" runat="server" /></td>
                        <td>Fecha Final</td>
                        <td>
                            <input id="dateFechaFin" type="date" runat="server" /></td>



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
                            <input style="width: 176px" id="txtAnfitriona" runat="server" />
                        </td>
                        <td style="width: 10%;">Estación:</td>
                        <td>
                            <input style="width: 176px" id="txtEstacion" runat="server" />
                        </td>
                        <td style="width: 10%;">Fecha Inicio:</td>
                        <td>
                            <input style="width: 176px" id="txtFechaInicio" runat="server" />
                        </td>
                        <td style="width: 10%;">Fecha Final:</td>
                        <td>
                            <input style="width: 176px" id="txtFechaFinal" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="well bs-component">
                <legend style="color: #7BC143">Desglose</legend>
                <table>
                    <tr>
                        <td>

                            <asp:GridView ID="GridViewReportes" Class="Gridcontenedor" runat="server" AllowPaging="true" AllowSorting="true" PageSize="10" OnPageIndexChanging="GridViewReporte_PageIndexChanging">
                                <SelectedRowStyle BackColor="#7BC143"
                                    ForeColor="Black"
                                    Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />
                            </asp:GridView>

                        </td>
                    </tr>
                </table>
            </div>
            <table>
                <tr>
                    <td>
                         <input type="button" class="btn btn-danger" id="btnCancelar" value="Cancelar" runat="server" onserverclick="clickCancelar" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

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
