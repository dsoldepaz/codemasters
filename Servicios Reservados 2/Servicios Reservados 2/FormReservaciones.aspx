﻿<%@ Page Title="Reservaciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormReservaciones.aspx.cs" Inherits="Servicios_Reservados_2.FormReservaciones" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <nav>
        <ul>
            <li class="item-navegacion"><a href="FormReservaciones.aspx" class="seleccionado">Reservaciones</a></li>
            <li class="item-navegacion"><a href="FormEmpleado.aspx">Empleados</a></li>
            <li class="item-navegacion">Notificaciones <span class="notificacion">0</span></li>
            <li class="item-navegacion"><a href="FormReportesComedor.aspx">Reportes</a></li>
        </ul>
    </nav>


    <legend>
        <h2>Reservaciones</h2>
    </legend>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset>
                <div class="well bs-component">
                    <legend style="color: #7BC143">Filtro de reservación</legend>
                    <fieldset>
                        <asp:Panel runat="server" DefaultButton="BotonBuscar">
                            <table>
                                <tr>
                                    <td style="width: 10%">Anfitriona:</td>
                                    <td>
                                        <select style="width: 176px" id="cbxAnfitriona" runat="server"></select>
                                    </td>
                                    <td style="width: 10%;">Estación:</td>
                                    <td>
                                        <select style="width: 176px" id="cbxEstacion" runat="server"></select>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>Solicitante:</td>
                                    <td>
                                        <input class="textbox" style="width: 500px" id="txtSolicitante" runat="server" />
                                    </td>
                                    <td>
                                        <asp:button text="Buscar" class="btn btn-success" id="BotonBuscar" OnClick="clickBuscar" runat="server"/>
                                        
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                </div>
                <div class="well bs-component">
                    <legend style="color: #7BC143">Listado de reservaciones</legend>
                    <table>
                        <tr>
                            <td>

                                <asp:GridView ID="GridViewReservaciones" Class="Gridcontenedor" runat="server" AutoGenerateSelectButton="True" OnRowCommand="seleccionarReservacion" AllowPaging="true" AllowSorting="true" PageSize="20" OnPageIndexChanging="GridViewReservaciones_PageIndexChanging">
                                    
                                    <SelectedRowStyle BackColor="#7BC143"
                                        ForeColor="Black"
                                        Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />
                                </asp:GridView>


                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>

                            <td>

                                <input type="button" runat="server" class="btn btn-success" id="botonServicioExtra" value="Agregar Servicios" onserverclick="clickAgregarServicioExtra" /></a>
                            </td>
                        </tr>
                    </table>


                </div>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

