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
        public static int modo;//variable para controlar el modo en el que se encuentra el sistema: 0 consulta, 1 agrega, 2modifica, 3 elimina

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
                modo = 1;//0 consulta, 1 agrega, 2 modifica, 3 elimina
                llenarRoles();
                llenarEstados();
            }
        }

        private void llenarEstados()
        {
            estado.Items.Add("Activo");
            estado.Items.Add("Inactivo");
        }
        /*
         * Efecto: cambia de modo de acuerdo a la operación a realizar (consultar=0, agrgar=1, modificar=2 y eliminar=3).
         * Requiere: presionar el botón.
         * Modifica: los estados de los componentes de pantalla y variables locales. 
        */
        protected void cambiarModo()
        {
            switch (modo)
            {
                case 0: //consultar
                    username.Disabled = true;
                    nombre.Disabled = true;
                    correo.Disabled = true;
                    estado.Enabled = false;
                    rolesGrid.Enabled = false;
                    break;
                case 1://agregar
                    username.Disabled = false;
                    nombre.Disabled = false;
                    correo.Disabled = false;
                    estado.Enabled = true;
                    rolesGrid.Enabled = true;
                    break;
                case 2://modificar
                    username.Disabled = false;
                    nombre.Disabled = false;
                    correo.Disabled = false;
                    estado.Enabled = true;
                    rolesGrid.Enabled = true;
                    break;
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

            DataTable roles = controladora.solicitarTodosRoles();// se consultan todos
            if (roles.Rows.Count > 0)
            {
                foreach (DataRow rol in roles.Rows)
                {
                    tabla.Rows.Add(rol[0].ToString());// cargar en la tabla los datos de cada uno
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
            columna.ColumnName = "Rol";
            tabla.Columns.Add(columna);

            return tabla;
        }
        protected void clickAceptar(object sender, EventArgs e)
        {
            bool accion;
            switch (modo)
            {
                case 0://consultar
                    accion = true;
                    if (accion)
                    {
                        Response.Redirect("FormUsuario");
                    }
                    break;
                case 1://insertar
                    accion = agregarUsuario();
                    if (accion)
                    {
                        mostrarMensaje("succes", "Exito:", "Se agregó el usuario correctamente");
                        modo = 0;
                        cambiarModo();
                    }
                    break;
                case 2://modificar
                    accion = modificarUsuario();
                    if (accion)
                    {
                        //Response.Redirect("FormServicios");
                    }
                    break;
            }
        }

        private bool modificarUsuario()
        {
            throw new NotImplementedException();
        }

        /*
        * Efecto: extrale los valores introducidos en la interfaz y los envia a la controladora para que sean insertados en la BD.
        * Requiere: que los campos estén rellenados con datos válidos (compatibles con la BD).
        * Modifica: 
       */
        private bool agregarUsuario()
        {
            

            //extraer roles seleccionados por el usuario
            Boolean res = true;
            List<string> rol = new List<string>();

            for (int row = 0; row < rolesGrid.Rows.Count; row++)
            {
                if (rolesGrid.Rows[0].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (rolesGrid.Rows[0].Cells[0].FindControl("chkRol") as CheckBox);
                    if (chkRow.Checked)
                    {
                        rol.Add(rolesGrid.Rows[0].Cells[1].Text);                        
                    }
                }                
            }
            if (rol.Count == 0)
            {
                mostrarMensaje("danger", "Error:", "Debe seleccionar al menos un rol");
                res = false;
            }
            else
            {
                //extraer la informacion personal
                Object[] nuevoUsuario= new Object[5];// objeto en el que se almacenan los datos para enviar a encapsular.
                nuevoUsuario[0] = username.Value.ToString();
                nuevoUsuario[1] = nombre.Value.ToString();
                nuevoUsuario[2] = correo.Value.ToString();
                nuevoUsuario[3] = estado.SelectedItem.ToString();
                nuevoUsuario[4] = rol;

                String[] error = controladora.agregarUsuario(nuevoUsuario);// se le pide a la controladora que lo inserte
                if ("danger".Equals(error[0]))
                {
                    res = false;
                }
                mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado

            }

            
           

            /*
            if (todos Loscheckbox vacios)
            {
                mostrarMensaje("danger", "Error:", "Debe seleccionar al menos un rol");
                res = false;
            }
            else
            {

                Object[] nuevoServicio = new Object[9];// objeto en el que se almacenan los datos para enviar a encapsular.

                nuevoUsuario[0] = username.Value.ToString();//recuperamos el id de la reservación
                //en adelante se extrae la información de cada uno de los componentes de la interfaz.
                int indice = cbxTipo.SelectedIndex - 1;
                nuevoServicio[1] = tipo.Rows[indice][0];
                nuevoServicio[2] = textFecha.Value;
                nuevoServicio[3] = "Activo";
                nuevoServicio[4] = txaNotas.Value;
                nuevoServicio[5] = txtPax.Value;
                nuevoServicio[6] = cbxHora.Value;
                nuevoServicio[7] = cbxTipoPago.Value;
                nuevoServicio[8] = "";


                String[] error = controladora.agregarServicioExtra(nuevoServicio);// se le pide a la controladora que lo inserte
                if ("danger".Equals(error[0]))
                {
                    res = false;
                }
                mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado
            }*/
            return res;
        }

        protected void clickCancelar(object sender, EventArgs e)
        {

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
        }


    }
}