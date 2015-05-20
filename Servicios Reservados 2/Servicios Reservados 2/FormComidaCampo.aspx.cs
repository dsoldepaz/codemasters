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
        Object[] adicionales = controladora.adicionalSeleccionado();

        public static int modo;
        public static int tipoComidaCampo;
        public static String idEmpleado;

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
            { // se desea insertar
                /* textFecha.Disabled = true;
                 btnEliminar.Disabled = true;
                 btnAceptar.Disabled = false;
                 btnCancelar.Disabled = false;
                 btnAgregar.Disabled = true;*/
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
                checkboxO1.Disabled = true;
                CheckboxO2.Disabled = true;
                CheckboxBebida.Disabled = true;
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
                radioAtun.Disabled = true;
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
            }
        }
        protected void checkO1click(object sender, EventArgs e)
        {
            // if (checkboxO1.Checked)
            //  {
            opcion2Fieldset.Visible = !opcion2Fieldset.Visible;
            Debug.WriteLine("picha vivir");
            // }


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
        protected Boolean agregarComidaCampo()
        {
            Boolean res = true;
            Object[] nuevaComidaCampo = new Object[12];// objeto en el que se almacenan los datos para enviar a encapsular.
            nuevaComidaCampo[0] = "";
            if (tipoComidaCampo == 1)
            {
                nuevaComidaCampo[1] = idEmpleado;
            }
            nuevaComidaCampo[2] = "";
            nuevaComidaCampo[3] = textFecha.Value;
            nuevaComidaCampo[4] = "activo";
            nuevaComidaCampo[5] = 0;
            if (checkboxO1.Checked)
            {
                nuevaComidaCampo[5] = "1";
                nuevaComidaCampo[7] = getPan();
            }
            else
            {
                nuevaComidaCampo[7] = "";

            }
            if (CheckboxO2.Checked)
            {
                nuevaComidaCampo[5] = "2";
                nuevaComidaCampo[6] = getTipoSandwich();
            }
            else
            {
                nuevaComidaCampo[6] = "";
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

            //String[] error = controladora.agregarComidaCampo(nuevaComidaCampo);// se le pide a la controladora que lo inserte
           // mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado


            return res;
        }

        protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje)
        {
            //alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
            //labelTipoAlerta.Text = alerta + " ";
            //labelAlerta.Text = mensaje;
            //alertAlerta.Attributes.Remove("hidden");
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
                    agregarComidaCampo();
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
                checkboxO1.Checked = true;
                tipoSandwich();
            }
            else if (entidadConsultada.Opcion == 2)
            {
                CheckboxO2.Checked = true;
                chGalloPinto.Checked=true;
            }
            if(entidadConsultada.Bebida=="Jugo"){
                CheckboxBebida.Checked = true;
                radioJugo.Checked=true;
            }else if(entidadConsultada.Bebida=="Agua"){
                CheckboxBebida.Checked = true;
                radioAgua.Checked=true;
            }

        }

            protected void tipoSandwich()
            {
                Debug.Write("BUUU:"+ entidadConsultada.Pan);
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
            
          
            
       

    }
}