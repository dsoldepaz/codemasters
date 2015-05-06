﻿using Servicios_Reservados_2;
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

        /*
         * Efecto: llena los campos de la interfaz con los valores del servicio extra consultado.
         * Requiere: iniciar el FormComidaExtra en modo consultar.
         * Modifica: los valores de los componentes de la pantalla.
        */
        public Boolean consultarServicio()
        {
            Boolean res = true;
            //los desplegamos en cada uno de los componentes de la pantalla
            txtHora.Value = entidadConsultada.Hora;
            txtPax.Value = entidadConsultada.Pax.ToString();
            cbxTipo.Value = controladora.consultarTipo(controladora.servicioSeleccionados().IdServiciosExtras);
            txaNotas.Value = entidadConsultada.Descripcion;
            textFecha.Value = entidadConsultada.Fecha.ToString();

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
            Object[] nuevoServicio = new Object[7];// objeto en el que se almacenan los datos para enviar a encapsular.

            nuevoServicio[0] = controladora.informacionServicio().Id;//recuperamos el id de la reservación
            //en adelante se extrae la información de cada uno de los componentes de la interfaz.
            int indice = cbxTipo.SelectedIndex-1;
            nuevoServicio[1] = tipo.Rows[indice][0];
            nuevoServicio[2] = textFecha.Value;
            nuevoServicio[3] = "no";
            nuevoServicio[4] = txaNotas.Value;
            nuevoServicio[5] = txtPax.Value;
            nuevoServicio[6] = txtHora.Value;

 
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
            Object[] nuevoServicio = new Object[7];// objeto en el que se almacenan los datos para enviar a encapsular.
            nuevoServicio[0] = controladora.informacionServicio().Id;//recuperamos el id de la reservación.
            //en adelante se extrae la información de cada uno de los componentes de la interfaz.
            int indice = cbxTipo.SelectedIndex - 1;
            nuevoServicio[1] = tipo.Rows[indice][0];
            nuevoServicio[2] = textFecha.Value;
            nuevoServicio[3] = "no";
            nuevoServicio[4] = txaNotas.Value;
            nuevoServicio[5] = txtPax.Value;
            nuevoServicio[6] = txtHora.Value;


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
         * Efecto: capta el evento al presionar el botón aceptar y realiza la operación de acuerdo a la operación.
         * Requiere: presionar el botón.
         * Modifica: 
        */
        protected void clickAceptar(object sender, EventArgs e)
        {
            switch (modo)
            {
                case 1:
                    agregarServicioExtra();
                    Response.Redirect("FormServicios");
                    break;
                case 2:
                    modificarServicioExtra();
                    break;
                case 3:
                    eliminarServicioExtra();
                    break;
            }
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
                case 2:
                    consultarServicio();
                    break;
            }
          /*  if (modo == 1)
            { // se desea insertar
                txtHora.Disabled = true;
                btnEliminar.Disabled = true;
                btnAceptar.Disabled = false;
                btnCancelar.Disabled = false;
                btnAgregar.Disabled = true;
            }
            else if (modo == 2)
            { //modificar
                btnModificar.Disabled = true;
                btnEliminar.Disabled = true;
                btnAceptar.Disabled = false;
                btnCancelar.Disabled = false;
                btnAgregar.Disabled = true;
            }
            else if (modo == 3)
            { // eliminar
                btnModificar.Disabled = true;
                btnEliminar.Disabled = true;
                btnAceptar.Disabled = false;
                btnCancelar.Disabled = false;
                btnAgregar.Disabled = true;
                habilitarCampos(false);
            }
            else if (modo == 4)
            { //consultar
                btnModificar.Disabled = false;
                btnEliminar.Disabled = false;
                btnAceptar.Disabled = true;
                btnCancelar.Disabled = false;
                btnAgregar.Disabled = true;
                habilitarCampos(false);
            }*/
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
    }
}