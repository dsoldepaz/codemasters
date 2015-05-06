<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="FormEmpleado.aspx.cs" Inherits="Servicios_Reservados_2.FormEmpleado" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="Content/site.css"/>
    <link rel="stylesheet" href="Content/empleado.css"/>
   
        <div>
            <h2>Empleados</h2>
            <fieldset>
                <legend style="color: #7BC143">Reservaciones de Empleado</legend>
                <table>
                    <tr>
                        <td style="width: 10%">Nombre:</td>
                        <td style="width: 70%">
                            <input class="textbox"/>
                        </td>
                        <td>
                            <button type="button" class="default" id="BotonBuscar">Buscar</button>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" Width="733px" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" runat="server">
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 76%">
                            <button type="button" class="btn btn-danger" id="BotonComidaCamp">Comida de campo</button>
                        </td>
                        <td>
                            <button type="button" class="btn btn-success" id="BotonServicioE">Servicio extra</button>
                        </td>
                    </tr>
                </table>

            </fieldset>

        </div>
    </asp:Content>
