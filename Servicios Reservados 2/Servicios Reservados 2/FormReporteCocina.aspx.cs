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
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList listaRoles = (ArrayList)Session["Roles"];
            string userid = (string)Session["username"];
            if (!IsPostBack)
            {
                
                estacion =  "Las Cruces";
                fechaInicio = DateTime.Today.ToString("MM/dd/yyyy");
                fechaFinal = DateTime.Today.ToString("MM/dd/yyyy");
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
        /**
   * Requiere: n/a
   * Efectua: Llena la tabla  GridTotal
   * retorna:  N/A
   */
        protected void llenarGridTotal()
        {
            DataTable tabla = crearTablaTotal();
            String sigla="";
            int desayunos=0;
            int almuerzos=0;
            int cena=0;
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
                DataTable turnosDiaTres = controladora.solicitarTurnoDiaTresComidas(sigla,fechaInicio,fechaFinal);

                if (turnosDiaTres.Rows.Count > 0)
                {
                    foreach (DataRow fila in turnosDiaTres.Rows)
                    {
                        desayunos = int.Parse(fila[0].ToString())*int.Parse(fila[1].ToString());
                    }
                }
                           
                
                almuerzos = desayunos;
                cena = desayunos;

                DataTable turnosDiaDos = controladora.solicitarTurnoDiaDosComidas(sigla, fechaInicio, fechaFinal);
                if (turnosDiaDos.Rows.Count > 0)
                {
                    foreach (DataRow fila in turnosDiaDos.Rows)
                    {
                        String turno;
                        int cantidad;
                        turno = fila[0].ToString();
                        cantidad = (int.Parse(fila[1].ToString())) * (int.Parse(fila[2].ToString()));
                        if (turno == "ALMUERZO")
                        {
                            almuerzos += cantidad;
                            cena += cantidad;
                        }
                        else if (turno == "CENA")
                        {
                            desayunos += cantidad;
                            cena +=cantidad;
                        }
                        else
                        {
                            desayunos += cantidad;
                            almuerzos += cantidad;
                        }
                        
                    }
                }


                DataTable reservaEntrante = controladora.reservaEntrante(sigla, fechaInicio, fechaFinal);
            
                if (reservaEntrante.Rows.Count > 0)
                {

                    foreach (DataRow fila in reservaEntrante.Rows)
                    {
                        String turno;
                        String tipoC;
                        int cantidad;
                        turno = fila[0].ToString();
                        tipoC = fila[1].ToString();
                        cantidad = (int.Parse(fila[2].ToString())) * (int.Parse(fila[3].ToString()));
                        if(turno == "ALMUERZO" && tipoC=="3 Comidas ("+sigla+")"){
                            desayunos = desayunos - cantidad;  
                        }
                        else if(turno =="CENA"){
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

                DataTable comidasE = controladora.solicitarCE(estacion, fechaInicio, fechaFinal);

                if (reservaEntrante.Rows.Count > 0)
                {

                    foreach (DataRow fila in comidasE.Rows)
                    {
                        String tipoC;
                        int cantidad;
                        tipoC = fila[0].ToString();
                        cantidad = (int.Parse(fila[1].ToString())) * (int.Parse(fila[2].ToString()));
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
                        else {
                            datos[0] = tipoC;
                            datos[1] = cantidad;
                            tabla.Rows.Add(datos);
                        }


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
        protected void clickBuscar(object sender, EventArgs e)
        {
            DateTime mañana = DateTime.Now.AddDays(1);
            if (cbxFecha.Value.ToString() == "Día siguiente")
            {
                fechaInicio = mañana.ToString("MM/dd/yyyy");
                fechaFinal = mañana.ToString("MM/dd/yyyy");
            }
            llenarGridTotal();
        }
    }
}