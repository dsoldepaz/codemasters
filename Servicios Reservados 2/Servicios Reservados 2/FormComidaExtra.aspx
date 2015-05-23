<%@ Page Title="Comida Extra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormComidaExtra.aspx.cs" Inherits="Servicios_Reservados_2.FormComidaExtra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <link rel="stylesheet" href="Content/ComidasExtra.css" />

    <a href="">
        <div id="alertAlerta" class="alert alert-danger fade in" runat="server" hidden="hidden">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
            <strong>
                <asp:Label ID="labelTipoAlerta" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="labelAlerta" runat="server" Text="Mensaje de alerta"></asp:Label>
        </div>
    </a>

    <fieldset>
         <legend>
                        <h2>Comida Extra</h2>
                    </legend>
        
              <div class="well bs-component">
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
                <li class="itemContenedor">Hora:<select id="cbxHora" runat="server" ></select> <!--class="itemContenedor">Hora:<input id="txtHora" runat="server" type="time" />-->
                </li>
                <li class="itemContenedor">#PAX:<input id="txtPax" runat="server" type="number" required="required" placeholder="Entre un digito" />

                </li>
                <li class="itemContenedor">Tipo de pago:<select id="cbxTipoPago" runat="server" ></select>

                </li>

            </ul>
            <p>
                <label>Notas:</label>
                <textarea id="txaNotas" cols="20" name="S1" rows="2" runat="server"></textarea>
            </p>
                  <table>
                        <tr>
                            <td>
                                <input type="button" class="btn btn-success" value="Cancelar" runat="server" onserverclick="clickCancelar"/>
                            </td>
                            <td>
                                <input type="button" class="btn btn-success" id="btnAceptar" value="Aceptar" runat="server" onserverclick="clickAceptar"/>
                            </td>
                            
                        </tr>
                    </table>

        </div>
    </fieldset>

        <div class="modal fade" id="modalConfirmacion" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabel">Ventana de Confirmación</h4>
                </div>
                <div class="modal-body">
                    ¿Está seguro que desea eliminar?                         
               
               
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default"  data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary">Eliminar</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function openModal() {
            $('#modalConfirmacion').modal('show');
        }
</script>


</asp:Content>
