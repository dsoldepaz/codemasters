using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicios_Reservados_2
{
    public partial class FormComidaCampo : System.Web.UI.Page
    {
        private static ControladoraComidaCampo controladora = new ControladoraComidaCampo();
        EntidadComidaCampo entidadConsultada = controladora.entidadSeleccionada();

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
                } if (!listaRoles.Contains("admin") && !listaRoles.Contains("recepcion"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
                cambiarModo();
            }
        }

        protected void cambiarModo()
        {

            if (tipoComidaCampo == 0)
            {
                cmbTipoPago.Visible = false;
                labelPago.Visible = false;
            }

            if (modo == 1)
            {
                textFecha.Disabled = true;
                txtHora.Disabled = true;
                txtPax.Disabled = true;
                radioPanBlanco.Disabled = true;
                radioPanBollo.Disabled = true;
                radioPanInt.Disabled = true;
                radioJamon.Disabled = true;
                radioFrijoles.Disabled = true;
                radioMyM.Disabled = true;
                radioOmelette.Disabled = true;
                radioEnsaladaHuevo.Disabled = true;
                chGalloPinto.Disabled = true;
                chEnsalada.Disabled = true;
                chGalloPinto.Disabled = true;
                chHuevoDuro.Disabled = true;
                chMayonesa.Disabled = true;
                chPlatanos.Disabled = true;
                chSalsaTomate.Disabled = true;
                chFrutas.Disabled = true;
                chConfites.Disabled = true;
                radioAgua.Disabled = true;
                radioJugo.Disabled = true;
                CheckboxBebida.Disabled = true;
                CheckboxO2.Disabled = true;
                btnO2.Disabled = true;
            }
            else if (modo == 2)
            { //modificar
                /*btnModificar.Disabled = true;
                btnEliminar.Disabled = true;
                btnAceptar.Disabled = false;
                btnCancelar.Disabled = false;
                btnAgregar.Disabled = true;*/
            }
            else if (modo == 3)
            { // eliminar
                /**btnModificar.Disabled = true;
                btnEliminar.Disabled = true;
                btnAceptar.Disabled = false;
                btnCancelar.Disabled = false;
                btnAgregar.Disabled = true;
                habilitarCampos(false);*/
            }
            else if (modo == 4)
            {  //consultar
                consultarComidaCampoReserv();
                textFecha.Disabled = true;
                txtHora.Disabled = true;
                txtPax.Disabled = true;
                radioPanBlanco.Disabled = true;
                radioPanBollo.Disabled = true;
                radioPanInt.Disabled = true;
                radioJamon.Disabled = true;
                radioFrijoles.Disabled = true;
                radioMyM.Disabled = true;
                radioOmelette.Disabled = true;
                radioEnsaladaHuevo.Disabled = true;
                chGalloPinto.Disabled = true;
                chEnsalada.Disabled = true;
                chGalloPinto.Disabled = true;
                chHuevoDuro.Disabled = true;
                chMayonesa.Disabled = true;
                chPlatanos.Disabled = true;
                chSalsaTomate.Disabled = true;
                chFrutas.Disabled = true;
                chConfites.Disabled = true;
                radioAgua.Disabled = true;
                radioJugo.Disabled = true;
                CheckboxBebida.Disabled = true;
                CheckboxO2.Disabled = true;
                btnO2.Disabled = true;
                btnAgregar.Disabled = true;
                
            }
        }
        protected void checkO2(object sender, EventArgs e)
        {
            fieldsetO2.Visible = !fieldsetO2.Visible;
            opcion = 2;
        }

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

        protected Boolean agregarComidaCampo()
        {
            Boolean res = true;
            Object[] nuevaComidaCampo = new Object[12];// objeto en el que se almacenan los datos para enviar a encapsular.
            List<String> lista = listaAdicionales();
            nuevaComidaCampo[0] = "";
            if (tipoComidaCampo == 1)
            {
                nuevaComidaCampo[1] = idEmpleado;
            }
            nuevaComidaCampo[2] = "";   
            nuevaComidaCampo[3] = textFecha.Value;
            nuevaComidaCampo[4] = "activo";
            nuevaComidaCampo[5] = 0;
            
            if (radioDesayuno.Checked)
            {
                nuevaComidaCampo[5] = "1";
            }
            else if (radioAlmuerzo.Checked)
            {
                nuevaComidaCampo[5] = "2";
            }
            else if (radioCena.Checked)
            {
                nuevaComidaCampo[5] = "3";
            }
            if (opcion==2)
            {
                nuevaComidaCampo[5] = "4";
                nuevaComidaCampo[7] = getPan();
                nuevaComidaCampo[6] = getTipoSandwich();
            }
            else
            {
                nuevaComidaCampo[7] = "";
                nuevaComidaCampo[6] = "";

            }
            if (CheckboxO2.Checked)
            {
                nuevaComidaCampo[5] = "5";
                
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

            nuevaComidaCampo[9] = cmbTipoPago.Value.ToString();
            nuevaComidaCampo[10] = txtPax.Value;
            nuevaComidaCampo[11] = txtHora.Value;

            String[] error = controladora.agregarComidaCampo(nuevaComidaCampo,lista);// se le pide a la controladora que lo inserte
            mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado


            return res;
        }


        protected Boolean agregarComidaCampoReserv()
        {
            Boolean res = true;
            Object[] nuevaComidaCampo = new Object[12];// objeto en el que se almacenan los datos para enviar a encapsular.
            List<String> lista = listaAdicionales();
            nuevaComidaCampo[0] = "";
            nuevaComidaCampo[1] = "";
            nuevaComidaCampo[2] = idReservacion;
            nuevaComidaCampo[3] = textFecha.Value;
            nuevaComidaCampo[4] = "Activo";
            nuevaComidaCampo[5] = 0;
            if (CheckboxCambio.Checked)
            {
                if (radioDesayuno.Checked) {
                    nuevaComidaCampo[5] = "1";
                }else if(radioAlmuerzo.Checked){
                    nuevaComidaCampo[5]="2";
                }else if(radioCena.Checked){
                    nuevaComidaCampo[5]="3";
                }
                nuevaComidaCampo[6]="";
                nuevaComidaCampo[7]="";
                nuevaComidaCampo[8]="";
                nuevaComidaCampo[9] = "";
            }
            else if(opcion==2){  //sandwich
                nuevaComidaCampo[5] ="4";
                nuevaComidaCampo[6]= getTipoSandwich();
                nuevaComidaCampo[7]= getPan();
            }else if(CheckboxO2.Checked){
                nuevaComidaCampo[5]="5";
                 nuevaComidaCampo[6]="";
                nuevaComidaCampo[7]= "";
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

            nuevaComidaCampo[9] = "";
            nuevaComidaCampo[10] = txtPax.Value;
            nuevaComidaCampo[11] = txtHora.Value;

            String[] error = controladora.agregarComidaCampo(nuevaComidaCampo, lista);// se le pide a la controladora que lo inserte
            mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado


            return res;
        }

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

        protected void clickAceptar(object sender, EventArgs e)
        {
            switch (modo)
            {
                case 1://insertar
                    if (tipoComidaCampo == 1) //agregar la comida dependiendo si es para un empleado o una reservacion.
                    {
                        agregarComidaCampo();
                    }
                    else
                    {
                        agregarComidaCampoReserv();
                        modo = 5;
                        cambiarModo();
                    }
                    
                    //Response.Redirect("FormServicios");
                    break;
                case 2://modificar

                    break;
                case 3://cancelar

                    break;
            }
        }
        protected void clickCancelar(object sender, EventArgs e)
        {

        }
        protected void fechaDeEntradaCalendario_SelectionChanged(object sender, EventArgs e)
        {
            textFecha.Value = fechaDeEntradaCalendario.SelectedDate.ToString("dd/MM/yyyy");
            fechaDeEntradaCalendario.Visible = false;
        }


        protected void consultarComidaCampoReserv()
        {

            textFecha.Value = entidadConsultada.Fecha;
            txtHora.Value = entidadConsultada.Hora;
            txtPax.Value = entidadConsultada.Pax.ToString();
            if (entidadConsultada.Opcion == 1)
            {
                CheckboxCambio.Checked = true;
                radioDesayuno.Checked= true;
            }
            if (entidadConsultada.Opcion == 2)
            {
                CheckboxCambio.Checked = true;
                radioAlmuerzo.Checked = true;
            }
            if (entidadConsultada.Opcion == 3)
            {
                CheckboxCambio.Checked = true;
                radioCena.Checked = true;
            }
            if (entidadConsultada.Opcion == 4)
            {
                 tipoSandwich();
            }
            else if (entidadConsultada.Opcion == 5)
            {
                CheckboxO2.Checked = true;
                chGalloPinto.Checked=true;
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

        }

            protected void tipoSandwich()
            {
                if(entidadConsultada.Pan == "Pan Blanco")
                {
                    radioPanBlanco.Checked = true;
                }else if(entidadConsultada.Pan == "Pan Bollo"){
                    radioPanBollo.Checked=true;
                }else if(entidadConsultada.Pan == "Pan Integral"){
                    radioPanInt.Checked = true;
                }
                if(entidadConsultada.Relleno == "Jamon"){
                    radioJamon.Checked=true;
                }else if(entidadConsultada.Relleno == "Atun"){
                    radioAtun.Checked =true;
                }else if(entidadConsultada.Relleno == "Frijoles"){
                    radioFrijoles.Checked=true;
                }else if(entidadConsultada.Relleno == "Mantequilla de maní y jalea"){
                    radioMyM.Checked=true;
                }else if(entidadConsultada.Relleno == "Omelette"){
                    radioOmelette.Checked=true;
                }else if(entidadConsultada.Relleno == "Ensalda de huevo"){
                    radioEnsaladaHuevo.Checked=true;
                }
            }

            protected void consultarAdicionales() 
            {
                if (entidadConsultada.Adicionales.Contains("Ensalada")){
                    chEnsalada.Checked = true;
                }
                if (entidadConsultada.Adicionales.Contains("Mayonesa")) {
                    chMayonesa.Checked = true;
                }
                if (entidadConsultada.Adicionales.Contains("Confites")) {
                    chConfites.Checked = true;
                }
                if (entidadConsultada.Adicionales.Contains("Frutas")) {
                    chFrutas.Checked = true;
                }
                if (entidadConsultada.Adicionales.Contains("Salsa de tomate")) {
                    chSalsaTomate.Checked = true;
                }
                if (entidadConsultada.Adicionales.Contains("Huevos duros")) {
                    chHuevoDuro.Checked = true;
                }
                if (entidadConsultada.Adicionales.Contains("Galletas")) {
                    chGalletas.Checked = true;
                }
                if (entidadConsultada.Adicionales.Contains("Platanos")) {
                    chPlatanos.Checked = true;
                }
            }
            
          
            
       

    }
}