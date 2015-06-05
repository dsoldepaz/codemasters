<%@ Page Title="Registro de usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormRegistro.aspx.cs" Inherits="Servicios_Reservados_2.FormRegistro" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="well bs-component">


                    <legend style="color: #7BC143">Registro de usuarios</legend>


                        <div class="well bs-component">
                            <fieldset>
                                <legend>
                                    <h4>Información personal </h4>
                                </legend>


                                <table>
                                    <tr>
                                        <td style="width: 10%;">Nombre de usuario:</td>
                                        <td>
                                            <input class="textbox" style="width: 500px" id="username" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 10%;">Contraseña:</td>
                                        <td>
                                            <input class="textbox" style="width: 500px" id="contrasena" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 10%;">Confirmar Contraseña:</td>
                                        <td>
                                            <input class="textbox" style="width: 500px" id="Text1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 10%;">Correo electronico:</td>
                                        <td>
                                            <input class="textbox" style="width: 500px" id="correo" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input type="button" class="btn btn-success" id="botonRegistrar" value="Registrar" /></a>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                                
                                <div class="well bs-component">
                                    <fieldset>
                                        <legend>
                                            <h4>Roles</h4>
                                        </legend>

                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <h5>Roles disponibles</h5>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>

                                                                <asp:GridView CssClass="form-control" Class="Gridcontenedor" ID="rolesDisponiblesGrid" Style="width: 100%; height: 100%" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="seleccionarDisponible">
                                                                    <SelectedRowStyle BackColor="LightCyan"
                                                                        ForeColor="DarkBlue"
                                                                        Font-Bold="true" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>

                                                <td>
                                                    <button runat="server" id="incluirRolBtn" onserverclick="incluirRolBtn_Click" type="button" class="btn btn-info btn-xs">>></button>
                                                    <br />
                                                    <button runat="server" id="sacarRolBtn" onserverclick="sacarRolBtn_Click" type="button" class="btn btn-info btn-xs"><<</button>
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <h5>Roles Asignados</h5>
                                                            </td>
                                                        </tr>
                                                        <tr>

                                                            <td>
                                                                <asp:GridView ID="rolesAsignadosGrid" CssClass="form-control" Class="Gridcontenedor" runat="server" Style="height: 100%" AutoGenerateSelectButton="True" OnSelectedIndexChanged="seleccionarAsignado">
                                                                    <SelectedRowStyle BackColor="LightCyan"
                                                                        ForeColor="DarkBlue"
                                                                        Font-Bold="true" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>                                                
                                            </tr>
                                        </table>

                                    </fieldset>
                                </div>
                            </fieldset>
                        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
