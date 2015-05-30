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
                            <input style="width:50px" id="txtPax" runat="server" required="required" title="Inserte un número" pattern="^[0-9]+$"/>
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
                                <asp:CheckBox ID="checkO1" runat="server" OnCheckedChanged="checkedO1" AutoPostBack="true" />
                            </td>
                            <td>
                                <h4>Opción #1 Remplezar por:</h4>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td class="auto-style5">
                                <asp:RadioButton ID="radioDesayuno" runat="server" GroupName="opcion1" AutoPostBack="true" OnCheckedChanged="cambiarFechaD" /></td><td class="auto-style4">Desayuno</td>
                            <td class="auto-style5">
                                <asp:RadioButton ID="radioAlmuerzo" runat="server" GroupName="opcion1" AutoPostBack="true" OnCheckedChanged="cambiarFechaA" /></td><td class="auto-style4">Almuerzo</td>
                            <td class="auto-style5">
                                <asp:RadioButton ID="radioCena" runat="server" GroupName="opcion1" AutoPostBack="true" OnCheckedChanged="cambiarFechaC" /></td><td class="auto-style4">Cena</td>

                        </tr>
                        <tr>
                            <td>Hora:</td><td><select id="cbxHoraOpcion1" runat="server"></select>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>

            <div class="well bs-component">
                <table>
                    <tr>
                        <td>
                            <asp:CheckBox ID="checkO2" runat="server" OnCheckedChanged="checkedO2" AutoPostBack="true" />
                        </td>
                        <td>
                            <h4>Opción #2 Sandwich [puede marcar dos opciones] </h4>
                        </td>
                    </tr>
                </table>
                <fieldset id="fieldsetO2" runat="server">
                                            <label>
                            Seleccione tipo Pan</label>
                    <table>
                        <tr>
                            <td  class="auto-style5">
                                <input id="radioPanBlanco" runat="server" name="bread" on="" type="radio" value="panblanco"></td><td class="auto-style4">Pan blanco</td>
                            <td class="auto-style5">
                                <input id="radioPanInt" runat="server" name="bread" type="radio" value="panintegral"></td><td class="auto-style4">Pan integral</td>
                            <td class="auto-style5">
                                <input id="radioPanBollo" runat="server" name="bread" type="radio" value="panbollo"></td><td class="auto-style4">Pan bollo</td>
                        </tr>
                    </table>
                                            <label>
                            Seleccione relleno</label>
                    <table>

                        <tr>
                            <td class="auto-style5">
                                <input id="radioJamon" runat="server" name="spreadoption" type="radio" value="jamon"></td><td class="auto-style4">Jamón</td>
                            <td class="auto-style5">
                                <input id="radioAtun" runat="server" name="spreadoption" type="radio" value="atun"></td><td class="auto-style4">Atún
                            </td>
                            <td  class="auto-style5">
                                <input id="radioFrijoles" runat="server" name="spreadoption" type="radio" value="frijoles"></td><td class="auto-style4">Frijoles</td>
                        </tr>
                        <tr>
                            <td  class="auto-style5">
                                <input id="radioMyM" runat="server" name="spreadoption" type="radio" value="mantequillamani"></td><td class="auto-style4">Mantequilla Maní y jalea</td>
                            <td>
                                <input id="radioOmelette" runat="server" name="spreadoption" type="radio" value="omelette"></td><td class="auto-style4">Omelette</td>
                            <td  class="auto-style5">
                                <input id="radioEnsaladaHuevo" runat="server" name="spreadoption" type="radio" value="ensaladahuevo"></td><td class="auto-style4">Ensalada de huevo</td>
                        </tr>
                        <tr>
                             <td>Hora:</td><td><select id="cmbHoraSandwich" runat="server"></select>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            <div class="well bs-component">
                <fieldset id="opcion2Fieldset" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:CheckBox ID="checkO3" runat="server" OnCheckedChanged="checkedO3" AutoPostBack="true" />
                            </td>
                            <td>
                                <h4>Opción #3 Gallo Pinto [Debe aportar su propio recipiente]</h4>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr><td>Hora:<select id="cmbHoraGalloPinto" runat="server"></select></td></tr>
                    </table>
                </fieldset>
            </div>
            <div class="well bs-component">
                <fieldset>
                    <legend>Adicional</legend>
                    <table>
                        <tr>
                            <td class="auto-style5">
                                <input type="checkbox" name="adicional" value="ensalada" id="chEnsalada" runat="server"></td><td class="auto-style4">Ensalada
                            </td>
                            <td class="auto-style5">
                                <input type="checkbox" name="adicional" value="mayonesa" id="chMayonesa" runat="server"></td><td class="auto-style4">Mayonesa
                            </td>
                            <td class="auto-style5">
                                <input type="checkbox" name="adicional" value="confites" id="chConfites" runat="server"></td><td class="auto-style4">Confites
                            </td>
                            <td class="auto-style5">
                                <input type="checkbox" name="adicional" value="frutas" id="chFrutas" runat="server"></td><td class="auto-style4">Frutas
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">
                                <input type="checkbox" name="adicional" value="salsatomate" id="chSalsaTomate" runat="server"></td><td class="auto-style4">Salsa de tomate 
                            </td>
                            <td class="auto-style5">
                                <input type="checkbox" name="adicional" value="huevos" id="chHuevoDuro" runat="server"></td><td class="auto-style4">Huevos duros 
                            </td>
                            <td class="auto-style5">
                                <input type="checkbox" name="adicional" value="galletas" id="chGalletas" runat="server"></td><td class="auto-style4">Galletas
                            </td>
                            <td class="auto-style5">
                                <input type="checkbox" name="adicional" value="platanos" id="chPlatanos" runat="server"></td><td class="auto-style4">Platanos
                            </td>
                    </table>
                </fieldset>
            </div>
            <div class="well bs-component">
                <fieldset>
                    <table>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckboxBebida" runat="server" OnCheckedChanged="checkbebida" AutoPostBack="true" />
                            </td>
                            <td>
                                <h4>Escoja la opción para bebida</h4>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td class="auto-style5">
                                <input type="radio" name="drink" value="agua" id="radioAgua" runat="server"></td><td class="auto-style4">Agua</td>
                            <td class="auto-style5">
                                <input type="radio" name="drink" value="jugo" id="radioJugo" runat="server"></td><td class="auto-style4">Jugo</td>
                        </tr>
                    </table>
                </fieldset>
                <button class="btn btn-danger" name="cancel" type="button" runat="server" onserverclick="clickCancelar">Cancelar</button>
                <input class="btn btn-success" id="btnAgregar" value="Aceptar" type="submit" runat="server" onserverclick="clickAceptar" />

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">

    <style type="text/css">
        .auto-style1 {
            width: 30px;
        }
        .auto-style2 {
            width: 16px;
        }
        .auto-style3 {
            width: 46px;
        }
        .auto-style4 {
            height: 36px;
        }
        .auto-style5 {
            width: 46px;
            height: 36px;
        }
    </style>

</asp:Content>
