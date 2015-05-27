using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicios_Reservados_2;
using System.Collections;

namespace Servicios_Reservados_2
{
    public partial class FormComidasEmpleado : System.Web.UI.Page
    {
        internal static String identificacionEmpleado = "";
        private static List<DateTime> list = new List<DateTime>();
        private EntidadEmpleado empleadoSeleccionado;
        private EntidadComidaEmpleado seleccionada;
        internal static int modo = 0;//0= Consultado; 1-Agregar Reservacion; 2-Modificar reservacion; 3-Cancelar
        internal static int idComida = -1;
        private DateTime fechaElegida;
        private ControladoraComidaEmpleado controladora = new ControladoraComidaEmpleado();
        /*
         * Requiere: Parametros de eventos de la GUI
         * Efectua : Valida que el ususario este registrado, en caso contrario lo envia a la pagina de inicio de sesion.
         * Retorna : N/A
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
                } if (!listaRoles.Contains("admin") && !listaRoles.Contains("recepcion"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
                arrancar();
            }
        }
        private void arrancar()
        {
            iniciarEmpleado();

            ponerModo();
        }

        private void ponerModo()
        {
            switch (modo)//0= Consultado; 1-Agregar Reservacion; 2-Modificar reservacion; 3-Cancelar
            {
                case 0: consultar();
                    break;
                case 1: agregarReservacion();
                    break;
                case 2: consultar();
                    modificarReservacion();
                    break;
                case 3: consultar();
                    cancelar();
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
            char[] turnos = new char[3];
            turnos[0] = (this.checkboxDesayuno.Checked) ? 'R' : 'N';//R = Reservado C= Consumido N=No reservado X=Cancelado
            turnos[1] = (this.checkboxAlmuerzo.Checked) ? 'R' : 'N';//R = Reservado C= Consumido N=No reservado X=Cancelado
            turnos[2] = (this.checkboxCena.Checked) ? 'R' : 'N';//R = Reservado C= Consumido N=No reservado X=Cancelado
            controladora.agregar(empleadoSeleccionado.Id, list, turnos, tipodePago.SelectedIndex == 1, notas.Value);
        }
        /*
         * Requiere: Parametros de eventos de la GUI
         * Efectua : recupera los datos de la GUI y los manda a la controlador junto con los datos que se seleccionaron, para que se actualicen en la base de datos.
         * Retorna : N/A
         */
        protected void modificarReservacion()
        {
            char[] turnos = new char[3];
            char valor;
            if (this.checkboxDesayuno.Checked)/*se mantuvo reservado*/
            {
                valor = (seleccionada.turnos[0] == 'R' || seleccionada.turnos[0] == 'N') ? 'R' : (seleccionada.turnos[0] == 'C') ? 'C' : 'X';
            }
            else
            {
                valor = (seleccionada.turnos[0] == 'N') ? 'N' : 'X';//Si estaba consumida, reservada o cancelada, los errores los manejaran las controladoras e informaran.
            }
            turnos[0] = valor;
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (this.checkboxAlmuerzo.Checked)/*se mantuvo reservado*/
            {
                valor = (seleccionada.turnos[1] == 'R' || seleccionada.turnos[1] == 'N') ? 'R' : (seleccionada.turnos[1] == 'C') ? 'C' : 'X';
            }
            else
            {
                valor = (seleccionada.turnos[1] == 'N') ? 'N' : 'X';//Si estaba consumida, reservada o cancelada, los errores los manejaran las controladoras e informaran.
            }
            turnos[1] = valor;
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (this.checkboxAlmuerzo.Checked)/*se mantuvo reservado*/
            {
                valor = (seleccionada.turnos[1] == 'R' || seleccionada.turnos[1] == 'N') ? 'R' : (seleccionada.turnos[1] == 'C') ? 'C' : 'X';
            }
            else
            {
                valor = (seleccionada.turnos[1] == 'N') ? 'N' : 'X';//Si estaba consumida, reservada o cancelada, los errores los manejaran las controladoras e informaran.
            }
            turnos[2] = valor;
            controladora.modificar(seleccionada, empleadoSeleccionado.Id, list, turnos, tipodePago.SelectedIndex == 1, notas.Value);
        }
        /* Requiere: N/A
         * Efectua : pide los datos a la controladora y los coloca en su posicion en la GUI.
         * Retorna : N/A
         */
        protected void consultar()
        {
            seleccionada = controladora.consultar(idComida);
            list = seleccionada.fechas;
            notas.Value = seleccionada.notas;
            this.checkboxDesayuno.Checked = (seleccionada.turnos[0] == 'R' || seleccionada.turnos[0] == 'C');
            this.checkboxDesayuno.Disabled = (seleccionada.turnos[0] == 'C');
            this.checkboxAlmuerzo.Checked = (seleccionada.turnos[1] == 'R' || seleccionada.turnos[1] == 'C');
            this.checkboxAlmuerzo.Disabled = (seleccionada.turnos[1] == 'C');
            this.checkboxCena.Checked = (seleccionada.turnos[2] == 'R' || seleccionada.turnos[2] == 'C');
            this.checkboxCena.Disabled = (seleccionada.turnos[2] == 'C');
            tipodePago.SelectedIndex = (seleccionada.pagado) ? 1 : 2;

        }
        /*
         * Requiere:N/A
         * Efectua :Pone en la etiqueta del nombre, la informacion del empleado.
         * Retrona :N/A
         */
        private void iniciarEmpleado()
        {            
            try
            {
                if (identificacionEmpleado.Length > 0)
                {
                    empleadoSeleccionado = controladora.getInformacionDelEmpleado(identificacionEmpleado);
                    lblEmpleado.InnerText = empleadoSeleccionado.Id + "-" + empleadoSeleccionado.Nombre + " " + empleadoSeleccionado.Apellido;
                }
                
            }
            catch (Exception e)
            {
                //No se selecciono un empleado.
                lblEmpleado.InnerText = "ERROR NO SE SELECCIONO NINGUN EMPLEADO";
            }
        }

    }
}