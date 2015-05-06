<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormLunchbox.aspx.cs" Inherits="Servicios_Reservados_2.lunchbox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Content/lunchboxstyles.css" type="text/css">
  <title>Comida-de-campo</title>
  <meta charset="utf-8" /><!-- METADATA to enable spanish chars-->	
</head>
<body>
    <form id="form1" runat="server">
    


        	<div><!--main div, contains all body do not apply styles here-->
		<form action="somescript.php" method="post">
			<fieldset><!--form elements such as fieldset and input types have to go inside a form-->
			<legend>Comida-de-campo</legend>
				<div class="containerdiv" >
					<div id="div0" class="centraldiv" >
						<span>
							<label for="fecha">Fecha:</label>
							<input name="fecha" type="date"><!--these are examples of input types, notice the pairing with label-->
							
							<label for="hora">Hora:</label>
							<input name="hora" type="time">
							
							<label for="npax"># PAX:</label>
							<input name="npax" type="text">
						</span>
					</div>
					
						<div class="radios" >
							<input type="radio" name="turn" value="desayuno" checked>Desayuno
							<input type="radio" name="turn" value="almuerzo">Almuerzo
							<input type="radio" name="turn" value="cena">Cena
							<input type="radio" name="turn" value="extra">Extra
						</div>			
				</div>
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
								<input type="checkbox" name="spreadoption" value="jamon">Jamón
								<br>
								<input type="checkbox" name="spreadoption" value="atun">Atún
								<br>
								<input type="checkbox" name="spreadoption" value="frijoles">Frijoles
							</div >
							<div class="blockdivright">
								<input type="checkbox" name="spreadoption" value="mantequillamani">Mantequilla Maní y jalea 
								<br>
								<input type="checkbox" name="spreadoption" value="omelette">Omelette 
								<br>
								<input type="checkbox" name="spreadoption" value="ensaladahuevo">Ensalada de huevo 	
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
							</div >
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
					<div class="centraldiv" >
						<span class="radios">
							<input type="radio" name="drink" value="agua" checked>Agua
							<input type="radio" name="drink" value="jugo">Jugo
						</span>
					</div>
				</fieldset>
				
				<div id="buttons">
					<button class="aceptar" name="accept" type="button">Aceptar</button>
					<button class="cancelar" name="cancel" type="button">cancelar</button>
				</div>
						
			</fieldset>
		</form>
	</div>







    </form>
</body>
</html>
