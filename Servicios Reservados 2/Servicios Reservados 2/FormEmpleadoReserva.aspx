﻿<%@ Page Language="C#" Title="Servicio para empleados" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FormEmpleadoReserva.aspx.cs" Inherits="Servicios_Reservados_2.FormEmpleadoReserva" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
      <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Content/EmpleadoReserva.css" />
    <nav>
        <ul>
            <li class="item-navegacion"><a href="Default.aspx" title="Página principal"><i class="glyphicon glyphicon-home"></i></a></li>
            <li class="item-navegacion"><a href="FormReservaciones.aspx" title="Reservaciones">Reservaciones</a></li>
            <li class="item-navegacion"><a href="FormEmpleado.aspx" title="Empleados" class="seleccionado">Empleados</a></li>
            <li class="item-navegacion"><a href="FormReportes.aspx" title="Reportes">Reportes</a></li>
            <li class="item-navegacion"><a href="Notificaciones.aspx" title="Notificaciones">Notificaciones <span class="notificacion" id="contador" runat="server">0</span></a></li>
        </ul>
    </nav>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table>
                <tr>
                    <td>
                        <legend>
                            <h2>Servicio para empleados</h2>
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
                <legend style="color: #7BC143">Información del empleado</legend>
                Nombre:
                <input id="txtNombre" value="{Nombre No recuperado}" runat="server" />
                Apellido:<input id="txtApellido" value="{Apellido No recuperado}" runat="server" />
            </div>

            <div class="well bs-component">
                <legend style="color: #7BC143">Agregar Servicios</legend>
                <table>
                    <tr>
                        <td>
                            <input type="button" class="btn btn-Naranja" value="Comida Regular" runat="server" onserverclick="btnAgregarCR_Click" />
                        </td>
                        <td>
                            <input type="button" class="btn btn-Naranja" value="Comida de Campo" runat="server" onserverclick="btnAgregarCC_Click" />
                        </td>
                    </tr>
                </table>
            </div>



            <div class="well bs-component">
                <legend style="color: #7BC143">Listado de servicios</legend>

                <asp:GridView ID="GridComidasReservadas" Class="Gridcontenedor" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="PageIndexChanging" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnActivarTiquete" runat="server" class="btn btn-default" OnClick="clickActivarTiquetes" ToolTip="Activar tiquetes"><i  class="glyphicon glyphicon-tags"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnConsultar" OnClick="btnVer_Click" runat="server" class="btn btn-default" ToolTip="Consultar"><i class="glyphicon glyphicon-search"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnModificar" runat="server" class="btn btn-default" OnClick="btnEditar_Click" ToolTip="Editar"><i class="glyphicon glyphicon-edit"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnCancelar" runat="server" class="btn btn-default"  OnClick="seleccionarCancelar" ToolTip="Anular"><i  class="glyphicon glyphicon-remove"></i></asp:LinkButton>
                                                    <!-- Modal -->
                                <div class="modal fade" id="modalcancelar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h4 class="modal-title" id="myModalLabel">Cancelar Reservacion</h4>
                                            </div>
                                            <div class="modal-body">
                                                <p>¿Desea Cancelar la reservacion? Es una operacion irreversible</p>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-success" runat="server" onserverclick="btnCancelar_Click" data-dismiss="modal">Aceptar</button>
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle BackColor="#7BC143" />
                </asp:GridView>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
