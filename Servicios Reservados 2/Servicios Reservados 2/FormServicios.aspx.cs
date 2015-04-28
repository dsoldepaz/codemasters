using Servicios_Reservados_2.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Diagnostics;
using System.Web.UI.WebControls;

namespace Servicios_Reservados_2
{
    public partial class FormServicios : System.Web.UI.Page
    {
        private ControladoraServicios controladora = new ControladoraServicios();
        private static DataTable reservacion = new DataTable();
        private static String[] ids;
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarCampos();
                llenarGridServicios();
            }
        }
        
        protected void clickAceptar(object sender, EventArgs e)
        {
            //rec = controladora.prueba("ANURA0310112004.095646531");
            //if (rec.Rows.Count > 0)
            //{ // si hay un valor
            //  string num = rec.Rows[0][8].ToString();
            //nombreReservacion.Value = num;
            //Debug.WriteLine(num);
            //}
        }

      

        protected void llenarCampos()
        {
            DataTable pax = controladora.obtenerPax(controladora.idSelected());
            txtAnfitriona.Value = controladora.informacionServicio().Id;
            txtEstacion.Value = controladora.informacionServicio().Estacion;
            txtNombre.Value = controladora.informacionServicio().Solicitante;
            fechaInicio.Value = controladora.informacionServicio().FechaInicio.ToString();
            fechaFinal.Value= controladora.informacionServicio().FechaSalida.ToString();
            txtPax.Value = pax.Rows[0][0].ToString();
        }


        void llenarGridServicios()
        {
            DataTable tabla = crearTablaServicios();

            try
            {

                Object[] datos = new Object[6];
                DataTable servicios = controladora.solicitarServicios(controladora.idSelected());// se consultan todos
                
                ids = new String[servicios.Rows.Count]; //crear el vector para ids en el grid

                int i = 0;
                Debug.WriteLine("what!!");

                if (servicios.Rows.Count > 0)
                {
                   

                    foreach (DataRow fila in servicios.Rows)
                    {
                        Debug.WriteLine("UNO");
                        ids[i] = fila[0].ToString();// guardar el id para su posterior consulta
                        datos[0] = fila[1].ToString();//obtener los datos a mostrar
                        datos[1] = fila[2].ToString();
                        datos[2] = fila[3].ToString();
                        datos[3] = DateTime.Parse(fila[4].ToString());
                        datos[4] = fila[5].ToString();
                        datos[5] = fila[6].ToString();
                        tabla.Rows.Add(datos);// cargar en la tabla los datos de cada proveedor
                        i++;
                    }
                    Debug.WriteLine("DOs");
                }

                //Session["tablaa"] = tabla;
                GridServicios.DataBind();
                //Debug.WriteLine("hola");
            }
            catch (Exception e)
            {
                Debug.WriteLine("No se pudo cargar las reservaciones");
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
            columna.ColumnName = "Tipo";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Descripcion";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Hora";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.DateTime");
            columna.ColumnName = "Fecha";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Consumido";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Pax";
            tabla.Columns.Add(columna);

            GridServicios.DataSource = tabla;
            GridServicios.DataBind();

            return tabla;
        }
        
        
    }
}