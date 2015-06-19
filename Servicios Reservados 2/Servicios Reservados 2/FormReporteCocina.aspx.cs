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
                estacion =  "Las Cruces";
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                } if (!listaRoles.Contains("administrador sistema") && !listaRoles.Contains("encargado cocina") && !listaRoles.Contains("administrador global"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
                llenarGridTotal();
            }
        }

        protected void GridViewSnacks_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

            GridViewSnacks.PageIndex = e.NewPageIndex;
            GridViewSnacks.DataSource = Session["tablaS"];
            GridViewSnacks.DataBind();

        }

        protected void GridViewBebidas_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

            GridViewBebidas.PageIndex = e.NewPageIndex;
            GridViewBebidas.DataSource = Session["tablaB"];
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

        protected void llenarGridTotal()
        {
            DataTable tabla = crearTablaTotal();
            String sigla="";
            int desayunos;
            int almuerzos;
            int cena;
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
                DataTable turnosDiaTres = controladora.solicitarTurnoDiaTresComidas(sigla);
                desayunos = (turnosDiaTres.Rows[0].Field<int>(0)) * (turnosDiaTres.Rows[0].Field<int>(1));
                Debug.WriteLine("consulta turnos dias 3 exitosa");
                almuerzos = desayunos;
                cena = desayunos;
                DataTable reservaEntrante = controladora.reservaEntrante(sigla);
            
                if (reservaEntrante.Rows.Count > 0)
                {

                    foreach (DataRow fila in reservaEntrante.Rows)
                    {
                        String turno;
                        int cantidad;
                        turno = fila[0].ToString();
                        cantidad = (int.Parse(fila[1].ToString())) * (int.Parse(fila[2].ToString()));
                        if(turno == "ALMUERZO"){
                            desayunos = desayunos - cantidad;  
                        }
                        else if(turno =="CENA"){
                            desayunos = desayunos - cantidad;
                            almuerzos = almuerzos - cantidad;
                        }
                        Debug.WriteLine(turno + " " + cantidad);
                    
                    }

                }
                
                for(int i = 0; i< 3;i++){
                    switch (i)
                    {
                        case 0:
                            datos[0]="Desayuno";
                            datos[1]= desayunos;
                            break;
                        case 1:
                            datos[0]="Almuerzo";
                            datos[1]= almuerzos;
                            break;

                        case 2:
                            datos[0]="Cena";
                            datos[1]= cena;
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
    }
}