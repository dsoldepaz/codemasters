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
                        <legend style="color: #7BC143">Información del PAX</legend>

                         <table>
                            <tr>
                                <td>Tiquete:</td>
                                <td>
                                    <input id="tiquete" runat="server" />
                                <td>
                                    <input id="Button1" runat="server" type="button" class="btn btn-success" value="Verificar"  onserverclick="clickVerificar" formmethod="post" />
                                </td>
                                <td>
                                    <input id="Button2" runat="server" type="button" class="btn btn-success" value="Servir" />

                            </tr>
                          
                        </table>
                        </div>

                        <div class="well bs-component">
                    <fieldset>
                        <legend style="color: #7BC143">Información de reservación</legend>
                        
                                    <asp:GridView ID="GridViewTiquete" runat="server" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px">
                                        <AlternatingRowStyle BorderStyle="None" />
                                        <HeaderStyle Font-Size="1.3em" />
                                        <SelectedRowStyle BackColor="#7BC143"
                                            ForeColor="Black"
                                            Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />
                                    </asp:GridView>

                        </div>
                

               
            </ContentTemplate>
        </asp:UpdatePanel>

    </fieldset>

               

</asp:Content>
