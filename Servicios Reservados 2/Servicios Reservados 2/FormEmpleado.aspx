<%@ Page Language="C#" Title="Empleados" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FormEmpleado.aspx.cs" Inherits="Servicios_Reservados_2.FormEmpleado" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="Content/formEmpleado.css" />
    <nav>
        <ul>
            <li class="item-navegacion"><a href="Default.aspx" title="Página principal"><i class="glyphicon glyphicon-home"></i></a></li>
            <li class="item-navegacion"><a href="FormReservaciones.aspx" title="Reservaciones">Reservaciones</a></li>
            <li class="item-navegacion"><a href="FormEmpleadoReserva.aspx" class="seleccionado" title="Empleados">Empleados</a></li>
            <li class="item-navegacion"><a href="Notificaciones.aspx">Notificaciones <span class="notificacion" id="contador" runat="server">0</span></a></li>
        </ul>
    </nav>
    <div>


        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <legend>
                                <h2>Empleados</h2>
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
                    <legend style="color: #7BC143">Filtro de empleados</legend>

                    <table>
                        <tr>
                            <td>Nombre:</td>
                            <td>
                                <input class="textbox" id="inputNombre" runat="server" />
                            </td>
                            <td>Carné:
                            </td>
                            <td>
                                <input class="textbox" id="inputIdentificacion" runat="server" />
                            </td>
                            <td>
                                <input type="button" class="btn btn-success" id="botonBuscar" onserverclick="clickBuscar" value="Buscar" runat="server" />
                            </td>
                        </tr>

                    </table>

                </div>
                <div class="well bs-component">
                    <legend style="color: #7BC143">Listado de empleados</legend>
                    <asp:GridView ID="GridViewEmpleados" Class="Gridcontenedor" runat="server" AllowPaging="true" AllowSorting="true" OnPageIndexChanging="GridViewReservaciones_PageIndexChanging" PageSize="20">

                        <SelectedRowStyle BackColor="#7BC143" BorderStyle="Dotted" BorderWidth="1px" Font-Bold="true" ForeColor="Black" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ToolTip="Consultar" ID="btnConsultar" runat="server" OnClick="clicAgregarServicio" class="btn btn-default"><i class="glyphicon glyphicon-search"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
