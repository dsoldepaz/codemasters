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
                txtPax.Value = controladora.paxReserv(reservacionConsultada.Numero);
            }

            if (modo == 1)
            {
                radioDesayuno.Enabled = false;
                radioAlmuerzo.Enabled = false;
                radioCena.Enabled = false;
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

            }
            else if (modo == 2)
            { //modificar
                consultarComidaCampo();
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

                consultarComidaCampo();
                radioDesayuno.Enabled = false;
                radioAlmuerzo.Enabled = false;
                radioCena.Enabled = false;
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
                chHuevoDuro.Disabled = true;
                chMayonesa.Disabled = true;
                chPlatanos.Disabled = true;
                chSalsaTomate.Disabled = true;
                chFrutas.Disabled = true;
                chGalletas.Disabled = true;
                chConfites.Disabled = true;
                radioAgua.Disabled = true;
                radioJugo.Disabled = true;
                CheckboxBebida.Enabled = true;
                checkO2.Enabled = true;
                btnAgregar.Disabled = true;
                checkO1.Enabled = true;

            }
        }
        protected void limpiarCampos()
        {
            cambiarModo();
            radioDesayuno.Checked = false;
            radioAlmuerzo.Checked = false;
            radioCena.Checked = false;
            radioPanBlanco.Checked = false;
            radioPanBollo.Checked = false;
            radioPanInt.Checked = false;
            radioJamon.Checked = false;
            radioFrijoles.Checked = false;
            radioMyM.Checked = false;
            radioOmelette.Checked = false;
            radioEnsaladaHuevo.Checked = false;
            chGalloPinto.Checked = false;
            chEnsalada.Checked = false;
            chGalletas.Checked = false;
            chHuevoDuro.Checked = false;
            chMayonesa.Checked = false;
            chPlatanos.Checked = false;
            chSalsaTomate.Checked = false;
            chFrutas.Checked = false;
            chConfites.Checked = false;
            radioAgua.Checked = false;
            radioJugo.Checked = false;


        }

        protected void cambiarFechaD(object sender, EventArgs e)
        {

            txtHora.Value = "8:00";
        }

        protected void cambiarFechaA(object sender, EventArgs e)
        {
            txtHora.Value = "12:00";
        }
        protected void cambiarFechaC(object sender, EventArgs e)
        {
            txtHora.Value = "18:00";
        }
        protected void checkedO1(object sender, EventArgs e)
        {
            limpiarCampos();
            if (checkO2.Checked)
            {
                checkO2.Checked = false;
            }
            else if (checkO3.Checked)
            {
                checkO3.Checked = false;
            }
            radioDesayuno.Enabled = true;
            radioAlmuerzo.Enabled = true;
            radioCena.Enabled = true;
        }

        protected void checkbebida(object sender, EventArgs e)
        {
            if (!CheckboxBebida.Checked)
            {
                radioAgua.Checked = false;
                radioJugo.Checked = false;
            }
        }

        protected void checkedO3(object sender, EventArgs e)
        {
            limpiarCampos();
            if (checkO2.Checked)
            {
                checkO2.Checked = false;
            }
            else if (checkO1.Checked)
            {
                checkO1.Checked = false;
            }
            chGalloPinto.Disabled = false;
        }
        protected void checkedO2(object sender, EventArgs e)
        {
            limpiarCampos();
            if (checkO1.Checked)
            {
                checkO1.Checked = false;
            }
            else if (checkO3.Checked)
            {
                checkO3.Checked = false;
            }
            radioPanBlanco.Disabled = false;
            radioPanBollo.Disabled = false;
            radioPanInt.Disabled = false;
            radioJamon.Disabled = false;
            radioFrijoles.Disabled = false;
            radioMyM.Disabled = false;
            radioOmelette.Disabled = false;
            radioEnsaladaHuevo.Disabled = false;
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

        /* protected Boolean agregarComidaCampo()
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
             nuevaComidaCampo[4] = "Activo";
             nuevaComidaCampo[5] = 0;
             if (checkO1.Checked)
             {
            
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
             }
             if(checkO2.Checked)
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
             if (checkO3.Checked)
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
         }*/


        protected Boolean agregarComidaCampo()
        {
            Boolean res = true;
            DateTime fechaInicio = reservacionConsultada.FechaInicio;
            DateTime fechaFinal = reservacionConsultada.FechaSalida;
            DateTime fechaSelect = fechaDeEntradaCalendario.SelectedDate;
            DateTime fechaHoy = DateTime.Today;
            if ((tipoComidaCampo == 0) && (fechaSelect < fechaInicio || fechaSelect > fechaFinal) || (fechaSelect <= fechaHoy))
            {
                mostrarMensaje("danger", "Error:", "Revise la fecha selccionada, debe estar dentro de la reservación");
                res = false;
            }
            else
            {
                Object[] nuevaComidaCampo = new Object[12];// objeto en el que se almacenan los datos para enviar a encapsular.
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
                    }
                    else if (radioAlmuerzo.Checked)
                    {
                        nuevaComidaCampo[5] = "2";
                    }
                    else if (radioCena.Checked)
                    {
                        nuevaComidaCampo[5] = "3";
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
                }
                else if (checkO3.Checked)
                {
                    nuevaComidaCampo[5] = "5";
                    nuevaComidaCampo[6] = "";
                    nuevaComidaCampo[7] = "";
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
                nuevaComidaCampo[11] = txtHora.Value;

                String[] error = controladora.agregarComidaCampo(nuevaComidaCampo, lista);// se le pide a la controladora que lo inserte
                mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado

            }
            return res;
        }

        protected Boolean modificarComidaCampo()
        {
            Boolean res = true;
            DateTime fechaInicio = reservacionConsultada.FechaInicio;
            DateTime fechaFinal = reservacionConsultada.FechaSalida;
            DateTime fechaSelect = DateTime.Parse(textFecha.Value);
            DateTime fechaHoy = DateTime.Today;
            if ((tipoComidaCampo == 0) && (fechaSelect < fechaInicio || fechaSelect > fechaFinal) || (fechaSelect <= fechaHoy))
            {
                mostrarMensaje("danger", "Error:", "Revise la fecha selccionada, debe estar dentro de la reservación");
                res = false;
            }
            else
            {
                Object[] comidaModificar = new Object[12];// objeto en el que se almacenan los datos para enviar a encapsular.
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
                    }
                    else if (radioAlmuerzo.Checked)
                    {
                        comidaModificar[5] = "2";
                    }
                    else if (radioCena.Checked)
                    {
                        comidaModificar[5] = "3";
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
                }
                else if (checkO3.Checked)
                {
                    comidaModificar[5] = "5";
                    comidaModificar[6] = "";
                    comidaModificar[7] = "";
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
                comidaModificar[11] = txtHora.Value;
                String[] error = controladora.modificarComidaCampo(comidaModificar, lista, entidadConsultada);// se le pide a la controladora que lo inserte
                mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado
            }
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
                        //FormEmpleadoReserva.idEmpleado = idEmpleado;
                        Response.Redirect("FormEmpleadoReserva");

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


                    }
                    else
                    {
                        modificarComidaCampo();
                        modo = 5;
                        cambiarModo();

                    }

                    break;
                case 3://cancelar

                    break;
            }
        }
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
            textFecha.Value = fechaDeEntradaCalendario.SelectedDate.ToString("dd/MM/yyyy");
            fechaDeEntradaCalendario.Visible = false;
        }


        protected void consultarComidaCampo()
        {

            textFecha.Value = entidadConsultada.Fecha;
            txtHora.Value = entidadConsultada.Hora;
            txtPax.Value = entidadConsultada.Pax.ToString();
            if (entidadConsultada.Opcion == 1)
            {
                checkO1.Checked = true;
                radioDesayuno.Checked = true;
            }
            if (entidadConsultada.Opcion == 2)
            {
                checkO1.Checked = true;
                radioAlmuerzo.Checked = true;
            }
            if (entidadConsultada.Opcion == 3)
            {
                checkO1.Checked = true;
                radioCena.Checked = true;
            }
            if (entidadConsultada.Opcion == 4)
            {
                tipoSandwich();
            }
            else if (entidadConsultada.Opcion == 5)
            {
                checkO3.Checked = true;
                chGalloPinto.Checked = true;
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







    }
}