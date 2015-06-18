using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraBDReporteCocina
    {
        private AdaptadorBD adaptador;
        DataTable dt;
        private DateTime fechaHoy;
        public ControladoraBDReporteCocina()
        {
            adaptador = new AdaptadorBD();
            dt = new DataTable();
        }

        internal DataTable solicitarTurnos(String sigla)
        {
            String fechaLocal = fechaHoy.ToString("MM/dd/yyyy");
            String consultaSQL2 = "select ri.id, vr.nombre, ri.pax from reservas.reservacionitem ri, reservas.v_reservable vr where ri.reservable= vr.id and vr.categoria='ANURA7249245184.5851916019'";
            String consultaSQL = "select r.id, v.siglas, v.estacion, v.numero, c.nombre, v.entra, v.sale FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.contacto c ON r.solicitante = c.id WHERE v.sale >= TO_DATE('" + fechaLocal + "','MM/dd/yyyy') and  v.estado = 'CNF' order by sale asc"; 
            return dt;
        }
    }
}