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
        private EntidadComidaEmpleado seleccionada;
        private int modo = 0;//0= Solo el empleado consultado; 1-Agregar Reservacion; 2-Modificar reservacion; 3-Cancelar
        private DateTime fechaElegida;
        private ControladoraComidaEmpleado controladora = new ControladoraComidaEmpleado();
        /*
         * Requiere: Parametros de eventos de la GUI
         * Efectua : Valida que el ususario este registrado, en caso contrario lo envia a la pagina de inicio de sesion.
         * Retorna : N/A
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = (string)Session["UsuarioID"];
            if (!IsPostBack)
            {
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                }
                
            }
        }
        private void arrancar()
        {
            iniciarEmpleado();

            ponerModo();
        }

        private void ponerModo()
        {
            switch (modo)
            {
                case 3: cancelar();
                    break;
            }
        }

        private void cancelar()
        {
            throw new NotImplementedException();
        }
        /*
         * Requiere: Parametros de eventos de la GUI
         * Efectua : Cuando se carga el calendario en la GUI se agrega la fecha que acaba de ser seleccionada y se agrega a la lista de fechas. Si ya estaba en lista, lo remueve.
         * Retorna : N/A
         */

        protected void fechaDeEntradaCalendario_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsSelected == true)
            {
                list.Add(e.Day.Date);
            }
            else
            {
                list.Remove(e.Day.Date);
            }
            Session["SelectedDates"] = list;
        }

        /*
         * Requiere: Parametros de eventos de la GUI
         * Efectua : Carga las fechas seleccionadas en el calendario una por una.
         * Retorna : N/A
         */
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

        /*
         * Requiere: Parametros de eventos de la GUI
         * Efectua : Pone el modo de agregar y habilita los botones de insercion.
         * Retorna : N/A
         */
        protected void clickAgregar(object sender, EventArgs e)
        {
            ContenedorManejoDeHorario.Visible = true;
            modo = 1;
           
        }
        /*
         * Requiere: Parametros de eventos de la GUI
         * Efectua : Cambia de modo, despliega los datos y bloquea el calendario para editar.
         * Retorna : N/A
         */
        protected void clickModificar(object sender, EventArgs e)
        {
            ContenedorManejoDeHorario.Visible = true;
            fechaDeEntradaCalendario.Enabled = false;//Solo se puede modificar una fecha a la vez
            //poner fecha seleccionada
            fechaDeEntradaCalendario.SelectedDate = fechaElegida;
            modo = 2;
        }
        /*
         * Requiere: Parametros de eventos de la GUI
         * Efectua : limpia la interfaz y retorna a la interfaz anterior
         * Retorna : N/A
         */
        protected void clickCancelar(object sender, EventArgs e)
        {
            limpiarCalendario();
            Response.Redirect("~/FormEmpleadoReserva.aspx");
        }
        /*
         * Requiere: Parametros de eventos de la GUI
         * Efectua : envia los datos seleccionados a la controladora para ser eliminada.
         * Retorna : N/A
         */
        protected void clickEliminar(object sender, EventArgs e)
        {
            controladora.eliminar(this.seleccionada);
        }
        /*
         * Requiere: Parametros de eventos de la GUI
         * Efectua : Evalua el modo en el que esta y apartir de alli llama el metodo que va a realizar la accion requerida.
         * Retorna : N/A
         */
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
        /*
         * Requiere: N/A
         * Efectua : Limpia el calendario y la lista de fechas, y cambia a modo 0.
         * Retorna : N/A
         */
        protected void limpiarCalendario()
        {
            fechaDeEntradaCalendario.SelectedDates.Clear();
            list.Clear();
            modo = 0;
        }
        /*
         * Requiere: Parametros de eventos de la GUI
         * Efectua : envia los datos de la GUI a la controladora para ser insertados.
         * Retorna : N/A
         */
        protected void agregarReservacion()
        {
            bool[] turnos = new bool[3];
            turnos[0] = this.checkboxDesayuno.Checked;
            turnos[1] = this.checkboxAlmuerzo.Checked;
            turnos[2] = this.checkboxCena.Checked;
            controladora.agregar(empleadoSeleccionado.Id, list, turnos, tipodePago.SelectedIndex==1,notas.Value);
        }
        /*
         * Requiere: Parametros de eventos de la GUI
         * Efectua : recupera los datos de la GUI y los manda a la controlador junto con los datos que se seleccionaron, para que se actualicen en la base de datos.
         * Retorna : N/A
         */
        protected void modificarReservacion()
        {
            bool[] turnos = new bool[3];
            turnos[0] = this.checkboxDesayuno.Checked;
            turnos[1] = this.checkboxAlmuerzo.Checked;
            turnos[2] = this.checkboxCena.Checked;
            controladora.modificar(seleccionada, empleadoSeleccionado.Id, list, turnos, tipodePago.SelectedIndex == 1, notas.Value);
        }
        protected void consultar(){
            iniciarEmpleado();
            seleccionada=controladora.consultar(empleadoSeleccionado.Id, fechaElegida);
            list = seleccionada.Fechas;
            notas.Value = seleccionada.Notas;
            bool[] turnos = seleccionada.Turnos;
            this.checkboxDesayuno.Checked= turnos[0];
            this.checkboxAlmuerzo.Checked = turnos[1];
            this.checkboxCena.Checked = turnos[2];
            tipodePago.SelectedIndex = (seleccionada.Pagado) ? 1 : 2;


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