using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraReporteCocina
    {
        private static ControladoraBDReporteCocina controladoraBD;
        private static ControladoraComidaEmpleado controladoraComdiaEmpleado;
        private static ControladoraComidaCampo controladoraCC;
        private static ControladoraComidaExtra controladoraCE;
        private static ControladoraReservaciones controladoraR;
        private ControladoraNotificaciones controladoraNotificaciones;
        public ControladoraReporteCocina()
        {
            controladoraCE = new ControladoraComidaExtra();
            controladoraCC = new ControladoraComidaCampo();
            controladoraComdiaEmpleado = new ControladoraComidaEmpleado();
            controladoraBD = new ControladoraBDReporteCocina();
            controladoraNotificaciones = new ControladoraNotificaciones();
            controladoraR = new ControladoraReservaciones();
        }

        internal DataTable solicitarTurnoDiaTresComidas(String sigla, String fecha)
        {
            return controladoraBD.solicitarTurnoDiaTresComidas(sigla, fecha);
        }

        internal DataTable solicitarTurnoDiaDosComidas(String sigla, String fecha)
        {
            return controladoraBD.solicitarTurnoDiaDosComidas(sigla, fecha);
        }

        internal DataTable reservaEntrante(String sigla, String fecha)
        {
            return controladoraBD.reservaEntrante(sigla, fecha);
        }

        internal DataTable solicitarCE(String estacion, String inicio, String final)
        {
            return controladoraBD.solicitarCE(estacion,inicio,final);

        }

        internal DataTable solicitarCC(String estacion, String inicio, String final)
        {
            return controladoraBD.solicitarCC(estacion, inicio, final);

        }

        internal DataTable solicitarBebidas(String estacion, String inicio, String final)
        {
            return controladoraBD.solicitarBebidas(estacion, inicio, final);

        }

        internal DataTable solicitarAdicionales(String estacion, String inicio, String final)
        {
            return controladoraBD.solicitarAdicionales(estacion, inicio, final);

        }

        /*
        * Requiere: N/A
        * Efectúa : Pide a la controladora de reservaciones todas las estaciones. 
        * Retorna : el datatable con las estaciones.
        */
        internal DataTable llenarEstaciones()
        {
            return controladoraR.solicitarEstaciones();
        }
        /*
         * Requiere: hilera con el identificador de la estacion, de la fecha inicio, de la fecha final
         * Efectua : llama a getDesayunos de la controladora de comida de empleado. 
         * Retorna :  El datatable retornado por la controladora.
         */
        internal DataTable getDesayunos(String estacion, String inicio, String final)
        {
            return controladoraComdiaEmpleado.getDesayunos(estacion, inicio, final);
        }

        /*
        * Requiere: hilera con el identificador de la estacion, de la fecha inicio, de la fecha final
        * Efectua : llama a getAlmuerzos de la controladora de comida de empleado. 
        * Retorna :  El datatable retornado por la controladora.
        */
        internal DataTable getAlmuerzos(String estacion, String inicio, String final)
        {
            return controladoraComdiaEmpleado.getAlmuerzos(estacion, inicio, final);
        }

        /*
        * Requiere: hilera con el identificador de la estacion, de la fecha inicio, de la fecha final
        * Efectua : llama a getAlmuerzos de la controladora de comida de empleado. 
        * Retorna :  El datatable retornado por la controladora.
        */
        internal DataTable getCenas(String estacion, String inicio, String final)
        {
            return controladoraComdiaEmpleado.getCenas(estacion, inicio, final);
        }

        /*
        * Requiere: hilera con el identificador de la estacion, de la fecha inicio, de la fecha final
        * Efectua : llama a getComidasCampo de la controladora de comida campo. 
        * Retorna :  El datatable retornado por la controladora.
        */
        internal DataTable getComidasCampo(String estacion, String inicio, String final)
        {
            return controladoraCC.getComidasCampo(estacion, inicio, final);
        }

        /*
        * Requiere: hilera con el identificador de la estacion, de la fecha inicio, de la fecha final
        * Efectua : llama a getComidasCampo de la controladora de comida extra. 
        * Retorna :  El datatable retornado por la controladora.
        */
        internal DataTable getComidasExtra(String estacion, String inicio, String final)
        {
            return controladoraCE.getComidasExtra(estacion, inicio, final);
        }

        /*
        * Requiere: hilera con el identificador de la estacion, de la fecha inicio, de la fecha final
        * Efectua : llama a getBebidas de la controladora de comida campo. 
        * Retorna :  El datatable retornado por la controladora.
        */
        internal DataTable getBebidas(String estacion, String inicio, String final)
        {
            return controladoraCC.getBebidas(estacion, inicio, final);
        }

        internal int getNotificaciones()
        {
            return controladoraNotificaciones.getNumeroDeNotificaciones();
        }
    }
}