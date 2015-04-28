<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComidaExtra.aspx.cs" Inherits="Servicios_Reservados_2.ComidaExtra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Comida Extra</title>
    <link rel="stylesheet" href="Content/reset.css"/>
    <link rel="stylesheet"href="Content/Site.css" />
    <link rel="stylesheet" href="Content/CalendarControl.css" />
    <link rel="stylesheet" href="Content/ComidasExtra.css" />
    
</head>
       <a href="/FormUsuario">
            <div id="alertAlerta" class="alert alert-danger fade in" runat="server" hidden="hidden">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <strong>
                    <asp:Label ID="labelTipoAlerta" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="labelAlerta" runat="server" Text="Mensaje de alerta"></asp:Label>
            </div>
        </a>

<body>
    <form id="form1" runat="server">
        <fieldset>

            <h3>Comida Extra</h3>
            <section class="principal">
                <ul>
                    <li class="itemContenedor">
                        Fecha:<input id="textFecha" onselect="fechaDeEntradaCalendario_SelectionChanged" disabled /> <input id="fechaDeEntrada" class="selectorDeFecha" type="button" runat="server" onserverclick="fechaDeEntrada_ServerClick"/>
                     <asp:Calendar ID="fechaDeEntradaCalendario" runat="server" BackColor="#CCCCCC" BorderStyle="Dashed" ForeColor="#7BC143" Height="80px" Width="100px" BorderWidth="1px" Visible="false" OnSelectionChanged="fechaDeEntradaCalendario_SelectionChanged">
                         <DayHeaderStyle ForeColor="#333333" Wrap="True" />
                         <DayStyle ForeColor="Black" />
                         <NextPrevStyle ForeColor="Black" />
                         <TitleStyle BackColor="#7BC143" ForeColor="#333333" />
                        </asp:Calendar>
                    </li>
                    <li class="itemContenedor">Hora:<input id="txtHora" runat="server"/>
                    </li>
                    <li class ="itemContenedor">#PAX:<input id="txtPax" runat="server" type="number" required="required" placeholder="Entre un digito"/>
                       
                    </li>
                    <li class="itemContenedor">Tipo:<select id="cbxTipo" runat="server"></select>
                    </li>

                </ul>
                <p>
                <label>Notas:</label>
                <textarea id="txaNotas" cols="20" name="S1" rows="2" runat="server"></textarea></p>
            <input type="button" class="cancelar-btn" value="Cancelar"/>
            <input type="button" class="aceptar-btn" onserverclick="clickAceptar" value="Aceptar" runat="server"/>
            </section>
        </fieldset>
    </form>
    <script src="Script/CalendarControl.js" type="text/javascript"></script>
 
</body>
</html>
