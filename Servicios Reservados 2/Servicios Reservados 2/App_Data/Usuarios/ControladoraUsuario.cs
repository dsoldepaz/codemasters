﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraUsuario
    {
        private static ControladoraBDUsuario controladoraBD;
        /*
         * Requiere: N/A
         * Efectúa : Inicializa las variables globales de la clase. 
         * Retorna : N/A
         */
        public ControladoraUsuario()
        {
            controladoraBD = new ControladoraBDUsuario();
        }
        /**
* Requiere: nada.
* Efectua: pide los datos de los roles disponibles .
* retorna:  un dato del tipo DataTable con los roles .
*/
        public DataTable solicitarRolesDisponibles()
        {

            return controladoraBD.obtenerRolesDisponibles();
        }



        internal DataTable solicitarRolesAsignados()
        {
            return controladoraBD.obtenerRolesAsignados();
        }
    }
}