<%@ Page Title="Comida Extra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormComidaExtra.aspx.cs" Inherits="Servicios_Reservados_2.FormComidaExtra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="Content/ComidasExtra.css" />
    <nav>
        <ul>
            <li class="item-navegacion"><a href="Default.aspx" title="Página principal"><i class="glyphicon glyphicon-home"></i></a></li>
            <li class="item-navegacion"><a href="FormReservaciones.aspx" class="seleccionado">Reservaciones</a></li>
            <li class="item-navegacion"><a href="FormEmpleado.aspx">Empleados</a></li>
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
                            <h2>Comida Extra</h2>
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

                <legend style="color: #7BC143">Información de la reservación</legend>
                <ul>
                    <li class="itemContenedor">Estación:<input id="txtEstacion" runat="server" style="width: 100px" disabled /></li>
                    <li class="itemContenedor">Anfitriona:<input id="txtAnfitriona" runat="server" style="width: 100px" disabled /></li>
                </ul>
                <table>
                    <tr>
                        <td>Solicitante:
                        </td>
                        <td>
                            <input id="txtSolicitante" runat="server" style="width: 230px" />
                        </td>
                        <td>Numero de Reservación:
                        </td>
                        <td>
                            <input id="txtNumReservacion" runat="server" style="width: 200px" />
                        </td>
                        <td>Fecha de entrada:
                        </td>
                        <td>
                            <input id="txtFechaInicial" runat="server" style="width: 100px" disabled />
                        </td>
                        <td>Fecha de salida:
                        </td>
                        <td>
                            <input id="txtFechaFinal" runat="server" style="width: 100px" disabled />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <input id="btnEditar" type="button" value="Editar" runat="server" onserverclick="clickModificar" />
                        </td>
                        <td>
                            <input id="btnAnular" type="button" value="Anular" runat="server" onserverclick="clickAnular" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="well bs-component">
                  <legend style="color: #7BC143">Información del servicio</legend>
                <ul>
                    <li class="itemContenedor">Fecha:<input runat="server" id="textFecha" onselect="fechaDeEntradaCalendario_SelectionChanged" disabled />
                        <input id="fechaDeEntrada" class="selectorDeFecha" type="button" runat="server" onserverclick="fechaDeEntrada_ServerClick" />
                        <asp:Calendar ID="fechaDeEntradaCalendario" runat="server" BackColor="#CCCCCC" BorderStyle="Dashed" ForeColor="#7BC143" Height="80px" Width="100px" BorderWidth="1px" Visible="false" OnSelectionChanged="fechaDeEntradaCalendario_SelectionChanged">
                            <DayHeaderStyle ForeColor="#333333" Wrap="True" />
                            <DayStyle ForeColor="Black" />
                            <NextPrevStyle ForeColor="Black" />
                            <TitleStyle BackColor="#7BC143" ForeColor="#333333" />
                        </asp:Calendar>
                    </li>

                    <li class="itemContenedor">Tipo:<asp:DropDownList ID="cbxTipo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="clickAdaptarHora"></asp:DropDownList>
                    </li>
                    <li class="itemContenedor">Hora:<select id="cbxHora" runat="server"></select>
                    </li>
                    <li class="itemContenedor">#PAX:<input id="txtPax" runat="server" required="required" title="Inserte un número." pattern="^[0-9]+$" />
                    </li>
                    <li class="itemContenedor">Tipo de pago:<select id="cbxTipoPago" runat="server"></select>
                    </li>

                </ul>
                <p>
                    <label>Notas:</label>
                    <textarea id="txaNotas" cols="20" name="S1" rows="2" runat="server" title="Solo puede insertar lestras, comas y puntos." pattern="^[a-z]+$"></textarea>
                </p>
                <table>
                    <tr>
                        <td>
                            <input type="submit" class="btn btn-success" id="btnAceptar" value="Aceptar" runat="server" onserverclick="clickAceptar" />

                        </td>
                        <td>

                            <input type="button" class="btn btn-danger" id="Button1" value="Cancelar" runat="server" onserverclick="clickCancelar" />
                        </td>

                    </tr>
                </table>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

