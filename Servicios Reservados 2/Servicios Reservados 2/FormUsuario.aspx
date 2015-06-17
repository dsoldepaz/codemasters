<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormUsuario.aspx.cs" Inherits="Servicios_Reservados_2.FormUsuario" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <link rel="stylesheet" href="Content/Servicios.css" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <legend>
                <h2>Administración de usuarios</h2>
            </legend>

           
            <div class="well bs-component">
                <legend style="color: #7BC143">Agregar</legend>
                <table>
                    <tr>
                        <td>
                            <input type="button" class="btn btn-Naranja" value="Usuario" runat="server" onserverclick="clickAgregar" />
                        </td>
                    </tr>
                </table>
            </div>
             <div class="well bs-component">
                <legend style="color: #7BC143">Filtro de usuarios</legend>
                <asp:Panel runat="server" DefaultButton="BotonBuscar">
                    <table>
                        <tr>
                            <td style="width: 10%;">Estación:</td>
                            <td>
                                <select style="width: 176px" id="cbxEstacion" runat="server"></select>
                            </td>
                            <td>Username:</td>
                            <td>
                                <input class="textbox" style="width: 500px" id="txtUsername" runat="server" />
                            </td>
                            <td>
                                <asp:Button Text="Buscar" class="btn btn-success" ID="BotonBuscar" OnClick="clickBuscar" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <legend style="color: #7BC143">Listado de usuarios</legend>

                <asp:GridView ID="GridUsuarios" runat="server" Class="Gridcontenedor" AllowSorting="true">
                    <AlternatingRowStyle BorderStyle="None" />
                    <HeaderStyle Font-Size="1.3em" />
                    <SelectedRowStyle BackColor="#7BC143"
                        ForeColor="Black"
                        Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnConsultar" CommandName="consultar" OnClick="clickConsultar" runat="server" class="btn btn-default" ToolTip="Consultar"><i class="glyphicon glyphicon-search"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
