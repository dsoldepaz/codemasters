﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormComidasEmpleado.aspx.cs" Inherits="Servicios_Reservados_2.FormComidasEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Content/ComidaEmpleado.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Comidas de Empleado</h1>
    <fieldset class="contenedor">
         <h4>Informacion Del Empleado</h4>
        <ul class ="lista formulario">
            <li  class="itemFormulario">
                Nombre: <input id="nombreLbl" />
            </li>
            <li  class="itemFormulario">
                Apellido: <input id="apellidoLbl" />
            </li>
            
            <li  class="itemFormulario">
                Indentificacion: <input id="idLbl" />
            </li>
        </ul>
         <h4>Seleccione el horario de comida</h4>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div>
            <input type="checkbox" value="Desayuno" />Desayuno
            <input type="checkbox" value="Almuerzo" />Almuerzo
            <input type="checkbox" value="Cena" />Cena
        </div>
        
                    <asp:Calendar ID="fechaDeEntradaCalendario" runat="server" OnSelectionChanged="fechaDeEntradaCalendario_SelectionChanged" OnDayRender="fechaDeEntradaCalendario_DayRender" BackColor="#CCCCCC" BorderStyle="Dashed" ForeColor="#7BC143" Height="320px" Width="400px" BorderWidth="1px" Visible="false">
                        <DayHeaderStyle ForeColor="#333333" Wrap="True" />
                        <DayStyle ForeColor="Black" />
                        <NextPrevStyle ForeColor="Black" />
                        <SelectedDayStyle BackColor="#7BC143" />
                        <TitleStyle BackColor="#7BC143" ForeColor="#333333" />
                    </asp:Calendar>
                    <h4 id="labelTabla">Comidas reservadas para </h4>
                     <asp:GridView ID="GridViewReservaciones" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateSelectButton="True" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px" OnPageIndexChanging="GridViewReservaciones_PageIndexChanging" OnSelectedIndexChanged="seleccionarEmpleado" PageSize="20">
                        <AlternatingRowStyle BorderStyle="None" />
                        <HeaderStyle Font-Size="1.3em" />
                        <SelectedRowStyle BackColor="#7BC143" BorderStyle="Dotted" BorderWidth="1px" Font-Bold="true" ForeColor="Black" />
                    </asp:GridView>
            </ContentTemplate>
   
        </asp:UpdatePanel>

    </fieldset>
</asp:Content>