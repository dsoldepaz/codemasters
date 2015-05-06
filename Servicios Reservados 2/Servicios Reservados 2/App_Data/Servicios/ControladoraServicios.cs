﻿using System;
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
    }
}