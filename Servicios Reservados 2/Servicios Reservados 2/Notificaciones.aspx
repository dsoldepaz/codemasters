<%@ Page Title="Notificaciones -servicios Reservados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notificaciones.aspx.cs" Inherits="Servicios_Reservados_2.Notificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <legend>
                            <h2>Notificaciones del día</h2>
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

            <div class="well">
                <asp:GridView ID="GridNotificaciones" Class="Gridcontenedor" runat="server" Width="80%">
                </asp:GridView>
                <input type="button" value="cancelar" class="btn btn-danger" runat="server" id="cancelar" onclick="bntCancelarClick" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
