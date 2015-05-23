<%@ Page Title="ComidaCampo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormComidaCampo.aspx.cs" Inherits="Servicios_Reservados_2.FormComidaCampo" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="Content/ComidasExtra.css" />

      <a href="">
        <div id="alertAlerta" class="alert alert-danger fade in" runat="server" hidden="hidden">
            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
            <strong>
                <asp:Label ID="labelTipoAlerta" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="labelAlerta" runat="server" Text="Mensaje de alerta"></asp:Label>
        </div>
    </a> <!--para manejar mensajes de exito/error!-->

    <legend>
        <h2>Comida Campo</h2>
    </legend>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                    
                  
                        </li>
                        <il class="itemFormulario">
                            Hora:
                            <input id="txtHora" runat="server" />
                        </il>
                        <il class="itemFormulario">
                            Pax:
                            <input id="txtPax" runat="server" />
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
                    <legend style="color: #7BC143">Opción #1 Reemplezar por: </legend>
                    <input type="checkbox" name="opciones" value="chbxo2" id="CheckboxCambio" runat="server">
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <input type="radio" name="desayuno" value="desayuno" id="radioDesayuno" runat="server">Desayuno
                            <input type="radio" name="almuerzo" value="desayuno" id="radioAlmuerzo" runat="server">Almuerzo
                            <input type="radio" name="cena" value="desayuno" id="radioCena" runat="server">Cena
                       </il>
                    </ul>
                </fieldset>
            </div>

            <div class="well bs-component">
                                     <table>
                        <tr>
                            <td>
                                <button style="background-color:white" id= "btnO2" name="btnO1" type="button" runat="server" onserverclick="checkO2"></button>
                                
                            </td>
                            <td>
                                <h4>Opción #2 Sandwich [puede marcar dos opciónes] </h4>
                            </td>
                        </tr>
                    </table>
                <fieldset id="fieldsetO2" visible="false" runat="server">

                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <input type="radio" name="bread" value="panblanco" runat="server" id="radioPanBlanco">Pan blanco
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
                </fieldset>
            </div>
            <div class="well bs-component">
                <fieldset id="opcion2Fieldset" runat="server">
                    <legend style="color: #7BC143">Opción #3 Debe aportar su propio recipiente</legend>
                    <input type="checkbox" name="opciones" value="chbxo2" id="CheckboxO2" runat="server">
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <input type="checkbox" name="pinto" value="gallopinto" id="chGalloPinto" runat="server">Gallo pinto
                       </il>
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
                    
                    <legend style="color: #7BC143">Escoja la opción para bebida</legend>
                    <input type="checkbox" name="opciones" value="chbxbebida" id="CheckboxBebida" runat="server">
                    <ul class="lista formulario">
                        <il class="itemFormulario">
                            <input type="radio" name="drink" value="agua" id="radioAgua" runat="server">Agua
                       </il>
                        <il class="itemFormulario">
                           <input type="radio" name="drink" value="jugo" id="radioJugo" runat="server">Jugo
                        </il>
                    </ul>
                </fieldset>
                <button class="btn btn-success" id= "btnAgregar" name="accept" type="button" runat="server" onserverclick="clickAceptar">Aceptar</button>
                <button class="btn btn-danger" name="cancel" type="button" runat="server" onserverclick="clickCancelar">cancelar</button>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
   

</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
