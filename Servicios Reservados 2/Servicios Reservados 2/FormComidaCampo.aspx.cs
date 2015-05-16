using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicios_Reservados_2
{
    public partial class FormComidaCampo : System.Web.UI.Page
    {
        private static ControladoraComidaCampo controladora  = new ControladoraComidaCampo();
        private static int modo;
        public static int tipoComidaCampo;
        public static String idEmpleado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cambiarModo();

            }
           

        }

        protected void cambiarModo()
        {
            
            if (tipoComidaCampo==0) {
                cmbTipoPago.Visible = false;
                labelPago.Visible = false;
            }
            
          /** if (modo == 1)
              { // se desea insertar
                  /*textFecha.Disabled = true;
                  btnEliminar.Disabled = true;
                  btnAceptar.Disabled = false;
                  btnCancelar.Disabled = false;
                  btnAgregar.Disabled = true;
              }
              else if (modo == 2)
              { //modificar
                  /*btnModificar.Disabled = true;
                  btnEliminar.Disabled = true;
                  btnAceptar.Disabled = false;
                  btnCancelar.Disabled = false;
                  btnAgregar.Disabled = true;
              }
              else if (modo == 3)
              { // eliminar
                  /*btnModificar.Disabled = true;
                  btnEliminar.Disabled = true;
                  btnAceptar.Disabled = false;
                  btnCancelar.Disabled = false;
                  btnAgregar.Disabled = true;
                  habilitarCampos(false);
              }
              else if (modo == 4)
             { //consultar
                  textFecha.Disabled = true;
                  txtHora.Disabled = true;
                  radioDesayuno.Disabled= true;
                  radioAlmuerzo.Disabled = false;
                  radioCena.Disabled = true;
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
              }**/
        }
        protected void checkO1click(object sender, EventArgs e)
        {
            if (checkboxO1.Checked)
            {
                radioPanBlanco.Disabled = false;
                radioPanBollo.Disabled = false;
                radioPanInt.Disabled = false;
                radioJamon.Disabled = false;
                radioFrijoles.Disabled = false;
                radioMyM.Disabled = false;
                radioOmelette.Disabled = false;
                radioEnsaladaHuevo.Disabled = false;
                if (CheckboxO2.Checked)
                {
                    CheckboxO2.Checked = false;
                }
            }
            
                
        }

        protected String getPan(){
            String pan = "";
            if(radioPanBlanco.Checked){
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

        protected String getTipoSandwich(){
            String tipo = "";
            if (radioJamon.Checked) {
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
        protected Boolean agregarComidaCampo()
        {
            Boolean res = true;
            Object[] nuevaComidaCampo = new Object[12];// objeto en el que se almacenan los datos para enviar a encapsular.
            nuevaComidaCampo[0]= "";
            if(tipoComidaCampo==1){
                nuevaComidaCampo[1] = idEmpleado;
            }
            nuevaComidaCampo[2] = "";
            nuevaComidaCampo[3] = textFecha.ToString();
            nuevaComidaCampo[4] = "activo";
            nuevaComidaCampo[5] = 0;
            if(checkboxO1.Checked){
                nuevaComidaCampo[5] = "1";
                nuevaComidaCampo[7] = getPan();
            }else{
                nuevaComidaCampo[7] = "";

            }
            if(CheckboxO2.Checked)
            {
                nuevaComidaCampo[5] = "2";
                nuevaComidaCampo[6] = getTipoSandwich();
            }else{
                nuevaComidaCampo[6] = "";
            }
            nuevaComidaCampo[8] = "";
            if (CheckboxBebida.Checked)
            {
                String bebida ="Jugo";
                if(radioAgua.Checked){
                    bebida ="Agua";
                }
                nuevaComidaCampo[8] = bebida;
            }

            nuevaComidaCampo[9] = cmbTipoPago.SelectedIndex.ToString();
            nuevaComidaCampo[10] = txtPax.ToString();
            nuevaComidaCampo[11] = txtHora.ToString();
           
                        
            
            return res;
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
        protected void clickAceptar(object sender, EventArgs e)
        {
         
        }
        protected void clickCancelar(object sender, EventArgs e)
        {

        }
        protected void fechaDeEntradaCalendario_SelectionChanged(object sender, EventArgs e)
        {
            textFecha.Value = fechaDeEntradaCalendario.SelectedDate.ToString("dd/MM/yyyy");
            fechaDeEntradaCalendario.Visible = false;
        }


    }



}