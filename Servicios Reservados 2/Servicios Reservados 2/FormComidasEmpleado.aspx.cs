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
        private int modo = 0;//0= Solo el empleado consultado; 1-Agregar Reservacion; 2-Modificar reservacion;
        private ContorladoraComidaEmpleado controladora = new ContorladoraComidaEmpleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                iniciarEmpleado();
            }
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
            ContenedorManejoDeHorario.Visible = true;
            modo = 1;

            //String idEmpleado, List<DateTime> fechasReserva, bool[] turnos
        }
        protected void clickModificar(object sender, EventArgs e)
        {
            ContenedorManejoDeHorario.Visible = true;
            fechaDeEntradaCalendario.Enabled = false;//Solo se puede modificar una fecha a la vez
            //poner fecha seleccionada
            //fechaDeEntradaCalendario.SelectedDate = (GridViewReservacionesEmpleado.SelectedRow.ToString();
            modo = 2;
        }
        protected void clickCancelar(object sender, EventArgs e)
        {
            
            limpiarCalendario();
        }
        protected void clickEliminar(object sender, EventArgs e)
        {

        }
        protected void clickAceptar(object sender, EventArgs e)
        {
            switch (modo)
            {
                case 1: agregarReservacion();   //agregar
                    break;

                case 2: modificarReservacion(); // modificar
                    break;
                default: break;
            }
            limpiarCalendario();
        }
        protected void limpiarCalendario()
        {
            fechaDeEntradaCalendario.SelectedDates.Clear();
            list.Clear();
            modo = 0;
        }
        protected void agregarReservacion()
        {
            bool[] turnos = new bool[3];
            turnos[0] = this.checkboxDesayuno.Checked;
            turnos[1] = this.checkboxAlmuerzo.Checked;
            turnos[2] = this.checkboxCena.Checked;
            controladora.Agregar(identificacionEmpleado, list, turnos);
        }
        protected void modificarReservacion()
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