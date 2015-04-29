<%@ Page Title="Reservaciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormReservaciones.aspx.cs" Inherits="Servicios_Reservados_2.FormReservaciones" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

     <nav>
            <ul>
                <li class="item-navegacion"><a href="FormReservaciones.aspx" class="seleccionado">Reservaciones</a></li>
                <li class="item-navegacion"><a href="FormEmpleadoReserva.aspx">Empleados</a></li>
                <li class="item-navegacion">Notificaciones <span class="notificacion">0</span></li>
            </ul>
        </nav>
      <h1>Reservaciones</h1>
    <fieldset>
        
        <div>
            <fieldset>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <legend style="color: #7BC143">Información de reservación</legend>
                <table>
                    <tr>
                         <td style="width: 10%">Anfitriona:</td>
                        <td>
                            <select style="width: 176px" id="cbxAnfitriona" runat="server" ></select>
                        </td>
                        <td style="width: 10%">Estación:</td>
                        <td>
                            <select style="width: 176px" id ="cbxEstacion" runat="server"></select>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td >Solicitante:</td>
                        <td >
                            <input class="textbox" id="txtSolicitante" runat="server"/>
                        </td>
                        <td>
                            <button type="button" class="default" id="BotonBuscar" onserverclick="clickBuscar" runat="server">Buscar</button>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridViewReservaciones" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="seleccionarReservacion" AllowPaging="true"  AllowSorting="true"     PageSize = "20" OnPageIndexChanging="GridViewReservaciones_PageIndexChanging" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px">
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
                        <td >
                            <button type="button" class="btn btn-danger" id="BotonImp">Activar tiquetes</button>
                        </td>
                        <td>
                            <a href="FormServicios.aspx"><input type="button" class="btn btn-success" id="botonServicioExtra"  value="Agregar Servicios"/></a>
                        </td>
                    </tr>
                </table>

                    </ContentTemplate>
                </asp:UpdatePanel>

                
                

            </fieldset>

        </div>
    </fieldset>
</asp:Content>

