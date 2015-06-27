using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraReportes
    {
        ControladoraBDReportes controladoraBD = new ControladoraBDReportes();

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica : 
         */
        internal DataTable cargarEstaciones()
        {
            return controladoraBD.cargarEstaciones();
        }

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica : 
         */
        internal DataTable obtenerComidaPax(String estacion, int opcion,  int anfitriona, String fecha, String fechaFinal)
        {
           return controladoraBD.obtenerComidaPax(estacion, opcion, anfitriona, fecha, fechaFinal);
        }

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica : 
         */
        internal DataTable obtenerComidaPaxEmp(String estacion, int opcion, String fecha, String fechaFinal)
        {
            return controladoraBD.obtenerComidaPaxEmp(estacion, opcion, fecha, fechaFinal);
        }

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica : 
         */
        internal DataTable obtenerComidaEmp(String estacion, String opcion, String fecha, String fechaFinal)
        {
            return controladoraBD.obtenerComidaEmp(estacion,opcion, fecha, fechaFinal);
        }


        /* 
         * Efecto: envía a la BD los valores para realizar el filtro en un rango de fechas, anfitriona y estación.
         * Requiere: la entrada de los atributos.
         * Modifica : 
         */
        internal DataTable obtenerComidaExtraEstacionAnfitrionaFecha(String estacion, String opcion, int anfitriona, String fecha, String fechaFinal, int consulta)
        {
            return controladoraBD.obtenerComidaExtraEstacionAnfitrionaFecha(estacion, opcion, anfitriona, fecha, fechaFinal, consulta);
        }

        /* 
         * Efecto: envía a la BD los valores para realizar el filtro en un rango de fechas y por anfitriona.
         * Requiere: la entrada de los atributos.
         * Modifica : 
         */
        internal DataTable obtenerComidaExtraAnfitrionaFecha(String opcion, int anfitriona, String fecha, String fechaFinal, int consulta)
        {
            return controladoraBD.obtenerComidaExtraAnfitrionaFecha(opcion, anfitriona, fecha, fechaFinal,consulta);
        }

        /* 
         * Efecto: envía a la BD los valores para realizar el filtro en un rango de fechas y por estación.
         * Requiere: la entrada de los atributos.
         * Modifica : 
         */
        internal DataTable obtenerComidaExtraEstacionFecha(String estacion, String opcion, String fecha, String fechaFinal, int consulta)
        {
            return controladoraBD.obtenerComidaExtraEstacionFecha(estacion, opcion,fecha, fechaFinal, consulta);
        }

        /* 
         * Efecto: envía a la BD los valores para realizar el filtro en un rango de fechas.
         * Requiere: la entrada de los atributos.
         * Modifica : 
         */
        internal DataTable obtenerComidaExtraFechas(String opcion, String fecha, String fechaFinal, int consulta)
        {
            return controladoraBD.obtenerComidaExtraFechas(opcion, fecha, fechaFinal,consulta);
        }
    }
}