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
        private String fechaInicio;
        private String fechaFinal;
        private int sumaTotalDesayuno;
        private int sumaTotalConsumidosDesayuno;
        private int contar;
        

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
            DateTime fechTemp = DateTime.Parse(dateFechaInicio.Value);
            Debug.WriteLine("FECHA: " + dateFechaInicio.Value);
            fechaSeleccionda = cbxFecha.Text;
            fechaInicio = fechTemp.ToString("MM/dd/yyyy");
            fechTemp = DateTime.Parse(dateFechaFin.Value);
            fechaFinal = fechTemp.ToString("MM/dd/yyyy");
        }


        /*Efecto: Crea la tabla de servicios
         * Requiere: NA
         * Modifica: la tabla servicios, si la reservacion tiene servicios asociados
         * */
        void llenarGridReportes()
        {
            DataTable tabla = crearTablaServicios();
            try
            {

                  Object[] datos = new Object[13];
                  if (estacion != null && fechaInicio != null && fechaFinal != null)
                  {
                      int opcion = 1; //desayuno
                      DataTable paxReserv = controladora.obtenerComidaPax(estacion, opcion, anfitriona, fechaInicio, fechaFinal);// se consultan desayunos de comida de campo dependiendo de fecha con estacion y anfitriona.
                      contar = paxReserv.Rows.Count;

                      if (anfitriona == 1)
                      {
                         
                          DataTable paxEmp = controladora.obtenerComidaPaxEmp(estacion, fechaInicio, fechaFinal); //desayuno comida campo reserv
                          DataTable comidaEmp = controladora.obtenerComidaEmp(estacion, fechaInicio, fechaFinal); //desayuno comida campo de empleados
                          sumaTotalDesayuno = int.Parse(paxReserv.Rows[0][0].ToString()) + int.Parse(paxEmp.Rows[0][0].ToString()) + int.Parse(comidaEmp.Rows[0][0].ToString());    //suma total desayuno  
                          sumaTotalConsumidosDesayuno = int.Parse(paxReserv.Rows[0][1].ToString()) + int.Parse(paxEmp.Rows[0][1].ToString()) + int.Parse(comidaEmp.Rows[0][1].ToString());
                      }
                      else
                      {
                          sumaTotalDesayuno = int.Parse(paxReserv.Rows[0][0].ToString());    //suma total desayuno  
                          sumaTotalConsumidosDesayuno = int.Parse(paxReserv.Rows[0][1].ToString());
                      }
                  }

                  if (contar > 0)
                {
                       for (int i = 0; i < contar; i++)
                    {
                          datos[0] = fechaInicio;
                           datos[1] = sumaTotalDesayuno;
                           datos[2] = sumaTotalConsumidosDesayuno;
                          datos[4] = "-";
                          datos[5] = "-";
                          datos[6] = "-";
                          datos[7] = "-";
                          datos[8] = "-";
                          datos[9] = "-";
                          datos[10] = "-";
                          datos[11] = "-";                     
                          datos[12] = "-";
                        tabla.Rows.Add(datos);// cargar en la tabla los datos de cada proveedor
                    }
                }

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
            llenarGridReportes();
        }




    }
}