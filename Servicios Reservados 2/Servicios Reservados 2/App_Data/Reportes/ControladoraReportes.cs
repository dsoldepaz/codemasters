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
        ControladoraNotificaciones controladoraNotificaciones = new ControladoraNotificaciones();
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
         * Efecto: consulta las comida de campo de una reservacion con filtros de estacion, anfitriona, y fechas.
         * Requiere: los valores de los filtros a aplicar
         * Modifica : la consulta que se pide a la base de datos.
         */
        internal DataTable obtenerComidaPax(String estacion, int opcion,  int anfitriona, String fecha, String fechaFinal)
        {
           return controladoraBD.obtenerComidaPax(estacion, opcion, anfitriona, fecha, fechaFinal);
        }

        /* 
         * Efecto: consulta las comida de campo de una reservacion con filtros de esatcion, y fechas.
         * Requiere: los valores de los filtros a aplicar
         * Modifica : la consulta que se pide a la base de datos. 
       */
        internal DataTable obtenerComidaPaxEstacionFechas(String estacion, int opcion, String fecha, String fechaFinal)
        {
            return controladoraBD.obtenerComidaPaxEstacionFecha(estacion, opcion,fecha, fechaFinal);
        }

        /* 
           * Efecto: consulta las comida de campo de una reservacion con filtros de anfitriona, y fechas.
           * Requiere: los valores de los filtros a aplicar
           * Modifica : la consulta que se pide a la base de datos. 
         */
        internal DataTable obtenerComidaPaxAnfitrionaFecha(int opcion, int anfitriona, String fecha, String fechaFinal)
        {
            return controladoraBD.obtenerComidaPaxAnfitrionaFecha(opcion, anfitriona, fecha, fechaFinal);
        }

        /* 
           * Efecto: consulta las comida de campo de una reservacion con filtros de fechas.
           * Requiere: los valores de los filtros a aplicar
           * Modifica : la consulta que se pide a la base de datos. 

   */
        internal DataTable obtenerComidaPaxFechas(int opcion, String fecha, String fechaFinal)
        {
            return controladoraBD.obtenerComidaPaxFechas(opcion, fecha, fechaFinal);
        }


        /* 
           * Efecto: consulta las comida de campo de un empleado con filtros de fechas.
           * Requiere: los valores de los filtros a aplicar
           * Modifica : la consulta que se pide a la base de datos. 

         */
        internal DataTable obtenerComidaPaxEmpFechas(int opcion, String fecha, String fechaFinal)
        {
            return controladoraBD.obtenerComidaPaxEmpFechas(opcion, fecha, fechaFinal);
        }

        /* 
        * Efecto: consulta las comida de empleado con filtros de estacion, anfitriona, y fechas.
        * Requiere: los valores de los filtros a aplicar
        * Modifica : la consulta que se pide a la base de datos. 
        */
        internal DataTable obtenerComidaPaxEmp(String estacion, int opcion, String fecha, String fechaFinal)
        {
            return controladoraBD.obtenerComidaPaxEmp(estacion, opcion, fecha, fechaFinal);
        }
        /* 
        * Efecto: consulta las comida de empleado con filtros de estacion, anfitriona y  fechas.
        * Requiere: los valores de los filtros a aplicar
        * Modifica : la consulta que se pide a la base de datos. 
         */
        internal DataTable obtenerComidaEmp(String estacion, String opcion, String fecha, String fechaFinal)
        {
            return controladoraBD.obtenerComidaEmp(estacion, opcion, fecha, fechaFinal);
        }
        /* 
        * Efecto: consulta las comida de empleado con filtros de fechas.
        * Requiere: los valores de los filtros a aplicar
        * Modifica : la consulta que se pide a la base de datos. 
         */
        internal DataTable obtenerComidaEmpFechas(String opcion, String fecha, String fechaFinal)
        {
            return controladoraBD.obtenerComidaEmpFechas(opcion, fecha, fechaFinal);
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

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica: 
         */
        internal int getNotificaciones()
        {
            return controladoraNotificaciones.getNumeroDeNotificaciones();
        }

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica: 
         */
        internal DataTable solicitarTurnoDiaTresComidas(String sigla, String inicio, String final)
        {
            return controladoraBD.solicitarTurnoDiaTresComidas(sigla, inicio, final);
        }

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica: 
         */
        internal DataTable solicitarTurnoDiaDosComidas(String sigla, String inicio, String final)
        {
            return controladoraBD.solicitarTurnoDiaDosComidas(sigla, inicio, final);
        }

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica: 
         */
        internal DataTable reservaEntrante(String sigla, String inicio, String final)
        {
            return controladoraBD.reservaEntrante(sigla, inicio, final);
        }
    }
}