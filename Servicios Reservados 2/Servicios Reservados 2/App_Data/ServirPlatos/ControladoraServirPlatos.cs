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
        private static ControladoraComidaEmpleado controladoraComidaEmp;
        private static ControladoraComidaCampo controladoraComidaCampo;
        private static ControladoraComidaExtra controladoraComidaExtra;
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
            
            String idServicio = tiquete.Rows[0][0].ToString();
            int consumido = int.Parse(tiquete.Rows[0][1].ToString());
            String categoria = tiquete.Rows[0][2].ToString();
            String solicitante = tiquete.Rows[0][3].ToString();             
            String tipoSolicitante = tiquete.Rows[0][4].ToString();
            if ("empleado".Equals(tipoSolicitante) && "Comida campo".Equals(categoria))
            {
                //controladoraComidaCampo.solicitar(idServicio, idSolicitante);
            }
            else if ("empleado".Equals(tipoSolicitante) && "Comida regular".Equals(categoria))
            {
                //controladoraComidaEmpleado.solicitar(idServicio, idSolicitante);
            }
            else if ("reservacion".Equals(tipoSolicitante) && "Paquete".Equals(categoria))
            {
                //controladoraServicios.solicitar(idServicio, idSolicitante);
            }
            else if ("reservacion".Equals(tipoSolicitante) && "Comida extra".Equals(categoria))
            {
                //controladoraComidaCampo.solicitar(idServicio, idSolicitante);
            }
            else if ("reservacion".Equals(tipoSolicitante) && "Comida campo".Equals(categoria))
            {
                //controladoraComidaCampo.solicitar(idServicio, idSolicitante);
            }
            String notas = "ir por las notas";
            seleccionado = new EntidadTiquete(numTiquete, idServicio, tipoSolicitante,consumido, solicitante, categoria, notas);
            return seleccionado;
        }


        internal void servirTiquete()
        {
            int vecesConsumido = seleccionado.Consumido + 1;
            controladoraBD.servirTiquete(seleccionado.Numero,vecesConsumido);
        }
    }
}