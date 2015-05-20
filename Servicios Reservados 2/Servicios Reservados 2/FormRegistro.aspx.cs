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
	public partial class FormRegistro : System.Web.UI.Page
	{
        ControladoraUsuario controladora = new ControladoraUsuario();
        private static int dispIndex = -1;
        private static DataRow dispSeleccionado;
        private static int asigIndex = -1;
        private static DataRow asigSeleccionado;

        private static DataTable tablaDisponibles = new DataTable();
        private static DataTable tablaAsignados = new DataTable();

		protected void Page_Load(object sender, EventArgs e)
		{
            string userid = (string)Session["username"];
            ArrayList listaRoles = (ArrayList)Session["Roles"];
            if (!IsPostBack)
            {
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                }
                if (!listaRoles.Contains("admin"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
                llenarRoles();
            }
		}
        /**
      * Requiere: N/A
      * Efectua: Muestra información sobre roles en el sistema.
      * retorna: N/A
      */
        private void llenarRoles()
        {

            DataTable tabla = crearTablaUsuarios();

            DataTable roles = controladora.solicitarRolesAsignados();// se consultan todos
            int i = 0;
            if (roles.Rows.Count > 0)
            {
                foreach (DataRow fila in roles.Rows)
                {
                    tabla.Rows.Add(fila[0].ToString());// cargar en la tabla los datos de cada uno
                    i++;
                }
            }

            tablaAsignados = tabla;
            rolesAsignadosGrid.DataSource = tabla;
            rolesAsignadosGrid.DataBind();

            tabla = crearTablaUsuarios();
            roles = controladora.solicitarRolesDisponibles();// se consultan todos

            i = 0;
            if (roles.Rows.Count > 0)
            {
                foreach (DataRow fila in roles.Rows)
                {
                    tabla.Rows.Add(fila[0].ToString());// cargar en la tabla los datos de cada uno
                    //tabla.AcceptChanges();
                    i++;
                }
            }


            tablaDisponibles = tabla;
            rolesDisponiblesGrid.DataSource = tabla;
            rolesDisponiblesGrid.DataBind();

        }

        /**
     * Requiere: n/a
     * Efectua: Crea la DataTable para desplegar usuarios.
     * retorna:  un dato del tipo DataTable con la estructura para consultar los usuarios.
     */
        protected DataTable crearTablaUsuarios()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            //se agrega el campo de nombre
            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Nombre";
            tabla.Columns.Add(columna);

            return tabla;
        }

        /**
* Requiere: Atributos de eventos gráficos.
* Efectua: Guarda los datos del rol dsiponible que se seleccionó.
* retorna: N/A
*/
        protected void seleccionarDisponible(object sender, EventArgs e)
        {
            dispIndex = rolesDisponiblesGrid.SelectedRow.RowIndex;
            dispSeleccionado = tablaDisponibles.Rows[dispIndex];

        }

        /**
      * Requiere: Atributos de eventos gráficos.
      * Efectua: Inserta el dato seleccionado de los roles disponibles en los asignados y lo elimina de los disponibles.
      * retorna: N/A
      */
        protected void incluirRolBtn_Click(object sender, EventArgs e)
        {
            if (dispSeleccionado != null)
            {
                //agregar al asignados
                DataRow row = tablaAsignados.NewRow();
                row[0] = dispSeleccionado[0];
                row[1] = dispSeleccionado[1];
                tablaAsignados.Rows.Add(row);

                rolesAsignadosGrid.DataSource = tablaAsignados;
                rolesAsignadosGrid.DataBind();

                //quitar del disponibles

                DataColumn[] keyCol = new DataColumn[1];
                keyCol[0] = tablaDisponibles.Columns["Cédula"];
                tablaDisponibles.PrimaryKey = keyCol;

                tablaDisponibles.Rows.Remove(tablaDisponibles.Rows.Find(row[0].ToString()));

                rolesDisponiblesGrid.DataSource = tablaDisponibles;
                rolesDisponiblesGrid.DataBind();

                rolesDisponiblesGrid.SelectedIndex = -1;
                dispSeleccionado = null;
            }
        }

        /**
      * Requiere: Atributos de eventos gráficos.
      * Efectua: Inserta el dato seleccionado de los roles asignado inserta en los disponibles y lo elimina de los asignados.
      * retorna: N/A
      */
        protected void sacarRolBtn_Click(object sender, EventArgs e)
        {
            if (asigSeleccionado != null)
            {
                //agregar al disponibles
                DataRow row = tablaDisponibles.NewRow();
                row[0] = asigSeleccionado[0];
                row[1] = asigSeleccionado[1];
                tablaDisponibles.Rows.Add(row);

                rolesDisponiblesGrid.DataSource = tablaDisponibles;
                rolesDisponiblesGrid.DataBind();

                //quitar del asignados
                DataColumn[] keyCol = new DataColumn[1];
                keyCol[0] = tablaAsignados.Columns["Cédula"];
                tablaAsignados.PrimaryKey = keyCol;

                tablaAsignados.Rows.Remove(tablaAsignados.Rows.Find(row[0].ToString()));

                rolesAsignadosGrid.DataSource = tablaAsignados;
                rolesAsignadosGrid.DataBind();               

                rolesAsignadosGrid.SelectedIndex = -1;
                asigSeleccionado = null;
            }


        }

        /**
* Requiere: Atributos de eventos gráficos.
* Efectua: Guarda los datos del rol asignado que se seleccionó.
* retorna: N/A
*/
        protected void seleccionarAsignado(Object sender, EventArgs e)
        {
            asigIndex = rolesAsignadosGrid.SelectedRow.RowIndex;
            asigSeleccionado = tablaAsignados.Rows[asigIndex];

        }


	}
}