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
        /*
       * Requiere: hilera con la sigla de la estacion y la fecha
       * Efectua : llama a solicitarTurnosDiaTresComidasde de la controladora de base de datos de reportes de cocina 
       * Retorna :  El datatable retornado por la controladora con los datos de las reservaciones de 3 comidas.
       */
        internal DataTable solicitarTurnoDiaTresComidas(String sigla, String fecha)
        {
            return controladoraBD.solicitarTurnoDiaTresComidas(sigla, fecha);
        }
        /*
       * Requiere: hilera con la sigla de la estacion y la fecha
       * Efectua :  llama a solicitarTurnosDiaDosComidasde de la controladora de base de datos de reportes de cocina 
       * Retorna :  El datatable retornado por la controladora con los datos de las reservaciones de 2 comidas.
       */
        internal DataTable solicitarTurnoDiaDosComidas(String sigla, String fecha)
        {
            return controladoraBD.solicitarTurnoDiaDosComidas(sigla, fecha);
        }
        /*
       * Requiere: hilera con la sigla de la estacion y la fecha
       * Efectua :  llama a reservaEntrante de la controladora de base de datos de reportes de cocina 
       * Retorna :  El datatable retornado por la controladora con los datos de las reservaciones que entran en la fecha dada.
       */
        internal DataTable reservaEntrante(String sigla, String fecha)
        {
            return controladoraBD.reservaEntrante(sigla, fecha);
        }
        /*
       * Requiere: hilera con el identificador de la estacion, de la fecha inicio, de la fecha final
       * Efectua : llama a solicitarCE de la controladora de base de datos de reportes de cocina . 
       * Retorna :  El datatable retornado por la controladora con el conteo de comidas extra.
       */
        internal DataTable solicitarCE(String estacion, String inicio, String final)
        {
            return controladoraBD.solicitarCE(estacion,inicio,final);

        }
        /*
       * Requiere: hilera con el identificador de la estacion, de la fecha inicio, de la fecha final
       * Efectua : llama a solicitarCC de la controladora de base de datos de reportes de cocina . 
       * Retorna :  El datatable retornado por la controladora con el conteo de comidas de campo.
       */
        internal DataTable solicitarCC(String estacion, String inicio, String final)
        {
            return controladoraBD.solicitarCC(estacion, inicio, final);

        }
        /*
       * Requiere: hilera con el identificador de la estacion, de la fecha inicio, de la fecha final
       * Efectua : llama a solicitarBebidas de la controladora de base de datos de reportes de cocina.
       * Retorna :  El datatable retornado por la controladora con la informacion de las bebidas.
       */
        internal DataTable solicitarBebidas(String estacion, String inicio, String final)
        {
            return controladoraBD.solicitarBebidas(estacion, inicio, final);

        }
        /*
       * Requiere: hilera con el identificador de la estacion, de la fecha inicio, de la fecha final
       * Efectua : llama a solicitarAdicionales de la controladora de comida de empleado. 
       * Retorna :  El datatable retornado por la controladora con el conteo de adicionales.
       */
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