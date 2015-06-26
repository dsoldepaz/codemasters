<%@ Page Title="Reestablecer Contraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormReestablecer.aspx.cs" Inherits="Servicios_Reservados_2.FormReestablecer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <legend>
                            <h2>Reestablecer contraseña</h2>
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
                <legend style="color: #7BC143">Intruduzca una nueva contraseña</legend>
                <p>Debe tener de 8 a 20 caracteres, al menos una mayúscula, al menos una minúscula y al menos un número. Ej: codeMasters9001</p>
                <h5>Nueva contraseña:</h5>
                <asp:TextBox ID="txtContraseña" TextMode="Password" runat="server" required="required" title="Debe tener de 8 a 20 caracteres, al menos una mayúscula, al menos una minúscula y al menos un número" pattern="((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,20})$"></asp:TextBox>
                <asp:Button ID="btnReestablecer" class="btn btn-success" runat="server" Text="Aceptar" OnClick="clickReestablecer" />
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
