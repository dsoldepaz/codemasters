using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Servicios_Reservados_2
{
    public partial class FormComidaCampo : System.Web.UI.Page
    {
        private static ControladoraComidaCampo controladora = new ControladoraComidaCampo();
        EntidadComidaCampo entidadConsultada = controladora.entidadSeleccionada();
        EntidadReservaciones reservacionConsultada = controladora.reservConsultada();
        public static int modo;
        public static int tipoComidaCampo;
        public static String idEmpleado;
        public static String idReservacion;
        public static int opcion;

        protected void Page_Load(object sender, EventArgs e)
        {

            ArrayList listaRoles = (ArrayList)Session["Roles"];
            string userid = (string)Session["username"];
            if (!IsPostBack)
            {
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                } if (!listaRoles.Contains("administrador sistema") && !listaRoles.Contains("recepcion"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
                llenarInfoServicio();
                cambiarModo();
            }
        }


        /*
     * Efecto: rellena los campos de la interfaz con la información de la reservaciòn seleccionada
     * Requiere: saber a cúal tipo se esta utilizando, de una reservación o de un empleado
     * Modifica: los campos en la interfaz.
    */
        void llenarInfoServicio() {
            
            if(tipoComidaCampo==0){//reservacion
                EntidadReservaciones res= controladora.infoServicioRes();
                txtSolicitante.Value = res.Solicitante;
                txtNumReservacion.Value = res.Numero;
                txtIdSolicitante.Text = "Número Reservación";
                txtFechaInicio.Value = res.FechaInicio.ToString("MM/dd/yyyy");
                textFechaFinal.Value = res.FechaSalida.ToString("MM/dd/yyyy");
                txtSolicitante.Disabled = true;
                txtNumReservacion.Disabled = true;
                infoReservacion.Visible = true;
            }
            else
            {
                EntidadEmpleado emp = controladora.infoServicioEmp();
                txtSolicitante.Value = emp.Nombre + " " + emp.Apellido;
                txtNumReservacion.Value = emp.Id;
                txtIdSolicitante.Text = "Carné de empleado:";
                txtSolicitante.Disabled = true;
                infoReservacion.Visible = false;

            }
            

        }


        /*
     * Efecto: se utiliza para manejar los campos que se habilitan o deshabilitan de acuerdo al botón presionado.
     * Requiere: La opción del botón seleccionado.
     * Modifica: los campos y botones de la interfaz. 
    */
        protected void cambiarModo()
        {
            txtPax.Value = "1";
            if (tipoComidaCampo == 0)
            {
                cmbTipoPago.Visible = false;
                labelPago.Visible = false;
                txtPax.Value = controladora.paxReserv(reservacionConsultada.Numero);
            }

            if (modo == 1)//insertar
            {
                DateTime fechIni = DateTime.Parse(reservacionConsultada.FechaInicio.ToString());
                if (fechIni <= DateTime.Today)
                {
                    fechIni = DateTime.Today;
                }
                fechaDeEntradaCalendario.SelectedDate = fechIni;
                textFecha.Value = fechIni.ToString("MM/dd/yyyy");
                radioDesayuno.Enabled = false;
                radioAlmuerzo.Enabled = false;
                radioCena.Enabled = false;
                textFecha.Disabled = true;
                txtPax.Disabled = false;
                radioPanBlanco.Disabled = true;
                radioPanBollo.Disabled = true;
                radioPanInt.Disabled = true;
                radioJamon.Disabled = true;
                radioFrijoles.Disabled = true;
                radioMyM.Disabled = true;
                radioOmelette.Disabled = true;
                radioAtun.Disabled = true;
                radioEnsaladaHuevo.Disabled = true;
                chEnsalada.Disabled = false;
                chMayonesa.Disabled = false;
                chConfites.Disabled = false;
                chFrutas.Disabled = false;
                chSalsaTomate.Disabled = false;
                chHuevoDuro.Disabled = false;
                chGalletas.Disabled = false;
                chPlatanos.Disabled = false;
                radioAgua.Disabled = true;
                radioJugo.Disabled = true;
                CheckboxBebida.Enabled = true;
                checkO2.Enabled = true;
                checkO3.Enabled = true;
                checkO1.Enabled = true;
                cmbHoraSandwich.Disabled = true;
                cmbHoraGalloPinto.Disabled = true;
                cbxHoraOpcion1.Disabled = true;
                btnAnular.Disabled = true;
                btnEditar.Disabled = true;
                btnAnular.Visible = false;
                btnEditar.Visible = false;
            }
            else if (modo == 2)
            { //modificar
                fechaDeEntradaCalendario.SelectedDate = DateTime.Parse(entidadConsultada.Fecha);
                radioDesayuno.Enabled = false;
                radioAlmuerzo.Enabled = false;
                radioCena.Enabled = false;
                textFecha.Disabled = false;
                radioPanBlanco.Disabled = true;
                radioPanBollo.Disabled = true;
                radioPanInt.Disabled = true;
                radioJamon.Disabled = true;
                radioFrijoles.Disabled = true;
                radioMyM.Disabled = true;
                radioOmelette.Disabled = true;
                radioEnsaladaHuevo.Disabled = true;
                radioAtun.Disabled = true;
                radioAgua.Disabled = true;
                radioJugo.Disabled = true;
                CheckboxBebida.Enabled = true;
                checkO2.Enabled = true;
                checkO1.Enabled = true;
                checkO3.Enabled = true;
                cmbHoraSandwich.Disabled = true;
                cmbHoraGalloPinto.Disabled = true;
                cmbHoraSandwich.Disabled = true;
                cmbHoraGalloPinto.Disabled = true;
                cbxHoraOpcion1.Disabled = true;
                consultarComidaCampo();
                btnAgregar.Disabled = false;
                btnAnular.Disabled = false;
                btnEditar.Disabled = true;
                btnAnular.Visible = true;
                btnEditar.Visible = true;
            }
            else if (modo == 4)
            {  //consultar
                fechaDeEntrada.Disabled = true;
                consultarComidaCampo();
                radioDesayuno.Enabled = false;
                radioAlmuerzo.Enabled = false;
                radioCena.Enabled = false;
                textFecha.Disabled = true;
                cbxHoraOpcion1.Disabled = true;
                txtPax.Disabled = true;
                radioPanBlanco.Disabled = true;
                radioPanBollo.Disabled = true;
                radioPanInt.Disabled = true;
                radioJamon.Disabled = true;
                radioFrijoles.Disabled = true;
                radioMyM.Disabled = true;
                radioOmelette.Disabled = true;
                radioEnsaladaHuevo.Disabled = true;
                radioAtun.Disabled = true;
                chEnsalada.Disabled = true;
                chHuevoDuro.Disabled = true;
                chMayonesa.Disabled = true;
                chPlatanos.Disabled = true;
                chSalsaTomate.Disabled = true;
                chFrutas.Disabled = true;
                chGalletas.Disabled = true;
                chConfites.Disabled = true;
                radioAgua.Disabled = true;
                radioJugo.Disabled = true;
                checkO2.Enabled = false;
                btnAgregar.Disabled = true;
                checkO1.Enabled = false;
                checkO3.Enabled = false;
                CheckboxBebida.Enabled = false;
                cmbHoraSandwich.Disabled = true;
                cmbHoraGalloPinto.Disabled = true;
                cbxHoraOpcion1.Disabled = true;
                cmbTipoPago.Disabled = true;
                btnAnular.Disabled = false;
                btnEditar.Disabled = false;
                btnAnular.Visible = true;
                btnEditar.Visible = true;
            }
        }


        /*
     * Efecto: se encarga de deshabilitar los campos en la interfaz de acuerdo a la opción selecionada.
     * Requiere: la opción seleccionada.
     * Modifica: los campos en la interfaz. 
    */
        protected void limpiarCamposOpcion2()
        {
            limpiarComidas();
            radioDesayuno.Checked = false;
            radioAlmuerzo.Checked = false;
            radioCena.Checked = false;
            cbxHoraOpcion1.Items.Clear();
            cmbHoraSandwich.Items.Clear();
            cmbHoraGalloPinto.Items.Clear();
            
        }

           /*
     * Efecto: se encarga de deshabilitar los campos en la interfaz de acuerdo a la opción selecionada.
     * Requiere: la opción seleccionada.
     * Modifica: los campos en la interfaz. 
    */
        protected void limpiarCamposOpcion1(){

            limpiarComidas();
            radioPanBlanco.Checked = false;
            radioPanBollo.Checked = false;
            radioPanInt.Checked = false;
            radioJamon.Checked = false;
            radioFrijoles.Checked = false;
            radioMyM.Checked = false;
            radioAtun.Checked = false;
            radioOmelette.Checked = false;
            radioEnsaladaHuevo.Checked = false;
            cmbHoraSandwich.Items.Clear();
            cmbHoraGalloPinto.Items.Clear();
        }

               /*
     * Efecto: se encarga de deshabilitar los campos en la interfaz de acuerdo a la opción selecionada.
     * Requiere: la opción seleccionada.
     * Modifica: los campos en la interfaz. 
    */
        protected void limpiarCamposOpcion3()
        {
            limpiarComidas();
            radioDesayuno.Checked = false;
            radioAlmuerzo.Checked = false;
            radioAlmuerzo.Checked = false;
            radioPanBlanco.Checked = false;
            radioPanBollo.Checked = false;
            radioPanInt.Checked = false;
            radioJamon.Checked = false;
            radioAtun.Checked = false;
            radioFrijoles.Checked = false;
            radioMyM.Checked = false;
            radioOmelette.Checked = false;
            radioEnsaladaHuevo.Checked = false;
            cmbHoraSandwich.Items.Clear();
            cbxHoraOpcion1.Items.Clear();
        }

           /*
     * Efecto: se encarga de deshabilitar los campos en la interfaz de acuerdo a la opción selecionada.
     * Requiere: la opción seleccionada.
     * Modifica: los campos en la interfaz. 
    */
        protected void limpiarComidas()
        {
            radioDesayuno.Enabled = false;
            radioAlmuerzo.Enabled = false;
            radioCena.Enabled = false;
            radioPanBlanco.Disabled = true;
            radioPanBollo.Disabled = true;
            radioPanInt.Disabled = true;
            radioJamon.Disabled = true;
            radioFrijoles.Disabled = true;
            radioMyM.Disabled = true;
            radioOmelette.Disabled = true;
            radioEnsaladaHuevo.Disabled = true;
            radioAtun.Disabled = true;
            CheckboxBebida.Enabled = true;
            checkO2.Enabled = true;
            checkO1.Enabled = true;
            checkO3.Enabled = true;
            cmbHoraSandwich.Disabled = true;
            cmbHoraGalloPinto.Disabled = true;
            cmbHoraSandwich.Disabled = true;
            cmbHoraGalloPinto.Disabled = true;
            cbxHoraOpcion1.Disabled = true;
        }

           /*
     * Efecto: se encarga de llenar el combo box de hora de acuerdo a la opción seleccionada.
     * Requiere: la opción seleccionada.
     * Modifica: el combo box de hora. 
    */
        protected void llenarHora()
        {
            int inicio = 6;
            int fin = 21;
            for (int i = inicio; i <= fin; i++)
            {
                String horas = i.ToString() + ":00";
                cmbHoraSandwich.Items.Add(horas);
            }  
        }

             /*
     * Efecto: se encarga de llenar el combo box de hora de acuerdo a la opción seleccionada.
     * Requiere: la opción seleccionada.
     * Modifica: el combo box de hora. 
    */
        protected void llenarHoraOpcion3() {
            int inicio = 6;
            int fin = 21;
            for (int i = inicio; i <= fin; i++)
            {
                String horas = i.ToString() + ":00";
                cmbHoraGalloPinto.Items.Add(horas);
            }  
        
        }

             /*
     * Efecto: se encarga de llenar el combo box de hora de acuerdo a la opción seleccionada.
     * Requiere: la opción seleccionada.
     * Modifica: el combo box de hora. 
    */
        protected void cambiarFechaD(object sender, EventArgs e)
        {
            cbxHoraOpcion1.Items.Clear();
            int inicio=6;
            int fin = 8;
            for (int i = inicio; i <= fin; i++) { 
                String horas=i.ToString()+ ":00";
                cbxHoraOpcion1.Items.Add(horas);
            }       
        }

             /*
     * Efecto: se encarga de llenar el combo box de hora de acuerdo a la opción seleccionada.
     * Requiere: la opción seleccionada.
     * Modifica: el combo box de hora. 
    */
        protected void cambiarFechaA(object sender, EventArgs e)
        {
            cbxHoraOpcion1.Items.Clear();
            int inicio = 11;
            int fin = 14;
            for (int i = inicio; i <= fin; i++)
            {
                String horas = i.ToString() + ":00";
                cbxHoraOpcion1.Items.Add(horas);
            }       
        }

     /*
     * Efecto: se encarga de llenar el combo box de hora de acuerdo a la opción seleccionada.
     * Requiere: la opción seleccionada.
     * Modifica: el combo box de hora. 
    */
        protected void cambiarFechaC(object sender, EventArgs e)
        {
            cbxHoraOpcion1.Items.Clear();
            int inicio = 18;
            int fin = 20;
            for (int i = inicio; i <= fin; i++)
            {
                String horas = i.ToString() + ":00";
                cbxHoraOpcion1.Items.Add(horas);
            }  
        }

      /*
     * Efecto: se habilitan y deshabilitan campos dependiendo de la opción a agregar
     * Requiere: la opción a seleccionar.
     * Modifica: los campos a habilitar/deshabilitar en la interfaz 
    */
        protected void checkedO1(object sender, EventArgs e)
        {
            limpiarCamposOpcion1();
            if (checkO2.Checked)
            {
                checkO2.Checked = false;
            }
            if (checkO3.Checked)
            {
                checkO3.Checked = false;
            }
            if (checkO1.Checked)
            {
                radioDesayuno.Checked = true;
                radioDesayuno.Enabled = true;
                radioAlmuerzo.Enabled = true;
                radioCena.Enabled = true;
                cbxHoraOpcion1.Disabled = false;
                cbxHoraOpcion1.Items.Clear();
                int inicio = 6;
                int fin = 8;
                for (int i = inicio; i <= fin; i++)
                {
                    String horas = i.ToString() + ":00";
                    cbxHoraOpcion1.Items.Add(horas);
                }       
            }
            else
            {
                limpiarCamposOpcion3();
                limpiarCamposOpcion1();
                limpiarCamposOpcion2();
            }
            
        }

        /*
    * Efecto: se habilitan y deshabilitan campos dependiendo de la opción a agregar
    * Requiere: la opción a seleccionar.
    * Modifica: los campos a habilitar/deshabilitar en la interfaz 
   */
        protected void checkbebida(object sender, EventArgs e)
        {
            if (CheckboxBebida.Checked)
            {
                radioAgua.Checked = true;
                radioAgua.Disabled = false;
                radioJugo.Disabled = false;
            }
            else
            {
                radioAgua.Checked = false;
                radioJugo.Checked = false;
                radioAgua.Disabled = true;
                radioJugo.Disabled = true;
            }
        }

     /*
    * Efecto: se habilitan y deshabilitan campos dependiendo de la opción a agregar
    * Requiere: la opción a seleccionar.
    * Modifica: los campos a habilitar/deshabilitar en la interfaz 
   */
        protected void checkedO3(object sender, EventArgs e)
        {
            limpiarCamposOpcion3();
            llenarHoraOpcion3();
            if (checkO2.Checked)
            {
                checkO2.Checked = false;
            }
            if (checkO1.Checked)
            {
                checkO1.Checked = false;
            }
            if (checkO3.Checked)
            {//chGalloPinto.Disabled = false;
                cmbHoraGalloPinto.Disabled = false;
            }
            else
            {
                limpiarCamposOpcion3();
                limpiarCamposOpcion1();
                limpiarCamposOpcion2();
            
            }
        }

      /*
    * Efecto: se habilitan y deshabilitan campos dependiendo de la opción a agregar
    * Requiere: la opción a seleccionar.
    * Modifica: los campos a habilitar/deshabilitar en la interfaz 
   */
        protected void checkedO2(object sender, EventArgs e)
        {
            limpiarCamposOpcion2();
            llenarHora();
            if (checkO1.Checked)
            {
                checkO1.Checked = false;
            }
            else if (checkO3.Checked)
            {
                checkO3.Checked = false;
            }
            if (checkO2.Checked)
            {
                radioPanBlanco.Checked = true;
                radioJamon.Checked = true;
                radioPanBlanco.Disabled = false;
                radioPanBollo.Disabled = false;
                radioPanInt.Disabled = false;
                radioJamon.Disabled = false;
                radioFrijoles.Disabled = false;
                radioMyM.Disabled = false;
                radioAtun.Disabled = false;
                radioOmelette.Disabled = false;
                radioEnsaladaHuevo.Disabled = false;
                cmbHoraSandwich.Disabled = false;
            }
            else
            {
                limpiarCamposOpcion3();
                limpiarCamposOpcion1();
                limpiarCamposOpcion2();

            }
        }


           /*
    * Efecto: Seleeciona el tipo de pan.
    * Requiere: la opción de pan.
    * Modifica: el string con el valor del pan seleccionado. 
   */
        protected String getPan()
        {
            String pan = "";
            if (radioPanBlanco.Checked)
            {
                pan = "Pan Blanco";
            }
            if (radioPanBollo.Checked)
            {
                pan = "Pan Bollo";
            }
            if (radioPanInt.Checked)
            {
                pan = "Pan Integral";
            }
            return pan;

        }

     /*
    * Efecto: retorna el tipo de sandwich seleccionado.
    * Requiere: la opción de sandwich.
    * Modifica: el string de tipo.
   */
        protected String getTipoSandwich()
        {
            String tipo = "";
            if (radioJamon.Checked)
            {
                tipo = "Jamon";
            }
            if (radioFrijoles.Checked)
            {
                tipo = "Frijoles";
            }

            if (radioAtun.Checked)
            {
                tipo = "Atun";
            }
            if (radioMyM.Checked)
            {
                tipo = "Mantequilla de maní y jalea";
            }
            if (radioOmelette.Checked)
            {
                tipo = "Omelette";
            }
            if (radioEnsaladaHuevo.Checked)
            {
                tipo = "Ensalada de Huevo";
            }
            return tipo;
        }


        /*
       * Efecto: retorna la lista con todos los adiccionales seleccionados.
       * Requiere: las opciones .
       * Modifica: la lista con de adicionales.
      */
        protected List<String> listaAdicionales()
        {
            List<String> lista = new List<String>();
            if (chEnsalada.Checked)
            {
                lista.Add("Ensalada");
            }
            if (chMayonesa.Checked)
            {
                lista.Add("Mayonesa");
            }
            if (chConfites.Checked)
            {
                lista.Add("Confites");
            }
            if (chFrutas.Checked)
            {
                lista.Add("Frutas");
            }
            if (chSalsaTomate.Checked)
            {
                lista.Add("Salsa de tomate");
            }
            if (chHuevoDuro.Checked)
            {
                lista.Add("Huevos duros");
            }
            if (chGalletas.Checked)
            {
                lista.Add("Galletas");
            }
            if (chPlatanos.Checked)
            {
                lista.Add("Platanos");
            }
            return lista;
        }


        /*
       * Efecto: se encarga de verificar las fechas de la reservación a insertar.
       * Requiere: las fechas seleccionadas.
       * Modifica: la variable booleana correcta.
      */
        protected Boolean revisarFechas()
        {
            
            DateTime fechaSeleccionada = fechaDeEntradaCalendario.SelectedDate;
            if (checkO1.Checked)
            {
                fechaSeleccionada = fechaSeleccionada.AddHours(int.Parse(cbxHoraOpcion1.Value.ToString().Split(':')[0]));
            }
            else if (checkO2.Checked)
            {
                fechaSeleccionada = fechaSeleccionada.AddHours(int.Parse(cmbHoraSandwich.Value.ToString().Split(':')[0]));
            }
            else if (checkO3.Checked)
            {
                fechaSeleccionada = fechaSeleccionada.AddHours(int.Parse(cmbHoraGalloPinto.Value.ToString().Split(':')[0]));
            }

            DateTime fechaHoy = DateTime.Now;
            Boolean correcta = true;
            if (tipoComidaCampo == 0)
            {
                DateTime fechaInicio = reservacionConsultada.FechaInicio;
                fechaInicio = fechaInicio.AddHours(6);
                DateTime fechaFinal = reservacionConsultada.FechaSalida;
                fechaFinal = fechaFinal.AddHours(23);
                if (fechaSeleccionada < fechaInicio || fechaSeleccionada > fechaFinal || fechaSeleccionada < fechaHoy)
                {
                    mostrarMensaje("danger", "Error:", "Revise la fecha y hora seleccionadas, debe estar dentro de la reservación y a futuro");
                      correcta = false;
                }
            }
            else
            {
                if(fechaSeleccionada < fechaHoy){
                    mostrarMensaje("danger", "Error:", "Revise la fecha y hora seleccionadas, debe estar dentro de la reservación y a futuro");
                    correcta = false;
                }
            }

            return correcta;
        }

        /*
       * Efecto: se utiliza para insertar la comida de campo deseada. 
       * Requiere: seleccionar las opciones del tipo de comida de campo.
       * Modifica: insertar la comida a la base de datos.
      */
        protected Boolean agregarComidaCampo()
        {
            Boolean res = true;
         
            if (!revisarFechas())
            {
                res = false;
            }
            else
            {
                Object[] nuevaComidaCampo = new Object[13];// objeto en el que se almacenan los datos para enviar a encapsular.
                List<String> lista = listaAdicionales();
                
                nuevaComidaCampo[0] = "";
                if (tipoComidaCampo == 0)
                {
                    nuevaComidaCampo[1] = "";
                    nuevaComidaCampo[2] = idReservacion;
                }
                else
                {
                    nuevaComidaCampo[1] = idEmpleado;
                    nuevaComidaCampo[2] = "";
                }


                nuevaComidaCampo[3] = textFecha.Value; 
                nuevaComidaCampo[4] = "Activo";
                nuevaComidaCampo[5] = 0;

                if (checkO1.Checked)
                {
                    if (radioDesayuno.Checked)
                    {
                        nuevaComidaCampo[5] = "1";
                        nuevaComidaCampo[11] = cbxHoraOpcion1.Value;
                    }
                    else if (radioAlmuerzo.Checked)
                    {
                        nuevaComidaCampo[5] = "2";
                        nuevaComidaCampo[11] = cbxHoraOpcion1.Value;
                    }
                    else if (radioCena.Checked)
                    {
                        nuevaComidaCampo[5] = "3";
                        nuevaComidaCampo[11] = cbxHoraOpcion1.Value;
                    }
                    nuevaComidaCampo[6] = "";
                    nuevaComidaCampo[7] = "";
                    nuevaComidaCampo[8] = "";
                    nuevaComidaCampo[9] = "";
                }
                else if (checkO2.Checked)
                {  //sandwich
                    nuevaComidaCampo[5] = "4";
                    nuevaComidaCampo[6] = getTipoSandwich();
                    nuevaComidaCampo[7] = getPan();
                    nuevaComidaCampo[11] = cmbHoraSandwich.Value;
                }
                else if (checkO3.Checked)
                {
                    //galloPinto
                    nuevaComidaCampo[5] = "5";
                    nuevaComidaCampo[6] = "";
                    nuevaComidaCampo[7] = "";
                    nuevaComidaCampo[11] = cmbHoraGalloPinto.Value;
                }
                else {
                    res = false;
                }
                
                nuevaComidaCampo[8] = "";
                if (CheckboxBebida.Checked)
                {
                    String bebida = "Jugo";
                    if (radioAgua.Checked)
                    {
                        bebida = "Agua";
                    }
                    nuevaComidaCampo[8] = bebida;
                }

                if (tipoComidaCampo == 0)
                {
                    nuevaComidaCampo[9] = "";
                }
                else
                {
                    nuevaComidaCampo[9] = cmbTipoPago.Value.ToString();
                }
                nuevaComidaCampo[10] = txtPax.Value;

                if (tipoComidaCampo == 0)
                {
                    nuevaComidaCampo[12] = reservacionConsultada.Estacion;
                }
                else
                {
                    nuevaComidaCampo[12] = (string)Session["Estacion"];
                }

                if ((checkO1.Checked && (radioDesayuno.Checked || radioAlmuerzo.Checked || radioCena.Checked)) || (checkO2.Checked && getTipoSandwich()!= "" && getPan() != "") || checkO3.Checked)
                {
                    String[] error = controladora.agregarComidaCampo(nuevaComidaCampo, lista);// se le pide a la controladora que lo inserte
                    mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado
                }
                else
                {
                    mostrarMensaje("danger", "Error:", "Debe seleccionar una opción");
                    res = false;
                }
            }
            return res;
        }


        /*
       * Efecto: se utiliza para modificar una comida de campo deseada. 
       * Requiere: seleccionar las opciones del tipo de comida de campo.
       * Modifica: insertar la comida a la base de datos.
      */
        protected Boolean modificarComidaCampo()
        {
            Boolean res = true;
            
            if (!revisarFechas())
            {
                res = false;
            }
            else
            {
                Object[] comidaModificar = new Object[13];// objeto en el que se almacenan los datos para enviar a encapsular.
                List<String> lista = listaAdicionales();
                comidaModificar[0] = "";
                if (tipoComidaCampo == 0)
                {
                    comidaModificar[1] = "";
                    comidaModificar[2] = idReservacion;
                }
                else
                {
                    comidaModificar[1] = idEmpleado;
                    comidaModificar[2] = "";
                }
                comidaModificar[3] = textFecha.Value;
                comidaModificar[4] = "Activo";
                comidaModificar[5] = 0;

                if (checkO1.Checked)
                {
                    if (radioDesayuno.Checked)
                    {
                        comidaModificar[5] = "1";
                        comidaModificar[11] = cbxHoraOpcion1.Value;
                    }
                    else if (radioAlmuerzo.Checked)
                    {
                        comidaModificar[5] = "2";
                        comidaModificar[11] = cbxHoraOpcion1.Value;
                    }
                    else if (radioCena.Checked)
                    {
                        comidaModificar[5] = "3";
                        comidaModificar[11] = cbxHoraOpcion1.Value;
                    }
                    comidaModificar[6] = "";
                    comidaModificar[7] = "";
                    comidaModificar[8] = "";
                    comidaModificar[9] = "";
                }
                else if (checkO2.Checked)
                {  //sandwich
                    comidaModificar[5] = "4";
                    comidaModificar[6] = getTipoSandwich();
                    comidaModificar[7] = getPan();
                    comidaModificar[11] = cmbHoraSandwich.Value;
                }
                else if (checkO3.Checked)
                {
                    comidaModificar[5] = "5";
                    comidaModificar[6] = "";
                    comidaModificar[7] = "";
                    comidaModificar[11] = cmbHoraGalloPinto.Value;
                }
                else
                {
                    res = false;
                }
                comidaModificar[8] = "";
                if (CheckboxBebida.Checked)
                {
                    String bebida = "Jugo";
                    if (radioAgua.Checked)
                    {
                        bebida = "Agua";
                    }
                    comidaModificar[8] = bebida;
                }
                if (tipoComidaCampo == 0)
                {
                    comidaModificar[9] = "";
                }
                else
                {
                    comidaModificar[9] = cmbTipoPago.Value.ToString(); ;
                }
                comidaModificar[10] = txtPax.Value;

                if (tipoComidaCampo == 0)
                {
                    comidaModificar[12] = reservacionConsultada.Estacion;
                }
                else
                {
                    comidaModificar[12] = (string)Session["Estacion"];
                }

                if ((checkO1.Checked && (radioDesayuno.Checked || radioAlmuerzo.Checked || radioCena.Checked)) || (checkO2.Checked && getTipoSandwich() != "" && getPan() != "") || checkO3.Checked)
                {
                    String[] error = controladora.modificarComidaCampo(comidaModificar, lista, entidadConsultada);// se le pide a la controladora que lo inserte
                    mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado
                }
                else
                {
                    mostrarMensaje("danger", "Error:", "Debe seleccionar una opción");
                }
               
            }
            return res;
        }


        /*
      * Efecto: despliga el mensaje de error.
      * Requiere: 
      * Modifica: el atributo de la alerta desplegado.
     */
        protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje)
        {
            alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
            labelTipoAlerta.Text = alerta + " ";
            labelAlerta.Text = mensaje;
            alertAlerta.Attributes.Remove("hidden");
            this.SetFocus(alertAlerta);
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

        protected void clickAceptar(object sender, EventArgs e)
        {
            switch (modo)
            {
                case 1://insertar
                    if (tipoComidaCampo == 1) //agregar la comida dependiendo si es para un empleado o una reservacion.
                    {
                        bool accion = agregarComidaCampo();
                        //FormEmpleadoReserva.idEmpleado = idEmpleado;
                        if (accion)
                        {
                        Response.Redirect("FormEmpleadoReserva");
                        }
                    }
                    else
                    {
                        bool accion = agregarComidaCampo();
                        if (accion)
                        {
                            Response.Redirect("FormServicios");
                        }
                    }

                    break;
                case 2://modificar
                    if (tipoComidaCampo == 1) //agregar la comida dependiendo si es para un empleado o una reservacion.
                    {
                        FormEmpleadoReserva.idEmpleado = idEmpleado;
                        bool accion = modificarComidaCampo();
                        if (accion)
                        {
                            Response.Redirect("FormEmpleadoReserva");
                        }

                    }
                    else
                    {
                        bool accion = modificarComidaCampo();
                        if (accion)
                        {
                            Response.Redirect("FormServicios");
                        }

                    }

                    break;
                case 3://cancelar

                    break;
            }
        }

        /*
      * Efecto: cancela una comida de campo, no la elimina de la base de datos. 
      * Requiere: la comida de campo a cancelar.
      * Modifica: la grid de servicios.
     */
        protected void clickCancelar(object sender, EventArgs e)
        {
            switch (tipoComidaCampo)
            {
                case 0: //cancelar reserv
                    Response.Redirect("FormServicios");
                    break;
                case 1://cancelar empleado
                    Response.Redirect("FormEmpleadoReserva");
                    break;
            }

        }
        protected void fechaDeEntradaCalendario_SelectionChanged(object sender, EventArgs e)
        {
            textFecha.Value = fechaDeEntradaCalendario.SelectedDate.ToString("MM/dd/yyyy");
            fechaDeEntradaCalendario.Visible = false;
        }


      /*
      * Efecto: se consulta una comida seleccionada.
      * Requiere: la comida de campo seleccionada.
      * Modifica: n/a
     */
        protected void consultarComidaCampo()
        {

            textFecha.Value = entidadConsultada.Fecha;
            txtPax.Value = entidadConsultada.Pax.ToString();
            if (tipoComidaCampo == 1)
            {
                cmbTipoPago.Value = entidadConsultada.TipoPago;
            }
            if (entidadConsultada.Opcion == 1)
            {
                checkO1.Checked = true;
                radioDesayuno.Checked = true;
                cbxHoraOpcion1.Items.Add(entidadConsultada.Hora);
               
            }
            if (entidadConsultada.Opcion == 2)
            {
                checkO1.Checked = true;
                radioAlmuerzo.Checked = true;
                cbxHoraOpcion1.Items.Add(entidadConsultada.Hora);
            }
            if (entidadConsultada.Opcion == 3)
            {
                checkO1.Checked = true;
                radioCena.Checked = true;
                cbxHoraOpcion1.Items.Add(entidadConsultada.Hora);
            }
            if (entidadConsultada.Opcion == 4)
            {
                checkO2.Checked = true;
                tipoSandwich();
                cmbHoraSandwich.Items.Add(entidadConsultada.Hora);
            }
            else if (entidadConsultada.Opcion == 5)
            {
                checkO3.Checked = true;
                //chGalloPinto.Checked = true;
                cmbHoraGalloPinto.Items.Add(entidadConsultada.Hora);
            }

            if (entidadConsultada.Adicionales != null)
            {
                consultarAdicionales();
            }
            if (entidadConsultada.Bebida != null)
            {
                if (entidadConsultada.Bebida == "Jugo")
                {
                    CheckboxBebida.Checked = true;
                    radioJugo.Checked = true;
                }
                else if (entidadConsultada.Bebida == "Agua")
                {
                    CheckboxBebida.Checked = true;
                    radioAgua.Checked = true;
                }
            }
            if (modo == 2)
            {
                if(checkO1.Checked){
                    radioDesayuno.Enabled = true;
                    radioAlmuerzo.Enabled = true;
                    radioCena.Enabled = true;
                }
                else if(checkO2.Checked){
                     radioPanBlanco.Disabled = false;
                     radioPanBollo.Disabled = false;
                     radioPanInt.Disabled = false;
                     radioJamon.Disabled = false;
                     radioFrijoles.Disabled = false;
                     radioMyM.Disabled = false;
                     radioOmelette.Disabled = false;
                     radioEnsaladaHuevo.Disabled = false;
                }
               /* else if(checkO3.Checked){
                    chGalloPinto.Disabled = false;
                }*/
                if(CheckboxBebida.Checked){
                    radioAgua.Disabled = false;
                    radioJugo.Disabled = false;
                }
            }
        }

       /*
      * Efecto: se consulta el tipo de sandwich seleccionado
      * Requiere: la información del tipo de sandwich seleccionado.
      * Modifica: n/a
     */
        protected void tipoSandwich()
        {
            if (entidadConsultada.Pan == "Pan Blanco")
            {
                radioPanBlanco.Checked = true;
            }
            else if (entidadConsultada.Pan == "Pan Bollo")
            {
                radioPanBollo.Checked = true;
            }
            else if (entidadConsultada.Pan == "Pan Integral")
            {
                radioPanInt.Checked = true;
            }
            if (entidadConsultada.Relleno == "Jamon")
            {
                radioJamon.Checked = true;
            }
            else if (entidadConsultada.Relleno == "Atun")
            {
                radioAtun.Checked = true;
            }
            else if (entidadConsultada.Relleno == "Frijoles")
            {
                radioFrijoles.Checked = true;
            }
            else if (entidadConsultada.Relleno == "Mantequilla de maní y jalea")
            {
                radioMyM.Checked = true;
            }
            else if (entidadConsultada.Relleno == "Omelette")
            {
                radioOmelette.Checked = true;
            }
            else if (entidadConsultada.Relleno == "Ensalda de huevo")
            {
                radioEnsaladaHuevo.Checked = true;
            }
        }


        /*
     * Efecto: se consultan los adicionales de una comida seleccionada.
     * Requiere: la información de la comida selecionada
     * Modifica: n/a
    */
        protected void consultarAdicionales()
        {
            if (entidadConsultada.Adicionales.Contains("Ensalada"))
            {
                chEnsalada.Checked = true;
            }
            if (entidadConsultada.Adicionales.Contains("Mayonesa"))
            {
                chMayonesa.Checked = true;
            }
            if (entidadConsultada.Adicionales.Contains("Confites"))
            {
                chConfites.Checked = true;
            }
            if (entidadConsultada.Adicionales.Contains("Frutas"))
            {
                chFrutas.Checked = true;
            }
            if (entidadConsultada.Adicionales.Contains("Salsa de tomate"))
            {
                chSalsaTomate.Checked = true;
            }
            if (entidadConsultada.Adicionales.Contains("Huevos duros"))
            {
                chHuevoDuro.Checked = true;
            }
            if (entidadConsultada.Adicionales.Contains("Galletas"))
            {
                chGalletas.Checked = true;
            }
            if (entidadConsultada.Adicionales.Contains("Platanos"))
            {
                chPlatanos.Checked = true;
            }
        }

        /*
     * Efecto: se encarga de habilitar campo para modificar una comida de campo
     * Requiere: n/a
     * Modifica: el modo.
    */
        protected void clickModificar(object sender, EventArgs e)
        {
            modo = 2;
            cambiarModo();
            btnAgregar.Disabled = false;
        }
        protected void clickAnular(object sender, EventArgs e)
        {

        }



    }
}