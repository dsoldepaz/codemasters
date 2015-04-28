<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormServirPlatos.aspx.cs" Inherits="Servicios_Reservados_2.FormServirPlatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
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
                                    <input id="Button1" runat="server" type="button" class="btn btn-success" value="Verificar" />
                                </td>
                                <td>
                                    <input id="Button2" runat="server" type="button" class="btn btn-success" value="Servir" />

                            </tr>
                          
                        </table>
                        </div>

                        <div class="well bs-component">
                    <fieldset>
                        <legend style="color: #7BC143">Información de reservación</legend>

                <table>
					<tr>
						<th>Cliente</th>
						<th>Anfitriona</th>
						<th>Estación</th>
						<th>Servido</th>
						<th>Notas</th>
					</tr>
					<tr>
						<td class="basura" runat="server">
                            <textarea id="clienteArea"  runat="server" ></textarea></td>
						<td id="anfitrionaArea"  runat="server"></td>
						<td id="estacionArea"  runat="server"></td>
						<td id="servidoArea"  runat="server"></td>
						<td class="basura"> <textarea id="notasArea"  runat="server"> </textarea></td>
					</tr>
				</table>

                <asp:GridView ID="GridServicios" runat="server" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px">
                                <SelectedRowStyle BackColor="#7BC143" />
                            </asp:GridView>

                        </div>
                

               
            </ContentTemplate>
        </asp:UpdatePanel>

    </fieldset>

               

</asp:Content>
