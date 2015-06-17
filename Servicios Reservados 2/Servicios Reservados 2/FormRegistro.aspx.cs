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
                if (!listaRoles.Contains("administrador sistema"))
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

            DataTable tabla = crearTablaRoles();

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
            //actualiza la tabla en pantalla
            rolesGrid.DataSource = tabla;
            rolesGrid.DataBind();         
        }

        /**
     * Requiere: n/a
     * Efectua: Crea la DataTable para desplegar usuarios.
     * retorna:  un dato del tipo DataTable con la estructura para consultar los usuarios.
     */
        protected DataTable crearTablaRoles()//consultar
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
        protected void clickAceptar(object sender, EventArgs e)
        {

        }
        protected void clickCancelar(object sender, EventArgs e)
        {

        }


	}
}