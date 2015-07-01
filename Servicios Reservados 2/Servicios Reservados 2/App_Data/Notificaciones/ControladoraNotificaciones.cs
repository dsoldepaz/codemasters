using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraNotificaciones
    {
        private ControladoraBDNotificaciones controladoraNotificaciones;
        


        public ControladoraNotificaciones()
        {
            controladoraNotificaciones = new ControladoraBDNotificaciones();
          
        }

        /*
         * Requiere: N/A
         * Efectua : pide el conteo de notificaciones desde la ultima vez a la controladora de base de datos
         * Retorna : un entero con el numero de notificaciones.
         */
        public int getNumeroDeNotificaciones()
        {
            try { 
                DataTable resultado = controladoraNotificaciones.numeroDeNotificaciones(Notificaciones.ultimaRevision);
                int notificaiones = int.Parse(resultado.Rows[0][0].ToString());
                return notificaiones;
            }catch(Exception e){
                Debug.WriteLine(e.ToString());
                return 0;
            }
        }
        /*
         * Requiere:N/A
         * Efectua :Pide a la controladora de Base de datos las notificaciones de las ultimas 12 horas hasta las proximas 12 horas
         * Retorna :un Data table con las notificaciones
         */
        public DataTable getNotificaciones()
        {
            DataTable notif = controladoraNotificaciones.getNotificaciones(Notificaciones.ultimaRevision);
            Notificaciones.ultimaRevision = getUltimaNotificacion();
            return notif;
        }
        /*
         * Requiere: N/A
         * Efectua : Pide a la controladora el numero de la ultima notificacion consultada.
         * Retorna : un entero con el numero
         */
        private String getUltimaNotificacion()
        {
            DataTable resultado = controladoraNotificaciones.numeroUltimaNotificacion();
            String notificaciones = resultado.Rows[0][0].ToString();
            return notificaciones;
        }

    }
}