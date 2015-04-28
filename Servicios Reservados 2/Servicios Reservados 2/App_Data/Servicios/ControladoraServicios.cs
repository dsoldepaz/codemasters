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

        public ControladoraServicios()
        {
            controladora = new ControladoraBDServicios();
            controladoraReserv = new ControladoraReservaciones();

        }

        public EntidadReservaciones informacionServicio() {
            servicios = controladoraReserv.getReservacionSeleccionada();
           
          return servicios;

        }

        public String idSelected()
        {
            String idReserv = controladoraReserv.getReservacionSeleccionada().Id;
            return idReserv;

        }

        internal DataTable obtenerPax(String id)
        {
            DataTable pax = controladora.obtenerPax(id);
            return pax;

        }

        internal DataTable solicitarServicios(String id)
        {
            DataTable servicios = controladora.solicitarServicios(id);
            return servicios;

        }
    }
}