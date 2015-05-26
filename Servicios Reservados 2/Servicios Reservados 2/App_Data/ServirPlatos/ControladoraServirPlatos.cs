using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraServirPlatos
    {
        private static EntidadTiquete seleccionado;
        private static ControladoraBDServirPlatos controladoraBD;
        /*
         * Requiere: N/A
         * Efectúa : Inicializa las variables globales de la clase. 
         * Retorna : N/A
         */
        public ControladoraServirPlatos()
        {
            controladoraBD = new ControladoraBDServirPlatos();
        }
        /*
         * Requiere: N/A
         * Efectúa : Pide a la controladora de base de datos la información del tiquete y las guarda en una tabla de datos. 
         * Retorna : la tabla de datos que se crea.
         */
        internal EntidadTiquete solicitarTiquete(int numTiquete)
        {            
            DataTable tiquete = controladoraBD.consultarTiquete(numTiquete);
            seleccionado = new EntidadTiquete();
            return seleccionado;
        }

    }
}