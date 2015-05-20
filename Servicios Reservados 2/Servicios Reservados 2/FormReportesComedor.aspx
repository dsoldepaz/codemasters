<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="FormReportesComedor.aspx.cs" Inherits="Servicios_Reservados_2.FormReportesComedor" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<link rel="stylesheet" href="Content/reportes.css"/>

<style type="text/css">
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
            <h2>Reportes Comedor</h2>
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
                 <ul>
                    <li><a href="#">Enero</a></li>
                    <li><a href="#">Febrero</a></li>
                    <li><a href="#">Marzo</a></li>
                    <li><a href="#">Abril</a></li>
                    <li><a href="#">Junio</a></li>
                    <li><a href="#">Juliio</a></li>
                    <li><a href="#">Agosto</a></li>
                    <li><a href="#">Septiembre</a></li>
                    <li><a href="#">Octubre</a></li>
                    <li><a href="#">Noviembre</a></li>
                    <li><a href="#">Diciembre</a></li>
                </ul>
            </li>
            <li><a href="#">Semana</a></li>
            <li><a href="#">Por Fechas</a></li>
       </ul>
    </div>

      

</asp:Content>
