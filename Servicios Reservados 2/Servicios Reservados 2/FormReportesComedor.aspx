<%-- IMPORTATN not every element auto generates events when clicked, a solution for li elements is to use </asp:LinkButton>
     without event-event handler there is no way to exec code on click, also in asp there are specific tag atributes to
     run code on server side (onclick, etc wich also needs runat=server) and client side like javascript
    (needs onclientclick attribute) see links below
    http://stackoverflow.com/questions/11417838/onclick-on-list
    https://www.youtube.com/watch?v=W8OoHmVP8iM --%>

<%@ Page Title="Reportes" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FormReportesComedor.aspx.cs" Inherits="Servicios_Reservados_2.FormReportesComedor" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

<link rel="stylesheet" href="Content/reportes.css"/>

<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
<script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
<script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>


<%--
<script>
    $(function () {
        $(".datepicker").datepicker({
            changeMonth: true,
            changeYear: true
        });
    });
</script>
--%>

<script type="text/javascript">
    $(function () {
        $("#datepicker").datepicker({
            showOn: 'button', buttonImage: '../Images/imagenes_OET/calendarjc.png', buttonImageOnly: true,
            changeMonth: true,
            changeYear: true
        });

        $("#datepicker2").datepicker({
            showOn: 'button', buttonImage: '../Images/imagenes_OET/calendarjc.png', buttonImageOnly: true,
            changeMonth: true,
            changeYear: true
        });

    });
</script>


<script>
    $.datepicker.regional['es'] = {
        closeText: 'Cerrar',
        prevText: '<Ant',
        nextText: 'Sig>',
        currentText: 'Hoy',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
        weekHeader: 'Sm',
        dateFormat: 'dd/mm/yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['es']);
    $(function () {
        $("#fecha").datepicker();
    });
</script>



<script type="text/javascript">

    $(function () {

        $(".ui-datepicker-trigger").on("mouseover", function () {
            $(this).attr('title', 'selección de fecha');
        });
    });
</script>

<script>
    $(function () {
        $(document).tooltip();
    });
</script>

 
<script>
    $(function () {
        $("#accordion").accordion();
    });
</script>


<style type="text/css">



  #jcDiv0{
      
        margin:auto;
        width:700px;
        height:200px;
     }


  
  #jcDiv1{
        height: 200px;
        float: left;
        margin:auto;
        width:300px;
        
     }

  #jcDiv2{
        height: 200px;
        float: right;
        margin:auto;
          width: 430px;
        
     }

    #jcDiv0 ul{  
        list-style:none;
        padding: inherit;  
        
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

       #menuContainerDiv{
       display:flex;
       width:auto;
     }

    .jch {
        color: #7BC143;
        padding:10px;
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

<fieldset>
<legend><h2 class="jch">Reportes Comedor</h2></legend>

<div id="menuContainerDiv">  
 
    <div id="jcDiv1" class="well bs-component">
        <label  class="jch" title="Click en el calendario para seleccionar criterio del reporte">Criterio de Fechas</label>
        <p>Del : <input type="text" id="datepicker" required="required" title="" pattern="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"></p>
        <p>&nbsp;&nbsp;Al : <input type="text" id="datepicker2" ></p>             
    </div>

    <div id="jcDiv0" class="well bs-component">
        <label  class="jch">Tipo de Reporte</label>
          <ul>
                    <li><a href="#">Turno</a>
                        <ul>
                            <li><a href="#">Desayuno</a></li>
                            <li><a href="#">Almuerzo</a></li>
                            <li><a href="#">Cena</a></li>
                        </ul>
                    </li>
                
                    <li><a href="#">Día</a></li>
                    <li><a href="#">Semana</a></li>

                    <li><a href="#">Mes</a></li>

                     <li><asp:LinkButton runat="server" Text="Rango de Fechas" OnClick="clickEnero"></asp:LinkButton></li>
            </ul>
    </div>

    <div id="jcDiv2" class="well bs-component">
        <label  class="jch">Información del Reporte</label>
    </div>
</div>     
</fieldset>

<div id="reportContainerDiv">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">       
        <ContentTemplate>
         <fieldset>
            <asp:GridView id="gvReportes" runat="server" AllowPaging="true" AllowSorting="true" PageSize="20"  BorderColor="#CCCCCC" BorderStyle="Dotted" BorderWidth="2px" >
                                        <AlternatingRowStyle BorderStyle="None" />
                                        <HeaderStyle Font-Size="1.3em" />
                                        <SelectedRowStyle BackColor="#7BC143"
                                        ForeColor="Black"
                                        Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />
            </asp:GridView>
          </fieldset>
         </ContentTemplate>
    </asp:UpdatePanel>

</div>
</asp:Content>
