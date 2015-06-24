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


        internal DataTable obtenerComidaPax(String estacion, int anfitriona, String fecha, String fechaFinal)
        {
           return controladoraBD.obtenerComidaPax(estacion, anfitriona, fecha, fechaFinal);
        }
        internal DataTable obtenerComidaPaxEmp(String estacion, String fecha, String fechaFinal)
        {
            return controladoraBD.obtenerComidaPaxEmp(estacion, fecha, fechaFinal);
        }
        internal DataTable obtenerComidaEmp(String estacion, String fecha, String fechaFinal)
        {
            return controladoraBD.obtenerComidaEmp(estacion, fecha, fechaFinal);
        }
        

    }
}