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
    public partial class FormServirPlatos : System.Web.UI.Page
    {

        ControladoraServirPlatos controladora = new ControladoraServirPlatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList listaRoles = (ArrayList)Session["Roles"];
            string userid = (string)Session["username"];
            if (!IsPostBack)
            {
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                } if (!listaRoles.Contains("admin") && !listaRoles.Contains("cocina"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
            }

        }

        /* Requiere: La introduccion de un numero de tiquete por parte del usuario
         * Efecto: Verifica el numero de tiquete y muestra la información de la reservacion asociada
         * Modifica: Nada
         */
        protected void clickVerificar(object sender, EventArgs e)
        {
            verificar();
        }

        protected void verificar() {
            DataTable tabla = crearTablaTiquete();
            int numTiquete = int.Parse(tiquete.Value);
            Object[] datos = new Object[4];

            EntidadTiquete datosTiquete = controladora.solicitarTiquete(numTiquete);// se consulta

            datos[0] = datosTiquete.Solicitante;//obtener los datos a mostrar
            datos[1] = datosTiquete.Categoria;
            datos[2] = datosTiquete.Consumido;
            datos[3] = datosTiquete.Notas;

            tabla.Rows.Add(datos);// cargar en la tabla los datos 

            GridViewTiquete.DataBind(); 
        }
        protected DataTable crearTablaTiquete()
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Solicitante";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Categoria";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Consumido";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Notas";
            tabla.Columns.Add(columna);

            GridViewTiquete.DataSource = tabla;
            GridViewTiquete.DataBind();

            return tabla;
        }
        protected void clickServir(object sender, EventArgs e)
        {
            controladora.servirTiquete();
            verificar();
        }

    }
}