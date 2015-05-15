<%@ Page Title="ComidaCampo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormComidaCampo.aspx.cs" Inherits="Servicios_Reservados_2.FormComidaCampo" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
     
    <!--<legend>
        <h2>Comida Campo</h2>
    </legend>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="well bs-component">
                <fieldset>
                   

                    <table>
                        <tr>
                         
                            <td>Fecha:</td>
                            <td>
                                <input id="txtEstacion" runat="server" />
                            </td>
                            <td>Hora:</td>
                            <td>
                                <input id="txtNombre" runat="server" /></td>

                        </tr>
                        <tr>
                            <td>PAX:</td>
                            <td>
                                <input id="fechaFinal" runat="server" /></select>
                            </td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            <div class="well bs-component">
                <fieldset>
                    <legend style="color: #7BC143">Opción #1 Sandwich [puede marcar dos opciónes]</legend>
                    <table>
                        <tr>
                                <input type="radio" name="bread" value="Pan blanco" checked runat="server" id="radioPanBlanco">Pan Blanco

                     
                            <td>
                                <input type="button" class="btn btn-success" value="Comida De Campo" onserverclick="cliclAgregarComidaCampo" />
                            </td>
                            <td>
                                <input type="button" class="btn btn-success" value="Servicio de Guías" /></td>
                        </tr>
                    </table>
            </div>
            <div class="well bs-component">
                <fieldset>

                    <legend style="color: #7BC143">Listado de servicios</legend>

                        <div class="well bs-component" style="background-color: white">
                            <table>
                                <tr>
                                    <td style="width: 95%">
                                        <asp:GridView ID="GridServicios" runat="server" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="seleccionarServicio">
                                            <SelectedRowStyle BackColor="#7BC143" />
                                        </asp:GridView>

                                    </td>
                                    <td>
                                        <div class="btn-group-vertical">
                                            <input type="button" class="btn btn-success" value="Consultar" runat="server" onserverclick="clickConsultarServicio"/>
                                            <input type="button" class="btn btn-success" value="Modificar" runat="server" onserverclick="modificarServicio" />
                                            <input type="button" class="btn btn-success" value="Elimnar" runat="server" onserverclick="clickEliminarServicio"/>

                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>

                </fieldset>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>-->

  
	
</asp:Content>