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

        internal DataTable obtenerComidaPax(String estacion, String anfitriona, String fecha)
        {
            DataTable comidaCampo;
            String consultaSQL = "select SUM(campo.pax) from reservas.vr_reservacion vista JOIN reservas.reservacion reserva ON vista.numero = reserva.numero JOIN comida_campo campo ON reserva.id = campo.idreservacion WHERE opcion = 1 and vista.estacion = '" + estacion + "' and vista.idanfitriona = 1 and to_date(campo.fecha, 'mm/dd/yyyy') = '" + fecha + "' ";
            comidaCampo = adaptador.consultar(consultaSQL);
            return comidaCampo;

            
        }
    }
}