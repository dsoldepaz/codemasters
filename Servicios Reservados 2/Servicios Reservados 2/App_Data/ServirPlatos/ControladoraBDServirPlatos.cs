using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;

namespace Servicios_Reservados_2
{
    public class ControladoraBDServirPlatos
    {
        private AdaptadorServirPlatos adaptador;
        DataTable dt;
        /*
         * Requiere: N/A
         * Efectúa : inicializa las variables globales de la clase
         * retorna : N/A
         */
        public ControladoraBDServirPlatos()
        {
            adaptador = new AdaptadorServirPlatos();
            dt = new DataTable();
        }
        /*
         * Requiere: N/A
         * Efectúa : Obtiene la fecha actual. Crea la consulta para obtener las cosultas activas con la fecha actual. Guarda en una tabla de datos el resultado a la consulta al adaptador.
         * Retorna : la tabla de datos con el resultado de la consulta.
         */
        internal DataTable consultarTiquete(int numTiquete)
        {
            String consultaSQL = "SELECT r.cuentaclientekey, r.siglas, r.estacion, r.notas FROM RESERVAS.VR_RESERVACION r";
            dt = adaptador.consultar(consultaSQL);

            return dt;
        }
      

    }
}