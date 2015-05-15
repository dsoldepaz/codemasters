using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;

namespace Servicios_Reservados_2.Servicios
{
    public class ControladoraBDServicios
    {
         
        private AdaptadorServicios adaptador;
        DataTable dt;

        public ControladoraBDServicios()
        {
            adaptador = new AdaptadorServicios();
            dt = new DataTable();
        }

        /**Efecto: Crea la consulta SQL que obtiene el numero de pax de la reservacion y la retorna en forma de datatable  
         * Requiere: id de la reservacion
         * Modifica: el dataTable dt
         */
        internal DataTable obtenerPax(String idNum)
        {
            String consultaSQL = "select PAX from reservas.vr_reservacion where numero = '" + idNum + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;

        }
        /**Efecto: Crea la consulta SQL que obtiene las tuplas de los servicios de una reservacion y la retorna en forma de datatable  
         * Requiere: id de la reservaciones 
         * Modifica: el dataTable dt
         */
        internal DataTable solicitarServicios(String id)
        {
            String consultaSQL = "select s.idreservacion, e.idservicio, e.tipo, s.descripcion, s.hora, s.fecha, s.consumido, s.pax from servicios_reservados.servicio_especial s JOIN servicios_reservados.servicios_extras e ON e.idservicio = s.idserviciosextras AND s.idreservacion= '" + id + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;

        }
        /**Efecto: Crea la consulta SQL que obtiene la tupla del servicio solicitado de la reservacion y la retorna en forma de datatable  
         * Requiere: id de la reservacion, id servicio
         * Modifica: el dataTable dt
         */
        internal DataTable seleccionarServicio(String id, String idserv)
        {
            String consultaSQL = "select * from servicios_reservados.servicio_especial where idreservacion = '" + id + "' and idserviciosextras = '" + idserv + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }
    }
}