using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;



namespace Servicios_Reservados_2.Servicios
{
    public class ControladoraServicios
    {
        public static EntidadReservaciones servicios;
        private ControladoraBDServicios controladora;
        public static ControladoraReservaciones controladoraReserv;
        public static ControladoraComidaExtra controladoraCE;

        public ControladoraServicios()
        {
            controladora = new ControladoraBDServicios();
            controladoraReserv = new ControladoraReservaciones();
            controladoraCE = new ControladoraComidaExtra();

        }

        public EntidadReservaciones informacionServicio() {
            servicios = controladoraReserv.getReservacionSeleccionada();
           
          return servicios;

        }
       /**Efecto: retorna el id de la reservacion seleccionada  
         * Requiere: NA
         * Modifica: el valor idReserv
         */
        public String idSelected()
        {
            String idReserv = controladoraReserv.getReservacionSeleccionada().Id;
            return idReserv;

        }

        /**Efecto: retorna un dataTable con el numero de pax de la reservacion seleccionada  
         * Requiere: id de la reservacion
         * Modifica: la datatable pax
         */
        internal DataTable obtenerPax(String id)
        {
            DataTable pax = controladora.obtenerPax(id);
            return pax;

        }
        /**Efecto: retorna un dataTable con todos los servicios de una reservacion 
         * Requiere: id de la reservacion
         * Modifica: la datable servicios
         */
        internal DataTable solicitarServicios(String id)
        {
            DataTable servicios = controladora.solicitarServicios(id);
            return servicios;

        }
        /**Efecto: Crea un objeto nuevoServicio y le guarda los valores del servicio selecionado  
         * Requiere: id reservacion, id servicio
         * Modifica: el objeto nuevoServicio
         */
        internal void seleccionarServicio(String id, String idServ)
        {
            DataTable servicios = controladora.seleccionarServicio(id, idServ);

            Object[] nuevoServicio = new Object[7];

            nuevoServicio[0] = servicios.Rows[0][0];
            nuevoServicio[1] = servicios.Rows[0][1];
            nuevoServicio[2] = servicios.Rows[0][3];
            nuevoServicio[3] = servicios.Rows[0][4];
            nuevoServicio[4] = servicios.Rows[0][5];
            nuevoServicio[5] = servicios.Rows[0][2];
            nuevoServicio[6] = servicios.Rows[0][6];

            controladoraCE.guardarServicioSeleccionado(nuevoServicio);

        }
        /**Efecto: llama al metodo  modificar servicio de la controladora de comidas extra  
         * Requiere: NA
         * Modifica: NA
         */
        internal void modificarServicio()
        {
            controladoraCE.modificarServicio();
        }
    }
}