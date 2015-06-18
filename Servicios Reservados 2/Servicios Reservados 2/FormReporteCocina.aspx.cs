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
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList listaRoles = (ArrayList)Session["Roles"];
            string userid = (string)Session["username"];
            if (!IsPostBack)
            {
                estacion =  (string)Session["Estacion"];
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                } if (!listaRoles.Contains("administrador local") && !listaRoles.Contains("encargado cocina") && !listaRoles.Contains("administrador global"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
            }
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

        protected void llenarGridTotal()
        {
            DataTable tabla = crearTablaTotal();
            String sigla="";
            if (estacion == "Las Cruces")
            {
                sigla = "LC";
            }
            else if(estacion == "Palo Verde"){
                sigla = "PV";

            }
            else
            {
                sigla = "LS";
            }

            try
            {

                Object[] datos = new Object[2];
                DataTable turnos = controladora.solicitarTurnos(sigla);// se consultan todos
                
                int i = 0;
                if (turnos.Rows.Count > 0)
                {

                    foreach (DataRow fila in turnos.Rows)
                    {
                                                
                        datos[0] = fila[0].ToString();//obtener los datos a mostrar
                        datos[1] = fila[1].ToString();
                        tabla.Rows.Add(datos);// cargar en la tabla los datos de cada proveedor
                        i++;
                    }
                    
                }

                 GridViewTotal.DataBind();
               
            }
            catch (Exception e)
            {
                Debug.WriteLine("No se pudo cargar el total de comidas");
            }


        }
    }
}