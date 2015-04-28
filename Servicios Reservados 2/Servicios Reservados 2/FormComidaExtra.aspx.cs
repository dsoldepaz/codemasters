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
        static DataTable tipo;
        static EntidadComidaExtra entidadVieja;

        private static String[] idReservacion = FormReservaciones.ids;
        private static ControladoraComidaExtra controladora = new ControladoraComidaExtra();
        int modo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatos();



            }
        }

        void cargarDatos()
        {
            llenarComboBoxTipo();
            //llenarGridReservaciones();
        }

        void llenarComboBoxTipo() {
            tipo = controladora.solicitarTipo();
            cbxTipo.Items.Clear();
            cbxTipo.Items.Add("Sleccionar");
            if (tipo.Rows.Count > 0) {
                foreach (DataRow fila in tipo.Rows) {
                    cbxTipo.Items.Add(fila[1].ToString());
                }
            }
        }

        protected Boolean agregarServicioExtra()
        {
            Boolean res = true;
            Object[] nuevoServicio = new Object[7];
            nuevoServicio[0] = "ANURA0229032005.0142746515";//idReservacion[0];
            int indice = cbxTipo.SelectedIndex-1;
            nuevoServicio[1] = tipo.Rows[indice][0];
            nuevoServicio[2] = fechaDeEntradaCalendario.SelectedDate.ToString("dd/MM/yyyy");
            nuevoServicio[3] = "no";
            nuevoServicio[4] = txaNotas.Value;
            nuevoServicio[5] = txtPax.Value;
            nuevoServicio[6] = txtHora.Value;

 
            String[] error = controladora.agregarServicioExtra(nuevoServicio);// se le pide a la controladora que lo inserte
            mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado
            return res;
        }

        protected Boolean modificarServicioExtra()
        {
            Boolean res = true;
            Object[] nuevoServicio = new Object[7];
            nuevoServicio[0] = "ANURA0229032005.0142746515";//idReservacion[0];
            int indice = cbxTipo.SelectedIndex - 1;
            nuevoServicio[1] = tipo.Rows[indice][0];
            nuevoServicio[2] = fechaDeEntradaCalendario.SelectedDate.ToString("dd/MM/yyyy");
            nuevoServicio[3] = "no";
            nuevoServicio[4] = txaNotas.Value;
            nuevoServicio[5] = txtPax.Value;
            nuevoServicio[6] = txtHora.Value;


            String[] error = controladora.modificarServicioExtra(nuevoServicio, entidadVieja);// se le pide a la controladora que lo inserte
            mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado
            return res;
        }

        protected void clickAceptar(object sender, EventArgs e)
        {
            agregarServicioExtra();
        }


        /*protected void cambiarModo()
        {
            if (modo == 1)
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
            }
        }*/

        
        protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje)
        {
            alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
            labelTipoAlerta.Text = alerta + " ";
            labelAlerta.Text = mensaje;
            alertAlerta.Attributes.Remove("hidden");
        }
        

        protected void fechaDeEntrada_ServerClick(object sender, EventArgs e)
        {
            fechaDeEntradaCalendario.Visible = !fechaDeEntradaCalendario.Visible;
        }

        protected void fechaDeEntradaCalendario_SelectionChanged(object sender, EventArgs e)
        {

        }
  


    }
}