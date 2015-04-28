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
        

        internal DataTable obtenerPax(String id)
        {
            String consultaSQL = "select PAX from reservacionItem where reservacion = '"+ id+ "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;

        }

        internal DataTable solicitarServicios(String id)
        {
            String consultaSQL = "select s.idreservacion, e.tipo, s.descripcion, s.hora, s.fecha, s.consumido, s.pax from servicio_especial s JOIN servicios_extras e ON e.idservicio = s.idserviciosextras AND s.idreservacion= '" + id + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;

        }
    }
}