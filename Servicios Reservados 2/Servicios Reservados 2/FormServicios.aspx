<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormServicios.aspx.cs" Inherits="Servicios_Reservados_2.FormServicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <link rel="stylesheet" href="Content/Servicios.css"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <nav>
            <ul>
                <li class="item-navegacion"><a href="FormReservaciones.aspx">Reservaciones</a></li>
                <li class="item-navegacion"><a href="FormEmpleadoReserva.aspx">Empleados</a></li>
                <li class="item-navegacion">Notificaciones <span class="notificacion">0</span></li>
            </ul>
        </nav>
        
        <h1>
        Reservaciones del Servicio
        </h1>
        <section class="principal">
            <section class="contenedor">
                <h2>Información de la Reserva</h2>
                <ul>
                 <li class="itemContenedor">
                     Anfitriona:<input id="txtAnfitriona" runat="server"/>
                 </li>
                 <li class="itemContenedor">
                     Estacion:<input id="txtEstacion" runat="server"/>
                 </li>   
                 <li class="itemContenedor">
                     Nombre<input id="txtNombre" runat="server"/>
                 </li>   
                 <li class="itemContenedor">
                     Fecha De Entrada:<input  id="fechaInicio" runat="server"/> 
                     
                 </li>   
                 <li class="itemContenedor">
                     Fecha De Salida:<input  id="fechaFinal" runat="server"/> 
                 </li>   
                 <li class="itemContenedor">
                     Numero de PAX<input id="txtPax" type="number" runat="server"/>
                 </li> 
                </ul>    
                <section class="contenedor">
                    <h2>Agregar Servicios extra</h2>
                     <ul>
                         <li class="itemContenedor">
                             <a href="ComidaExtra.aspx"><input type="button" value="Comida Extra"/>
                         </li>
                         <li class="itemContenedor">
                             <a><input type="button" value="Comida De Campo"/></a>
                         </li>
                         <li class="itemContenedor">
                            <a><input type="button" value="Servicio de Guías"/></a> 
                         </li>
                     </ul>

                </section>
                <h3>Agregar Servicios extra</h3>
                <section class="contenedor_tabla">
                   <aside id="botonesLaterales">
                        <input type="button" class="consultar-btn" value="Consultar"/>
                        <input type="button" class="editar-btn" value="Modificar"/>
                        <input type="button" class="eliminar-btn"value="Elimnar"/>
                    </aside> 
                       
                     <asp:GridView ID="GridServicios" runat="server" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px">
                         <SelectedRowStyle BackColor="#7BC143" />
                     </asp:GridView>
                 
                </section>

            </section>
            <input type="button" class="aceptar-btn" value="Aceptar"/>
            <input type="button" class="cancelar-btn" value="Cancelar"/>
        </section>
        
    <script type="text/javascript" src="Scripts/jquery-2.1.3.min.js"></script>
        </a>
</asp:Content>
