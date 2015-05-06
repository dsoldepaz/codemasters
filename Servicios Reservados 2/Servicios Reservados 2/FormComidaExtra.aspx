﻿<%@ Page Title="Comida Extra" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormComidaExtra.aspx.cs" Inherits="Servicios_Reservados_2.FormComidaExtra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <link rel="stylesheet" href="Content/ComidasExtra.css" />

    <a href="">
        <div id="alertAlerta" class="alert alert-danger fade in" runat="server" hidden="hidden">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
            <strong>
                <asp:Label ID="labelTipoAlerta" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="labelAlerta" runat="server" Text="Mensaje de alerta"></asp:Label>
        </div>
    </a>

    <fieldset>
         <legend>
                        <h2>Comida Extra</h2>
                    </legend>
        
              <div class="well bs-component">
            <ul>
                <li class="itemContenedor">Fecha:<input runat="server" id="textFecha" onselect="fechaDeEntradaCalendario_SelectionChanged" disabled />
                    <input id="fechaDeEntrada" class="selectorDeFecha" type="button" runat="server" onserverclick="fechaDeEntrada_ServerClick" />
                    <asp:Calendar ID="fechaDeEntradaCalendario" runat="server" BackColor="#CCCCCC" BorderStyle="Dashed" ForeColor="#7BC143" Height="80px" Width="100px" BorderWidth="1px" Visible="false" OnSelectionChanged="fechaDeEntradaCalendario_SelectionChanged">
                        <DayHeaderStyle ForeColor="#333333" Wrap="True" />
                        <DayStyle ForeColor="Black" />
                        <NextPrevStyle ForeColor="Black" />
                        <TitleStyle BackColor="#7BC143" ForeColor="#333333" />
                    </asp:Calendar>
                </li>
                <li class="itemContenedor">Hora:<input id="txtHora" runat="server" />
                </li>
                <li class="itemContenedor">#PAX:<input id="txtPax" runat="server" type="number" required="required" placeholder="Entre un digito" />

                </li>
                <li class="itemContenedor">Tipo:<select id="cbxTipo" runat="server"></select>
                </li>

            </ul>
            <p>
                <label>Notas:</label>
                <textarea id="txaNotas" cols="20" name="S1" rows="2" runat="server"></textarea>
            </p>
                  <table>
                        <tr>
                            <td><a href="FormComidaExtra.aspx">
                                <input type="button" class="btn btn-success" value="Cancelar" /></a></td>
                            <td>
                                <input type="button" class="btn btn-success" value="Aceptar" runat="server" onserverclick="clickAceptar"/>
                            </td>
                            
                        </tr>
                    </table>

        </div>
    </fieldset>


</asp:Content>
