<%@ Page Title="Reservaciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormReservaciones.aspx.cs" Inherits="Servicios_Reservados_2.FormReservaciones" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <nav>
        <ul>
            <li class="item-navegacion"><a href="Default.aspx" title="Página principal"><i class="glyphicon glyphicon-home"></i></a></li>
            <li class="item-navegacion"><a href="FormReservaciones.aspx" title="Reservaciones" class="seleccionado">Reservaciones</a></li>
            <li class="item-navegacion"><a href="FormEmpleado.aspx" title="Empleados">Empleados</a></li>
            <li class="item-navegacion"><a href="Notificaciones.aspx">Notificaciones <span class="notificacion" id="contador" runat="server">0</span><a /></li>
            <li class="item-navegacion"><a href="FormReportesComedor.aspx" title="Reportes">Reportes</a></li>
        </ul>
    </nav>



    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <legend>
                            <h2>Reservaciones</h2>
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
                <legend style="color: #7BC143">Filtro de reservación</legend>

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
                                <asp:Button Text="Buscar" class="btn btn-success" ID="BotonBuscar" OnClick="clickBuscar" runat="server" />

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

                            <asp:GridView ID="GridViewReservaciones" Class="Gridcontenedor" runat="server" AllowPaging="true" AllowSorting="true" PageSize="20" OnPageIndexChanging="GridViewReservaciones_PageIndexChanging">

                                <SelectedRowStyle BackColor="#7BC143"
                                    ForeColor="Black"
                                    Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnConsultar" ToolTip="Consultar" runat="server" OnClick="clickAgregarServicioExtra" class="btn btn-default"><i class="glyphicon glyphicon-search"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>


                        </td>
                    </tr>
                </table>


            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

