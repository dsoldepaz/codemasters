<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormComidasEmpleado.aspx.cs" Inherits="Servicios_Reservados_2.FormComidasEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Content/ComidaEmpleado.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Comidas de Empleado</h1>
    <fieldset class="contenedor">
         <h4>Informacion Del Empleado</h4>
        <ul class ="lista formulario">
            <li  class="itemFormulario">
                Nombre: <input id="nombreLbl" runat="server"/>
            </li>
            <li  class="itemFormulario">
                Apellido: <input id="apellidoLbl" runat="server"/>
            </li>
            
            <li  class="itemFormulario">
                Indentificacion: <input id="idLbl" runat="server"/>
            </li>
        </ul>
         
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div title="Seleccione una operacion sobre las reservaciones de comida">
             
                <input type="button" value="Agregar" runat="server" onserverclick="clickAgregar"/>
                <input type="button" value="Modificar" onserverclick="clickModificar"/>
                <input type="button" value="Eliminar" onserverclick="clickEliminar"/>
            </div>
            <div id="ContenedorManejoDeHorario" runat="server" visible="false">
                    <div id="selectorDeHorario" runat="server" visible="false" title="Seleccione el horario de comida">
                        <input type="checkbox" id="checkboxDesayuno" runat="server" value="Desayuno" />Desayuno
                        <input type="checkbox" id="checkboxAlmuerzo" runat="server" value="Almuerzo" />Almuerzo
                        <input type="checkbox" id="checkboxCena" runat="server" value="Cena" />Cena
                    </div>
                    <h4>
                        Seleccione las fechas en las que desea reservar
                    </h4>
                    <asp:Calendar ID="fechaDeEntradaCalendario" runat="server" OnSelectionChanged="fechaDeEntradaCalendario_SelectionChanged" OnDayRender="fechaDeEntradaCalendario_DayRender" BackColor="#CCCCCC" BorderStyle="Dashed" ForeColor="#7BC143" Height="55%" Width="70%" BorderWidth="1px" Visible="false" ShowNextPrevMonth="False">
                        <DayHeaderStyle ForeColor="#333333" Wrap="True" />
                        <DayStyle ForeColor="Black" />
                        <NextPrevStyle ForeColor="Black" />
                        <SelectedDayStyle BackColor="#7BC143" />
                        <TitleStyle BackColor="#7BC143" ForeColor="#333333" />
                    </asp:Calendar>
                    <input type="button" value="Cancelar" runat="server" onserverclick="clickCancelar"/>
                    <input type="button" value="Aceptar" onserverclick="clickAceptar"/>
                 </div>
            
                 <h4 id="labelTabla">Comidas reservadas para </h4>
                 <asp:GridView ID="GridViewReservacionesEmpleado" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateSelectButton="True" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px" OnPageIndexChanging="GridViewReservaciones_PageIndexChanging" OnSelectedIndexChanged="seleccionarReservacion" PageSize="20">
                     <AlternatingRowStyle BorderStyle="None" />
                     <HeaderStyle Font-Size="1.3em" />
                 <SelectedRowStyle BackColor="#7BC143" BorderStyle="Dotted" BorderWidth="1px" Font-Bold="true" ForeColor="Black" />
                 </asp:GridView>

            </ContentTemplate>
   
        </asp:UpdatePanel>

    </fieldset>
</asp:Content>
