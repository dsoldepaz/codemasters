<%@ Page Title="ComidaCampo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormComidaCampo.aspx.cs" Inherits="Servicios_Reservados_2.FormComidaCampo" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
     
   <legend>
        <h2>Comida Campo</h2>
    </legend>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="well bs-component">
                <fieldset>
                    <p>
                        Fecha:<input runat="server" id="textFecha" onselect="fechaDeEntradaCalendario_SelectionChanged" disabled />
                        <input id="fechaDeEntrada" class="selectorDeFecha" type="button" runat="server" onserverclick="fechaDeEntrada_ServerClick" />
                    </p>
                    <asp:Calendar ID="fechaDeEntradaCalendario" runat="server" BackColor="#CCCCCC" BorderStyle="Dashed" BorderWidth="1px" ForeColor="#7BC143" Height="80px" OnSelectionChanged="fechaDeEntradaCalendario_SelectionChanged" Visible="false" Width="100px">
                        <DayHeaderStyle ForeColor="#333333" Wrap="True" />
                        <DayStyle ForeColor="Black" />
                        <NextPrevStyle ForeColor="Black" />
                        <TitleStyle BackColor="#7BC143" ForeColor="#333333" />
                    </asp:Calendar>
                    <p>
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
                            Tipo Pago:
                            <select id="cmbTipoPago" runat="server"/>
                        </il>
                    </p>
                    <il class="itemFormulario">
                        <input id="radioDesayuno" runat="server" name="turn" type="radio" value="desayuno">Desayuno </input></il>
                    <il class="itemFormulario">
                        <input id="radioAlmuerzo" runat="server" name="turn" type="radio" value="almuerzo">Almuerzo </input></il>
                    <il class="itemFormulario">
                        <input id="radioCena" runat="server" name="turn" type="radio" value="cena">Cena </input></il>
                </fieldset>
            </div>
            <div class="well bs-component">
                <fieldset>
                    <legend style="color: #7BC143">Opción #1 Sandwich [puede marcar dos opciónes]</legend>
                   <ul class ="lista formulario">
                       <il class="itemFormulario">
                            <input type="radio" name="bread" value="panblanco" checked runat="server" id="radioPanBlanco">Pan blanco
                       </il>
                        <il class="itemFormulario">
                            <input type="radio" name="bread" value="panintegral" runat="server" id="radioPanInt">Pan integral
                        </il>
                         <il class="itemFormulario">
                          <input type="radio" name="bread" value="panbollo" runat="server" id="radioPanBollo">Pan bollo
                         </il>
                       </ul>
                    <ul class ="lista formulario">
                        <il class="itemFormulario">
                            <input type="radio" name="spreadoption" value="jamon" id="radioJamon" runat="server">Jamón
                       </il>
                        </ul>
                      <ul class ="lista formulario">
                        <il class="itemFormulario">
                            <input type="radio" name="spreadoption" value="atun" id="radioAtun" runat="server">Atún 
                       </il>
                        </ul>
                      <ul class ="lista formulario">
                        <il class="itemFormulario">
                            <input type="radio" name="spreadoption" value="frijoles" id="radioFrijoles" runat="server">Frijoles
                       </il>
                        </ul>
                      <ul class ="lista formulario">
                        <il class="itemFormulario">
                           <input type="radio" name="spreadoption" value="mantequillamani" id="radioMyM" runat="server">Mantequilla Maní y jalea 
                       </il>
                        </ul>
                      <ul class ="lista formulario">
                        <il class="itemFormulario">
                           <input type="radio" name="spreadoption" value="omelette" id="radioOmelette" runat="server">Omelette 
                       </il>
                        </ul>
                      <ul class ="lista formulario">
                        <il class="itemFormulario">
                           <input type="radio" name="spreadoption" value="ensaladahuevo" id="radioEnsaladaHuevo" runat="server">Ensalada de huevo 	
                       </il>
                        </ul>   
                    </fieldset>     
            </div>
            <div class="well bs-component">
                <fieldset>
                    <legend style="color: #7BC143">Opción #2 Debe aportar su propio recipiente</legend>
                    <ul class ="lista formulario">
                        <il class="itemFormulario">
                            <input type="checkbox" name="pinto" value="gallopinto" id="chGalloPinto" runat="server">Gallo pinto
                       </il>
                        </ul>
                    </fieldset>     
            </div>
            <div class="well bs-component">
                <fieldset>
                    <legend style="color: #7BC143">Adicional</legend>
                    <ul class ="lista formulario">
                        <il class="itemFormulario">
                            <input type="checkbox" name="adicional" value="ensalada" id="chEnsalada" runat="server">Ensalada
                       </il>
                        </ul>
                      <ul class ="lista formulario">
                        <il class="itemFormulario">
                           <input type="checkbox" name="adicional" value="mayonesa" id="chMayonesa" runat="server">Mayonesa
                       </il>
                        </ul>
                      <ul class ="lista formulario">
                        <il class="itemFormulario">
                             <input type="checkbox" name="adicional" value="confites" id="chConfites" runat="server">Confites
                       </il>
                        </ul>
                      <ul class ="lista formulario">
                        <il class="itemFormulario">
                          <input type="checkbox" name="adicional" value="frutas" id="chFrutas" runat="server">Frutas
                       </il>
                        </ul>
                      <ul class ="lista formulario">
                        <il class="itemFormulario">
                          <input type="checkbox" name="adicional" value="salsatomate" id="chSalsaTomate" runat="server">Salsa de tomate 
                       </il>
                        </ul>
                      <ul class ="lista formulario">
                        <il class="itemFormulario">
                            <input type="checkbox" name="adicional" value="huevos" id="chHuevos" runat="server">Huevos duros 
                       </il>
                        </ul>   
                    <ul class ="lista formulario">
                        <il class="itemFormulario">
                            <input type="checkbox" name="adicional" value="huevos" id="Checkbox1" runat="server">Huevos duros 
                       </il>
                        </ul>   
                    <ul class ="lista formulario">
                        <il class="itemFormulario">
                            <input type="checkbox" name="adicional" value="galletas" id="chGalletas" runat="server">Galletas
                       </il>
                        </ul>   
                    <ul class ="lista formulario">
                        <il class="itemFormulario">
                            <input type="checkbox" name="adicional" value="platanos" id="chPlatanos" runat="server">Platanos
                       </il>
                        </ul>   
                    </fieldset>     
            </div>
            <div class="well bs-component">
                <fieldset>
                    <legend style="color: #7BC143">Escoja la opción para bebida</legend>
                   <ul class ="lista formulario">
                       <il class="itemFormulario">
                            <input type="radio" name="drink" value="agua" checked id="radioAgua" runat="server">Agua
                       </il>
                        <il class="itemFormulario">
                           <input type="radio" name="drink" value="jugo" id="radioJugo" runat="server">Jugo
                        </il>
                       </ul>       
                    </fieldset>     
                 <button class="btn btn-success" name="accept" type="button">Aceptar</button>
                 <button class="btn btn-danger" name="cancel" type="button">cancelar</button>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

  
	
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
