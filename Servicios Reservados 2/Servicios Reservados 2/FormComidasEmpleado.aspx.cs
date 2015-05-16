using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicios_Reservados_2;

namespace Servicios_Reservados_2
{
    public partial class FormComidasEmpleado : System.Web.UI.Page
    {
        protected String identificacionEmpleado = "";
        private static List<DateTime> list = new List<DateTime>();
        private EntidadEmpleado empleadoSeleccionado;
        private ContorladoraComidaEmpleado controladora = new ContorladoraComidaEmpleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void fechaDeEntradaCalendario_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsSelected == true)
            {
                list.Add(e.Day.Date);
            }
            Session["SelectedDates"] = list;
        }


        protected void fechaDeEntradaCalendario_SelectionChanged(object sender, EventArgs e)
        {
            if (Session["SelectedDates"] != null)
            {
                List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
                foreach (DateTime dt in newList)
                {
                    fechaDeEntradaCalendario.SelectedDates.Add(dt);
                }
            }
        }
        protected void fechaDeEntrada_ServerClick(object sender, EventArgs e)
        {
            fechaDeEntradaCalendario.Visible = !(fechaDeEntradaCalendario.Visible);
        }
        /*
         *  Requiere: Controladores de eventos de la interfaz.
         *  Efectúa:  Cambia el contenido de la tabla al índice seleccionado.
         *  Retrona:  N/A
         */
        protected void GridViewReservaciones_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

            GridViewReservacionesEmpleado.PageIndex = e.NewPageIndex;
            GridViewReservacionesEmpleado.DataSource = Session["tablaa"];
            GridViewReservacionesEmpleado.DataBind();

        }

        protected void seleccionarReservacion(object sender, EventArgs e)
        {

        }
        protected void clickAgregar(object sender, EventArgs e)
        {
            selectorDeHorario.Visible = true;
            fechaDeEntradaCalendario.Visible = true;
        }
        protected void clickModificar(object sender, EventArgs e)
        {

        }
        protected void clickCancelar(object sender, EventArgs e)
        {

        }
        private void iniciarEmpleado()
        {
            empleadoSeleccionado = controladora.getInformacionDelEmpleado(identificacionEmpleado);
            try
            {
                this.nombreLbl.Value=empleadoSeleccionado.Nombre;
                this.apellidoLbl.Value = empleadoSeleccionado.Apellido;
                this.idLbl.Value = identificacionEmpleado;

            }
            catch (Exception e)
            {
                //No se selecciono un empleado.
            }
        }
    }
}