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
        public static String[] ids;
        private static int indice = -1;
        private static DataTable todos;
        /*
        * Efecto: inicializa las variables de la clase
        * Requiere: nada
        * Modifica: nada
        */
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
                llenarEstaciones();
            }
        }
        /*
        * Efecto: carga la inorfmacion de los usuarios
        * Requiere: nada
        * Modifica: interfaz
        */
        private void llenarGridUsuarios()
        {
            DataTable tabla = crearTablaUsuarios();
            Object[] datos = new Object[5];
            DataTable usuarios = controladora.solicitarUsuarios();// se consultan todos
            ids = new String[usuarios.Rows.Count];
            //agrega los servicios incluidos en el paquete
            if (usuarios.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow fila in usuarios.Rows)
                {
                    ids[i++] = fila[0].ToString();//username
                    datos[0] = fila[0].ToString();//username
                    datos[1] = fila[1].ToString();//nombre
                    EntidadUsuario usuarioSeleccionado = controladora.solicitarUsuario(fila[0].ToString());
                    string roles = "";
                    foreach (string rol in usuarioSeleccionado.Rol)
                    {
                        roles += rol + ", ";
                    }
                    datos[2] = roles;//rol
                    datos[3] = fila[2].ToString();//estacion

                    datos[4] = "Activo";//estado
                    if ("0".Equals(fila[3].ToString()))
                    {
                        datos[4] = "Inactivo";//estado
                    }


                    tabla.Rows.Add(datos);// cargar en la tabla los datos de cada proveedor

                }
                todos = tabla;
                GridUsuarios.DataBind();
            }
        }
        /*
        * Efecto: carga la informacion de estaciones
        * Requiere: nada
        * Modifica: interfaz
        */
        private void llenarEstaciones()
        {
            cbxEstacion.Items.Add("Todas");
            cbxEstacion.Items.Add("La Selva");
            cbxEstacion.Items.Add("Palo Verde");
            cbxEstacion.Items.Add("Las Cruces");
            cbxEstacion.Items.Add("North American Offices");
            cbxEstacion.Items.Add("Costa Rican Offices");            
        }
        /*
        * Efecto: crea la tabla para almacenar la informacion de usuarios
        * Requiere: nada
        * Modifica: nada
        */
        private DataTable crearTablaUsuarios()
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

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Estado";
            tabla.Columns.Add(columna);

            GridUsuarios.DataSource = tabla;
            GridUsuarios.AllowSorting = false;
            GridUsuarios.DataBind();

            return tabla;
        }
        /*
        * Efecto: capta el evento del botón para agregar
        * Requiere: presionar el botón.
        * Modifica: el seleccionado.
        */
        protected void clickAgregar(object sender, EventArgs e)
        {
            FormRegistro.usernameSeleccionado = "";
            FormRegistro.modo = 1;
            Response.Redirect("FormRegistro");
        }
        /*
      * Efecto: capta el evento del botón para consultar 
      * Requiere: presionar el botón.
      * Modifica: el seleccionado.
      */
        protected void clickConsultar(object sender, EventArgs e)
        {
            indice = obtenerIndex(sender, e) + (GridUsuarios.PageIndex * 10);//se obtiene la cedula a consultar
            FormRegistro.usernameSeleccionado = ids[indice];
            FormRegistro.modo = 0;
            Response.Redirect("FormRegistro");
        }
        /*
        * Efecto: obtiene el indice del usuario seleccionado
        * Requiere: seleccion en la interfaz
        * Modifica: nada
        */
        protected int obtenerIndex(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int index = Convert.ToInt32(row.RowIndex);
            return index;

        }

        /*
         *  Requiere: Controladores de eventos de la interfaz.
         *  Efectúa:  Cambia el contenido de la tabla al índice seleccionado.
         *  Retrona:  N/A
         */
        protected void PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            GridUsuarios.PageIndex = e.NewPageIndex;
            GridUsuarios.DataSource = todos;
            GridUsuarios.DataBind();
        }
        /*
        * Efecto: aplica los filtros seleccionados por el usuario
        * Requiere: nada
        * Modifica: interfaz
        */
        protected void clickBuscar(object sender, EventArgs e)
        {
            String estacion = "";
            String nombre = "";
            String nombreUsuario = "";
            if (cbxEstacion.SelectedIndex != 0)
            {
                estacion = cbxEstacion.Value.ToString();
            }
            if (!"".Equals(txtUsername.Value.ToString()))
            {
                nombreUsuario = txtUsername.Value.ToString();
            }
            if (!"".Equals(txtNombre.Value.ToString()))
            {
                nombre = txtNombre.Value.ToString();
            }

            DataTable tabla = crearTablaUsuarios();
            Object[] datos = new Object[5];
            DataTable usuarios = controladora.solicitarUsuariosFiltro(estacion, nombreUsuario, nombre);// se consultan todos
            ids = new String[usuarios.Rows.Count];

            if (usuarios.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow fila in usuarios.Rows)
                {
                    ids[i++] = fila[0].ToString();//username
                    datos[0] = fila[0].ToString();//username
                    datos[1] = fila[1].ToString();//nombre
                    EntidadUsuario usuarioSeleccionado = controladora.solicitarUsuario(fila[0].ToString());
                    string roles = "";
                    foreach (string rol in usuarioSeleccionado.Rol)
                    {
                        roles += rol + ", ";
                    }
                    datos[2] = roles;//rol
                    datos[3] = fila[2].ToString();//estacion

                    datos[4] = "Activo";//estado
                    if ("0".Equals(fila[3].ToString()))
                    {
                        datos[4] = "Inactivo";//estado
                    }


                    tabla.Rows.Add(datos);// cargar en la tabla los datos de cada proveedor

                }
                todos = tabla;
                GridUsuarios.DataBind();
            }
        }
        /*
        * Efecto: redirige a la interfaz de modificacion de ususarios
        * Requiere: seleccion de un usuario desde la interfaz
        * Modifica: interfaz
        */
        protected void clickModificar(object sender, EventArgs e)
        {
            indice = obtenerIndex(sender, e) + (GridUsuarios.PageIndex * 10);//se obtiene la cedula a consultar
            FormRegistro.usernameSeleccionado = ids[indice];
            FormRegistro.modo = 2;
            Response.Redirect("FormRegistro");
        }
        /*
        * Efecto: desactiva un usuario
        * Requiere: nada
        * Modifica: interfaz
        */
        protected void clickDesactivar(object sender, EventArgs e)
        {
            String[] error= controladora.desactivarUsuario(ids[indice]);
            if ("danger".Equals(error[0]))
            {
                mostrarMensaje(error[0], error[1], "No se ha podido desactivar el usuario"); // se muestra el resultado
            }
            else
            {
                mostrarMensaje(error[0], error[1], "Se ha deasactivado correctamente"); // se muestra el resultado
            }     
        }
        /*
        * Efecto: selecciona el usuario a desactivar
        * Requiere: seleccion de un usuario desde la interfaz
        * Modifica: interfaz
        */
        protected void seleccionarDesactivar(object sender, EventArgs e)
        {
            indice = obtenerIndex(sender, e) + (GridUsuarios.PageIndex * 10);//se obtiene la cedula a consultar
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#modalDesactivar').modal('show');</script>", false);
        }

        /*
         * Efecto: mostrar en pantalla los mensajes del sistema, ya sean de error o de éxito.
         * Requiere: que se inicie y se active alguna de las funcionalidades.
         * Modifica: 
        */
        protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje)
        {
            alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
            labelTipoAlerta.Text = alerta + " ";
            labelAlerta.Text = mensaje;
            alertAlerta.Attributes.Remove("hidden");
            this.SetFocus(alertAlerta);
        }

    }
}