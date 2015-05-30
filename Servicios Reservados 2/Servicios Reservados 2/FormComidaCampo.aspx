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

                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <input type="radio" name="bread" value="panblanco" runat="server" id="radioPanBlanco" on>Pan blanco
                       </il>
                        <il class="itemFormulario">
                            <input type="radio" name="bread" value="panintegral" runat="server" id="radioPanInt">Pan integral
                        </il>
                        <il class="itemFormulario">
                          <input type="radio" name="bread" value="panbollo" runat="server" id="radioPanBollo">Pan bollo
                         </il>
                    </ul>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <input type="radio" name="spreadoption" value="jamon" id="radioJamon" runat="server">Jamón
                       </il>
                    </ul>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <input type="radio" name="spreadoption" value="atun" id="radioAtun" runat="server">Atún 
                       </il>
                    </ul>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <input type="radio" name="spreadoption" value="frijoles" id="radioFrijoles" runat="server">Frijoles
                       </il>
                    </ul>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                           <input type="radio" name="spreadoption" value="mantequillamani" id="radioMyM" runat="server">Mantequilla Maní y jalea 
                       </il>
                    </ul>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                           <input type="radio" name="spreadoption" value="omelette" id="radioOmelette" runat="server">Omelette 
                       </il>
                    </ul>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                           <input type="radio" name="spreadoption" value="ensaladahuevo" id="radioEnsaladaHuevo" runat="server">Ensalada de huevo 	
                       </il>
                    </ul>
                     <ul>
                         </li>
                        <li class="itemContenedor">Hora:<select id="cmbHoraSandwich" runat="server"></select>
                        </li>
                    </ul>
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
                    <legend style="color: #7BC143">Adicional</legend>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <input type="checkbox" name="adicional" value="ensalada" id="chEnsalada" runat="server">Ensalada
                       </il>
                    </ul>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                           <input type="checkbox" name="adicional" value="mayonesa" id="chMayonesa" runat="server">Mayonesa
                       </il>
                    </ul>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                             <input type="checkbox" name="adicional" value="confites" id="chConfites" runat="server">Confites
                       </il>
                    </ul>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                          <input type="checkbox" name="adicional" value="frutas" id="chFrutas" runat="server">Frutas
                       </il>
                    </ul>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                          <input type="checkbox" name="adicional" value="salsatomate" id="chSalsaTomate" runat="server">Salsa de tomate 
                       </il>
                    </ul>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <input type="checkbox" name="adicional" value="huevos" id="chHuevoDuro" runat="server">Huevos duros 
                       </il>
                    </ul>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <input type="checkbox" name="adicional" value="galletas" id="chGalletas" runat="server">Galletas
                       </il>
                    </ul>
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <input type="checkbox" name="adicional" value="platanos" id="chPlatanos" runat="server">Platanos
                       </il>
                    </ul>
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
</asp:Content>
