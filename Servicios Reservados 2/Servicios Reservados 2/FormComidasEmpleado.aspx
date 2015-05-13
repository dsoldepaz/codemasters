<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormComidasEmpleado.aspx.cs" Inherits="Servicios_Reservados_2.FormComidasEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Content/ComidaEmpleado.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Comidas de Empleado</h1>
    <fieldset>
         <h4>Seleccione el horario de comida</h4>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div>
            <input type="checkbox" value="Desayuno" />Desayuno
            <input type="checkbox" value="Almuerzo" />Almuerzo
            <input type="checkbox" value="Cena" />Cena
            <input type="checkbox" value="Otro" />Otro
        </div>
        Fecha:<input runat="server" id="textFecha" onselect="fechaDeEntradaCalendario_SelectionChanged" disabled />
                    <input class="selectorDeFecha" id="fechaDeEntrada" type="button" runat="server" onserverclick="fechaDeEntrada_ServerClick" />
        
                    <asp:Calendar ID="fechaDeEntradaCalendario" runat="server" OnSelectionChanged="fechaDeEntradaCalendario_SelectionChanged" OnDayRender="fechaDeEntradaCalendario_DayRender" BackColor="#CCCCCC" BorderStyle="Dashed" ForeColor="#7BC143" Height="80px" Width="100px" BorderWidth="1px" Visible="false">
                        <DayHeaderStyle ForeColor="#333333" Wrap="True" />
                        <DayStyle ForeColor="Black" />
                        <NextPrevStyle ForeColor="Black" />
                        <TitleStyle BackColor="#7BC143" ForeColor="#333333" />
                    </asp:Calendar>

            </ContentTemplate>
   
        </asp:UpdatePanel>

    </fieldset>
</asp:Content>
