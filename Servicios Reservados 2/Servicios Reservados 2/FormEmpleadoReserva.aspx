﻿<%@ Page Language="C#" Title="Empleados" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="FormEmpleadoReserva.aspx.cs" Inherits="Servicios_Reservados_2.FormEmpleadoReserva" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="Content/empleado.css"/>
        <nav>
            <ul>
                <li class="item-navegacion"><a href="FormReservaciones.aspx">Reservaciones</a></li>
                <li class="item-navegacion"><a href="FormEmpleadoReserva.aspx"  class="seleccionado">Empleados</a></li>
                <li class="item-navegacion">Notificaciones <span class="notificacion">0</span></li>
                <li class="item-navegacion"><a href="FormReportesComedor.aspx">Reportes</a></li>

            </ul>
        </nav>
        <div>
            <h2>Empleados</h2>
            <fieldset>
                <legend style="color: #7BC143">Reservación del Empleado</legend>
                <table>
                    <tr>
                        <td style="width: 10%">Nombre:</td>
                        <td style="width: 40%">
                            <input class="textbox"/>
                        </td>
                        <td style="width: 15%">Cantidad de Personas:</td>
                        <td>
                            <input class="textbox"/>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                         <td style="width: 20%">Tipo Comida:</td>
                        <td>
                            <select style="width: 176px"></select>
                        </td>
                        <td style="width: 20%">Fecha:</td>
                        <td>
                            <select style="width: 176px"></select> <!--MODIFICAR CALENDARIO-->
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                          <td style="width: 20%">Descripción:</td>
                        <td>
                           <textarea id="notasEmp" cols="20" name="S1" rows="2"></textarea>
                        </td>
                    </tr>
                </table>
               

            </fieldset>

        </div>
    </asp:Content>
