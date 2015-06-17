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
    public partial class FormReportes : System.Web.UI.Page
    {
        private static ControladoraReportes controladora = new ControladoraReportes();
        String estacion;
        protected void Page_Load(object sender, EventArgs e)
        {
            estacion = (string)Session["Estacion"];
            ArrayList listaRoles = (ArrayList)Session["Roles"];
            string userid = (string)Session["username"];
            if (!IsPostBack)
            {
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                } if (!listaRoles.Contains("administrador local") && !listaRoles.Contains("recepcion") && !listaRoles.Contains("administrador global") && !listaRoles.Contains("administrador sistema"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
            }
            cargarDatos();
        }

        /*
         * Efecto: carga los datos y actiba los combobox. 
         * Requiere: iniciar el FormReportes.
         * Modifica: no realiza modificaciones, solo carga la pantalla.
        */
        void cargarDatos()
        {
            if (estacion == "todas")
            {
                cbxEstacion.Items.Clear();
                cbxEstacion.Items.Add(estacion);
            }
            else
            {
                cargarEstaciones();
            }

            cbxAnfitriona.Items.Clear();
            cbxAnfitriona.Items.Add("Seleccionar");
            cbxAnfitriona.Items.Add("OET");
            cbxAnfitriona.Items.Add("ESINTRO");
            /*
            cbxFecha.Items.Clear();
            cbxFecha.Items.Add("Seleccionar");
            cbxFecha.Items.Add("Hoy");
            cbxFecha.Items.Add("Semana");
            cbxFecha.Items.Add("Mes");
            cbxFecha.Items.Add("Personalizado");
             * */
        }

        /*
         * Efecto: llena el cbxEstacion con las diferentes estaciones.
         * Requiere: iniciar el FormReportes.
         * Modifica: los valores del cbxEstacion.
        */
        private void cargarEstaciones()
        {
            DataTable estaciones = controladora.cargarEstaciones();
            cbxEstacion.Items.Clear();// limpiamos el combobox
            if (estaciones.Rows.Count > 0)
            {// agregamos cada uno de los tipos 
                foreach (DataRow fila in estaciones.Rows)
                {
                    cbxEstacion.Items.Add(fila[0].ToString());
                }
            }
        }

        /*
         * Efecto: modifica la interfaz de acuerdo a lo selecionado en las opciones de filtro.
         * Requiere: iniciar el FormReportes y seleccionar el combobox.
         * Modifica: el FormReportes.
        */
        protected void mostrarFechas(object sender, EventArgs e)
        {
            String s = cbxFecha.Text;
            s = DateTime.Today.ToString("MM/dd/yyyy");
            int indice = cbxFecha.SelectedIndex;
            switch (indice)
            {
                case (1):
                    FechaInicial.Value = DateTime.Today.ToString("MM/dd/yyyy");
                    FechaFinal.Value = DateTime.Today.ToString("MM/dd/yyyy");
                    break;
                case(2):
                    FechaInicial.Value = DateTime.Today.ToString("MM/dd/yyyy");
                    FechaFinal.Value = DateTime.Today.AddDays(7).ToString("MM/dd/yyyy");
                    break;
                case(3):
                    FechaInicial.Value = DateTime.Today.ToString("YYYY-MM-DD");
                    FechaFinal.Value = DateTime.Today.AddMonths(7).ToString("MM/dd/yyyy");
                    break;
            }
            FechaFinal.Disabled = true;
            FechaInicial.Disabled = true;
            txtReservacion.Value = "cosa";

        }



    }
}