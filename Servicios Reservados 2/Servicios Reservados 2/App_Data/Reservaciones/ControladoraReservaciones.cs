using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraReservaciones
    {
        private static EntidadReservaciones reservacionSeleccionada;
        private static ControladoraBDReservaciones controladoraBD;

        public ControladoraReservaciones()
        {
            controladoraBD = new ControladoraBDReservaciones();
        }
        internal DataTable solicitarTodasReservaciones()
        {
            //Debug.WriteLine("solicitar");
            DataTable todas = controladoraBD.consultarTodasReservaciones();

            return todas;

        }

        internal DataTable solicitarAnfitriones()
        {
            DataTable anfitrion = controladoraBD.solicitarAnfitriones();
            return anfitrion;
        }

        internal DataTable solicitarEstaciones()
        {
            DataTable estacion = controladoraBD.solicitarEstaciones();
            return estacion;
        }

        internal DataTable consultarReservaciones(String anfitriona, String estacion, String solicitante)
        {
            
            DataTable reservaciones = controladoraBD.consultarReservaciones(anfitriona, estacion, solicitante);
            return reservaciones;
        }


        internal void seleccionarReservacion(String id)
        {
            DataTable reservacion = controladoraBD.consultarUnaReservacion(id);

            String anfitriona = reservacion.Rows[0][1].ToString();
            String estacion = reservacion.Rows[0][2].ToString();
            String numero = reservacion.Rows[0][3].ToString();
            String solicitante = reservacion.Rows[0][4].ToString();
            DateTime fechaInicio = DateTime.Parse(reservacion.Rows[0][5].ToString());
            DateTime fechaSalida = DateTime.Parse(reservacion.Rows[0][6].ToString());

          reservacionSeleccionada = new EntidadReservaciones(id, anfitriona, estacion, numero, solicitante, fechaInicio, fechaSalida);
        }

        public EntidadReservaciones getReservacionSeleccionada() {
            return reservacionSeleccionada;
        }

        internal DataTable solicitarInfo(String id)
        {
            DataTable reservInfo = controladoraBD.solicitarInfo(id);
            return reservInfo;


        }

    }
}