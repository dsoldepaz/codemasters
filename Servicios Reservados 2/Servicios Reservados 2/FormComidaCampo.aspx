﻿<%@ Page Title="ComidaCampo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormComidaCampo.aspx.cs" Inherits="Servicios_Reservados_2.FormComidaCampo" %>

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
                <li>Hora:<input id="txtHora" runat="server" type="time" />
                </li>
             </ul>
        </div>
        <fieldset>
        <div class="centraldiv">
              <span class="radios">
            <input type="radio" name="turn" value="desayuno" checked>Desayuno
							<input type="radio" name="turn" value="almuerzo">Almuerzo
							<input type="radio" name="turn" value="cena">Cena	
             </span>	
        </div>
        </fieldset>
    </div>
   </fieldset>
    <fieldset class="containerdiv">
        <legend>Opción #1 Sandwich [puede marcar dos opciónes]</legend>
        <div class="centraldiv">
            <span class="radios">
                <input type="radio" name="bread" value="panblanco" checked>Pan blanco
							<input type="radio" name="bread" value="panintegral">Pan integral
							<input type="radio" name="bread" value="panbollo">Pan bollo
            </span>
        </div>
        <div class="optionblock">

            <div class="blockdivleft">
                <input type="radio" name="spreadoption" value="jamon">Jamón
								<br>
                <input type="radio" name="spreadoption" value="atun">Atún 
								<br>
                <input type="radio" name="spreadoption" value="frijoles">Frijoles
            </div>
            <div class="blockdivright">
                <input type="radio" name="spreadoption" value="mantequillamani">Mantequilla Maní y jalea 
								<br>
                <input type="radio" name="spreadoption" value="omelette">Omelette 
								<br>
                <input type="radio" name="spreadoption" value="ensaladahuevo">Ensalada de huevo 	
            </div>
        </div>
    </fieldset>

    <fieldset class="containerdiv">
        <legend>Opción #2 Debe aportar su propio recipiente</legend>
        <input type="checkbox" name="pinto" value="gallopinto">Gallo pinto
    </fieldset>

    <fieldset>
        <legend>Adicional (marque la opción que desea)</legend>
        <div class="optionblock">
            <div class="blockdivleft">
                <input type="checkbox" name="adicional" value="ensalada">Ensalada
								<br>
                <input type="checkbox" name="adicional" value="mayonesa">Mayonesa
								<br>
                <input type="checkbox" name="adicional" value="confites">Confites
								<br>
                <input type="checkbox" name="adicional" value="frutas">Frutas
            </div>
            <div class="blockdivright">
                <input type="checkbox" name="adicional" value="salsatomate">Salsa de tomate 
								<br>
                <input type="checkbox" name="adicional" value="huevos">Huevos duros 
								<br>
                <input type="checkbox" name="adicional" value="galletas">Galletas
								<br>
                <input type="checkbox" name="adicional" value="platanos">Platanos								
            </div>
        </div>
    </fieldset>
    <fieldset class="containerdiv">
        <legend>Escoja la opción para bebida</legend>
        <div class="centraldiv">
            <span class="radios">
                <input type="radio" name="drink" value="agua" checked>Agua
							<input type="radio" name="drink" value="jugo">Jugo
            </span>
        </div>
    </fieldset>

    <div id="buttons">
        <button class="btn btn-success" name="accept" type="button">Aceptar</button>
        <button class="btn btn-danger" name="cancel" type="button">cancelar</button>
    </div>

	
</asp:Content>