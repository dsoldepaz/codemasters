﻿<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="FormEmpleado.aspx.cs" Inherits="Servicios_Reservados_2.FormEmpleado" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
           <link rel="stylesheet" href="Content/formEmpleado.css" />
           <nav>
            <ul>
                <li class="item-navegacion"><a href="FormReservaciones.aspx">Reservaciones</a></li>
                <li class="item-navegacion"><a href="FormEmpleadoReserva.aspx"  class="seleccionado">Empleados</a></li>
                <li class="item-navegacion">Notificaciones <span class="notificacion">0</span></li>
                <li class="item-navegacion"><a href="FormReportesComedor.aspx">Reportes</a></li>
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
                               Nombre<input class="textbox" id="inputNombre" runat="server" />
                            </li>
                            <li class="itemFormulario">
                            Carné<input class="textbox" id="inputIdentificacion" runat="server" />
                            </li>
                            <li class="itemFormulario">
                                <input type="button" class="btn btn-success" id="botonBuscar" onserverclick="clickBuscar" value="Buscar" runat="server" />

                            </li>
                        </ul>
                    </div>
                    <div class="well bs-component">
                    <legend style="color: #7BC143">Listado de empleados</legend>
                    <asp:GridView ID="GridViewEmpleados" Class="Gridcontenedor" runat="server" AllowPaging="true" AllowSorting="true" OnPageIndexChanging="GridViewReservaciones_PageIndexChanging"  PageSize="20">
                        
                        <SelectedRowStyle BackColor="#7BC143" BorderStyle="Dotted" BorderWidth="1px" Font-Bold="true" ForeColor="Black" />
                                          <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                      <asp:LinkButton  ID="btnConsultar" runat="server" onclick="clicAgregarServicio" class="btn btn-default"><i class="glyphicon glyphicon-search"></i></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                    </asp:GridView>
                    
                    </div>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>

        </div>
    </asp:Content>
