using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraReportes
    {
        ControladoraBDReportes controladoraBD = new ControladoraBDReportes();

        internal DataTable cargarEstaciones()
        {
            return controladoraBD.cargarEstaciones();
        }


        internal DataTable obtenerComidaPax(String estacion, String anfitriona, String fecha)
        {
           return controladoraBD.obtenerComidaPax(estacion, anfitriona, fecha);
        }
    }
}