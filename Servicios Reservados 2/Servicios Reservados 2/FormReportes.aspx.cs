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
        private int desayunos;
        private int almuerzos;
        private int cena;



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
            if (estacion == "Todas")
            {
                cargarEstaciones();
            }
            else
            {
                cbxEstacion.Items.Clear();
                cbxFecha.Items.Add("Seleccionar");
                cbxEstacion.Items.Add(estacion);

            }

            listAnfitriona.Items.Clear();
            listAnfitriona.Items.Add("Seleccionar");
            listAnfitriona.Items.Add("OET");
            listAnfitriona.Items.Add("ESINTRO");

            cbxFecha.Items.Clear();
            cbxFecha.Items.Add("Hoy");
            cbxFecha.Items.Add("Semana");
            cbxFecha.Items.Add("Mes");
            cbxFecha.Items.Add("Año Fiscal");
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
            cbxEstacion.Items.Add("Seleccionar");
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
            else if (listAnfitriona.SelectedValue.Equals("ESINTRO"))
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


        /*
         * Efecto: Crea la tabla de servicios
         * Requiere: NA
         * Modifica: la tabla servicios, si la reservacion tiene servicios asociados
         */
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

                Session["tabla"] = tabla;
                GridViewReportes.DataBind();

            }
            catch (Exception e)
            {
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
            switch (indice)//dependiendo de la opción de filtro de horas seleccionada se modifican valores en la interfaz
            {
                case (0)://día
                    dateFechaInicio.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    dateFechaFin.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    break;
                case (1)://semana
                    dateFechaInicio.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    dateFechaFin.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today.AddDays(7));
                    break;
                case (2)://mes
                    dateFechaInicio.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    dateFechaFin.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today.AddMonths(1));
                    break;
                case (3)://año fiscal
                    int mes = DateTime.Today.Month;
                    DateTime inicFecha = new DateTime();
                    DateTime finFecha = new DateTime();
                    if (mes == 1 || mes == 2 || mes == 3 || mes == 4 || mes == 5 || mes == 6)
                    {
                        inicFecha = DateTime.Parse("07/01/" + ((DateTime.Today.Year)-1));
                        finFecha = DateTime.Parse("06/30/" + (DateTime.Today.Year));
                    }
                    else
                    {
                        inicFecha = DateTime.Parse("07/01/" + (DateTime.Today.Year));
                        finFecha = DateTime.Parse("06/30/" + ((DateTime.Today.Year)+1));
                    }

                    dateFechaInicio.Value = String.Format("{0:yyyy-MM-dd}", inicFecha);
                    dateFechaFin.Value = String.Format("{0:yyyy-MM-dd}", finFecha);  //año fiscal
                    break;
                case (4)://predeterminado
                    dateFechaInicio.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    dateFechaFin.Value = String.Format("{0:yyyy-MM-dd}", DateTime.Today);
                    dateFechaFin.Disabled = false;
                    dateFechaInicio.Disabled = false;
                    break;
            }
            GridViewReportes.DataSource = null;
            GridViewReportes.DataBind();
        }


    /*
     * Efecto: Crea el DataTable para desplegar.
     * Requiere: n/a
     * Modifica:  un dato del tipo DataTable con la estructura para consultar en la interfaz.
     */
        protected DataTable crearTablaServicios()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;
            // a continuación se crean cada una de las columnas
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
            GridViewReportes.DataBind();


            return tabla;
        }

        /* 
         * Efecto: llena los campos de la interfaz dependiendo de la opción seleccionada para el filtrado.
         * Requiere: que sean seleccionados los valores del filtro.
         * Modifica: la interfaz.
         */
        protected void llenarDatos()
        {
            if (listAnfitriona.SelectedValue != "Seleccionar")
            {
                txtAnfitriona.Value = listAnfitriona.SelectedValue;
            }
            else
            {
                txtAnfitriona.Value = "No se seleccionó";
            }
            if (cbxEstacion.Value != "Seleccionar")
            {
                txtEstacion.Value = cbxEstacion.Value;
            }
            else
            {
                txtEstacion.Value = "No se seleccionó";
            }
            txtFechaInicio.Value = fechaInicial;
            txtFechaFinal.Value = fechaFin;
        }

        /* 
         * Efecto: realiza el filtro y verifica las fechas seleccionadas en el filtro.
         * Requiere: que se precione el botón generar filtro.
         * Modifica: NA.
         */
        protected void BotonGenerar_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(dateFechaFin.Value) < DateTime.Parse(dateFechaInicio.Value))//si la fecha de inicio es mayor que la de fin, envía un error
            {
                mostrarMensaje("danger", "Error:", "Revise las fechas seleccionadas, la fecha final debe ser mayor que la inicial.");
            }
            else//sino realiza la consulta
            {
                GridViewReportes.DataSource = null;
                GridViewReportes.DataBind();
                obtenerFiltros();
                llenarDatos();
                cicloFechas();
            }
        }

        /* 
         * Efecto: realiza las consultas a la base de datos para generar los reportes.
         * Requiere: selección de los parámetros de filtrado.
         * Modifica: el grid de detalle.
         */
        protected void cicloFechas()
        {
            DataTable tabla = crearTablaServicios();
            DateTime fin = DateTime.Parse(dateFechaFin.Value);
            DateTime inicio = DateTime.Parse(dateFechaInicio.Value);

            if (estacion != "Sleccionar" && anfitriona != 0 && fechaInicial != null && fechaFin != null) //si se selecciona una estacion, fecha y anfitriona
            {
                while (inicio <= fin)//se realiza el for en el rango de fechas especificado
                {
                    obtenerServiciosReservacionesEstacionAnfitrionaFecha(inicio.ToString("MM/dd/yyyy"), inicio.ToString("MM/dd/yyyy"));
                    filtroEstacionAnfitrionaFecha(inicio.ToString("MM/dd/yyyy"), inicio.ToString("MM/dd/yyyy"));
                    llenarGridReportes(inicio.ToString("MM/dd/yyyy"), tabla);
                    inicio = DateTime.Parse(inicio.AddDays(1).ToString("MM/dd/yyyy"));
                }
            }
            else if (estacion != "Seleccionar" && anfitriona == 0 && fechaInicial != null && fechaFin != null) //si se selecciona solo una estacion y fechas.
            {
                while (inicio <= fin)//se realiza el for en el rango de fechas especificado
                {
                    obtenerServiciosReservacionesEstacionFecha(inicio.ToString("MM/dd/yyyy"), inicio.ToString("MM/dd/yyyy"));
                    filtroEstacionFecha(inicio.ToString("MM/dd/yyyy"), inicio.ToString("MM/dd/yyyy"));
                    llenarGridReportes(inicio.ToString("MM/dd/yyyy"), tabla);
                    inicio = DateTime.Parse(inicio.AddDays(1).ToString("MM/dd/yyyy"));
                }
            }
            else if (estacion.Equals("Seleccionar") && anfitriona != 0 && fechaInicial != null && fechaFin != null) //si se seleccciona fecha y anfitriona.
            {
                while (inicio <= fin)//se realiza el for en el rango de fechas especificado
                {
                    obtenerServiciosReservacionesAnfitrionaFecha(inicio.ToString("MM/dd/yyyy"), inicio.ToString("MM/dd/yyyy"));
                    filtroEstacionAnfitrionaFecha(inicio.ToString("MM/dd/yyyy"), inicio.ToString("MM/dd/yyyy"));
                    llenarGridReportes(inicio.ToString("MM/dd/yyyy"), tabla);
                    inicio = DateTime.Parse(inicio.AddDays(1).ToString("MM/dd/yyyy"));
                }
            }
            else if (estacion.Equals("Seleccionar") && anfitriona == 0 && fechaInicial != null && fechaFin != null) //si se seleccioa solo fechas
            {
                while (inicio <= fin)//se realiza el for en el rango de fechas especificado
                {
                    obtenerServiciosReservacionesFecha(inicio.ToString("MM/dd/yyyy"), inicio.ToString("MM/dd/yyyy"));
                    filtroFechas(inicio.ToString("MM/dd/yyyy"), inicio.ToString("MM/dd/yyyy"));
                    llenarGridReportes(inicio.ToString("MM/dd/yyyy"), tabla);
                    inicio = DateTime.Parse(inicio.AddDays(1).ToString("MM/dd/yyyy"));
                }

            }



        }

        /* 
        * Efecto: devuelve la consulta con los filtros de estación, anfitriona y fechas
        * Requiere: selección de los filtros de fechas, anfitriona y estación
        * Modifica: el grid de detalle.
        */
        protected void filtroEstacionAnfitrionaFecha(String fechaInicio, String fechaFinal)
        {
            DataTable comidaCampoReservDesayuno = verificarDataTable(controladora.obtenerComidaPax(estacion, 1, anfitriona, fechaInicio, fechaFinal));
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
                DataTable comidaCampoEmpPinto = verificarDataTable(controladora.obtenerComidaPaxEmp(estacion, 5, fechaInicio, fechaFinal)); // gallo pinto de empleados

                sumaTotalDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][1].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][1].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][1].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][1].ToString()) + desayunos;    //suma total desayuno  
                sumaTotalConsumidosDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][2].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][2].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][2].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][2].ToString()); //suma total desayuno servidos 
                sumaTotalAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][1].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][1].ToString()) + almuerzos; //suma total de almuerzos
                sumaTotalConsumidosAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][2].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][2].ToString()); //suma total almuerzo servidos 
                sumaTotalCena = int.Parse(comidaCampoReservCena.Rows[0][1].ToString()) + int.Parse(comidaExtraCena.Rows[0][1].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][1].ToString()) + int.Parse(comidaCenaEmp.Rows[0][1].ToString()) + cena; //suma total de cena
                sumaTotalConsumidosCena = int.Parse(comidaCampoReservCena.Rows[0][2].ToString()) + int.Parse(comidaExtraCena.Rows[0][2].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][2].ToString()) + int.Parse(comidaCenaEmp.Rows[0][2].ToString()); //suma total cena servidos 
                sumaTotalComidasCampo = int.Parse(comidaCampoReservaSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][1].ToString()); //suma total de snacks
                sumaTotalComidasCampoServidos = int.Parse(comidaCampoReservaSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][2].ToString()); //suma total de snacks servidos

            }
            else
            {
                sumaTotalDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][1].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][1].ToString()) + desayunos;    //suma total desayuno  
                sumaTotalConsumidosDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][2].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][2].ToString());
                sumaTotalAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][1].ToString()) + almuerzos; //suma total de almuerzos
                sumaTotalConsumidosAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][2].ToString()); //suma total almuerzo servidos 
                sumaTotalCena = int.Parse(comidaCampoReservCena.Rows[0][1].ToString()) + int.Parse(comidaExtraCena.Rows[0][1].ToString()) + cena; //suma total de cena
                sumaTotalConsumidosCena = int.Parse(comidaCampoReservCena.Rows[0][2].ToString()) + int.Parse(comidaExtraCena.Rows[0][2].ToString()); //suma total cena servidos 
                sumaTotalComidasCampo = int.Parse(comidaCampoReservaSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][1].ToString());
                sumaTotalComidasCampoServidos = int.Parse(comidaCampoReservaSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][2].ToString());

            }

            sumaTotalSnacks = int.Parse(comidaExtraSnack.Rows[0][1].ToString());
            sumaTotalConsumidosSnacks = int.Parse(comidaExtraSnack.Rows[0][2].ToString());


        }

        /* 
       * Efecto: devuelve la consulta con los filtros de estación y fechas
       * Requiere: selección de los filtros de fechas y estación
       * Modifica: el grid de detalle.
       */
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
            DataTable comidaCampoEmpSandiwch = verificarDataTable(controladora.obtenerComidaPaxEmp(estacion, 4, fechaInicio, fechaFinal)); //sandwiches de empleado
            DataTable comidaCampoEmpPinto = verificarDataTable(controladora.obtenerComidaPaxEmp(estacion, 5, fechaInicio, fechaFinal)); // gallo pinto de empleados

            sumaTotalDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][1].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][1].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][1].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][1].ToString()) + desayunos;    //suma total desayuno  
            sumaTotalConsumidosDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][2].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][2].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][2].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][2].ToString()); //suma total desayuno servidos 
            sumaTotalAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][1].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][1].ToString()) + almuerzos; //suma total de almuerzos
            sumaTotalConsumidosAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][2].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][2].ToString()); //suma total almuerzo servidos 
            sumaTotalCena = int.Parse(comidaCampoReservCena.Rows[0][1].ToString()) + int.Parse(comidaExtraCena.Rows[0][1].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][1].ToString()) + int.Parse(comidaCenaEmp.Rows[0][1].ToString()) + cena; //suma total de cena
            sumaTotalConsumidosCena = int.Parse(comidaCampoReservCena.Rows[0][2].ToString()) + int.Parse(comidaExtraCena.Rows[0][2].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][2].ToString()) + int.Parse(comidaCenaEmp.Rows[0][2].ToString()); //suma total cena servidos 
            sumaTotalComidasCampo = int.Parse(comidaCampoReservaSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][1].ToString()); //suma total de snacks
            sumaTotalComidasCampoServidos = int.Parse(comidaCampoReservaSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][2].ToString()); //suma total de snacks servidos

            sumaTotalSnacks = int.Parse(comidaExtraSnack.Rows[0][1].ToString());
            sumaTotalConsumidosSnacks = int.Parse(comidaExtraSnack.Rows[0][2].ToString());

        }

        /* 
       * Efecto: devuelve la consulta con los filtros de fechas y anfitriona.
       * Requiere: selección de los filtros de fechas y anfitriona.
       * Modifica: el grid de detalle.
       */
        protected void filtroAnfitrionaFecha(String fechaInicio, String fechaFinal)
        {

            DataTable comidaCampoReservDesayuno = verificarDataTable(controladora.obtenerComidaPaxAnfitrionaFecha(1, anfitriona, fechaInicio, fechaFinal));
            contar = comidaCampoReservDesayuno.Rows.Count;
            DataTable comidaCampoReservAlmuerzo = verificarDataTable(controladora.obtenerComidaPaxAnfitrionaFecha(2, anfitriona, fechaInicio, fechaFinal)); //almuerzo de comidaCampo reservado
            DataTable comidaCampoReservCena = verificarDataTable(controladora.obtenerComidaPaxAnfitrionaFecha(3, anfitriona, fechaInicio, fechaFinal)); //cena de comidaCampo reservado
            DataTable comidaExtraDesayuno = verificarDataTable(controladora.obtenerComidaExtraAnfitrionaFecha("Desayuno", anfitriona, fechaInicio, fechaFinal, 1)); //desayuno comida extra
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

                sumaTotalDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][1].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][1].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][1].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][1].ToString()) + desayunos;    //suma total desayuno  
                sumaTotalConsumidosDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][2].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][2].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][2].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][2].ToString()); //suma total desayuno servidos 
                sumaTotalAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][1].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][1].ToString()) + almuerzos; //suma total de almuerzos
                sumaTotalConsumidosAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][2].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][2].ToString()); //suma total almuerzo servidos 
                sumaTotalCena = int.Parse(comidaCampoReservCena.Rows[0][1].ToString()) + int.Parse(comidaExtraCena.Rows[0][1].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][1].ToString()) + int.Parse(comidaCenaEmp.Rows[0][1].ToString()) + cena; //suma total de cena
                sumaTotalConsumidosCena = int.Parse(comidaCampoReservCena.Rows[0][2].ToString()) + int.Parse(comidaExtraCena.Rows[0][2].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][2].ToString()) + int.Parse(comidaCenaEmp.Rows[0][2].ToString()); //suma total cena servidos 
                sumaTotalComidasCampo = int.Parse(comidaCampoReservaSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][1].ToString()); //suma total de snacks
                sumaTotalComidasCampoServidos = int.Parse(comidaCampoReservaSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][2].ToString()); //suma total de snacks servidos

            }
            else
            {
                sumaTotalDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][1].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][1].ToString()) + desayunos;    //suma total desayuno  
                sumaTotalConsumidosDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][2].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][2].ToString());
                sumaTotalAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][1].ToString() + comidaExtraAlmuerzo.Rows[0][1].ToString()) + almuerzos; //suma total de almuerzos
                sumaTotalConsumidosAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][2].ToString()); //suma total almuerzo servidos 
                sumaTotalCena = int.Parse(comidaCampoReservCena.Rows[0][1].ToString()) + int.Parse(comidaExtraCena.Rows[0][1].ToString()) + cena; //suma total de cena
                sumaTotalConsumidosCena = int.Parse(comidaCampoReservCena.Rows[0][2].ToString()) + int.Parse(comidaExtraCena.Rows[0][2].ToString()); //suma total cena servidos 
                sumaTotalComidasCampo = int.Parse(comidaCampoReservaSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][1].ToString());
                sumaTotalComidasCampoServidos = int.Parse(comidaCampoReservaSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][2].ToString());

            }

            sumaTotalSnacks = int.Parse(comidaExtraSnack.Rows[0][1].ToString());
            sumaTotalConsumidosSnacks = int.Parse(comidaExtraSnack.Rows[0][2].ToString());

        }

        /* 
       * Efecto: devuelve la consulta con los filtros de fechas
       * Requiere: selección de los filtros de fechas
       * Modifica: el grid de detalle.
       */
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

            sumaTotalDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][1].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][1].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][1].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][1].ToString()) + desayunos;    //suma total desayuno  
            sumaTotalConsumidosDesayuno = int.Parse(comidaCampoReservDesayuno.Rows[0][2].ToString()) + int.Parse(comidaExtraDesayuno.Rows[0][2].ToString()) + int.Parse(comidaCampoDesayunoEmp.Rows[0][2].ToString()) + int.Parse(comidaDesayunoEmp.Rows[0][2].ToString()); //suma total desayuno servidos 
            sumaTotalAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][1].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][1].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][1].ToString()) + almuerzos; //suma total de almuerzos
            sumaTotalConsumidosAlmuerzo = int.Parse(comidaCampoReservAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaExtraAlmuerzo.Rows[0][2].ToString()) + int.Parse(comidaCampoAlmuerzoEmp.Rows[0][2].ToString()) + int.Parse(comidaAlmuerzoEmp.Rows[0][2].ToString()); //suma total almuerzo servidos 
            sumaTotalCena = int.Parse(comidaCampoReservCena.Rows[0][1].ToString()) + int.Parse(comidaExtraCena.Rows[0][1].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][1].ToString()) + int.Parse(comidaCenaEmp.Rows[0][1].ToString()) + cena; //suma total de cena
            sumaTotalConsumidosCena = int.Parse(comidaCampoReservCena.Rows[0][2].ToString()) + int.Parse(comidaExtraCena.Rows[0][2].ToString()) + int.Parse(comidaCampoCenaEmp.Rows[0][2].ToString()) + int.Parse(comidaCenaEmp.Rows[0][2].ToString()); //suma total cena servidos 
            sumaTotalComidasCampo = int.Parse(comidaCampoReservaSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][1].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][1].ToString()); //suma total de snacks
            sumaTotalComidasCampoServidos = int.Parse(comidaCampoReservaSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoReservaPinto.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpSandiwch.Rows[0][2].ToString()) + int.Parse(comidaCampoEmpPinto.Rows[0][2].ToString()); //suma total de snacks servidos

            sumaTotalSnacks = int.Parse(comidaExtraSnack.Rows[0][1].ToString());
            sumaTotalConsumidosSnacks = int.Parse(comidaExtraSnack.Rows[0][2].ToString());

        }


        /* 
      * Efecto: verifica que el DataTable devuelve tuplas y sino se agrega una fila
      * Requiere: DataTable
      * Modifica: el DataTable que retorna
      */
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

        /* 
      * Efecto: verifica que el DataTable para las consultas de empleado devuelve tuplas y sino se agrega una fila
      * Requiere: DataTable
      * Modifica: el DataTable que retorna
      */
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
       * Efecto: verifica que el DataTable para las consultas de una reservación devuelve tuplas y sino se agrega una fila
       * Requiere: DataTable
       * Modifica: el DataTable que retorna
       */
        protected DataTable verificarComidasReservaciones(DataTable datos)
        {
            DataTable resultante = datos;
            Object[] objeto = new Object[2];
            objeto[0] = DateTime.Today;
            objeto[1] = 0;
            if (int.Parse(resultante.Rows[0][0].ToString()) == 0)
            {
                //resultante.Columns.Add("PAX");
                resultante.Rows[0][1] = 0;
            }
            return resultante;
        }

        /*
        * Efecto : Pide el numero de notificaciones a la controladora y lo actualiza en la interfaz grafica
        * Requiere: N/A
        * Modifica: N/A
        */
        private void obtenerNotificaciones()
        {
            int numNotificaciones = controladora.getNotificaciones();
            contador.InnerText = numNotificaciones + "";
        }

        /*
        *  Efecto:  Cambia el contenido de la tabla al índice seleccionado.
        *  Requiere: Controladores de eventos de la interfaz.
        *  Modifica:  las dimnensiones del grid en la interfaz.
        */
        protected void GridViewReporte_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

            GridViewReportes.PageIndex = e.NewPageIndex;
            GridViewReportes.DataSource = Session["tabla"];
            GridViewReportes.DataBind();

        }

       /*
        *  Efecto:  cancelar la operación y redirecciona a la página default..
        *  Requiere: presione el botón cancelar.
        *  Modifica:  NA
        */
        protected void clickCancelar(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }


       /*
        * Efecto : realiza las consultas para onbtener el número de comidas filtrando por estación y fechas.
        * Requiere: la entrada de los parámetros para realizar el filtro.
        * Modifica: variables globales para realizar el conteo general.
        */
        private void obtenerServiciosReservacionesEstacionFecha(String fechaInicio, String fechaFinal)
        {
            string sigla;
            string estacionSeleccionada = cbxEstacion.Value;

            if (estacionSeleccionada == "Las Cruces")
            {
                sigla = "LC";
            }
            else if (estacionSeleccionada == "Palo Verde")
            {
                sigla = "PV";

            }
            else
            {
                sigla = "LS";
            }
            //Obtiene los datos de las reservaciones que reservan las 3 comidas por dia
            DataTable turnosDiaTres = verificarComidasReservaciones(controladora.solicitarTurnoDiaTresComidasEstacionFecha(sigla, fechaInicio, fechaFinal));

            if (turnosDiaTres.Rows.Count > 0)
            {
                foreach (DataRow fila in turnosDiaTres.Rows)
                {
                    desayunos = int.Parse(fila[1].ToString());
                }
            }


            almuerzos = desayunos;
            cena = desayunos;
            //Obtiene los datos de reservaciones que reservan solo 2 comidas por dia
            DataTable turnosDiaDos = controladora.solicitarTurnoDiaDosComidasEstacionFecha(sigla, fechaInicio, fechaFinal);// verificarComidasReservaciones(controladora.solicitarTurnoDiaDosComidasEstacionFecha(sigla, fechaInicio, fechaFinal));
            if (turnosDiaDos.Rows.Count > 0)
            {
                foreach (DataRow fila in turnosDiaDos.Rows)
                {
                    String turno;
                    int cantidad;
                    turno = fila[0].ToString();
                    cantidad = (int.Parse(fila[2].ToString()));
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
            DataTable reservaEntrante = controladora.reservaEntranteEstacionFecha(sigla, fechaInicio, fechaFinal);// verificarComidasReservaciones(controladora.reservaEntranteEstacionFecha(sigla, fechaInicio, fechaFinal));

            if (reservaEntrante.Rows.Count > 0)
            {

                foreach (DataRow fila in reservaEntrante.Rows)
                {
                    String turno;
                    String tipoC;
                    int cantidad;
                    turno = fila[0].ToString();
                    tipoC = fila[1].ToString();
                    cantidad = (int.Parse(fila[3].ToString()));
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
        }

        /*
        * Efecto : realiza las consultas para onbtener el número de comidas filtrando por anfitriona y fechas.
        * Requiere: la entrada de los parámetros para realizar el filtro.
        * Modifica: variables globales para realizar el conteo general.
        */
        private void obtenerServiciosReservacionesAnfitrionaFecha(String fechaInicio, String fechaFinal)
        {

            //Obtiene los datos de las reservaciones que reservan las 3 comidas por dia
            DataTable turnosDiaTres = verificarComidasReservaciones(controladora.solicitarTurnoDiaTresComidasAnfitrionaFecha(anfitriona, fechaInicio, fechaFinal));

            if (turnosDiaTres.Rows.Count > 0)
            {
                foreach (DataRow fila in turnosDiaTres.Rows)
                {
                    desayunos = int.Parse(fila[1].ToString());
                }
            }


            almuerzos = desayunos;
            cena = desayunos;
            //Obtiene los datos de reservaciones que reservan solo 2 comidas por dia
            DataTable turnosDiaDos = controladora.solicitarTurnoDiaDosComidasAnfitrionaFecha(anfitriona, fechaInicio, fechaFinal);//verificarComidasReservaciones(controladora.solicitarTurnoDiaDosComidasAnfitrionaFecha(anfitriona, fechaInicio, fechaFinal));
            if (turnosDiaDos.Rows.Count > 0)
            {
                foreach (DataRow fila in turnosDiaDos.Rows)
                {
                    String turno;
                    int cantidad;
                    turno = fila[0].ToString();
                    cantidad = (int.Parse(fila[2].ToString()));
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
            DataTable reservaEntrante = controladora.reservaEntranteAnfitrionaFecha(anfitriona, fechaInicio, fechaFinal);//verificarComidasReservaciones(controladora.reservaEntranteAnfitrionaFecha(anfitriona, fechaInicio, fechaFinal));

            if (reservaEntrante.Rows.Count > 0)
            {

                foreach (DataRow fila in reservaEntrante.Rows)
                {
                    String turno;
                    String tipoC;
                    int cantidad;
                    turno = fila[0].ToString();
                    tipoC = fila[1].ToString();
                    cantidad = (int.Parse(fila[3].ToString()));
                    if (turno == "ALMUERZO" && tipoC.Contains("3 Comidas"))
                    {
                        desayunos = desayunos - cantidad;
                    }
                    else if (turno == "CENA")
                    {
                        if (tipoC.Contains("3 Comidas"))
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
        }

        /*
        * Efecto : realiza las consultas para onbtener el número de comidas filtrando por estación, anfitriona y fechas.
        * Requiere: la entrada de los parámetros para realizar el filtro.
        * Modifica: variables globales para realizar el conteo general.
        */
        private void obtenerServiciosReservacionesEstacionAnfitrionaFecha(String fechaInicio, String fechaFinal)
        {
            string sigla;
            string estacionSeleccionada = cbxEstacion.Value;

            if (estacionSeleccionada == "Las Cruces")
            {
                sigla = "LC";
            }
            else if (estacionSeleccionada == "Palo Verde")
            {
                sigla = "PV";

            }
            else
            {
                sigla = "LS";
            }
            //Obtiene los datos de las reservaciones que reservan las 3 comidas por dia
            DataTable turnosDiaTres = verificarComidasReservaciones(controladora.solicitarTurnoDiaTresComidasEstacionAnfitrionaFecha(sigla, fechaInicio, fechaFinal, anfitriona));
           
            if (turnosDiaTres.Rows.Count > 0)
            {
                foreach (DataRow fila in turnosDiaTres.Rows)
                {
                    desayunos = int.Parse(fila[1].ToString());
                }
            }


            almuerzos = desayunos;
            cena = desayunos;
            //Obtiene los datos de reservaciones que reservan solo 2 comidas por dia
            DataTable turnosDiaDos = controladora.solicitarTurnoDiaDosComidasEstacionAnfitrionaFecha(sigla, fechaInicio, fechaFinal, anfitriona);//verificarComidasReservaciones(controladora.solicitarTurnoDiaDosComidasEstacionAnfitrionaFecha(sigla, fechaInicio, fechaFinal, anfitriona));
            if (turnosDiaDos.Rows.Count > 0)
            {
                foreach (DataRow fila in turnosDiaDos.Rows)
                {
                    String turno;
                    int cantidad;
                    turno = fila[0].ToString();
                    cantidad = (int.Parse(fila[2].ToString()));
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
            DataTable reservaEntrante = controladora.reservaEntranteEstacionAnfitrionaFecha(sigla, fechaInicio, fechaFinal, anfitriona);// verificarComidasReservaciones(controladora.reservaEntranteEstacionAnfitrionaFecha(sigla, fechaInicio, fechaFinal, anfitriona));

            if (reservaEntrante.Rows.Count > 0)
            {

                foreach (DataRow fila in reservaEntrante.Rows)
                {
                    String turno;
                    String tipoC;
                    int cantidad;
                    turno = fila[0].ToString();
                    tipoC = fila[1].ToString();
                    cantidad = (int.Parse(fila[3].ToString()));
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
        }

        /*
        * Efecto : realiza las consultas para onbtener el número de comidas filtrando por fechas.
        * Requiere: la entrada de los parámetros para realizar el filtro.
        * Modifica: variables globales para realizar el conteo general.
        */
        private void obtenerServiciosReservacionesFecha(String fechaInicio, String fechaFinal)
        {

            //Obtiene los datos de las reservaciones que reservan las 3 comidas por dia
            DataTable turnosDiaTres = verificarComidasReservaciones(controladora.solicitarTurnoDiaTresComidasFecha(fechaInicio, fechaFinal));

            if (turnosDiaTres.Rows.Count > 0)
            {
                foreach (DataRow fila in turnosDiaTres.Rows)
                {
                    desayunos = int.Parse(fila[1].ToString());
                }
            }

            almuerzos = desayunos;
            cena = desayunos;
            //Obtiene los datos de reservaciones que reservan solo 2 comidas por dia
            DataTable turnosDiaDos = controladora.solicitarTurnoDiaDosComidasFecha(fechaInicio, fechaFinal);// verificarComidasReservaciones(controladora.solicitarTurnoDiaDosComidasFecha(fechaInicio, fechaFinal));
            if (turnosDiaDos.Rows.Count > 0)
            {
                foreach (DataRow fila in turnosDiaDos.Rows)
                {
                    String turno;
                    int cantidad;
                    turno = fila[0].ToString();
                    cantidad = (int.Parse(fila[2].ToString()));
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
            DataTable reservaEntrante = controladora.reservaEntranteFecha(fechaInicio, fechaFinal);//verificarComidasReservaciones(controladora.reservaEntranteFecha(fechaInicio, fechaFinal));

            if (reservaEntrante.Rows.Count > 0)
            {
                foreach (DataRow fila in reservaEntrante.Rows)
                {
                    String turno;
                    String tipoC;
                    int cantidad;
                    turno = fila[0].ToString();
                    tipoC = fila[1].ToString();
                    cantidad = (int.Parse(fila[3].ToString()));
                    if (turno == "ALMUERZO" && tipoC.Contains("3 Comidas"))
                    {
                        desayunos = desayunos - cantidad;
                    }
                    else if (turno == "CENA")
                    {
                        if (tipoC.Contains("3 Comidas"))
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
        }

        /*
         * Efecto: mostrar en pantalla los mensajes del sistema, ya sean de error o de éxito.
         * Requiere: que se inicie el FormComidaExtra y se active alguna de las funcionalidades.
         * Modifica: NA
        */
        protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje)
        {
            alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
            labelTipoAlerta.Text = alerta + " ";
            labelAlerta.Text = mensaje;
            alertAlerta.Attributes.Remove("hidden");
            this.SetFocus(alertAlerta);
        }
    }
}