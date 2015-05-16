using Servicios_Reservados_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;

namespace Servicios_Reservados_2
{
    public partial class FormComidaExtra : System.Web.UI.Page
    {
        static DataTable tipo;//contiene los diferentes tipos de comida extra
        static EntidadComidaExtra entidadVieja;//entidad consultada

        private static ControladoraComidaExtra controladora = new ControladoraComidaExtra();//instancia de la controladora de comida extra
        EntidadComidaExtra entidadConsultada = controladora.servicioSeleccionados();//buscamos el servicio consultado en la controladora
        private static int paxSeleccionado = controladora.paxSeleccionado();

        private static String[] idReservacion = FormReservaciones.ids;
        private static int modo;//variable para controlar el modo en el que se encuentra el sistema (modificar, consultar, agregar o eliminar)

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatos();
                //consultarServicio();
            }
        }

        /*
         * Efecto: activa las funciones necesarias para cargar los datos en la pantalla. 
         * Requiere: iniciar el FormComidaExtra.
         * Modifica: no realiza modificaciones, solo carga la pantalla.
        */
        void cargarDatos()
        {
            modo = FormServicios.modo;
            llenarComboBoxTipo();
            llenarCbxTipoPago();
            cambiarModo();
        }

        /*
         * Efecto: llena el cbxTipo con las diferentes opciones de comidas extras.
         * Requiere: iniciar el FormComidaExtra.
         * Modifica: los valores del cbxTipo.
        */
        void llenarComboBoxTipo() {
            tipo = controladora.solicitarTipo();// solicita los tipos a la controladora
            cbxTipo.Items.Clear();// limpiamos el combobox
            cbxTipo.Items.Add("Seleccionar");// agregamos seleccionar
            if (tipo.Rows.Count > 0) {// agregamos cada uno de los tipos 
                foreach (DataRow fila in tipo.Rows) {
                    cbxTipo.Items.Add(fila[1].ToString());
                }
            }
        }

        void llenarCbxTipoPago()
        {
            cbxTipoPago.Items.Clear();// limpiamos el combobox
            cbxTipoPago.Items.Add("Efectivo");
            cbxTipoPago.Items.Add("Tarjeta");
            cbxTipoPago.Items.Add("Deducción de planilla");
        }

        /*
         * Efecto: llena los campos de la interfaz con los valores del servicio extra consultado.
         * Requiere: iniciar el FormComidaExtra en modo consultar.
         * Modifica: los valores de los componentes de la pantalla.
        */
        public Boolean consultarServicio()
        {
            Boolean res = true;
            //los desplegamos en cada uno de los componentes de la pantalla
            cbxHora.Items.Clear();
            cbxHora.Value = entidadConsultada.Hora;
            txtPax.Value = entidadConsultada.Pax.ToString();
            cbxTipo.Text = controladora.consultarTipo(controladora.servicioSeleccionados().IdServiciosExtras);
            txaNotas.Value = entidadConsultada.Descripcion;
            textFecha.Value = entidadConsultada.Fecha.ToString();
            cbxTipoPago.Value = entidadConsultada.TipoPago;

            return res;
        }

        /*
         * Efecto: extrale los valores introducidos en la interfaz y los envia a la controladora para que sean insertados en la BD.
         * Requiere: que los campos estén rellenados con datos válidos (compatibles con la BD).
         * Modifica: 
        */
        protected Boolean agregarServicioExtra()
        {
            Boolean res = true;
            Object[] nuevoServicio = new Object[8];// objeto en el que se almacenan los datos para enviar a encapsular.

            nuevoServicio[0] = controladora.informacionServicio().Id;//recuperamos el id de la reservación
            //en adelante se extrae la información de cada uno de los componentes de la interfaz.
            int indice = cbxTipo.SelectedIndex-1;
            nuevoServicio[1] = tipo.Rows[indice][0];
            nuevoServicio[2] = textFecha.Value;
            nuevoServicio[3] = "no";
            nuevoServicio[4] = txaNotas.Value;
            nuevoServicio[5] = txtPax.Value;
            nuevoServicio[6] = cbxHora.Value;
            nuevoServicio[7] = cbxTipoPago.Value;

 
            String[] error = controladora.agregarServicioExtra(nuevoServicio);// se le pide a la controladora que lo inserte
            mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado
            return res;
        }

        /*
         * Efecto: extrale los valores introducidos en la interfaz y los envia a la controladora para modificarlos en la BD.
         * Requiere: que se consulte previamente una comida extra y que los campos estén rellenados con datos válidos (compatibles con la BD).
         * Modifica: 
        */
        protected Boolean modificarServicioExtra()
        {
            Boolean res = true;
            Object[] nuevoServicio = new Object[8];// objeto en el que se almacenan los datos para enviar a encapsular.
            nuevoServicio[0] = controladora.informacionServicio().Id;//recuperamos el id de la reservación.
            //en adelante se extrae la información de cada uno de los componentes de la interfaz.
            int indice = cbxTipo.SelectedIndex - 1;
            nuevoServicio[1] = tipo.Rows[indice][0];
            nuevoServicio[2] = textFecha.Value;
            nuevoServicio[3] = "no";
            nuevoServicio[4] = txaNotas.Value;
            nuevoServicio[5] = txtPax.Value;
            nuevoServicio[6] = cbxHora.Value;
            nuevoServicio[7] = cbxTipoPago.Value;

            String[] error = controladora.modificarServicioExtra(nuevoServicio, controladora.servicioSeleccionados());// se le pide a la controladora que lo inserte
            mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado
            return res;
        }

        /*
         * Efecto: solicita a la controladora que elimine el servicio con los ids consultados.
         * Requiere: que se consulte previamente una comida extra.
         * Modifica: 
        */
        protected Boolean eliminarServicioExtra()
        {
            //sacamos de la entidad consultada los ids.
            String idReservacion = entidadConsultada.IdReservacion;
            String idComidaExtra = entidadConsultada.IdServiciosExtras;

            Boolean res = true;
            String[] error = controladora.eliminarServicioExtra(idReservacion, idComidaExtra);// se le pide a la controladora que lo inserte
            mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado
            return res;
        }

        /*
         * Efecto: capta el evento al presionar el botón aceptar y realiza la operación de acuerdo al modo en el que se encuentra el sistema.
         * Requiere: presionar el botón.
         * Modifica: 
        */
        protected void clickAceptar(object sender, EventArgs e)
        {
            switch (modo)
            {
                case 1://insertar
                    agregarServicioExtra();
                    Response.Redirect("FormServicios");
                    break;
                case 2://modificar
                    modificarServicioExtra();
                    break;
                case 3://cancelar
                    eliminarServicioExtra();
                    break;
            }
        }

        /*
         * Efecto: capta el evento al presionar el botón cancelar y regresa a la pantalla de servicios.
         * Requiere: presionar el botón.
         * Modifica: 
        */
        protected void clickCancelar(object sender, EventArgs e)
        {
            Response.Redirect("FormServicios");
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
                case 0:
                    cbxHora.Disabled = true;
                    txtPax.Disabled = true;
                    txaNotas.Disabled = true;
                    textFecha.Disabled = true;
                    cbxTipo.Enabled = false;
                    cbxTipoPago.Disabled = true;
                    btnAceptar.Disabled = true;
                    fechaDeEntrada.Disabled = true;
                    consultarServicio();
                    break;
                case 1:
                    txtPax.Value = controladora.paxSeleccionado().ToString();
                    break;
                case 2:
                    consultarServicio();
                    break;
                case 3:
                    eliminarServicioExtra();
                    Response.Redirect("FormServicios");
                    break;
            }
        }

        /*
         * Efecto: mostrar en pantalla los mensajes del sistema, ya sean de error o de éxito.
         * Requiere: que se inicie el FormComidaExtra y se active alguna de las funcionalidades.
         * Modifica: 
        */
        protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje)
        {
            alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
            labelTipoAlerta.Text = alerta + " ";
            labelAlerta.Text = mensaje;
            alertAlerta.Attributes.Remove("hidden");
        }

        /*
         * Efecto: capta el evento al presionar el botón del calendario para hacerlo visible.
         * Requiere: presionar el calendario.
         * Modifica: la apariencia del calendario en pantalla. 
        */
        protected void fechaDeEntrada_ServerClick(object sender, EventArgs e)
        {
            fechaDeEntradaCalendario.Visible = !fechaDeEntradaCalendario.Visible;
        }

        /*
         * Efecto: capta el evento al presionar una fecha en el calendario y lo pasa al textFexha.
         * Requiere: presionar el calendario y una de las fechas.
         * Modifica: 
        */
        protected void fechaDeEntradaCalendario_SelectionChanged(object sender, EventArgs e)
        {
            textFecha.Value = fechaDeEntradaCalendario.SelectedDate.ToString("dd/MM/yyyy");
            fechaDeEntradaCalendario.Visible = false;
        }

        /*
         * Efecto: capta el evento al seleccionar uno de los tipos de comida y filtra las horas.
         * Requiere: presionar el cbxTipo.
         * Modifica: el estado del cbxHora.
        */
        protected void clickAdaptarHora(object sender, EventArgs e)
        {
            int inicio = 0;
            int fin = 0;
            if (cbxTipo.Text == "Desayuno")
            {
                inicio = 6;
                fin = 9;
            }
            if (cbxTipo.Text == "Almuerzo")
            {
                inicio = 11;
                fin = 14;
            }
            if (cbxTipo.Text == "Cena")
            {
                inicio = 18;
                fin = 21;
            }
            if (cbxTipo.Text == "Cafe" || cbxTipo.Text == "Queque")
            {
                inicio = 9;
                fin = 21;
            }

            cbxHora.Items.Clear();// limpiamos el combobox
            cbxHora.Items.Add("Seleccionar");// agregamos seleccionar
            for (int i = inicio; i <= fin; ++i)
            {
                String horas = i.ToString() + ":00";
                cbxHora.Items.Add(horas);
            }
        }
    }
}