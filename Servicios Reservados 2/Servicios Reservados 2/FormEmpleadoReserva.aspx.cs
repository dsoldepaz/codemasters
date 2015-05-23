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
    public partial class FormEmpleadoReserva : System.Web.UI.Page
    {
        internal String idEmpleado = String.Empty;
        private ControladoraEmpleadoReserva controladora = new ControladoraEmpleadoReserva();
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList listaRoles = (ArrayList)Session["Roles"];
            string userid = (string)Session["username"];
            if (!IsPostBack)
            {
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                } if (!listaRoles.Contains("admin") && !listaRoles.Contains("recepcion"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
                llenarCampos();
                cargarComidas();

            }
        }

        protected void llenarCampos()
        {


        }

        /*
         * Requiere: N/A
         * EFECTUA :Inserta todas las columnas de la tabla que pasa la contorladora en la tabla de datos del grid ge la GUI
         * retorna: N/A
         */
        internal void cargarComidas()
        {
            DataTable tabla = crearTablaComidaEmpleado();
            DataTable data = controladora.obtenerTabla(idEmpleado);
            Object[] datos = new Object[5];
            foreach (DataRow fila in data.Rows)
            {
                //SELECT IDCOMIDAEMPLEADO,'Comida regular',IDEMPLEADO,FECHA,PAGADO
                datos[0] = fila[0].ToString(); //IDCOMIDAEMPLEADO
                datos[1] = fila[1].ToString(); //Tipo
                datos[2] = fila[2].ToString(); //IDEMPLEADO
                datos[3] = fila[3].ToString(); //FECHA
                datos[4] = fila[4].ToString(); //PAGADO
                tabla.Rows.Add(datos);
            }

            GridComidasReservadas.DataBind();
        }
        /**
        * Requiere: n/a
        * Efectua: Crea la DataTable para desplegar.
        * retorna:  un dato del tipo DataTable con la estructura para consultar.
        */
        //SELECT IDCOMIDAEMPLEADO,'Comida regular',IDEMPLEADO,FECHA,PAGADO
        protected DataTable crearTablaComidaEmpleado()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Numero";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Tipo";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "ID del empleado";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Fecha";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Tipo de Pago";
            tabla.Columns.Add(columna);


            GridComidasReservadas.DataSource = tabla;
            GridComidasReservadas.DataBind();

            return tabla;
        }
        /*
         * Requiere:Argumentos de eventos de la GUI
         * Efectua :Revisa que tipo de comida es y redirecciona a la pagina correspondiente en modo de consulta
         * Retorna :N/A
         */
        protected void btnVer_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridComidasReservadas.SelectedRow;
            String tipo = row.Cells[2].Text;
            if (tipo.Contains("Comida regular"))
            {
                //llama comida empleado en modo de consulta

            }
            else
            {
                //llama comida campo en modo de consulta
            }
        }
        /*
         * Requiere:Argumentos de eventos de la GUI
         * Efectua :Revisa que tipo de comida es y redirecciona a la pagina correspondiente en modo de agregar
         * Retorna :N/A
         */
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridComidasReservadas.SelectedRow;
            String tipo = row.Cells[2].Text;
            if (tipo.Contains("Comida regular"))
            {
                //llama comida empleado en modo de agregar

            }
            else
            {
                //llama comida campo en modo de agregar
            }
        }
        /*
         * Requiere:Argumentos de eventos de la GUI
         * Efectua :Revisa que tipo de comida es y redirecciona a la pagina correspondiente en modo de editar
         * Retorna :N/A
         */
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridComidasReservadas.SelectedRow;
            String tipo = row.Cells[2].Text;
            if (tipo.Contains("Comida regular"))
            {
                //llama comida empleado en modo de Editar

            }
            else
            {
                //llama comida campo en modo de Editar
            }
        }
        /*
         * Requiere:Argumentos de eventos de la GUI
         * Efectua :Revisa que tipo de comida es y redirecciona a la pagina correspondiente en modo de Cancelar
         * Retorna :N/A
         */
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridComidasReservadas.SelectedRow;
            String tipo = row.Cells[2].Text;
            if (tipo.Contains("Comida regular"))
            {
                //llama comida empleado en modo de cancelar

            }
            else
            {
                //llama comida campo en modo de cancelar
            }
        }
        /*
         * Requiere:Argumentos de eventos de la GUI
         * Efectua :Pone visible el panel de botones para poder trabajar sobre la fila selecconada.
         * Retorna :N/A
         */

        protected void seleccionarComida(object sender, EventArgs e)
        {
            seccionBotones.Visible = true;
        }
        /*
         * Requiere:
         * Efectua :
         * Retorna :
         */
        private void iniciarEmpleado()
        {
            if (idEmpleado.Length != 0)//la cadena tiene algo
            {
                //controladora.
            }
        }
    }
}