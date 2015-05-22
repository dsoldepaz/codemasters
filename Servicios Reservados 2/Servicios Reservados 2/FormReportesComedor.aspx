<%-- IMPORTATN not every element auto generates events when clicked, a solution for li elements is to use </asp:LinkButton>
     without event-event handler there is no way to exec code on click, also in asp there are specific tag atributes to
     run code on server side (onclick, etc wich also needs runat=server) and client side like javascript
    (needs onclientclick attribute) see links below
    http://stackoverflow.com/questions/11417838/onclick-on-list
    https://www.youtube.com/watch?v=W8OoHmVP8iM --%>

<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="FormReportesComedor.aspx.cs" Inherits="Servicios_Reservados_2.FormReportesComedor" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<link rel="stylesheet" href="Content/reportes.css"/>
<%--<link rel="stylesheet" href="Content/ComidasExtra.css" /> --%>


<style type="text/css">
    #jcDiv1{
        margin:auto;
        width:700px;
     }

    #jcDiv1 ul{
        padding:0px;
        list-style:none;
     }
    
     #jcDiv0{
        margin:auto;
        width:700px;
        
     }

    #jcDiv0 ul{
        padding:0px;
        list-style:none;
        
     }

    #jcDiv0 ul li{
        float:left;
        text-align:center;
        width:120px;
        margin:1px;
        
     }

    #jcDiv0 ul li a{
        color:#fff;
        text-decoration:none;
        font-family:Calibri;
        background:#0a0;
        display:block;
        padding:10px;
        
     }

     #jcDiv0 ul li a:hover{
        color:#000;      
        background:#0e0;      
     }
     
     
     #jcDiv0 ul li ul{
       display:none;   
     }



     #jcDiv0 ul li:hover ul{
       display:block;
     }


     #jcDiv0 ul li:hover ul li{
       display:block;
     }

     /*
     .itemContenedor{
       display:none;   
     }*/

 
     
        
    
</style>


    <nav>
        <ul>
            <li class="item-navegacion"><a href="FormReservaciones.aspx" >Reservaciones</a></li>
            <li class="item-navegacion"><a href="FormEmpleadoReserva.aspx">Empleados</a></li>
            <li class="item-navegacion">Notificaciones <span class="notificacion">0</span></li>
            <li class="item-navegacion"><a href="FormReportesComedor.aspx" class="seleccionado">Reportes</a></li>
        </ul>
    </nav>


        <legend>
            <h2 >Reportes Comedor</h2>
        </legend>



   <div id="jcDiv0">
       <ul>
            <li><a href="#">Proximo</a>
                <ul>
                    <li><a href="#">Desayuno</a></li>
                    <li><a href="#">Almuerzo</a></li>
                    <li><a href="#">Cena</a></li>
                </ul>
            </li>
                
            <li><a href="#">Dia</a></li>
            <li><a href="#">Mes</a>
                 <ul runat="server" >

                    <li><asp:LinkButton runat="server" Text="Enero" OnClick="clickEnero"></asp:LinkButton></li>
                    <li><asp:LinkButton runat="server" Text="Febrero" OnClick="clickEnero"></asp:LinkButton></li>
                    <li><asp:LinkButton runat="server" Text="Marzo" OnClick="clickEnero"></asp:LinkButton></li>
                    <li><asp:LinkButton runat="server" Text="Abril" OnClick="clickEnero"></asp:LinkButton></li>
     
                </ul>
            </li>
            <li><a href="#">Semana</a>
                <ul>
                    <li><asp:LinkButton runat="server" Text="1" OnClick="clickEnero"></asp:LinkButton></li>
                    <li><asp:LinkButton runat="server" Text="2" OnClick="clickEnero"></asp:LinkButton></li>
                    <li><asp:LinkButton runat="server" Text="3" OnClick="clickEnero"></asp:LinkButton></li>
                    <li><asp:LinkButton runat="server" Text="4" OnClick="clickEnero"></asp:LinkButton></li>

                </ul>

             <li><asp:LinkButton runat="server" Text="Por Fechas" OnClick="fechaDeEntrada_ServerClick"></asp:LinkButton></li>
       </ul>
    </div>




    <div id="jcDiv1">

        <ul>
                <li class="itemContenedor">
                    <asp:Calendar ID="fechaDeEntradaCalendario" runat="server" BackColor="#CCCCCC" BorderStyle="Dashed" ForeColor="#7BC143" Height="80px" Width="100px" BorderWidth="1px" Visible="false" OnSelectionChanged="fechaDeEntradaCalendario_SelectionChanged">
                        <DayHeaderStyle ForeColor="#333333" Wrap="True" />
                        <DayStyle ForeColor="Black" />
                        <NextPrevStyle ForeColor="Black" />
                        <TitleStyle BackColor="#7BC143" ForeColor="#333333" />
                    </asp:Calendar>
                </li>
        </ul>
    </div>

      

</asp:Content>
