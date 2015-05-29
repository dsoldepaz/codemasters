<%@ Page Title="Servir Platos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormServirPlatos.aspx.cs" Inherits="Servicios_Reservados_2.FormServirPlatos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <nav>
        <ul>
            <li class="item-navegacion">Servir Platos</li>
            <li class="item-navegacion">Reportes</li>
            <li class="item-navegacion">Horarios</li>
            <li class="item-navegacion">Notificaciones <span class="notificacion">0</span></li>
        </ul>
    </nav>
    <fieldset>
        <legend>
            <h2>Servir Platos</h2>
        </legend>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="well bs-component">
                    <fieldset>
                        <legend style="color: #7BC143">Servicio por tiquetes</legend>


                        <asp:Panel runat="server" DefaultButton="btnVerificar">
                            <table>
                                <tr>
                                    <td>Tiquete:</td>
                                    <td>
                                        <input id="tiquete" runat="server" />
                                    <td>
                                        <asp:Button ID="btnVerificar" class="btn btn-success" Text="Verificar" runat="server" OnClick="clickVerificar" />
                                    </td>
                                </tr>

                            </table>
                        </asp:Panel>
                </div>

                <div class="well bs-component" runat="server" id="infoTiquete">
                    <fieldset>
                        <legend style="color: #7BC143">Información de reservación</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="GridViewTiquete" runat="server" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px">
                                        <AlternatingRowStyle BorderStyle="None" />
                                        <HeaderStyle Font-Size="1.3em" />
                                        <SelectedRowStyle BackColor="#7BC143"
                                            ForeColor="Black"
                                            Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="btnServir" runat="server" type="button" class="btn btn-success" value="Servir" onserverclick="clickServir" />
                                </td>
                            </tr>


                        </table>
                </div>



            </ContentTemplate>
        </asp:UpdatePanel>

    </fieldset>



</asp:Content>
