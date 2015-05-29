<%@ Page Title="Activar tiquetes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormTiquete.aspx.cs" Inherits="Servicios_Reservados_2.FormTiquete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

    
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <nav>
        <ul>
            <li class="item-navegacion"><a href="FormReservaciones.aspx">Reservaciones</a></li>
            <li class="item-navegacion"><a href="FormEmpleadoReserva.aspx">Empleados</a></li>
            <li class="item-navegacion">Notificaciones <span class="notificacion">0</span></li>
            <li class="item-navegacion"><a href="FormReportesComedor.aspx">Reportes</a></li>
        </ul>
    </nav>
    
        <legend>
            <h2>Activar tiquetes</h2>
        </legend>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <fieldset>
                    <div class="well bs-component">
                        <legend style="color: #7BC143">Información del servicio</legend>
                        <fieldset>
                            <table>
                                <tr>
                                    <td>Anfitriona:</td>
                                    <td>
                                        <input class="textbox" style="width:500px" id="anfitriona" runat="server" />
                                    </td>
                                    <td>Estación:</td>
                                    <td>
                                        <input class="textbox" style="width:500px" id="estacion" runat="server" />
                                    </td>
                                    </tr>
                                    <tr>
                                    <td>Número de reservación:</td>
                                    <td>
                                        <input class="textbox" style="width:500px" id="numero" runat="server" />
                                    </td>
                                    <td>Solicitante:</td>
                                    <td>
                                        <input class="textbox" style="width:500px" id="solicitante" runat="server" />
                                    </td>
                                </tr>
                                   <tr>
                                    <td>Categoria de servicio:</td>
                                    <td>
                                        <input class="textbox" style="width:500px" id="categoria" runat="server" />
                                    </td>
                                    <td>Estado:</td>
                                    <td>
                                        <input class="textbox" style="width:500px" id="estado" runat="server" />
                                    </td>
                                </tr>
                                 </tr>
                                   <tr>
                                    <td>Pax:</td>
                                    <td>
                                        <input class="textbox" style="width:500px" id="pax" runat="server" />
                                    </td>
                                </tr>
                            </table>                                                       
                    </div>
                    
                    <div class="well bs-component">
                        <legend style="color: #7BC143">Información de tiquetes activos</legend>
                          <table>
                                <tr>
                                    <td>Número:</td>
                                    <td>
                                        <input class="textbox"  id="numTiquete" runat="server" />
                                    </td>
                                    <td>                                       
                                        <button type="button" class="btn btn-success" id="BotonAgregar" onserverclick="clickAgregar" runat="server">Agregar</button>
                                    </td>
                                </tr>
                            </table>
                        <table>
                            <tr>
                                <td>

                                    <asp:GridView ID="GridViewTiquetes" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="seleccionarTiquete"  AllowSorting="true"  BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px">
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
                                        <input type="button" class="btn btn-success" id="botonQuitar" value="Quitar tiquete"  onserverclick="clickQuitar" runat="server"/></a>
                                </td>                          
            
                            </tr>
                        </table>

                    </div>

                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>