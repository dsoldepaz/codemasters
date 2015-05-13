<%@ Page Title="ComidaCampo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormComidaCampo.aspx.cs" Inherits="Servicios_Reservados_2.FormComidaCampo" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <legend><h2>Comida de Campo</h2></legend>
    <fieldset>
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
                <li>Hora:<input id="txtHora" runat="server" />
                </li>
             </ul>
        </div>
        <fieldset>
        <div class="containerdiv">
              <span class="radios">
            <input type="radio" name="turn" id="radioDesayuno" value="desayuno" runat="server" checked>Desayuno
			<input type="radio" name="turn" id="radioAlmuerzo" value="almuerzo" runat="server">Almuerzo
			<input type="radio" name="turn" id="radioCena" value="cena" runat="server">Cena	
             </span>	
        </div>
        </fieldset>
    </div>
   </fieldset>
    <fieldset class="containerdiv">
        <legend>Opción #1 Sandwich [puede marcar dos opciónes]</legend>
        <div class="centraldiv">
            <span class="radios">
                <input type="radio" name="bread" value="panblanco" checked runat="server" id="radioPanBlanco">Pan blanco
							<input type="radio" name="bread" value="panintegral" runat="server" id="radioPanInt">Pan integral
							<input type="radio" name="bread" value="panbollo" runat="server" id="radioPanBollo">Pan bollo
            </span>
        </div>
        </br>
        
            <div class="centraldiv">
                <input type="radio" name="spreadoption" value="jamon" id="radioJamon" runat="server">Jamón
								<br>
                <input type="radio" name="spreadoption" value="atun" id="radioAtun" runat="server">Atún 
								<br>
                <input type="radio" name="spreadoption" value="frijoles" id="radioFrijoles" runat="server">Frijoles
                        </br>
                <input type="radio" name="spreadoption" value="mantequillamani" id="radioMyM" runat="server">Mantequilla Maní y jalea 
								<br>
                <input type="radio" name="spreadoption" value="omelette" id="radioOmelette" runat="server">Omelette 
								<br>
                <input type="radio" name="spreadoption" value="ensaladahuevo" id="radioEnsaladaHuevo" runat="server">Ensalada de huevo 	
            </div>
    </fieldset>

    <fieldset class="containerdiv">
        <legend>Opción #2 Debe aportar su propio recipiente</legend>
        <div class="centraldiv">
        <input type="checkbox" name="pinto" value="gallopinto" id="chGalloPinto" runat="server">Gallo pinto
            </div>
    </fieldset>

    <fieldset class="containerdiv">
        <legend>Adicional (marque la opción que desea)</legend>
        <div class="centraldiv">
                <input type="checkbox" name="adicional" value="ensalada" id="chEnsalada" runat="server">Ensalada
								<br>
                <input type="checkbox" name="adicional" value="mayonesa" id="chMayonesa" runat="server">Mayonesa
								<br>
                <input type="checkbox" name="adicional" value="confites" id="chConfites" runat="server">Confites
								<br>
                <input type="checkbox" name="adicional" value="frutas" id="chFrutas" runat="server">Frutas
                    </br>
                <input type="checkbox" name="adicional" value="salsatomate" id="chSalsaTomate" runat="server">Salsa de tomate 
								<br>
                <input type="checkbox" name="adicional" value="huevos" id="chHuevos" runat="server">Huevos duros 
								<br>
                <input type="checkbox" name="adicional" value="galletas" id="chGalletas" runat="server">Galletas
								<br> 
                <input type="checkbox" name="adicional" value="platanos" id="chPlatanos" runat="server">Platanos								
            </div>
    </fieldset>
    <fieldset class="containerdiv">
        <legend>Escoja la opción para bebida</legend>
        <div class="centraldiv">
            <span class="radios">
                <input type="radio" name="drink" value="agua" checked id="radioAgua" runat="server">Agua
							</br>
               <input type="radio" name="drink" value="jugo" id="radioJugo" runat="server">Jugo
            </span>
        </div>
    </fieldset>

    <div id="buttons">
        <button class="btn btn-success" name="accept" type="button">Aceptar</button>
        <button class="btn btn-danger" name="cancel" type="button">cancelar</button>
    </div>

	
</asp:Content>