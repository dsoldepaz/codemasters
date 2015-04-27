using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

    }
}