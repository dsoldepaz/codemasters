<%@ Page Language="C#" Title="Empleados" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="FormEmpleadoReserva.aspx.cs" Inherits="Servicios_Reservados_2.FormEmpleadoReserva" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" href="Content/EmpleadoReserva.css"/>
        <nav>
            <ul>
                <li class="item-navegacion"><a href="FormReservaciones.aspx">Reservaciones</a></li>
                <li class="item-navegacion"><a href="FormEmpleado.aspx"  class="seleccionado">Empleados</a></li>
                <li class="item-navegacion">Notificaciones <span class="notificacion">0</span></li>
                <li class="item-navegacion"><a href="FormReportesComedor.aspx">Reportes</a></li>

            </ul>
        </nav>
        <div>
            <h2>Empleados</h2>
            <h3>Reservaciones del empleado:<span id="lblNombre" runat="server"></span> </h3>
            <div class ="well">
                Nombre: <input id="txtNombre" value="{Nombre No recuperado}" runat="server" />
                Apellido:<input id="txtApellido" value="{Apellido No recuperado}" runat="server" />

            </div>
            <div class="well">
                <h4>
                    Agregar Servicios
                </h4>
                <input type="button"  class="btn btn-success comida" value="Nueva Comida Regular" runat="server" onserverclick="btnAgregarCR_Click"/>
                <input type="button"  class="btn btn-success comida" value="Nueva Comida Campo" runat="server" onserverclick="btnAgregarCC_Click"/>
            </div>
             <asp:UpdatePanel ID="UpdatePanel1"  class="well" runat="server">
            <ContentTemplate>
            <fieldset>
                 <h4>
                        Comidas desde el ultimo mes del empleado
                    </h4>
                <section id="comidasReservadas">
                    <asp:GridView ID="GridComidasReservadas" Class="Gridcontenedor" runat="server" AllowPaging="true" AllowSorting="true" OnPageIndexChanging="GridViewReservaciones_PageIndexChanging" BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px" Width="100%">
                       <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton  ID="btnActivarTiquete" runat="server" class="btn btn-default" OnClick="clickActivarTiquetes"><i  class="glyphicon glyphicon-tags"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                           <asp:TemplateField>
                               <ItemTemplate>
                                  <asp:LinkButton  ID="btnConsultar"  onclick="btnVer_Click"  runat="server" class="btn btn-default"><i class="glyphicon glyphicon-search"></i></asp:LinkButton>
                               </ItemTemplate>
                           </asp:TemplateField>
                       </Columns>
                       <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnModificar" runat="server" class="btn btn-default" OnClick="btnEditar_Click"><i class="glyphicon glyphicon-edit"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                           <asp:TemplateField>
                                 <ItemTemplate>
                                    <asp:LinkButton  ID="btnCancelar" runat="server" class="btn btn-default" onclick="btnCancelar_Click"><i  class="glyphicon glyphicon-remove"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                         </Columns>
                        <SelectedRowStyle BackColor="#7BC143" />
                     </asp:GridView>
                     <!--<section id="seccionBotones" class="btn-group-vertical" runat="server">
                       <input id="tiquetesBtn" type="button" class="btn btn-success tiquete" value="Activar Tiquete" runat="server" onserverclick="clickActivarTiquetes" />
                        <!--<input id="btnVer" type="button" class="btn btn-success" value="Consultar" runat="server" onserverclick="btnVer_Click" />
                        <input id="btnEditar" type="button" class="btn btn-success" value="Modificar" runat="server" onserverclick="btnEditar_Click"/>
                        <input id="btnCancelar" type="button" class="btn btn-success cancelar" value="Cancelar" runat="server" onserverclick="btnCancelar_Click"/>
                    </section>-->
                    

                </section>
              
            </fieldset>
                 </ContentTemplate>
        </asp:UpdatePanel>

        </div>
    </asp:Content>
