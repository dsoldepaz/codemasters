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
    public partial class FormTiquete : System.Web.UI.Page
    {
        private static ControladoraTiquete controladora = new ControladoraTiquete();
        private static EntidadReservaciones reservacion;
        private static EntidadEmpleado empleado;
        private static EntidadServicios servicio;

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
                if (!listaRoles.Contains("admin") && !listaRoles.Contains("recepcion"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
                llenarInfoServicio();
                llenarListaTiquetes();
            }

        }

        private void llenarListaTiquetes()
        {
            DataTable tabla = crearTablaTiquetes();
            DataTable tiquetes = controladora.solicitarTiquetes(servicio.IdServicio);// se consultan todos
            if (tiquetes.Rows.Count > 0)
            {
                foreach (DataRow fila in tiquetes.Rows)
                {
                    tabla.Rows.Add(fila[0].ToString());// cargar en la tabla los datos de cada proveedor
                }
            }
            GridViewTiquetes.DataBind();
        }

        private void llenarInfoServicio()
        {
            servicio = controladora.solicitarInfoServicio();
            categoria.Value = servicio.Categoria;
            estado.Value = servicio.Estado;
            pax.Value = servicio.Pax.ToString();

            if("empleado".Equals(servicio.TipoSolicitante)){
                empleado = controladora.solicitarInfoEmpleado(servicio.IdSolicitante);
                anfitriona.Value = "No disponible";
                estacion.Value = "No disponible";
                numero.Value = empleado.Id;
                solicitante.Value = empleado.Nombre + " " + empleado.Apellido;

            
            }else if("reservacion".Equals(servicio.TipoSolicitante)){
                reservacion = controladora.solicitarInfoReservacion();
                anfitriona.Value = reservacion.Anfitriona;
                estacion.Value = reservacion.Estacion;
                numero.Value = reservacion.Numero;
                solicitante.Value = reservacion.Solicitante;
            }
            
            
        }
        protected void clickAgregar(object sender, EventArgs e)
        {
            controladora.activarTiquete(int.Parse(numTiquete.Value));
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected void seleccionarTiquete(object sender, EventArgs e)
        {
          controladora.seleccionarTiquete(int.Parse(GridViewTiquetes.SelectedRow.Cells[1].Text));
        }
        protected void clickQuitar(object sender, EventArgs e)
        {
            controladora.desactivarTiquete(int.Parse(numTiquete.Value));
            Response.Redirect(Request.Url.AbsoluteUri);

        }
        protected void clickActivar(object sender, EventArgs e)
        {

        }
        protected DataTable crearTablaTiquetes()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Número";
            tabla.Columns.Add(columna);

            GridViewTiquetes.DataSource = tabla;
            GridViewTiquetes.DataBind();

            return tabla;
        }
    }
}