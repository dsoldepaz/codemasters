<%@ Page Title="Acerca de" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AcercaDe.aspx.cs" Inherits="Servicios_Reservados_2.AcercaDe" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
     <nav>
        <ul>
            <li class="item-navegacion"><a href="Default.aspx" title="Página principal"><i class="glyphicon glyphicon-home"></i></a></li>           
            <li class="item-navegacion"><a href="Notificaciones.aspx" title="Notificaciones">Notificaciones <span class="notificacion" id="contador" runat="server">0</span></a></li>
        </ul>
    </nav>
     <table>
                <tr>
                    <td>
                        <legend>
                            <h2>Acerca de</h2>
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
        <legend>Sistema de servicios reservados</legend>

        <p>
            El control de servicios de alimentación para clientes y empleados se basa en la asignación previa 
            Con estas reservaciones se 
        </p>

        <h3>Diseñado e implementado por Code Masters en colaboracion con la Universidad de Costa Rica para OET</h3>
        <ul>
            <li>José Vitaly Mayorga Jvozt</li>
            <li>Armando Nevares Luis</li>
            <li>José Daniel Picado Hidalgo</li>
            <li>David Solís De la Paz</li>
            <li>Dalila Vásquez Barrantes</li>
        </ul>

    </div>
</asp:Content>
