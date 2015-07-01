using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraBDNotificaciones
    {
        private AdaptadorBD adaptador;
        public ControladoraBDNotificaciones()
        {
            adaptador = new AdaptadorBD();
        }
        public DataTable numeroDeNotificaciones(String ultima)
        {
            String consulta = "Select COUNT (*)  From notificaciones Where momento> CURRENT_TIMESTAMP-interval '18' hour (1) AND NUMERODENOTIFICACION > " + ultima;
            DataTable resultado = adaptador.consultar(consulta);
            return resultado;
        }
        /*
         * Requiere:N/A
         * Efectua : Pide al adaptador las notificaciones de las comidas entre las ultimas 12 horas y las proximas 12 horas.
         * Retorna : un data table con las notificaciones.
         */
        internal DataTable getNotificaciones(String ultima)
        {
            string consulta = "SELECT MOMENTO, ESTACION, TIPODESERVICIO, TIPODECAMBIO, VALORANTERIOR, VALORACTUAL, IDSERVICIO FROM servicios_reservados.Notificaciones Where momento> CURRENT_TIMESTAMP-interval '18' hour (1)";
            return adaptador.consultar(consulta);
        }

        //
        public DataTable numeroUltimaNotificacion()
        {
            String consulta = "Select max (NUMERODENOTIFICACION) From servicios_reservados.Notificaciones";
            DataTable resultado = adaptador.consultar(consulta);
            return resultado;
        }

    }
}