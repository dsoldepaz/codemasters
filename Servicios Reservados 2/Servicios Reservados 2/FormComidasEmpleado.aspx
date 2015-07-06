<%@ Page Title="Comida de Empleado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormComidasEmpleado.aspx.cs" Inherits="Servicios_Reservados_2.FormComidasEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Content/ComidaEmpleado.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <nav>
        <ul>
            <li class="item-navegacion"><a href="Default.aspx" title="Página principal"><i class="glyphicon glyphicon-home"></i></a></li>
            <li class="item-navegacion"><a href="FormReservaciones.aspx" title="Reservaciones">Reservaciones</a></li>
            <li class="item-navegacion"><a href="FormEmpleado.aspx" title="Empleados" class="seleccionado">Empleados</a></li>
            <li class="item-navegacion"><a href="FormReportes.aspx" title="Reportes">Reportes</a></li>
            <li class="item-navegacion"><a href="Notificaciones.aspx" title="Notificaciones">Notificaciones <span class="notificacion" id="contador" runat="server">0</span></a></li>
            
        </ul>
    </nav>
    <a href="">
        <div id="Div1" class="alert alert-danger fade in" runat="server" hidden="hidden">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
            <strong>
             <asp:Label ID="label1" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="label2" runat="server" Text="Mensaje de alerta"></asp:Label>
        </div>
    </a>
    <table>
        <tr>
            <td>
                    <h2>Comida de Empleado</h2>
               
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

        <legend style="color: #7BC143">Información del servicio</legend>
        <table>
            <tr>
                <td>
                Solicitante:
                         <td>
                             <input id="txtNombre" runat="server" style="width: 350px" />
                         </td>
            </tr>

        </table>




        <table>
            <tr>
                <td>
                    <input id="btnEditar" type="button" value="Editar" runat="server" onserverclick="clickModificar" />
                </td>
                <td>
                    <input id="btnAnular" type="button" value="Anular" runat="server" data-toggle="modal" data-target="#modalcancelar" />
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
                                                <button type="button" class="btn btn-success" runat="server" onserverclick="clickEliminar" data-dismiss="modal">Aceptar</button>
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                </td>
            </tr>
        </table>
    </div>

    <div id="ContenedorManejoDeHorario" runat="server" class="well bs-component">
        <div id="selectorDeHorario" runat="server" title="Seleccione el horario de comida">
            <input type="checkbox" id="checkboxDesayuno" runat="server" value="Desayuno" />Desayuno
                        <input type="checkbox" id="checkboxAlmuerzo" runat="server" value="Almuerzo" />Almuerzo
                        <input type="checkbox" id="checkboxCena" runat="server" value="Cena" />Cena
                        <select id="tipodePago" runat="server" title="Seleccione un metodo de pago">
                            <option value="Efectivo">Efectivo</option>
                            <option value="Descuento">Descuento de salario</option>
                        </select>

            <h4>Notas:</h4>
            <textarea id="notas" runat="server" title="Notas">

                            </textarea>
            <h4>Seleccione las fechas en las que desea reservar
            </h4>
            <input type="date" id="fecha" name="fechas" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" id="btnFecha" class="btn btn-submmit" value="Incluir fecha" runat="server" onserverclick="AgregarFecha_ServerClick" />
        </div>
        <asp:GridView ID="GridFechasReservadas" Class="Gridcontenedor" runat="server" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px" AutoGenerateDeleteButton="False">
            <SelectedRowStyle BackColor="#7BC143" />
        </asp:GridView>


    </div>
    <table>
        <tr>
            <td>
                <input type="button" id="btnAceptar" value="Aceptar" runat="server" onserverclick="clickAceptar" disabled="disabled" />
            </td>
            <td>

                <input type="button" class="btn-danger" value="Cancelar" runat="server" onserverclick="clickCancelar" />
            </td>
        </tr>
    </table>
</asp:Content>
