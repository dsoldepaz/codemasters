using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

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
        internal DataTable obtenerPax(String id)
        {
            String consultaSQL = "select PAX from reservacionItem where reservacion = '"+ id+ "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;

        }
        /**Efecto: Crea la consulta SQL que obtiene las tuplas de los servicios de una reservacion y la retorna en forma de datatable  
         * Requiere: id de la reservacion
         * Modifica: el dataTable dt
         */
        internal DataTable solicitarServicios(String id)
        {
            String consultaSQL = "select s.idreservacion, e.idservicio, e.tipo, s.descripcion, s.hora, s.fecha, s.consumido, s.pax from servicio_especial s JOIN servicios_extras e ON e.idservicio = s.idserviciosextras AND s.idreservacion= '" + id + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;

        }
        /**Efecto: Crea la consulta SQL que obtiene la tupla del servicio solicitado de la reservacion y la retorna en forma de datatable  
         * Requiere: id de la reservacion, id servicio
         * Modifica: el dataTable dt
         */
        internal DataTable seleccionarServicio(String id, String idserv)
        {
            String consultaSQL = "select * from servicio_especial where idreservacion = '" + id + "' and idserviciosextras = '" + idserv + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }
    }
}