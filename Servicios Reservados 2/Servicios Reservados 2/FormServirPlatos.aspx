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
        <h1>
            Servir Platos
        </h1>
        <section class="principal">
            <section class="contenedor">
                <ul>
                    <li class="itemContenedor">
                     Tiquete:<input id="tiquete" runat="server" />
                     </li>
                     <li class="itemContenedor">
                     <input type="button" value="Verificar" onserverclick="clickVerificar" runat="server" formmethod="post" />
                     </li>
                     <li class="itemContenedor">
                     <input type="button" value="Servir" />
                     </li>
                </ul>
            </section>
                <table>
					<caption>Información de reservación</caption>
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
         </section>
    </form>

</asp:Content>
