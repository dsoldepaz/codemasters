using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace Servicios_Reservados_2
{
    public partial class FormReportes : System.Web.UI.Page
    {
        private static ControladoraReportes controladora = new ControladoraReportes();
        private String estacion;
        private int anfitriona;
        private String fechaSeleccionda;
        private String fechaInicial;
        private String fechaFin;
        private int sumaTotalDesayuno;
        private int sumaTotalConsumidosDesayuno;
        private int sumaTotalAlmuerzo;
        private int sumaTotalConsumidosAlmuerzo;
        private int sumaTotalCena;
        private int sumaTotalConsumidosCena;
        private int contar;
        private int sumaTotalSnacks;
        private int sumaTotalConsumidosSnacks;
        private int sumaTotalComidasCampo;
        private int sumaTotalComidasCampoServidos;
        private DataTable fechas;



        protected void Page_Load(object sender, EventArgs e)
        {
            estacion = (string)Session["Estacion"];
            ArrayList listaRoles = (ArrayList)Session["Roles"];
            string userid = (string)Session["username"];
            if (!IsPostBack)
            {

                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                } if (!listaRoles.Contains("administrador local") && !listaRoles.Contains("recepcion") && !listaRoles.Contains("administrador global") && !listaRoles.Contains("administrador sistema"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
                cargarDatos();
            }
            obtenerNotificaciones();

        }

        /*
         * Efecto: carga los datos y activa los combobox. 
         * Requiere: iniciar el FormComidaExtra.
         * Modifica: no realiza modificaciones, solo carga la pantalla.
        */
        void cargarDatos()
        {
            if (estacion == "todas")
            {
                cbxEstacion.Items.Clear();
                cbxEstacion.Items.Add(estacion);
            }
            else
            {
                cargarEstaciones();
            }

            listAnfitriona.Items.Clear();
            listAnfitriona.Items.Add("OET");
            listAnfitriona.Items.Add("ESINTRO");

            cbxFecha.Items.Clear();
            cbxFecha.Items.Add("Hoy");
            cbxFecha.Items.Add("Semana");
            cbxFecha.Items.Add("Mes");
            cbxFecha.Items.Add("Personalizado");

            //para que siempre esten desactivados 
            dateFechaFin.Disabled = true;
            dateFechaInicio.Disabled = true;
            dateFechaInicio.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
            dateFechaFin.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);

        }

        /*
         * Efecto: llena el cbxEstacion con las diferentes estaciones.
         * Requiere: iniciar el FormReportes.
         * Modifica: los valores del cbxEstacion.
        */
        private void cargarEstaciones()
        {
            DataTable estaciones = controladora.cargarEstaciones();
            cbxEstacion.Items.Clear();// limpiamos el combobox
            if (estaciones.Rows.Count > 0)
            {// agregamos cada uno de los tipos 
                foreach (DataRow fila in estaciones.Rows)
                {
                    cbxEstacion.Items.Add(fila[0].ToString());
                }
            }
        }


        /*
         * Efecto: obtiene los valores de los filtros seleccionados. 
         * Requiere: Click en generar reporte.
         * Modifica: el desglose del reporte.
        */
        protected void obtenerFiltros()
        {
            if (listAnfitriona.SelectedValue.Equals("OET"))
            {
                anfitriona = 01;
            }
            else
            {
                anfitriona = 02;
            }
            estacion = cbxEstacion.Value;
            fechaSeleccionda = cbxFecha.Text;
            DateTime fechTemp = DateTime.Parse(dateFechaInicio.Value);
            fechaInicial = fechTemp.ToString("MM/dd/yyyy");
            fechTemp = DateTime.Parse(dateFechaFin.Value);
            fechaFin = fechTemp.ToString("MM/dd/yyyy");
        }


        /*Efecto: Crea la tabla de servicios
         * Requiere: NA
         * Modifica: la tabla servicios, si la reservacion tiene servicios asociados
         * */
        void llenarGridReportes(String fecha, DataTable tabla)
        {

            try
            {

                DataRow fila = tabla.NewRow();
                Object[] datos = new Object[13];

                datos[0] = fecha;
                datos[1] = sumaTotalDesayuno;
                datos[2] = sumaTotalConsumidosDesayuno;
                datos[3] = sumaTotalAlmuerzo;
                datos[4] = sumaTotalConsumidosAlmuerzo;
                datos[5] = sumaTotalCena;
                datos[6] = sumaTotalConsumidosCena;
                datos[7] = sumaTotalSnacks;
                datos[8] = sumaTotalConsumidosSnacks;
                datos[9] = sumaTotalComidasCampo;
                datos[10] = sumaTotalComidasCampoServidos;
                datos[11] = sumaTotalDesayuno + sumaTotalAlmuerzo + sumaTotalCena + sumaTotalComidasCampo;
                datos[12] = sumaTotalConsumidosDesayuno + sumaTotalConsumidosAlmuerzo + sumaTotalConsumidosCena + sumaTotalComidasCampoServidos;

                tabla.Rows.Add(datos);

                GridViewReportes.AllowSorting = false;
                GridViewReportes.DataBind();

            }
            catch (Exception e)
            {
                //Debug.WriteLine("No se pudo cargar las reservaciones");
            }
        }



        /*
         * Efecto: modifica la interfaz de acuerdo a lo selecionado en las opciones de filtro.
         * Requiere: iniciar el FormReportes y seleccionar el combobox.
         * Modifica: el FormReportes.
        */
        protected void mostrarFechas(object sender, EventArgs e)
        {
            int indice = cbxFecha.SelectedIndex;
            switch (indice)
            {
                case (0):
                    dateFechaInicio.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    dateFechaFin.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    break;
                case (1):
                    dateFechaInicio.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    dateFechaFin.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today.AddDays(7));
                    break;
                case (2):
                    dateFechaInicio.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    dateFechaFin.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today.AddMonths(1));
                    break;
                case (3):
                    dateFechaInicio.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    dateFechaFin.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    dateFechaFin.Disabled = false;
                    dateFechaInicio.Disabled = false;
                    break;
            }
        }






        /**
     * Requiere: n/a
     * Efectua: Crea la DataTable para desplegar.
     * retorna:  un dato del tipo DataTable con la estructura para consultar.
     */
        protected DataTable crearTablaServicios()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Día";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Desayuno";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Desayunos Servidos";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Almuerzo";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Almuerzo Servidos";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Cena";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Cenas Servidas";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Snack";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Snack Servidos";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Comida Campo";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Comida Campo Servida";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Total";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Total Servidos";
            tabla.Columns.Add(columna);

            GridViewReportes.DataSource = tabla;
            GridViewReportes.AllowSorting = false;
            GridViewReportes.DataBind();


            return tabla;
        }

        protected void BotonGenerar_Click(object sender, EventArgs e)
        {
            obtenerFiltros();
            cicloFechas();
            //llenarGridReportes();
        }

        protected void cicloFechas()
        {
            DataTable tabla = crearTablaServicios();
            if (estacion != null && fechaInicial != null && fechaFin != null) //si se selecciona una estacion, fecha y anfitriona
            {
                DateTime fin = DateTime.Parse(dateFechaFin.Value);
                DateTime inicio = DateTime.Parse(dateFechaInicio.Value);

                while (inicio <= fin)//se realiza el for en el rango de fechas especificado
                {
                    filtroEstacionAnfitrionaFecha(inicio.ToString("MM/dd/yyyy"), inicio.ToString("MM/dd/yyyy"));
                    llenarGridReportes(inicio.ToString("MM/dd/yyyy"), tabla);
                    inicio = DateTime.Parse(inicio.AddDays(1).ToString("MM/dd/yyyy"));
                }
            }
        }

        protected void filtroEstacionAnfitrionaFecha(String fechaInicio, String fechaFinal)
        {

            DataTable comidaCampoReservDesayuno = verificarDataTable(controladora.obtenerComidaPax(estacion, 1, anfitriona, fechaInicio, fechaFinal));
            contar = comidaCampoReservDesayuno.Rows.Count;
            DataTable comidaCampoReservAlmuerzo = verificarDataTable(controladora.obtenerComidaPax(estacion, 2, anfitriona, fechaInicio, fechaFinal)); //almuerzo de comidaCampo reservado
            DataTable comidaCampoReservCena = verificarDataTable(controladora.obtenerComidaPax(estacion, 3, anfitriona, fechaInicio, fechaFinal)); //cena de comidaCampo reservado
            DataTable comidaExtraDesayuno = verificarDataTable(controladora.obtenerComidaExtraEstacionAnfitrionaFecha(estacion, "Desayuno", anfitriona, fechaInicio, fechaFinal, 1)); //desayuno comida extra
            DataTable comidaExtraAlmuerzo = verificarDataTable(controladora.obtenerComidaExtraEstacionAnfitrionaFecha(estacion, "Almuerzo", anfitriona, fechaInicio, fechaFinal, 1)); //almuerzo comida extra
            DataTable comidaExtraCena = verificarDataTable(controladora.obtenerComidaExtraEstacionAnfitrionaFecha(estacion, "Cena", anfitriona, fechaInicio, fechaFinal, 1)); //cena comida extra
            DataTable comidaCampoReservaSandiwch = verificarDataTable(controladora.obtenerComidaPax(estacion, 4, anfitriona, fechaInicio, fechaFinal)); //sandwiches de reservacion
            DataTable comidaCampoReservaPinto = verificarDataTable(controladora.obtenerComidaPax(estacion, 5, anfitriona, fechaInicio, fechaFinal)); //gallo pinto de reservacion
            DataTable comidaExtraSnack = verificarDataTable(controladora.obtenerComidaExtraEstacionAnfitrionaFecha(estacion, "Cena", anfitriona, fechaInicio, fechaFinal, 2));

            if (anfitriona == 2)
            {

                DataTable comidaCampoDesayunoEmp = verificarDataTable(controladora.obtenerComidaPaxEmp(estacion, 1, fechaInicio, fechaFinal)); //desayuno comida campo empleado
                DataTable comidaCampoAlmuerzoEmp = verificarDataTable(controladora.obtenerComidaPaxEmp(estacion, 2, fechaInicio, fechaFinal));//almuerzo comida campo empleado
                DataTable comidaCampoCenaEmp = verificarDataTable(controladora.obtenerComidaPaxEmp(estacion, 3, fechaInicio, fechaFinal)); //cena comida campo empleado
                DataTable comidaDesayunoEmp = verificarDataTableEmp(controladora.obtenerComidaEmp(estacion, "desayuno", fechaInicio, fechaFinal)); //desayuno comida campo de empleados
                DataTable comidaAlmuerzoEmp = verificarDataTableEmp(controladora.obtenerComidaEmp(estacion, "almuerzo", fechaInicio, fechaFinal)); //almuerzo comida campo de empleados
                DataTable comidaCenaEmp = verificarDataTableEmp(controladora.obtenerComidaEmp(estacion, "cena", fechaInicio, fechaFinal)); //cena comida campo de empleados
                DataTable comidaCampoEmpSandiwch = verificarDataTable(controladora.obtenerComidaPaxEmp(estacion, 4, fechaInicio, fechaFinal)); //sandwiches de empleado
                DataTable comidaCampoEmpPinto = verificarDataTable(controladora.obtenerComidaPaxEmp(estacion, 5,fechaInicio, fechaFinal)); // gallo pinto de empleados

                sumaTotalDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][1].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][1].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][1].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][1].ToString());    //suma total desayuno  
                sumaTotalConsumidosDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][2].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][2].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][2].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][2].ToString()); //suma total desayuno servidos 
                sumaTotalAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][1].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][1].ToString()); //suma total de almuerzos
                sumaTotalConsumidosAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][2].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][2].ToString()); //suma total almuerzo servidos 
                sumaTotalCena = int.Parse(comidaCampoReservCena.Rows[0][1].ToString()) + int.Parse(comidaExtraCena.Rows[0][1].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][1].ToString()) + int.Parse(comidaCenaEmp.Rows[0][1].ToString()); //suma total de cena
                sumaTotalConsumidosCena = int.Parse(comidaCampoReservCena.Rows[0][2].ToString()) + int.Parse(comidaExtraCena.Rows[0][2].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][2].ToString()) + int.Parse(comidaCenaEmp.Rows[0][2].ToString()); //suma total cena servidos 
                sumaTotalComidasCampo = int.Parse(comidaCampoReservaSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][1].ToString()); //suma total de snacks
                sumaTotalComidasCampoServidos = int.Parse(comidaCampoReservaSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][2].ToString()); //suma total de snacks servidos

            }
            else
            {
                sumaTotalDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][1].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][1].ToString());    //suma total desayuno  
                sumaTotalConsumidosDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][2].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][2].ToString());
                sumaTotalAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][1].ToString() + comidaExtraAlmuerzo.Rows[0][1].ToString()); //suma total de almuerzos
                sumaTotalConsumidosAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][2].ToString()); //suma total almuerzo servidos 
                sumaTotalCena = int.Parse(comidaCampoReservCena.Rows[0][1].ToString() + comidaExtraCena.Rows[0][1].ToString()); //suma total de cena
                sumaTotalConsumidosCena = int.Parse(comidaCampoReservCena.Rows[0][2].ToString()) + int.Parse(comidaExtraCena.Rows[0][2].ToString()); //suma total cena servidos 
                sumaTotalComidasCampo = int.Parse(comidaCampoReservaSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][1].ToString());
                sumaTotalComidasCampoServidos = int.Parse(comidaCampoReservaSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][2].ToString());

            }

            sumaTotalSnacks = int.Parse(comidaExtraSnack.Rows[0][1].ToString());
            sumaTotalConsumidosSnacks = int.Parse(comidaExtraSnack.Rows[0][2].ToString());


        }

        protected void filtroEstacionFecha(String fechaInicio, String fechaFinal)
        {

            DataTable comidaCampoReservDesayuno = verificarDataTable(controladora.obtenerComidaPaxEstacionFechas(estacion, 1, fechaInicio, fechaFinal));
            contar = comidaCampoReservDesayuno.Rows.Count;
            DataTable comidaCampoReservAlmuerzo = verificarDataTable(controladora.obtenerComidaPaxEstacionFechas(estacion, 2, fechaInicio, fechaFinal)); //almuerzo de comidaCampo reservado
            DataTable comidaCampoReservCena = verificarDataTable(controladora.obtenerComidaPaxEstacionFechas(estacion, 3, fechaInicio, fechaFinal)); //cena de comidaCampo reservado
            DataTable comidaExtraDesayuno = verificarDataTable(controladora.obtenerComidaExtraEstacionFecha(estacion, "Desayuno", fechaInicio, fechaFinal, 1)); //desayuno comida extra
            DataTable comidaExtraAlmuerzo = verificarDataTable(controladora.obtenerComidaExtraEstacionFecha(estacion, "Almuerzo", fechaInicio, fechaFinal, 1)); //almuerzo comida extra
            DataTable comidaExtraCena = verificarDataTable(controladora.obtenerComidaExtraEstacionFecha(estacion, "Cena", fechaInicio, fechaFinal, 1)); //cena comida extra
            DataTable comidaCampoReservaSandiwch = verificarDataTable(controladora.obtenerComidaPaxEstacionFechas(estacion, 4, fechaInicio, fechaFinal)); //sandwiches de reservacion
            DataTable comidaCampoReservaPinto = verificarDataTable(controladora.obtenerComidaPaxEstacionFechas(estacion, 5, fechaInicio, fechaFinal)); //gallo pinto de reservacion
            DataTable comidaExtraSnack = verificarDataTable(controladora.obtenerComidaExtraEstacionFecha(estacion, "Cena", fechaInicio, fechaFinal, 2));
           
            DataTable comidaCampoDesayunoEmp = verificarDataTable(controladora.obtenerComidaPaxEmp(estacion, 1, fechaInicio, fechaFinal)); //desayuno comida campo empleado
            DataTable comidaCampoAlmuerzoEmp = verificarDataTable(controladora.obtenerComidaPaxEmp(estacion, 2, fechaInicio, fechaFinal));//almuerzo comida campo empleado
            DataTable comidaCampoCenaEmp = verificarDataTable(controladora.obtenerComidaPaxEmp(estacion, 3, fechaInicio, fechaFinal)); //cena comida campo empleado
            DataTable comidaDesayunoEmp = verificarDataTableEmp(controladora.obtenerComidaEmp(estacion, "desayuno", fechaInicio, fechaFinal)); //desayuno comida campo de empleados
            DataTable comidaAlmuerzoEmp = verificarDataTableEmp(controladora.obtenerComidaEmp(estacion, "almuerzo", fechaInicio, fechaFinal)); //almuerzo comida campo de empleados
            DataTable comidaCenaEmp = verificarDataTableEmp(controladora.obtenerComidaEmp(estacion, "cena", fechaInicio, fechaFinal)); //cena comida campo de empleados
            DataTable comidaCampoEmpSandiwch = verificarDataTable(controladora.obtenerComidaPaxEmp(estacion, 4,fechaInicio, fechaFinal)); //sandwiches de empleado
            DataTable comidaCampoEmpPinto = verificarDataTable(controladora.obtenerComidaPaxEmp(estacion, 5,fechaInicio, fechaFinal)); // gallo pinto de empleados

            sumaTotalDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][1].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][1].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][1].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][1].ToString());    //suma total desayuno  
            sumaTotalConsumidosDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][2].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][2].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][2].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][2].ToString()); //suma total desayuno servidos 
            sumaTotalAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][1].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][1].ToString()); //suma total de almuerzos
            sumaTotalConsumidosAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][2].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][2].ToString()); //suma total almuerzo servidos 
            sumaTotalCena = int.Parse(comidaCampoReservCena.Rows[0][1].ToString()) + int.Parse(comidaExtraCena.Rows[0][1].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][1].ToString()) + int.Parse(comidaCenaEmp.Rows[0][1].ToString()); //suma total de cena
            sumaTotalConsumidosCena = int.Parse(comidaCampoReservCena.Rows[0][2].ToString()) + int.Parse(comidaExtraCena.Rows[0][2].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][2].ToString()) + int.Parse(comidaCenaEmp.Rows[0][2].ToString()); //suma total cena servidos 
            sumaTotalComidasCampo = int.Parse(comidaCampoReservaSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][1].ToString()); //suma total de snacks
            sumaTotalComidasCampoServidos = int.Parse(comidaCampoReservaSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][2].ToString()); //suma total de snacks servidos

            sumaTotalSnacks = int.Parse(comidaExtraSnack.Rows[0][1].ToString());
            sumaTotalConsumidosSnacks = int.Parse(comidaExtraSnack.Rows[0][2].ToString());

        }

        protected void filtroAnfitrionaFecha(String fechaInicio, String fechaFinal)
        {

            DataTable comidaCampoReservDesayuno = verificarDataTable(controladora.obtenerComidaPaxAnfitrionaFecha(1, anfitriona, fechaInicio, fechaFinal));
            contar = comidaCampoReservDesayuno.Rows.Count;
            DataTable comidaCampoReservAlmuerzo = verificarDataTable(controladora.obtenerComidaPaxAnfitrionaFecha(2, anfitriona, fechaInicio, fechaFinal)); //almuerzo de comidaCampo reservado
            DataTable comidaCampoReservCena = verificarDataTable(controladora.obtenerComidaPaxAnfitrionaFecha(3, anfitriona, fechaInicio, fechaFinal)); //cena de comidaCampo reservado
            DataTable comidaExtraDesayuno = verificarDataTable(controladora.obtenerComidaExtraAnfitrionaFecha("Desayuno",anfitriona, fechaInicio, fechaFinal, 1)); //desayuno comida extra
            DataTable comidaExtraAlmuerzo = verificarDataTable(controladora.obtenerComidaExtraAnfitrionaFecha("Almuerzo", anfitriona, fechaInicio, fechaFinal, 1)); //almuerzo comida extra
            DataTable comidaExtraCena = verificarDataTable(controladora.obtenerComidaExtraAnfitrionaFecha("Cena", anfitriona, fechaInicio, fechaFinal, 1)); //cena comida extra
            DataTable comidaCampoReservaSandiwch = verificarDataTable(controladora.obtenerComidaPaxAnfitrionaFecha(4, anfitriona, fechaInicio, fechaFinal)); //sandwiches de reservacion
            DataTable comidaCampoReservaPinto = verificarDataTable(controladora.obtenerComidaPaxAnfitrionaFecha(5, anfitriona, fechaInicio, fechaFinal)); //gallo pinto de reservacion
            DataTable comidaExtraSnack = verificarDataTable(controladora.obtenerComidaExtraAnfitrionaFecha("Cena", anfitriona, fechaInicio, fechaFinal, 2));

            if (anfitriona == 2)
            {

                DataTable comidaCampoDesayunoEmp = verificarDataTable(controladora.obtenerComidaPaxEmpFechas(1, fechaInicio, fechaFinal)); //desayuno comida campo empleado
                DataTable comidaCampoAlmuerzoEmp = verificarDataTable(controladora.obtenerComidaPaxEmpFechas(2, fechaInicio, fechaFinal));//almuerzo comida campo empleado
                DataTable comidaCampoCenaEmp = verificarDataTable(controladora.obtenerComidaPaxEmpFechas(3, fechaInicio, fechaFinal)); //cena comida campo empleado
                DataTable comidaDesayunoEmp = verificarDataTableEmp(controladora.obtenerComidaEmpFechas("desayuno", fechaInicio, fechaFinal)); //desayuno comida campo de empleados
                DataTable comidaAlmuerzoEmp = verificarDataTableEmp(controladora.obtenerComidaEmpFechas("almuerzo", fechaInicio, fechaFinal)); //almuerzo comida campo de empleados
                DataTable comidaCenaEmp = verificarDataTableEmp(controladora.obtenerComidaEmpFechas("cena", fechaInicio, fechaFinal)); //cena comida campo de empleados
                DataTable comidaCampoEmpSandiwch = verificarDataTable(controladora.obtenerComidaPaxEmpFechas(4, fechaInicio, fechaFinal)); //sandwiches de empleado
                DataTable comidaCampoEmpPinto = verificarDataTable(controladora.obtenerComidaPaxEmpFechas(5, fechaInicio, fechaFinal)); // gallo pinto de empleados

                sumaTotalDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][1].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][1].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][1].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][1].ToString());    //suma total desayuno  
                sumaTotalConsumidosDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][2].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][2].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][2].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][2].ToString()); //suma total desayuno servidos 
                sumaTotalAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][1].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][1].ToString()); //suma total de almuerzos
                sumaTotalConsumidosAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][2].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][2].ToString()); //suma total almuerzo servidos 
                sumaTotalCena = int.Parse(comidaCampoReservCena.Rows[0][1].ToString()) + int.Parse(comidaExtraCena.Rows[0][1].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][1].ToString()) + int.Parse(comidaCenaEmp.Rows[0][1].ToString()); //suma total de cena
                sumaTotalConsumidosCena = int.Parse(comidaCampoReservCena.Rows[0][2].ToString()) + int.Parse(comidaExtraCena.Rows[0][2].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][2].ToString()) + int.Parse(comidaCenaEmp.Rows[0][2].ToString()); //suma total cena servidos 
                sumaTotalComidasCampo = int.Parse(comidaCampoReservaSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][1].ToString()); //suma total de snacks
                sumaTotalComidasCampoServidos = int.Parse(comidaCampoReservaSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][2].ToString()); //suma total de snacks servidos

            }
            else
            {
                sumaTotalDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][1].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][1].ToString());    //suma total desayuno  
                sumaTotalConsumidosDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][2].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][2].ToString());
                sumaTotalAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][1].ToString() + comidaExtraAlmuerzo.Rows[0][1].ToString()); //suma total de almuerzos
                sumaTotalConsumidosAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][2].ToString()); //suma total almuerzo servidos 
                sumaTotalCena = int.Parse(comidaCampoReservCena.Rows[0][1].ToString() + comidaExtraCena.Rows[0][1].ToString()); //suma total de cena
                sumaTotalConsumidosCena = int.Parse(comidaCampoReservCena.Rows[0][2].ToString()) + int.Parse(comidaExtraCena.Rows[0][2].ToString()); //suma total cena servidos 
                sumaTotalComidasCampo = int.Parse(comidaCampoReservaSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][1].ToString());
                sumaTotalComidasCampoServidos = int.Parse(comidaCampoReservaSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][2].ToString());

            }

            sumaTotalSnacks = int.Parse(comidaExtraSnack.Rows[0][1].ToString());
            sumaTotalConsumidosSnacks = int.Parse(comidaExtraSnack.Rows[0][2].ToString());

        }

        protected void filtroFechas(String fechaInicio, String fechaFinal)
        {

            DataTable comidaCampoReservDesayuno = verificarDataTable(controladora.obtenerComidaPaxFechas(1, fechaInicio, fechaFinal));
            contar = comidaCampoReservDesayuno.Rows.Count;
            DataTable comidaCampoReservAlmuerzo = verificarDataTable(controladora.obtenerComidaPaxFechas(2, fechaInicio, fechaFinal)); //almuerzo de comidaCampo reservado
            DataTable comidaCampoReservCena = verificarDataTable(controladora.obtenerComidaPaxFechas(3, fechaInicio, fechaFinal)); //cena de comidaCampo reservado
            DataTable comidaExtraDesayuno = verificarDataTable(controladora.obtenerComidaExtraFechas("Desayuno", fechaInicio, fechaFinal, 1)); //desayuno comida extra
            DataTable comidaExtraAlmuerzo = verificarDataTable(controladora.obtenerComidaExtraFechas("Almuerzo", fechaInicio, fechaFinal, 1)); //almuerzo comida extra
            DataTable comidaExtraCena = verificarDataTable(controladora.obtenerComidaExtraFechas("Cena", fechaInicio, fechaFinal, 1)); //cena comida extra
            DataTable comidaCampoReservaSandiwch = verificarDataTable(controladora.obtenerComidaPaxFechas(4, fechaInicio, fechaFinal)); //sandwiches de reservacion
            DataTable comidaCampoReservaPinto = verificarDataTable(controladora.obtenerComidaPaxFechas(5, fechaInicio, fechaFinal)); //gallo pinto de reservacion
            DataTable comidaExtraSnack = verificarDataTable(controladora.obtenerComidaExtraFechas("Cena", fechaInicio, fechaFinal, 2));

            DataTable comidaCampoDesayunoEmp = verificarDataTable(controladora.obtenerComidaPaxEmpFechas(1, fechaInicio, fechaFinal)); //desayuno comida campo empleado
            DataTable comidaCampoAlmuerzoEmp = verificarDataTable(controladora.obtenerComidaPaxEmpFechas(2, fechaInicio, fechaFinal));//almuerzo comida campo empleado
            DataTable comidaCampoCenaEmp = verificarDataTable(controladora.obtenerComidaPaxEmpFechas(3, fechaInicio, fechaFinal)); //cena comida campo empleado
            DataTable comidaDesayunoEmp = verificarDataTableEmp(controladora.obtenerComidaEmpFechas("desayuno", fechaInicio, fechaFinal)); //desayuno comida campo de empleados
            DataTable comidaAlmuerzoEmp = verificarDataTableEmp(controladora.obtenerComidaEmpFechas("almuerzo", fechaInicio, fechaFinal)); //almuerzo comida campo de empleados
            DataTable comidaCenaEmp = verificarDataTableEmp(controladora.obtenerComidaEmpFechas("cena", fechaInicio, fechaFinal)); //cena comida campo de empleados
            DataTable comidaCampoEmpSandiwch = verificarDataTable(controladora.obtenerComidaPaxEmpFechas(4, fechaInicio, fechaFinal)); //sandwiches de empleado
            DataTable comidaCampoEmpPinto = verificarDataTable(controladora.obtenerComidaPaxEmpFechas(5, fechaInicio, fechaFinal)); // gallo pinto de empleados

            sumaTotalDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][1].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][1].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][1].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][1].ToString());    //suma total desayuno  
            sumaTotalConsumidosDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][2].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][2].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][2].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][2].ToString()); //suma total desayuno servidos 
            sumaTotalAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][1].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][1].ToString()); //suma total de almuerzos
            sumaTotalConsumidosAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][2].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][2].ToString()); //suma total almuerzo servidos 
            sumaTotalCena = int.Parse(comidaCampoReservCena.Rows[0][1].ToString()) + int.Parse(comidaExtraCena.Rows[0][1].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][1].ToString()) + int.Parse(comidaCenaEmp.Rows[0][1].ToString()); //suma total de cena
            sumaTotalConsumidosCena = int.Parse(comidaCampoReservCena.Rows[0][2].ToString()) + int.Parse(comidaExtraCena.Rows[0][2].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][2].ToString()) + int.Parse(comidaCenaEmp.Rows[0][2].ToString()); //suma total cena servidos 
            sumaTotalComidasCampo = int.Parse(comidaCampoReservaSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][1].ToString()); //suma total de snacks
            sumaTotalComidasCampoServidos = int.Parse(comidaCampoReservaSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][2].ToString()); //suma total de snacks servidos

            sumaTotalSnacks = int.Parse(comidaExtraSnack.Rows[0][1].ToString());
            sumaTotalConsumidosSnacks = int.Parse(comidaExtraSnack.Rows[0][2].ToString());

        }

        protected DataTable verificarDataTable(DataTable datos)
        {
            DataTable resultante = datos;
            int contador = resultante.Rows.Count;
            Object[] objeto = new Object[3];
            objeto[0] = 0;
            objeto[1] = 0;
            objeto[2] = 0;
            if (contador == 0)
            {
                resultante.Rows.Add(objeto);

            }
            return resultante;
        }

        protected DataTable verificarDataTableEmp(DataTable datos)
        {
            DataTable resultante = datos;
            int contador = resultante.Rows.Count;
            Object[] objeto = new Object[3];
            objeto[0] = DateTime.Today;
            objeto[1] = 0;
            objeto[2] = 0;
            if (contador == 0)
            {
                resultante.Rows.Add(objeto);

            }
            return resultante;
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
        }

        /*
        *  Requiere: Controladores de eventos de la interfaz.
        *  Efectúa:  Cambia el contenido de la tabla al índice seleccionado.
        *  Retrona:  N/A
        */
        protected void GridViewReporte_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

            GridViewReportes.PageIndex = e.NewPageIndex;
            GridViewReportes.DataSource = Session["tablaa"];
            GridViewReportes.DataBind();

        } 
    }
}