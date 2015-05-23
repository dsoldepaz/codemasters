﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraTiquete
    {
        private static EntidadTiquete Seleccionado;
        private static ControladoraServicios controladoraServ;
        private static ControladoraBDTiquete controladoraBD;
        private static ControladoraReservaciones controladoraRes;
        /*
         * Requiere: N/A
         * Efectúa : Inicializa las variables globales de la clase. 
         * Retorna : N/A
         */
        public ControladoraTiquete()
        {
            controladoraBD = new ControladoraBDTiquete();
            controladoraRes = new ControladoraReservaciones();
            controladoraServ = new ControladoraServicios();
        }
        /*
         * Requiere: N/A
         * Efectúa : Pide a la controladora de base de datos la información de todas las reservaciones y las guarda en una tabla de datos. 
         * Retorna : la tabla de datos que se crea.
         */
        internal EntidadReservaciones solicitarInfoReservacion()
        {
            return controladoraRes.getReservacionSeleccionada();

        }
        internal EntidadServicios solicitarInfoServicio()
        {
            return controladoraServ.servicioSeleccionado();
        }
    }
}