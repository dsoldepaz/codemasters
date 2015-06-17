using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicios_Reservados_2
{
    public partial class FormUsuario : System.Web.UI.Page
    {
        private ControladoraUsuario controladora = new ControladoraUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList listaRoles = (ArrayList)Session["Roles"];
            string userid = (string)Session["username"];

            if (!IsPostBack)
            {
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                }
                if (!listaRoles.Contains("administrador sistema"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
                llenarGridUsuarios();
            }
        }

        private void llenarGridUsuarios()
        {
            DataTable tabla = crearTablaServicios();
            Object[] datos = new Object[4];
            DataTable usuarios = controladora.solicitarUsuarios();// se consultan todos
            //agrega los servicios incluidos en el paquete
            if (usuarios.Rows.Count > 0)
            {
                foreach (DataRow fila in usuarios.Rows)
                {
                    datos[0] = fila[0].ToString();//username
                    datos[1] = fila[1].ToString();//nombre
                    datos[2] = "rol dummy";//rol
                    datos[3] = fila[2].ToString();//estacion

                    tabla.Rows.Add(datos);// cargar en la tabla los datos de cada proveedor

                }
                GridUsuarios.DataBind();
            }
        }

        private DataTable crearTablaServicios()
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Username";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Nombre";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Roles";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Estación";
            tabla.Columns.Add(columna);

            GridUsuarios.DataSource = tabla;
            GridUsuarios.AllowSorting = false;
            GridUsuarios.DataBind();

            return tabla;
        }

        protected void clickAgregar(object sender, EventArgs e)
        {

        }
        /*
      * Efecto: capta el evento del botón para consultar 
      * Requiere: presionar el botón.
      * Modifica: el seleccionado.
      */
        protected void clickConsultar(object sender, EventArgs e)
        {

        }
        protected void clickBuscar(object sender, EventArgs e)
        {
        }

    }
}