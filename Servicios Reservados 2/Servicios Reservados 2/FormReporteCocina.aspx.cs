using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicios_Reservados_2
{
    public partial class FormReporteCocina : System.Web.UI.Page
    {
        private static ControladoraReporteCocina controladora = new ControladoraReporteCocina();
        private static String estacion;
        private String fechaInicio;
        private String fechaFinal;
        private static DataTable snacks;
        private static DataTable bebidas;
        private DateTime fechaInicioConsulta;
        private DateTime fechaDia;
        private DateTime fechaUltima;
        public static string retorno;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList listaRoles = (ArrayList)Session["Roles"];
            string userid = (string)Session["username"];
            if (!IsPostBack)
            {
                               
                fechaInicio = DateTime.Today.ToString("MM/dd/yyyy");
                fechaFinal = DateTime.Today.ToString("MM/dd/yyyy");
                fechaDia = DateTime.Today;
                fechaUltima = DateTime.Today;
                fechaInicioConsulta = DateTime.Today;
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                } if (!listaRoles.Contains("administrador sistema") && !listaRoles.Contains("encargado cocina") && !listaRoles.Contains("administrador global") && !listaRoles.Contains("cocinero"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
                if (listaRoles.Contains("cocinero"))
                {
                    cargarDatos(0);
                }
                else if (listaRoles.Contains("administrador sistema"))
                {
                    cargarDatos(1);
                    
                }
                else if (listaRoles.Contains("encargado cocina") || listaRoles.Contains("administrador global"))
                {
                    cargarDatos(2);
                }
                
                
            }
        }
        /**
        * Requiere: n/a
        * Efectua: Inicializa los datos necesarios en la pagina
        * retorna:  N/A
        */
        protected void cargarDatos(int valor)
        {
            DataTable estaciones = controladora.llenarEstaciones();
            cbxEstacion.Items.Clear();
            cbxEstacion.Items.Add("Seleccionar");
            if (estaciones.Rows.Count > 0)
            {
                foreach (DataRow fila2 in estaciones.Rows)
                {
                    cbxEstacion.Items.Add(fila2[0].ToString());
                }
            }
            
            cbxFecha.Items.Clear();
            cbxFecha.Items.Add("Hoy");
            cbxFecha.Items.Add("Día siguiente");
            if (valor!=0)
            {
                cbxFecha.Items.Add("Personalizado");
            }
            cbxFecha.SelectedIndex = 0;
            cbxEstacion.Disabled = true;
            txtFechaInicial.Disabled = true;
            txtFechaFinal.Disabled = true;
            if (valor == 1)
            {
                cbxEstacion.Disabled = false;
            }
            else
            {
                estacion = (String)Session["Estacion"];
                for (int i = 1; i < 4; i++)
                {
                    cbxEstacion.SelectedIndex = i;
                    if (cbxEstacion.Value.ToString() == estacion)
                    {
                        i = 4;
                    }
                    
                }
                llenarGridTotal();
                llenarGridTurnos();
                llenarGridSnacks();
                llenarGridBebidas();
            }


           

        }
        protected void GridViewSnacks_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

            GridViewSnacks.PageIndex = e.NewPageIndex;
            GridViewSnacks.DataSource = snacks;
            GridViewSnacks.DataBind();

        }

        protected void GridViewBebidas_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

            GridViewBebidas.PageIndex = e.NewPageIndex;
            GridViewBebidas.DataSource = bebidas;
            GridViewBebidas.DataBind();

        }


        /**
      * Requiere: n/a
      * Efectua: Crea la DataTable para desplegar.
      * retorna:  un dato del tipo DataTable con la estructura para consultar.
      */
        protected DataTable crearTablaTotal()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Tipo Servicio";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Total";
            tabla.Columns.Add(columna);

            GridViewTotal.DataSource = tabla;
            GridViewTotal.DataBind();

            return tabla;
        }

        /**
      * Requiere: n/a
      * Efectua: Crea la DataTable para desplegar.
      * retorna:  un dato del tipo DataTable con la estructura para consultar.
      */
        protected DataTable crearTablaTurnos()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Categoria";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Restaurante";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Comida Campo";
            tabla.Columns.Add(columna);

            GridViewTurnos.DataSource = tabla;
            GridViewTurnos.DataBind();

            return tabla;
        }

        /**
      * Requiere: n/a
      * Efectua: Crea la DataTable para desplegar.
      * retorna:  un dato del tipo DataTable con la estructura para consultar.
      */
        protected DataTable crearTablaSnacks()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Hora";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Tipo";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Descripción";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Total";
            tabla.Columns.Add(columna);

            GridViewSnacks.DataSource = tabla;
            GridViewSnacks.DataBind();

            return tabla;
        }
        /**
     * Requiere: n/a
     * Efectua: Crea la DataTable para desplegar.
     * retorna:  un dato del tipo DataTable con la estructura para consultar.
     */
        protected DataTable crearTablaBebidas()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Hora";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Tipo";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Descripción";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Total";
            tabla.Columns.Add(columna);

            GridViewBebidas.DataSource = tabla;
            GridViewBebidas.DataBind();

            return tabla;
        }

       
     /**
   * Requiere: n/a
   * Efectua: Llena la tabla  GridTotal
   * retorna:  N/A
   */
        protected void llenarGridTotal()
        {
            String fecha;
            DataTable tabla = crearTablaTotal();
            String sigla = "";
            int desayunos = 0;
            int almuerzos = 0;
            int cena = 0;
            int queque = 0;
            int cafe = 0;
            int sandwich = 0;
            int galloPinto = 0;
            int jugo = 0;
            int agua = 0;
            int ensalada = 0;
            int mayonesa = 0;
            int confites = 0;
            int frutas = 0;
            int salsa = 0;
            int huevoDuro = 0;
            int galletas = 0;
            int platanos = 0;
            int cont = 1;        
            if (estacion == "Las Cruces")
            {
                sigla = "LC";
            }
            else if (estacion == "Palo Verde")
            {
                sigla = "PV";

            }
            else
            {
                sigla = "LS";
            }

            try
            {

                Object[] datos = new Object[2];
                
                //Obtiene los datos de las reservaciones que reservan las 3 comidas por dia
                while(fechaDia <= fechaUltima){
                    fecha = fechaDia.ToString("MM/dd/yyyy");
                    fechaInicio = fecha;
                    fechaFinal = fecha;
                    DataTable turnosDiaTres = controladora.solicitarTurnoDiaTresComidas(sigla, fecha);

                    if (turnosDiaTres.Rows.Count > 0)
                    {
                        foreach (DataRow fila in turnosDiaTres.Rows)
                        {
                            desayunos+= int.Parse(fila[0].ToString());
                            almuerzos += int.Parse(fila[0].ToString());
                            cena += int.Parse(fila[0].ToString());
                        }
                    }


                    
                    //Obtiene los datos de reservaciones que reservan solo 2 comidas por dia
                    DataTable turnosDiaDos = controladora.solicitarTurnoDiaDosComidas(sigla, fecha);
                    if (turnosDiaDos.Rows.Count > 0)
                    {
                        foreach (DataRow fila in turnosDiaDos.Rows)
                        {
                            String turno;
                            int cantidad;
                            turno = fila[0].ToString();
                            cantidad = (int.Parse(fila[1].ToString()));
                            if (turno == "ALMUERZO")
                            {
                                almuerzos += cantidad;
                                cena += cantidad;
                            }
                            else if (turno == "CENA")
                            {
                                desayunos += cantidad;
                                cena += cantidad;
                            }
                            else
                            {
                                desayunos += cantidad;
                                almuerzos += cantidad;
                            }

                        }
                    }

                    //Obtener reservaciones entrantes para calculos mas exactos de platos a cocinar
                    DataTable reservaEntrante = controladora.reservaEntrante(sigla, fecha);

                    if (reservaEntrante.Rows.Count > 0)
                    {

                        foreach (DataRow fila in reservaEntrante.Rows)
                        {
                            String turno;
                            String tipoC;
                            int cantidad;
                            turno = fila[0].ToString();
                            tipoC = fila[1].ToString();
                            cantidad = (int.Parse(fila[2].ToString()));
                            if (turno == "ALMUERZO" && tipoC == "3 Comidas (" + sigla + ")")
                            {
                                desayunos = desayunos - cantidad;
                            }
                            else if (turno == "CENA")
                            {
                                if (tipoC == "3 Comidas (" + sigla + ")")
                                {
                                    desayunos = desayunos - cantidad;
                                    almuerzos = almuerzos - cantidad;
                                }
                                else
                                {
                                    desayunos = desayunos - cantidad;
                                }

                            }


                        }

                    }
                 
               
                //solicitar datos de comidaExtra
                    DataTable comidasE = controladora.solicitarCE(estacion, fechaInicio, fechaFinal);

                    if (comidasE.Rows.Count > 0)
                    {

                        foreach (DataRow fila in comidasE.Rows)
                        {
                            String tipoC;
                            int cantidad;
                            tipoC = fila[0].ToString();
                            cantidad = (int.Parse(fila[1].ToString()));
                            if (tipoC == "Desayuno")
                            {
                                desayunos += cantidad;
                            }
                            else if (tipoC == "Almuerzo")
                            {
                                almuerzos += cantidad;

                            }
                            else if (tipoC == "Cena")
                            {
                                cena += cantidad;
                            }
                            else if (tipoC == "Queque")
                            {
                                queque += cantidad;

                            }
                            else if (tipoC == "Café")
                            {
                                cafe += cantidad;
                            }


                        }

                    }
                    //solicitar datos de comida campo
                    DataTable comidasC = controladora.solicitarCC(estacion, fechaInicio, fechaFinal);

                    if (comidasC.Rows.Count > 0)
                    {

                        foreach (DataRow fila in comidasC.Rows)
                        {
                            int opcion;
                            int cantidad;
                            opcion = int.Parse(fila[0].ToString());
                            cantidad = (int.Parse(fila[1].ToString()));
                            if (opcion == 1)
                            {
                                desayunos += cantidad;
                            }
                            else if (opcion == 2)
                            {
                                almuerzos += cantidad;

                            }
                            else if (opcion == 3)
                            {
                                cena += cantidad;
                            }
                            else if (opcion == 4)
                            {
                                sandwich += cantidad;

                            }
                            else if (opcion == 5)
                            {
                                galloPinto += cantidad;
                            }


                        }

                    }

                    //Obteber cantidad de comidas para empleado
                    DataTable comidasEmpleado = controladora.getDesayunos(estacion, fechaInicio, fechaFinal);
                    if (comidasEmpleado.Rows.Count > 0)
                    {

                        foreach (DataRow fila in comidasEmpleado.Rows)
                        {
                            int cantidad;
                            cantidad = int.Parse(fila[1].ToString());
                            desayunos += cantidad;



                        }
                    }
                    //Obtiene los almuerzos
                    comidasEmpleado = controladora.getAlmuerzos(estacion, fechaInicio, fechaFinal);
                    if (comidasEmpleado.Rows.Count > 0)
                    {

                        foreach (DataRow fila in comidasEmpleado.Rows)
                        {
                            int cantidad;
                            cantidad = int.Parse(fila[1].ToString());
                            almuerzos += cantidad;



                        }
                    }
                    //Obtiene las cenas      
                    comidasEmpleado = controladora.getCenas(estacion, fechaInicio, fechaFinal);
                    if (comidasEmpleado.Rows.Count > 0)
                    {

                        foreach (DataRow fila in comidasEmpleado.Rows)
                        {
                            int cantidad;
                            cantidad = int.Parse(fila[1].ToString());
                            cena += cantidad;



                        }
                    }
                    //Obtener cantidad de bebidas
                    DataTable bebidas = controladora.solicitarBebidas(estacion, fechaInicio, fechaFinal);

                    if (bebidas.Rows.Count > 0)
                    {

                        foreach (DataRow fila in bebidas.Rows)
                        {
                            String tipo;
                            int cantidad;
                            tipo = fila[0].ToString();
                            cantidad = (int.Parse(fila[1].ToString()));
                            if (tipo == "Agua")
                            {
                                agua += cantidad;
                            }
                            else
                            {
                                jugo += cantidad;
                            }

                        }

                    }
                    //Obtener cantidad de adicionales
                    DataTable adicionales = controladora.solicitarAdicionales(estacion, fechaInicio, fechaFinal);

                    if (adicionales.Rows.Count > 0)
                    {

                        foreach (DataRow fila in adicionales.Rows)
                        {
                            String tipo;
                            int cantidad;
                            tipo = fila[0].ToString();
                            cantidad = (int.Parse(fila[1].ToString()));
                            if (tipo == "Ensalada")
                            {
                                ensalada += cantidad;
                            }
                            else if (tipo == "Mayonesa")
                            {
                                mayonesa += cantidad;

                            }
                            else if (tipo == "Confites")
                            {
                                confites += cantidad;
                            }
                            else if (tipo == "Frutas")
                            {
                                frutas += cantidad;

                            }
                            else if (tipo == "Salsa de tomate")
                            {
                                salsa += cantidad;
                            }

                            else if (tipo == "Huevos duros")
                            {
                                huevoDuro += cantidad;
                            }

                            else if (tipo == "Galletas")
                            {
                                galletas += cantidad;
                            }

                            else if (tipo == "Platanos")
                            {
                                platanos += cantidad;
                            }

                        }

                    }
                    fechaDia = fechaDia.AddDays(cont);

               }
                //crea la tabla que se mostrara en pantalla
                for (int i = 0; i < 17; i++)
                {
                    switch (i)
                    {
                        case 0:
                            datos[0] = "Desayuno";
                            datos[1] = desayunos;
                            break;
                        case 1:
                            datos[0] = "Almuerzo";
                            datos[1] = almuerzos;
                            break;

                        case 2:
                            datos[0] = "Cena";
                            datos[1] = cena;
                            break;
                        case 3:
                            datos[0] = "Queque";
                            datos[1] = queque;
                            break;
                        case 4:
                            datos[0] = "Café";
                            datos[1] = cafe;
                            break;

                        case 5:
                            datos[0] = "Sandwich";
                            datos[1] = sandwich;
                            break;

                        case 6:
                            datos[0] = "Gallo Pinto";
                            datos[1] = galloPinto;
                            break;
                        case 7:
                            datos[0] = "Agua";
                            datos[1] = agua;
                            break;
                        case 8:
                            datos[0] = "Jugo";
                            datos[1] = jugo;
                            break;

                        case 9:
                            datos[0] = "Ensalada";
                            datos[1] = ensalada;
                            break;

                        case 10:
                            datos[0] = "Mayonesa";
                            datos[1] = mayonesa;
                            break;

                        case 11:
                            datos[0] = "Confites";
                            datos[1] = confites;
                            break;
                        case 12:
                            datos[0] = "Frutas";
                            datos[1] = frutas;
                            break;

                        case 13:
                            datos[0] = "Salsa de tomate";
                            datos[1] = salsa;
                            break;

                        case 14:
                            datos[0] = "Huevos Duros";
                            datos[1] = huevoDuro;
                            break;

                        case 15:
                            datos[0] = "Galletas";
                            datos[1] = galletas;
                            break;

                        case 16:
                            datos[0] = "Platanos";
                            datos[1] = platanos;
                            break;


                        default:
                            break;

                    }
                    tabla.Rows.Add(datos);
                }

                GridViewTotal.DataBind();


            }
            catch (Exception e)
            {
                Debug.WriteLine("No se pudo cargar el total de comidas");
            }

        }

        /**
        * Requiere: n/a
        * Efectua: Llena la tabla de GridSnacks
        * retorna:  N/A
        */
        protected void llenarGridSnacks()
        {
            DataTable tabla = crearTablaSnacks();
            String descripcion = "";
            Object[] datos = new Object[4];
            fechaDia = fechaInicioConsulta;
             while(fechaDia <= fechaUltima){
                    
                fechaInicio =fechaDia.ToString("MM/dd/yyyy");
                fechaFinal = fechaDia.ToString("MM/dd/yyyy");
                DataTable datosCC = controladora.getComidasCampo(estacion, fechaInicio, fechaFinal);
                if (datosCC.Rows.Count > 0)
                {

                    foreach (DataRow fila in datosCC.Rows)
                    {
                        int opcion = int.Parse(fila[1].ToString());
                        if (opcion == 4)
                        {
                            descripcion = fila[2].ToString() + " con relleno de " + fila[3].ToString();
                            datos[0] = fila[0].ToString();
                            datos[1] = "Sandwich";
                            datos[2] = descripcion;
                            datos[3] = fila[4].ToString();

                        }
                        else if (opcion == 5)
                        {
                            datos[0] = fila[0].ToString();
                            datos[1] = "Gallo Pinto";
                            datos[2] = "-";
                            datos[3] = fila[4].ToString();

                        }
                        tabla.Rows.Add(datos);
                        
                    }
                
                    
                }

                DataTable datosCE = controladora.getComidasExtra(estacion, fechaInicio, fechaFinal);
                if (datosCC.Rows.Count > 0)
                {

                    foreach (DataRow fila in datosCE.Rows)
                    {
                        String tipo = fila[1].ToString();
                        if(tipo=="Queque"){
                            datos[0] = fila[0].ToString();
                            datos[1] = fila[1].ToString();
                            datos[2] = fila[2].ToString();
                            datos[3] = fila[3].ToString();
                            tabla.Rows.Add(datos);
                            
                        }
                   
                    }

                }
          fechaDia = fechaDia.AddDays(1);

          }
            snacks = tabla;
            GridViewSnacks.DataSource = snacks;
            GridViewSnacks.DataBind();
           


        }
        /**
        * Requiere: n/a
        * Efectua: Llena la tabla  GridBebidas
        * retorna:  N/A
        */
        protected void llenarGridBebidas()
        {
            DataTable tabla = crearTablaBebidas();
            String descripcion = "";
            Object[] datos = new Object[4];
            fechaDia = fechaInicioConsulta;
            while(fechaDia <= fechaUltima){
                fechaInicio = fechaDia.ToString("MM/dd/yyyy");
                fechaFinal = fechaDia.ToString("MM/dd/yyyy");
                DataTable datosCC = controladora.getBebidas(estacion, fechaInicio, fechaFinal);
                if (datosCC.Rows.Count > 0)
                {

                    foreach (DataRow fila in datosCC.Rows)
                    {
                        descripcion ="-";
                        datos[0] = fila[0].ToString();
                        datos[1] = fila[1].ToString();
                        datos[2] = descripcion;
                        datos[3] = fila[2].ToString();
                        tabla.Rows.Add(datos);
                    }


                }
                DataTable datosCE = controladora.getComidasExtra(estacion, fechaInicio, fechaFinal);
                if (datosCC.Rows.Count > 0)
                {

                    foreach (DataRow fila in datosCE.Rows)
                    {
                        String tipo = fila[1].ToString();
                        if (tipo == "Café")
                        {
                            datos[0] = fila[0].ToString();
                            datos[1] = fila[1].ToString();
                            datos[2] = fila[2].ToString();
                            datos[3] = fila[3].ToString();
                            tabla.Rows.Add(datos);
                        }

                    }

                }
            fechaDia = fechaDia.AddDays(1);

         }
           bebidas = tabla;
           GridViewBebidas.DataSource = bebidas;
           GridViewBebidas.DataBind();
        }
        /**
        * Requiere: n/a
        * Efectua: Llena la tabla  GridTurnos
        * retorna:  N/A
        */
        protected void llenarGridTurnos()
        {
            int desayunos = 0;
            int almuerzos = 0;
            int cenas = 0;
            int desayunosC = 0;
            int almuerzosC = 0;
            int cenasC = 0;
            fechaDia = fechaInicioConsulta;
            Object[] datos = new Object[3];
            while(fechaDia <= fechaUltima){
                fechaInicio = fechaDia.ToString("MM/dd/yyyy");
                fechaFinal = fechaDia.ToString("MM/dd/yyyy");
                DataTable tabla = crearTablaTurnos();
                desayunos = Convert.ToInt32(GridViewTotal.Rows[0].Cells[1].Text);
                almuerzos = Convert.ToInt32(GridViewTotal.Rows[1].Cells[1].Text);
                cenas = Convert.ToInt32(GridViewTotal.Rows[2].Cells[1].Text);

                DataTable comidaCampo = controladora.solicitarCC(estacion, fechaInicio, fechaFinal);

                if (comidaCampo.Rows.Count > 0)
                {

                    foreach (DataRow fila in comidaCampo.Rows)
                    {
                        int opcion;
                        int cantidad;
                        opcion = int.Parse(fila[0].ToString());
                        cantidad = (int.Parse(fila[1].ToString()));
                        if (opcion == 1)
                        {
                            desayunosC += cantidad;
                            desayunos -= cantidad;
                        }
                        else if (opcion == 2)
                        {
                            almuerzosC += cantidad;
                            almuerzos -= cantidad;

                        }
                        else if (opcion == 3)
                        {
                            cenasC += cantidad;
                            cenas -= cantidad;
                        }



                    }

                }

                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 0:
                            datos[0] = "Desayuno";
                            datos[1] = desayunos;
                            datos[2] = desayunosC;
                            break;
                        case 1:
                            datos[0] = "Almuerzo";
                            datos[1] = almuerzos;
                            datos[2] = almuerzosC;
                            break;

                        case 2:
                            datos[0] = "Cena";
                            datos[1] = cenas;
                            datos[2] = cenasC;
                            break;

                        default:
                            break;
                    }
                    tabla.Rows.Add(datos);
                }
          fechaDia = fechaDia.AddDays(1);

         }
            GridViewTurnos.DataBind();

        }

        protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje)
        {
            alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
            labelTipoAlerta.Text = alerta + " ";
            labelAlerta.Text = mensaje;
            alertAlerta.Attributes.Remove("hidden");
            this.SetFocus(alertAlerta);
        }
        protected void fecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFecha.SelectedIndex == 2)
            {
                txtFechaInicial.Disabled = false;
                txtFechaFinal.Disabled = false;
                txtFechaInicial.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                txtFechaFinal.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
            }
            else
            {
                txtFechaInicial.Disabled = true;
                txtFechaFinal.Disabled = true;
                txtFechaInicial.Value = null;
                txtFechaFinal.Value = null;
            }
            
        }
        /*
      * Requiere: N/A
      * Efectua : hace las consultas con las fechas especificadas
      * Retorna :  N/A.
      */             
        protected void clickBuscar(object sender, EventArgs e)
        {
                Boolean correcta = true;
                String estacionSeleccionada = "vacio";
                String tipoFecha = "vacio";
                Debug.WriteLine(cbxEstacion.SelectedIndex);

                if (cbxEstacion.SelectedIndex != 0)
                {
                    estacionSeleccionada = cbxEstacion.Value.ToString();
                    estacion = estacionSeleccionada;
                }
                else{
                    mostrarMensaje("danger", "Error:", "Seleccione una estación");
                    correcta = false;
                }

                if (cbxFecha.SelectedIndex == 0)
                {
                    tipoFecha = "Hoy";
                }
                else if (cbxFecha.SelectedIndex == 1)
                {
                    tipoFecha = "Día siguiente"; 
                }
                else
                {
                    tipoFecha = "Personalizado";
                }
                DateTime mañana = DateTime.Now.AddDays(1);
                if (correcta)
                {
                    if (tipoFecha == "Día siguiente")
                    {
                        fechaInicio = mañana.ToString("MM/dd/yyyy");
                        fechaFinal = mañana.ToString("MM/dd/yyyy");
                        fechaDia = mañana;
                        fechaUltima = mañana;
                        fechaInicioConsulta = mañana;
                        llenarGridTotal();
                        llenarGridTurnos();
                        llenarGridSnacks();
                        llenarGridBebidas();
                    }

                    if (tipoFecha == "Hoy")
                    {
                        fechaInicio = DateTime.Today.ToString("MM/dd/yyyy");
                        fechaFinal = DateTime.Today.ToString("MM/dd/yyyy");
                        fechaDia = DateTime.Today;
                        fechaUltima = DateTime.Today;
                        fechaInicioConsulta = DateTime.Today;
                        llenarGridTotal();
                        llenarGridTurnos();
                        llenarGridSnacks();
                        llenarGridBebidas();
                    }
                    if (tipoFecha == "Personalizado")
                    {
                        if (fechaValida())
                        {
                            DateTime fechTemp = DateTime.Parse(txtFechaInicial.Value);
                            fechaDia = fechTemp;
                            fechaInicio = fechTemp.ToString("MM/dd/yyyy");
                            fechTemp = DateTime.Parse(txtFechaFinal.Value);
                            fechaUltima = fechTemp;
                            fechaInicioConsulta = fechaDia;
                            fechaFinal = fechTemp.ToString("MM/dd/yyyy");
                            llenarGridTotal();
                            llenarGridTurnos();
                            llenarGridSnacks();
                            llenarGridBebidas();
                        }
                        else
                        {
                            mostrarMensaje("danger", "Error:", "Seleccione un rango de fechas válido");
                            
                        }
                    }
                }
                
                


            
            
        }
        /*
      * Requiere: N/A
      * Efectua : Revisa que las fechas ingresadas sean correctas 
      * Retorna :  verdadero si son fechas validas, falso si no
      */
        protected Boolean fechaValida()
        {
            Boolean valido = true;
            if (fechaDia > fechaUltima)
            {
                valido = false;
            }
            return valido;
        }

       
        /*
         * Requiere: N/A
         * Efectua : Pide el numero de notificaciones a la controladora y lo actualiza en la interfaz grafica
         * Retoirna: N/A
         */
        private void obtenerNotificaciones()
        {
            int numNotificaciones = controladora.getNotificaciones();
            contador.InnerText = numNotificaciones + "";
            if (numNotificaciones > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('tiene " + numNotificaciones + " notificaciones nuevas');", true);
            }
        }
    }
}