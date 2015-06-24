<%@ Page Title="Perfil de usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormPerfil.aspx.cs" Inherits="Servicios_Reservados_2.FormPerfil" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <a href="">
                <div id="alertAlerta" class="alert alert-danger fade in" runat="server" hidden="hidden">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <strong>
                        <asp:Label ID="labelTipoAlerta" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="labelAlerta" runat="server" Text="Mensaje de alerta"></asp:Label>
                </div>
            </a>


            <legend style="color: #7BC143">Perfil de usuario</legend>

            <div class="well bs-component">
                <legend>
                    <h4>Información personal </h4>
                </legend>

                <table>
                    <tr>
                        <td style="width: 10%;">Username:</td>
                        <td>
                            <input class="textbox" style="width: 500px" id="username" runat="server" />
                        </td>
                    </tr>                   
                    <tr>
                        <td style="width: 10%;">Nombre:</td>
                        <td>
                            <input class="textbox" style="width: 500px" id="nombre" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%;">Correo electronico:</td>
                        <td>
                            <input class="textbox" style="width: 500px" id="correo" runat="server" />
                        </td>
                    </tr>
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
                        <input type="button" id="btnAceptar" value="Aceptar" runat="server" onserverclick="clickAceptar" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
