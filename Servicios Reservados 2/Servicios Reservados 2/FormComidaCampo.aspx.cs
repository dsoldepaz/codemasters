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
        public static EntidadComidaCampo comidaSeleccionada;

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
                textFecha.Disabled = true;
                txtHora.Disabled = true;
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
                chHuevos.Disabled = true;
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
             if (checkboxO1.Checked)
              {
                  CheckboxO2.Checked = false;
                  Debug.WriteLine("ooops");
             }


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
                tipo = "Mantequilla y maní";
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
            List<String> list= new List<String>();
            if (chEnsalada.Checked)
            {
                list.Add("Ensalada");
            }
            if (chMayonesa.Checked)
            {
                list.Add("Mayonesa");
            }
            if (chConfites.Checked)
            {
                list.Add("Confites");
            }
            if (chFrutas.Checked)
            {
                list.Add("Frutas");
            }
            if (chSalsaTomate.Checked)
            {
                list.Add("Salsa de tomate");
            }
            if (chHuevoDuro.Checked)
            {
                list.Add("Huevos duros");
            }
            if (chGalletas.Checked)
            {
                list.Add("Galletas");
            }
            if (chPlatanos.Checked)
            {
                list.Add("Platanos");
            }

            return list;
        } 

        protected Boolean agregarComidaCampo()
        {
            Boolean res = true;
            Object[] nuevaComidaCampo = new Object[12];// objeto en el que se almacenan los datos para enviar a encapsular.
            List<String> adicionales = listaAdicionales();
            nuevaComidaCampo[0] = "temporal";
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
                nuevaComidaCampo[6] = getTipoSandwich();
                
            }
            else
            {
                nuevaComidaCampo[7] = "";

            }
            if (CheckboxO2.Checked)
            {
                nuevaComidaCampo[5] = "2";
                nuevaComidaCampo[7] = "";
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
            Debug.WriteLine(cmbTipoPago.SelectedIndex);
            Debug.WriteLine(cmbTipoPago.Value.ToString());
            nuevaComidaCampo[9] = cmbTipoPago.Value.ToString();
            nuevaComidaCampo[10] = txtPax.Value;
            nuevaComidaCampo[11] = txtHora.Value;

            String[] error = controladora.agregarComidaCampo(nuevaComidaCampo,adicionales);// se le pide a la controladora que lo inserte
            mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado


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
            Debug.WriteLine(modo);
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
                default:
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

            if (controladora.entidadSeleccionada()[5].ToString() == "1")
            {

                chGalloPinto.Checked = true;

            }
            txtPax.Value = controladora.entidadSeleccionada()[10].ToString();

            if (controladora.adicionalSeleccionado()[0] == "Confites")
            {

                chConfites.Checked = true;
            }


        }



    }
}