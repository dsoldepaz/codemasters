using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;



namespace Servicios_Reservados_2
{
    public class ControladoraServicios
    {
        public static EntidadReservaciones servicios;
        private static ControladoraBDServicios controladoraBD;
        public static ControladoraReservaciones controladoraReserv;
        public static ControladoraComidaExtra controladoraCE;
        public static ControladoraComidaCampo controladoraComidaCampo;
        public List<String> adicionales;
        private static EntidadServicios seleccionado;



        public ControladoraServicios()
        {
            controladoraBD = new ControladoraBDServicios();
            controladoraReserv = new ControladoraReservaciones();
            controladoraCE = new ControladoraComidaExtra();
            controladoraComidaCampo = new ControladoraComidaCampo();
        }

        public EntidadReservaciones informacionServicio()
        {
            servicios = controladoraReserv.getReservacionSeleccionada();

            return servicios;

        }

        public String idSelected()
        {
            String idReserv = controladoraReserv.getReservacionSeleccionada().Id;
            return idReserv;

        }

        public String idNumSelected()
        {
            string idNum = controladoraReserv.getReservacionSeleccionada().Numero;
            return idNum;

        }

        internal DataTable obtenerPax(String id)
        {
            DataTable pax = controladoraBD.obtenerPax(id);

            Object[] dato = new Object[2];
            dato[0] = pax.Rows[0][0].ToString();
            dato[1] = idSelected();
            controladoraCE.guardarReservacionSeleccionada(dato);//enviamos la información a la controladora de comida extra

            return pax;

        }

        internal DataTable solicitarServicios(String id)
        {
            DataTable servicios = controladoraBD.solicitarServicios(id);
            return servicios;

        }

        internal DataTable solicitarComidaCampo(String id)
        {
            DataTable comidaCampo = controladoraBD.solicitarComidaCampo(id);
            return comidaCampo;
        }

        internal EntidadComidaExtra seleccionarServicio(String id, String idServ)
        {
            return controladoraCE.guardarServicioSeleccionado(id, idServ);
        }

        internal EntidadComidaCampo seleccionarComidaCampo(String id, String idServ)
        {
            return controladoraComidaCampo.guardarComidaSeleccionada(id, idServ);
        }


        /*
         * Efecto: recibe los ids y los manda a la controladora de BD para eliminar el servicio.
         * Requiere: los ids.
         * Modifica:
         */
        internal String[] cancelarComidaExtra(String idReservacion, String idComidaExtra, String fecha, String hora)
        {
            String[] resultado = controladoraCE.cancelarComidaExtra(idReservacion, idComidaExtra, fecha, hora);
            return resultado;
        }

        /*
         * Efecto: recibe el id de la comida de campo y lo manda a cancelar a la controladora de BD.
         * Requiere: el id.
         * Modifica:
         */
        internal String[] cancelarComidaCampo(String idCC)
        {
            String[] resultado = controladoraComidaCampo.cancelarComidaCampo(idCC);
            return resultado;
        }


        internal DataTable solicitarPaquete(string idReservacion)
        {
            return controladoraBD.obtenerPaquete(idReservacion);
        }

        internal EntidadServicios crearServicio(string idRes, string id)
        {
             if (id.Contains("."))
            {
                DataTable dt= controladoraBD.solicitarReservItem(id);
                seleccionado= new EntidadServicios(idRes, "reservacion", id,  "Paquete", "Toda la estadía", "ponerconsumido", int.Parse(dt.Rows[0][0].ToString()));
                
            }
            else if (id.Contains("S"))
            {
                EntidadComidaExtra servicio = seleccionarServicio(idRes, id);
                seleccionado = new EntidadServicios(idRes, "reservacion", id, "Comida extra", servicio.Fecha, servicio.Consumido, servicio.Pax);
            }
            else
            {
                EntidadComidaCampo comidaCampo = seleccionarComidaCampo(idRes, id);
                seleccionado = new EntidadServicios(idRes, "reservacion", id, "Comida campo", comidaCampo.Fecha, comidaCampo.Estado, comidaCampo.Pax);
            }
             return seleccionado;
        }

        public EntidadServicios servicioSeleccionado(){ 
            return seleccionado;
        }
        internal void activarTiquete()
        {
            ControladoraTiquete.setServicio(seleccionado);
        }

    }
}