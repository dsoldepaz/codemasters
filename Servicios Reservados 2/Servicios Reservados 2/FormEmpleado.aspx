<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="FormEmpleado.aspx.cs" Inherits="Servicios_Reservados_2.FormEmpleado" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
           <link rel="stylesheet" href="Content/formEmpleado.css" />
           <nav>
            <ul>
                <li class="item-navegacion"><a href="FormReservaciones.aspx">Reservaciones</a></li>
                <li class="item-navegacion"><a href="FormEmpleadoReserva.aspx"  class="seleccionado">Empleados</a></li>
                <li class="item-navegacion">Notificaciones <span class="notificacion">0</span></li>
            </ul>
        </nav>
            <div>

    <h2>Empleados</h2>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <fieldset>
                    <div class="well bs-component">        
                     <legend style="color: #7BC143">Filtro de empleados</legend>
                        <ul class ="lista formulario">
                            <li class="itemFormulario">
                                <input type="radio" class="radioBusqueda" name="busqueda" value="nombre" checked>Nombre <input id="inputNombre" />
                            </li>
                            <li class="itemFormulario">
                            <input type="radio" class="radioBusqueda" name="busqueda" value="identificacion">Identificacion: <input id="inputIdentificacion" />
                            </li>
                            <li class="itemFormulario">
                                <input type="button" class="btn btn-success" id="botonBuscar" value="Buscar" />

                            </li>
                        </ul>
                    </div>
                    <div class="well bs-component">
                    <legend style="color: #7BC143">Listado de empleados</legend>
                    <asp:GridView ID="GridViewReservaciones" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateSelectButton="True" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px" OnPageIndexChanging="GridViewReservaciones_PageIndexChanging" OnSelectedIndexChanged="seleccionarEmpleado" PageSize="20">
                        <AlternatingRowStyle BorderStyle="None" />
                        <HeaderStyle Font-Size="1.3em" />
                        <SelectedRowStyle BackColor="#7BC143" BorderStyle="Dotted" BorderWidth="1px" Font-Bold="true" ForeColor="Black" />
                    </asp:GridView>
                    <a href="FormServicios.aspx">
                    <input type="button" class="btn btn-success" id="botonServicioExtra" value="Agregar Servicios" />
                    </a>
                    </div>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>

        </div>
    </asp:Content>
