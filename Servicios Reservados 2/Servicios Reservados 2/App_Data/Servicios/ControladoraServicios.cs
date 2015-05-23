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
            String[] resultado = controladoraBD.cancelarComidaExtra(idReservacion, idComidaExtra, fecha, hora);
            return resultado;
        }

        /*
         * Efecto: pide a la controladora de BD el estado de una comida extra  
         * Requiere: id de la reservacion y id de la comida extra
         * Modifica:
         */
        internal DataTable obtenerEstadoComidaExtra(String idReservacion, String idCE)
        {
            return controladoraBD.obtenerEstadoComidaExtra(idReservacion, idCE);
        }

        /*
         * Efecto: pide a la controladora de BD el estado de una comida de campo  
         * Requiere: id de la comida de campo 
         * Modifica:
         */
        internal DataTable obtenerEstadoComidaCampo(String idCC)
        {
            return controladoraBD.obtenerEstadoComidaCampo(idCC);
        }

        /*
         * Efecto: recibe el id de la comida de campo y lo manda a cancelar a la controladora de BD.
         * Requiere: el id.
         * Modifica:
         */
        internal String[] cancelarComidaCampo(String idCC)
        {
            String[] resultado = controladoraBD.cancelarComidaCampo(idCC);
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
                seleccionado= new EntidadServicios(idRes, id,  "Paquete", "-", "-", "-", int.Parse(dt.Rows[0][0].ToString()));
                
            }
            else if (id.Contains("S"))
            {
                EntidadComidaExtra servicio = seleccionarServicio(idRes, id);
                seleccionado = new EntidadServicios(idRes, id, "Comida Extra", servicio.Hora, servicio.Fecha, servicio.Consumido, servicio.Pax);
            }
            else
            {
                EntidadComidaCampo comidaCampo = seleccionarComidaCampo(idRes, id);
                seleccionado = new EntidadServicios(idRes, id, "Comida Campo", comidaCampo.Hora, comidaCampo.Fecha, comidaCampo.Estado, comidaCampo.Pax);
            }
             return seleccionado;
        }

        public EntidadServicios servicioSeleccionado(){ 
            return seleccionado;
        }

    }
}