﻿<%@ Page Title="Servir Platos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormServirPlatos.aspx.cs" Inherits="Servicios_Reservados_2.FormServirPlatos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <nav>
        <ul>
            <li class="item-navegacion"><a href="Default.aspx" title="Página principal"><i class="glyphicon glyphicon-home"></i></a></li>
            <li class="item-navegacion"><a href="FormServirPlatos.aspx" title="Servir platos" class="seleccionado">Servir platos</a></li>
            <li class="item-navegacion"><a href="FormReporteCocina.aspx" title="Reportes" >Reportes de cocina</a></li>
            <li class="item-navegacion"><a href="Notificaciones.aspx" title="Notificaciones">Notificaciones <span class="notificacion" id="contador" runat="server">0</span></a></li>
        </ul>
    </nav>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <legend>
                            <h2>Servir Platos</h2>
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

                <legend style="color: #7BC143">Servicio por tiquetes</legend>


                <asp:Panel runat="server" DefaultButton="btnVerificar">
                    <table>
                        <tr>
                            <td>Tiquete:</td>
                            <td>
                                <input id="tiquete" runat="server" required="required" title="Inserte un número de 4 digitos" pattern="^[0-9]{1,4}$" />
                            <td>
                                <asp:Button ID="btnVerificar" class="btn btn-success" Text="Verificar" runat="server" OnClick="clickVerificar" />
                            </td>
                        </tr>

                    </table>
                </asp:Panel>

            </div>



            <div class="well bs-component" runat="server" id="infoTiquete">

                <legend style="color: #7BC143">Información de reservación</legend>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridViewTiquete" Class="Gridcontenedor" runat="server" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px">
                                <AlternatingRowStyle BorderStyle="None" />
                                <HeaderStyle Font-Size="1.3em" />
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
                            <input id="btnServir" runat="server" type="button" class="btn btn-success" value="Servir" onserverclick="clickServir" />
                        </td>
                        <td>
                            <input id="btnServirDesactivar" runat="server" type="button" class="btn btn-danger" value="Desactivar" onserverclick="clickServirDesactivar" />
                        </td>
                    </tr>


                </table>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
