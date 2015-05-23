<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormComidasEmpleado.aspx.cs" Inherits="Servicios_Reservados_2.FormComidasEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Content/ComidaEmpleado.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Comidas de Empleado <span id="lblEmpleado" runat="server">{nombre Empleado}</span></h1>
    <fieldset class="contenedor">
         
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div title="Seleccione una operacion sobre las reservaciones de comida">
             
                <input type="button" value="Agregar" runat="server" onserverclick="clickAgregar"/>
                <input type="button" value="Modificar" runat="server" onserverclick="clickModificar"/>
                <input type="button" value="Eliminar" runat="server" onserverclick="clickEliminar"/>
            </div>
            <section id="ContenedorManejoDeHorario" runat="server" visible="false">
                    <div id="selectorDeHorario" runat="server" visible="false" title="Seleccione el horario de comida">
                        <input type="checkbox" id="checkboxDesayuno" runat="server" value="Desayuno" />Desayuno
                        <input type="checkbox" id="checkboxAlmuerzo" runat="server" value="Almuerzo" />Almuerzo
                        <input type="checkbox" id="checkboxCena" runat="server" value="Cena" />Cena
                        <select id="tipodePago" runat="server" title="Seleccione un metodo de pago">
                          <option value="volvo">Efectivo</option>
                          <option value="saab">Descuento de salario</option>
                        </select>
                    </div>
                    <h4>Notas:</h4>
                    <textarea id="notas" runat="server" title="Notas">

                    </textarea>
                    <h4>
                        Seleccione las fechas en las que desea reservar
                    </h4>
                    <asp:Calendar ID="fechaDeEntradaCalendario" runat="server" OnSelectionChanged="fechaDeEntradaCalendario_SelectionChanged" OnDayRender="fechaDeEntradaCalendario_DayRender" BackColor="#CCCCCC" BorderStyle="Dashed" ForeColor="#7BC143" Height="200px" Width="280px" BorderWidth="1px" Visible="false" ShowNextPrevMonth="False">
                        <DayHeaderStyle ForeColor="#333333" Wrap="True" />
                        <DayStyle ForeColor="Black" />
                        <NextPrevStyle ForeColor="Black" />
                        <SelectedDayStyle BackColor="#7BC143" />
                        <TitleStyle BackColor="#7BC143" ForeColor="#333333" />
                    </asp:Calendar>
                    <input type="button" value="Cancelar" runat="server" onserverclick="clickCancelar"/>
                    <input type="button" value="Aceptar" onserverclick="clickAceptar"/>
                 </section>
            


            </ContentTemplate>
   
        </asp:UpdatePanel>

    </fieldset>
</asp:Content>
