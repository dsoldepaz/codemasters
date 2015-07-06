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
         * Efecto: solicita a la base de datos los nombres de las estaciones.
         * Requiere: NA
         * Modifica : NA
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
        internal DataTable obtenerComidaPax(String estacion, int opcion, int anfitriona, String fecha, String fechaFinal)
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
            return controladoraBD.obtenerComidaPaxEstacionFecha(estacion, opcion, fecha, fechaFinal);
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
            return controladoraBD.obtenerComidaExtraAnfitrionaFecha(opcion, anfitriona, fecha, fechaFinal, consulta);
        }

        /* 
         * Efecto: envía a la BD los valores para realizar el filtro en un rango de fechas y por estación.
         * Requiere: la entrada de los atributos.
         * Modifica : 
         */
        internal DataTable obtenerComidaExtraEstacionFecha(String estacion, String opcion, String fecha, String fechaFinal, int consulta)
        {
            return controladoraBD.obtenerComidaExtraEstacionFecha(estacion, opcion, fecha, fechaFinal, consulta);
        }

        /* 
         * Efecto: envía a la BD los valores para realizar el filtro en un rango de fechas.
         * Requiere: la entrada de los atributos.
         * Modifica : 
         */
        internal DataTable obtenerComidaExtraFechas(String opcion, String fecha, String fechaFinal, int consulta)
        {
            return controladoraBD.obtenerComidaExtraFechas(opcion, fecha, fechaFinal, consulta);
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
         * Efecto: selecciona las tres comidas filtrando por estación y fecha.
         * Requiere: la entrada de los filtros.
         * Modifica: NA.
         */
        internal DataTable solicitarTurnoDiaTresComidasEstacionFecha(String sigla, String inicio, String final)
        {
            return controladoraBD.solicitarTurnoDiaTresComidasEstacionFecha(sigla, inicio, final);
        }

        /* 
         * Efecto: selecciona las dos comidas filtrando por estación y fecha.
         * Requiere: la entrada de los filtros.
         * Modifica: NA.
         */
        internal DataTable solicitarTurnoDiaDosComidasEstacionFecha(String sigla, String inicio, String final)
        {
            return controladoraBD.solicitarTurnoDiaDosComidasEstacionFecha(sigla, inicio, final);
        }

        /* 
         * Efecto: selecciona las reservas entrantes filtrando por estación y fecha.
         * Requiere: la entrada de los filtros.
         * Modifica: NA.
         */
        internal DataTable reservaEntranteEstacionFecha(String sigla, String inicio, String final)
        {
            return controladoraBD.reservaEntranteEstacionFecha(sigla, inicio, final);
        }

        /* 
         * Efecto: selecciona las tres comidas filtrando por anfitriona y fecha.
         * Requiere: la entrada de los filtros.
         * Modifica: NA.
         */
        internal DataTable solicitarTurnoDiaTresComidasAnfitrionaFecha(int anfitriona, String inicio, String final)
        {
            return controladoraBD.solicitarTurnoDiaTresComidasAnfitrionaFecha(anfitriona, inicio, final);
        }

        /* 
         * Efecto: selecciona las reservas entrantes filtrando por anfitriona y fecha.
         * Requiere: la entrada de los filtros.
         * Modifica: NA.
         */
        internal DataTable reservaEntranteAnfitrionaFecha(int anfitriona, String inicio, String final)
        {
            return controladoraBD.reservaEntranteAnfitrionaFecha(anfitriona, inicio, final);
        }

        /* 
         * Efecto: selecciona las dos comidas filtrando por anfitriona y fecha.
         * Requiere: la entrada de los filtros.
         * Modifica: NA.
         */
        internal DataTable solicitarTurnoDiaDosComidasAnfitrionaFecha(int anfitriona, String inicio, String final)
        {
            return controladoraBD.solicitarTurnoDiaDosComidasAnfitrionaFecha(anfitriona, inicio, final);
        }

        /* 
         * Efecto: selecciona las tres comidas filtrando por estación, anfitriona y fecha.
         * Requiere: la entrada de los filtros.
         * Modifica: NA.
         */
        internal DataTable solicitarTurnoDiaTresComidasEstacionAnfitrionaFecha(String sigla, String inicio, String final, int anfitriona)
        {
            return controladoraBD.solicitarTurnoDiaTresComidasEstacionAnfitrionaFecha(sigla, inicio, final, anfitriona);
        }

        /* 
         * Efecto: selecciona las reservas entrantes filtrando por estación, anfitriona y fecha.
         * Requiere: la entrada de los filtros.
         * Modifica: NA.
         */
        internal DataTable reservaEntranteEstacionAnfitrionaFecha(String sigla, String inicio, String final, int anfitriona)
        {
            return controladoraBD.reservaEntranteEstacionAnfitrionaFecha(sigla, inicio, final, anfitriona);
        }

        /* 
         * Efecto: selecciona las dos comidas filtrando por estación, anfitriona y fecha.
         * Requiere: la entrada de los filtros.
         * Modifica: NA.
         */
        internal DataTable solicitarTurnoDiaDosComidasEstacionAnfitrionaFecha(String sigla, String inicio, String final, int anfitriona)
        {
            return controladoraBD.solicitarTurnoDiaDosComidasEstacionAnfitrionaFecha(sigla, inicio, final, anfitriona);
        }

        /* 
         * Efecto: selecciona las tres comidas filtrando por fechas.
         * Requiere: la entrada de los filtros.
         * Modifica: NA.
         */
        internal DataTable solicitarTurnoDiaTresComidasFecha(String inicio, String final)
        {
            return controladoraBD.solicitarTurnoDiaTresComidasFecha(inicio, final);
        }

        /* 
         * Efecto: selecciona las reservas entrantes filtrando por fechas.
         * Requiere: la entrada de los filtros.
         * Modifica: NA.
         */
        internal DataTable reservaEntranteFecha(String inicio, String final)
        {
            return controladoraBD.reservaEntranteFecha(inicio, final);
        }

        /* 
         * Efecto: selecciona las dos comidas filtrando por fechas.
         * Requiere: la entrada de los filtros.
         * Modifica: NA.
         */
        internal DataTable solicitarTurnoDiaDosComidasFecha(String inicio, String final)
        {
            return controladoraBD.solicitarTurnoDiaDosComidasFecha(inicio, final);
        }
    }
}