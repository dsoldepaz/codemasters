<%@ Page Title="ComidaCampo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormComidaCampo.aspx.cs" Inherits="Servicios_Reservados_2.FormComidaCampo" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <link rel="stylesheet" href="Content/ComidasExtra.css" />



    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a href="">
                <div id="alertAlerta" class="alert alert-danger fade in" runat="server" hidden="hidden">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <strong>
                        <asp:Label ID="labelTipoAlerta" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="labelAlerta" runat="server" Text="Mensaje de alerta"></asp:Label>
                </div>
            </a>
            <legend>
                <h2>Comida Campo</h2>
            </legend>
            <div class="well bs-component">
                <fieldset>
                    <ul>
                        <li class="itemContenedor">Fecha:<input runat="server" id="textFecha" onselect="fechaDeEntradaCalendario_SelectionChanged" disabled />
                            <input id="fechaDeEntrada" class="selectorDeFecha" type="button" runat="server" onserverclick="fechaDeEntrada_ServerClick" />
                            <asp:Calendar ID="fechaDeEntradaCalendario" runat="server" BackColor="#CCCCCC" BorderStyle="Dashed" BorderWidth="1px" ForeColor="#7BC143" Height="80px" OnSelectionChanged="fechaDeEntradaCalendario_SelectionChanged" Visible="false" Width="100px">
                                <DayHeaderStyle ForeColor="#333333" Wrap="True" />
                                <DayStyle ForeColor="Black" />
                                <NextPrevStyle ForeColor="Black" />
                                <TitleStyle BackColor="#7BC143" ForeColor="#333333" />
                            </asp:Calendar>
                        </li>

                        <il class="itemFormulario">
                            Pax:
                            <input id="txtPax" runat="server" required="required" title="Inserte un número" pattern="^[0-9]+$"/>
                        </il>
                        <il class="itemFormulario">
                            <label class="labelfont" id="labelPago" runat="server">Tipo Pago:</label>
                            <select id="cmbTipoPago" runat="server">
                            <option value="De contado">De contado</option>
                            <option value="Rebajo de planilla">Rebajo de planilla</option>
                            </select>
                        </il>
                        </p>
                    </ul>

                </fieldset>
            </div>
            <div class="well bs-component">
                <fieldset id="Fieldset1" runat="server">
                    <table>
                    <tr>
                        <td>
                            <asp:CheckBox ID="checkO1" runat="server" OnCheckedChanged="checkedO1" AutoPostBack ="true"/>
                        </td>
                        <td>
                            <h4>Opción #1 Remplezar por:</h4>
                        </td>
                    </tr>
                </table>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <asp:RadioButton ID="radioDesayuno" runat="server" GroupName="opcion1" AutoPostBack ="true" OnCheckedChanged="cambiarFechaD"/>Desayuno
                            <asp:RadioButton ID="radioAlmuerzo" runat="server" GroupName="opcion1" AutoPostBack ="true" OnCheckedChanged="cambiarFechaA"/>Almuerzo
                            <asp:RadioButton ID="radioCena" runat="server" GroupName="opcion1" AutoPostBack ="true" OnCheckedChanged="cambiarFechaC"/>Cena
                            
                       </il>
                        </ul>
                    <ul>
                         </li>
                        <li class="itemContenedor">Hora:<select id="cbxHoraOpcion1" runat="server"></select>
                        </li>
                    </ul>

                </fieldset>
            </div>

            <div class="well bs-component">
                <table>
                    <tr>
                        <td>
                            <asp:CheckBox ID="checkO2" runat="server" OnCheckedChanged="checkedO2" AutoPostBack ="true"/>
                        </td>
                        <td>
                            <h4>Opción #2 Sandwich [puede marcar dos opciones] </h4>
                        </td>
                    </tr>
                    </table>
                <fieldset id="fieldsetO2" runat="server">
                    <table>
                       <caption>
                                <label>
                                Seleccionar tipo Pan</label></caption>
                        <tr>
                                <td>
                                    <input id="radioPanBlanco" runat="server" name="bread" on="" type="radio" value="panblanco">Pan blanco</td>
                                    <td>
                                        <input id="radioPanInt" runat="server" name="bread" type="radio" value="panintegral">Pan integral</td>
                                    <td>
                                        <input id="radioPanBollo" runat="server" name="bread" type="radio" value="panbollo">Pan bollo</td>
                            </tr>
                               </table>
                    <table>
                            <caption>
                                <label>
                                Seleccionar relleno</label></caption>
                                <tr>
                                    <td>
                                        <input id="radioJamon" runat="server" name="spreadoption" type="radio" value="jamon">Jamón</td>
                                    <td>
                                        <input id="radioAtun" runat="server" name="spreadoption" type="radio" value="atun">Atún
                                       </td>
                                        <td>
                                            <input id="radioFrijoles" runat="server" name="spreadoption" type="radio" value="frijoles">Frijoles</td>
                                </tr>
                                <tr>
                                    <td>
                                        <input id="radioMyM" runat="server" name="spreadoption" type="radio" value="mantequillamani">Mantequilla Maní y jalea</td>
                                    <td>
                                        <input id="radioOmelette" runat="server" name="spreadoption" type="radio" value="omelette">Omelette</td>
                                    <td>
                                        <input id="radioEnsaladaHuevo" runat="server" name="spreadoption" type="radio" value="ensaladahuevo">Ensalada de huevo</td>
                                </tr>
                                <tr>
                                    <td>Hora:<select id="cmbHoraSandwich" runat="server">
                                        </select> </td>
                                </tr>
                        </table>
                </fieldset>
            </div>
            <div class="well bs-component">
                <fieldset id="opcion2Fieldset" runat="server">
                    <table>
                    <tr>
                        <td>
                            <asp:CheckBox ID="checkO3" runat="server" OnCheckedChanged="checkedO3" AutoPostBack ="true"/> 
                        </td>
                        <td>
                            <h4>Opción #3 Debe aportar su propio recipiente</h4>
                        </td>
                    </tr>
                </table>
                    
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <input type="checkbox" name="pinto" value="gallopinto" id="chGalloPinto" runat="server">Gallo pinto
                       </il>
                    </ul>
                      <ul>
                         </li>
                        <li class="itemContenedor">Hora:<select id="cmbHoraGalloPinto" runat="server"></select>
                        </li>
                    </ul>
                </fieldset>
            </div>
            <div class="well bs-component">
                <fieldset>
                    <legend>Adicional</legend>
                    <table>
                   <tr>
                        <td>
                            <input type="checkbox" name="adicional" value="ensalada" id="chEnsalada" runat="server">Ensalada
                       </td>
                        <td>
                           <input type="checkbox" name="adicional" value="mayonesa" id="chMayonesa" runat="server">Mayonesa
                       </td>
                        <td>
                             <input type="checkbox" name="adicional" value="confites" id="chConfites" runat="server">Confites
                       </td>
                        <td>
                          <input type="checkbox" name="adicional" value="frutas" id="chFrutas" runat="server">Frutas
                    </td>
                       </tr>
                        <tr>
                        <td>
                          <input type="checkbox" name="adicional" value="salsatomate" id="chSalsaTomate" runat="server">Salsa de tomate 
                       </td>
                        <td>
                            <input type="checkbox" name="adicional" value="huevos" id="chHuevoDuro" runat="server">Huevos duros 
                       </td>
                        <td>
                            <input type="checkbox" name="adicional" value="galletas" id="chGalletas" runat="server">Galletas
                       </td>
                    <td>
                            <input type="checkbox" name="adicional" value="platanos" id="chPlatanos" runat="server">Platanos
                       </il>
                    </td>
                   </table>
                </fieldset>
            </div>
            <div class="well bs-component">
                <fieldset>
                     <table>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckboxBebida" runat="server" OnCheckedChanged="checkbebida" AutoPostBack ="true"/>
                        </td>
                        <td>
                            <h4>Escoja la opción para bebida</h4>
                        </td>
                    </tr>
                </table>
                    
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <input type="radio" name="drink" value="agua" id="radioAgua" runat="server">Agua
                       </il>
                        <il class="itemFormulario">
                           <input type="radio" name="drink" value="jugo" id="radioJugo" runat="server">Jugo
                        </il>
                    </ul>
                </fieldset>
                <button class="btn btn-danger" name="cancel" type="button" runat="server" onserverclick="clickCancelar">Cancelar</button>
                <input class="btn btn-success" id="btnAgregar" value="Aceptar" type="submit" runat="server" onserverclick="clickAceptar"/>
                
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 242px;
        }
    </style>
</asp:Content>
