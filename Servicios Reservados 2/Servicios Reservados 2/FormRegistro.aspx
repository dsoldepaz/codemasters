<%@ Page Title="Registro de usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormRegistro.aspx.cs" Inherits="Servicios_Reservados_2.FormRegistro" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
    <div id="top"></div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <legend>
                            <h2>Registro de usuarios</h2>
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
                <legend>
                    <h4>Información personal </h4>
                </legend>

                <table>
                    <tr>
                        <td style="width: 10%;">Username:</td>
                        <td>
                            <input class="textbox" style="width: 500px" id="username" runat="server" required="required" title="Debe tener de 4 a 15 caracteres, solo letras minúsculas sín tilde o números" pattern="^[a-z0-9]{4,15}$" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%;">Nombre:</td>
                        <td>
                            <input class="textbox" style="width: 500px" id="nombre" runat="server" required="required" title="El nombre no debe estar vacío" pattern="^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.-]+$" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%;">Correo electronico:</td>
                        <td>
                            <input class="textbox" style="width: 500px" id="correo" runat="server" required="required" title="Debe ser una dirección de correo válida ej: usuario@dominio.com" pattern="[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%;">Estado:</td>
                        <td>
                            <asp:DropDownList ID="estado" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="acciones" runat="server">
                        <td>
                            <input id="btnEditar" type="button" value="Editar" runat="server" onserverclick="clickEditar" />
                        </td>
                        <td>
                            <input type="button" id="reestablecer" value="Reestablecer Contraseña" runat="server" onserverclick="seleccionarReestablecer" style="width: 200px" />
                                <!-- Modal -->
                                <div class="modal fade" id="modalReestablecer" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h4 class="modal-title" id="myModalLabel">Reestablecer contraseña</h4>
                                            </div>
                                            <div class="modal-body">
                                                <p>¿Desea reestablecer la contraseña? Se reestablecerá usando el mismo nombre de usuario</p>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-success" runat="server" onserverclick="clickReestablecer" data-dismiss="modal">Aceptar</button>
                                                <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                        </td>
                    </tr>
                </table>
            </div>

            <div class="well bs-component">

                <legend>
                    <h4>Roles</h4>
                </legend>

                <table>
                    <tr>
                        <td>
                            <asp:GridView CssClass="form-control" Class="Gridcontenedor" ID="rolesGrid" Style="width: 100%; height: 100%" runat="server">
                                <SelectedRowStyle BackColor="LightCyan"
                                    ForeColor="DarkBlue"
                                    Font-Bold="true" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkRol" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 10%;">Estacion:</td>
                        <td>
                            <asp:DropDownList ID="estacion" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>

            <table>
                <tr>
                    <td>
                        <input type="submit" id="btnAceptar" class="btn btn-success" value="Aceptar" runat="server" onserverclick="clickAceptar" on />
                    </td>
                    <td>
                        <input type="button" class="btn-danger" value="Cancelar" runat="server" onserverclick="clickCancelar" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
