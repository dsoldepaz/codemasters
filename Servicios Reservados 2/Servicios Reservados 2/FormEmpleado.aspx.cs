using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
namespace Servicios_Reservados_2
{
    public partial class FormEmpleado : System.Web.UI.Page
    {
        
        private static ControladoraEmpleado controladora = new ControladoraEmpleado();
        public static String[] ids;
                
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //cargarDatos();  



            }
            

            // ponerModo();

        }

         void cargarDatos()
        {
            llenarGridReservaciones();
            
        }

        void llenarGridReservaciones()
        {
            DataTable tabla = crearTablaEmpleados();

            try
            {

                Object[] datos = new Object[3];
                DataTable empleados = controladora.solicitarTodosEmpleados();// se consultan todos
                ids = new String[empleados.Rows.Count]; //crear el vector para ids en el grid

                int i = 0;
                if (empleados.Rows.Count > 0)
                {
                    foreach (DataRow fila in empleados.Rows)
                    {
                        
                        ids[i] = fila[0].ToString();// guardar el id para su posterior consulta
                        datos[0] = fila[1].ToString();//obtener los datos a mostrar
                        datos[1] = fila[2].ToString();
                        datos[2] = fila[3].ToString();
                        tabla.Rows.Add(datos);// cargar en la tabla los datos de cada proveedor
                        i++;
                    }
                   
                }

                Session["tablaa"] = tabla;
                GridViewReservaciones.DataBind();
                //Debug.WriteLine("hola");
            }
            catch (Exception e)
            {
                Debug.WriteLine("No se pudo cargar las reservaciones");
            }


        }

        protected DataTable crearTablaEmpleados()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Identificación";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Nombre";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Apellido";
            tabla.Columns.Add(columna);
                       
            GridViewReservaciones.DataSource = tabla;
            GridViewReservaciones.DataBind();

            return tabla;
        }

        
        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        protected void seleccionarEmpleado(object sender, EventArgs e)
        {
            try
            {
                //controladora.seleccionarReservacion(ids[GridViewReservaciones.SelectedIndex]);
            }
            catch (Exception ee) { 
                
            }
        }
        /*
         *  Requiere: Controladores de eventos de la interfaz.
         *  Efectúa:  Cambia el contenido de la tabla al índice seleccionado.
         *  Retrona:  N/A
         */
        protected void GridViewReservaciones_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

            GridViewReservaciones.PageIndex = e.NewPageIndex;
            GridViewReservaciones.DataSource = Session["tablaa"];
            GridViewReservaciones.DataBind();

        }

        protected void botonBuscar(Object sender, EventArgs e){
            String nombre = "vacio";
            String iden = "vacio";
            if (inputNombre.Value != null)
            {
              nombre = inputNombre.Value.ToString();
            }
            if (inputIdentificacion.Value != null)
            {
              iden = inputIdentificacion.Value.ToString();
            }
            if (nombre.CompareTo("vacio") != 0 || iden.CompareTo("vacio") != 0)
          {
              DataTable tabla = crearTablaEmpleados();
                
              try
              {

                  Object[] datos = new Object[3];
                  DataTable empleados = controladora.consultarEmpleados(nombre, iden);// se consulta el empleado 
                  ids = new String[empleados.Rows.Count]; //crear el vector para ids en el grid
                    
                  int i = 0;
                  if (empleados.Rows.Count > 0)
                  {
                      foreach (DataRow fila in empleados.Rows)
                      {
                          ids[i] = fila[0].ToString();// guardar el id para su posterior consulta
                          datos[0] = fila[1].ToString();//obtener los datos a mostrar
                          datos[1] = fila[2].ToString();
                          datos[2] = fila[3].ToString();
                          tabla.Rows.Add(datos);// cargar en la tabla los datos de cada proveedor
                          i++;
                      }
                  }
                  Session["tablaa"] = tabla;
                    //GridViewReservaciones.DataSource = tabla;
                  GridViewReservaciones.DataBind();

              }
              catch (Exception s)
              {
                  Debug.WriteLine("No se pudo cargar las reservaciones");
              }
          }
          else
          {
              llenarGridReservaciones();
          }
        
        }
    }
}