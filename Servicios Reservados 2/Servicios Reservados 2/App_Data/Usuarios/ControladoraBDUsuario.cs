using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;

namespace Servicios_Reservados_2
{
    public class ControladoraBDUsuario
    {
        private AdaptadorBD adaptador;
        DataTable dt;
    /*
     * Requiere: N/A
     * Efectúa : inicializa las variables globales de la clase
     * retorna : N/A
     */
        public ControladoraBDUsuario()
        {
            adaptador = new AdaptadorBD();
            dt = new DataTable();
        }

        internal DataTable obtenerRolesDisponibles()
        {
            dt = new DataTable();
            String consultaSQL = "select nombre from rol";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        internal DataTable obtenerRolesAsignados()
        {
            dt = new DataTable();
            String consultaSQL = "select rol from usuariorol";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }
    }
}