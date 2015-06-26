using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraBDReportes
    {
        AdaptadorBD adaptador = new AdaptadorBD();

        internal DataTable cargarEstaciones()
        {
            DataTable estaciones;
            String consultaSQL = "select nombre from reservas.estacion";
            estaciones = adaptador.consultar(consultaSQL);
            return estaciones;
        }

        internal DataTable obtenerComidaPax(String estacion, int opcion, int anfitriona, String fecha, String fechaFinal)
        {
            DataTable comidaCampo;

            String consultaSQL = "select distinct campo.fecha, sum(campo.pax), sum(vecesconsumido) from (reservas.vr_reservacion vista JOIN reservas.reservacion reserva ON vista.numero = reserva.numero) JOIN comida_campo campo ON reserva.id = campo.idreservacion WHERE opcion = " + opcion + " and vista.estacion = '" + estacion + "' and vista.idanfitriona = " + anfitriona + " and to_date(campo.fecha, 'MM/dd/yyyy') <= to_date('" + fechaFinal + "', 'MM/dd/yyyy') and to_date(campo.fecha, 'MM/dd/yyyy') >= to_date('" + fecha + "', 'MM/dd/yyyy') group by campo.fecha";
            comidaCampo = adaptador.consultar(consultaSQL);
            return comidaCampo;
        }
        internal DataTable obtenerComidaPaxEmp(String estacion, int opcion, String fecha, String fechaFinal)
        {
            DataTable comidaCampoEmp;

            String consultaSQL = "select sum(pax), sum(vecesconsumido) from comida_campo where estacion = '" + estacion + "' and opcion = " + opcion + " and to_date(fecha, 'MM/dd/yyyy') <= to_date('" + fechaFinal + "', 'MM/dd/yyyy') and to_date(fecha, 'MM/dd/yyyy') >= to_date('" + fecha + "', 'MM/dd/yyyy') and idempleado is not null";
            comidaCampoEmp = adaptador.consultar(consultaSQL);
            return comidaCampoEmp;
        }

        internal DataTable obtenerComidaEmp(String estacion, String opcion, String fecha, String fechaFinal)
        {
            DataTable comidaCampoEmp;

            String consultaSQL = "select count(" + opcion + "), count(vecesconsumido) from reserva_empleado where " + opcion + " = 'R' and fecha >= to_date('" + fecha + "', 'mm/dd/yyyy') and fecha <= to_date('" + fechaFinal + "', 'mm/dd/yyyy') and estacion ='" + estacion + "'";
            comidaCampoEmp = adaptador.consultar(consultaSQL);
            return comidaCampoEmp;
        }

        internal DataTable obtenerComidaExtraFechas(String opcion, String fecha, String fechaFinal)
        {
            DataTable comidaExtra;

            String consultaSQL = "select sum(s.pax), sum(s.vecesconsumido) from servicio_especial s join servicios_extras se on se.idservicio = s.idserviciosextras where to_date(s.fecha,'mm/dd/yyyy') < to_date('" + fecha + "','mm/dd/yyyy') and" +
            "to_date(s.fecha,'mm/dd/yyyy') < to_date('" + fechaFinal + "','mm/dd/yyyy') and se.tipo = '" + opcion + "'";
            comidaExtra = adaptador.consultar(consultaSQL);
            return comidaExtra;
        }

        internal DataTable obtenerComidaExtraEstacionAnfitrionaFecha(String estacion, String opcion, int anfitriona, String fecha, String fechaFinal)
        {
            DataTable comidaExtra;

            String consultaSQL = "select sum(s.pax), sum(s.vecesconsumido) from ((RESERVAS.reservacion r join RESERVAS.vr_reservacion vr on r.numero = vr.numero ) join servicio_especial s on s.idreservacion = r.id) join " +
                "servicios_extras se on se.idservicio = s.idserviciosextras where to_date(s.fecha,'mm/dd/yyyy') < to_date('" + fecha + "','mm/dd/yyyy') and" +
                "to_date(s.fecha,'mm/dd/yyyy') < to_date('" + fechaFinal + "','mm/dd/yyyy') and r.anfitriona=" + anfitriona + " and vr.estacion = '" + estacion + "' and se.tipo = '" + opcion + "'";

            comidaExtra = adaptador.consultar(consultaSQL);
            return comidaExtra;
        }

        internal DataTable obtenerComidaExtraEstacionFecha(String estacion, String opcion, String fecha, String fechaFinal)
        {
            DataTable comidaExtra;

            String consultaSQL = "select sum(s.pax), sum(s.vecesconsumido) from ((RESERVAS.reservacion r join RESERVAS.vr_reservacion vr on r.numero = vr.numero ) join servicio_especial s on s.idreservacion" +
                "= r.id) join servicios_extras se on se.idservicio = s.idserviciosextras where to_date(s.fecha,'mm/dd/yyyy') < to_date('" + fecha + "','mm/dd/yyyy') and" +
                "to_date(s.fecha,'mm/dd/yyyy') < to_date('" + fechaFinal + "','mm/dd/yyyy') and vr.estacion = '" + estacion + "' and se.tipo = '" + opcion + "'";

            comidaExtra = adaptador.consultar(consultaSQL);
            return comidaExtra;
        }

        internal DataTable obtenerComidaExtraAnfitrionaFecha(String opcion, int anfitriona, String fecha, String fechaFinal)
        {
            DataTable comidaExtra;

            String consultaSQL = "select sum(s.pax), sum(s.vecesconsumido) from (servicio_especial s join RESERVAS.reservacion r on s.idreservacion = r.id)join servicios_extras se on se.idservicio =" +
            "s.idserviciosextras where to_date(s.fecha,'mm/dd/yyyy') < to_date('" + fecha + "','mm/dd/yyyy') and" +
            "to_date(s.fecha,'mm/dd/yyyy') < to_date('" + fechaFinal + "','mm/dd/yyyy') and r.anfitriona=" + anfitriona + " and se.tipo = '" + opcion + "'";

            comidaExtra = adaptador.consultar(consultaSQL);
            return comidaExtra;
        }

    }
}