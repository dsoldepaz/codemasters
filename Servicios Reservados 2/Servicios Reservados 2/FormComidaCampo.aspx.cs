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
        private static ControladoraComidaCampo controladora = new ControladoraComidaCampo();
        private static int modo;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cambiarModo()
        {
           if (modo == 1)
              { // se desea insertar
                  /*textFecha.Disabled = true;
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
                  /*btnModificar.Disabled = true;
                  btnEliminar.Disabled = true;
                  btnAceptar.Disabled = false;
                  btnCancelar.Disabled = false;
                  btnAgregar.Disabled = true;
                  habilitarCampos(false);*/
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
              }
        }

 
    
        /*
        * Efecto: capta el evento al presionar el botón del calendario para hacerlo visible.
        * Requiere: presionar el calendario.
        * Modifica: la apariencia del calendario en pantalla. 
       */
        protected void fechaDeEntrada_ServerClick(object sender, EventArgs e)
        {
            
        }

        /*
         * Efecto: capta el evento al presionar una fecha en el calendario y lo pasa al textFexha.
         * Requiere: presionar el calendario y una de las fechas.
         * Modifica: 
        */
        protected void fechaDeEntradaCalendario_SelectionChanged(object sender, EventArgs e)
        {
         
        }

    }



}