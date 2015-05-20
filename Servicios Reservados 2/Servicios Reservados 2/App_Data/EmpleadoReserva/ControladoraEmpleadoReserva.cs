using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraEmpleadoReserva
    {
        private ControladoraBDEmpleado controladoraEmpleado;
        private ControladoraComidaEmpleado controladoraComidaEmpleado;
        private ControladoraComidaCampo controladoraComidaCampo;

        public DataTable obtenerTabla(String idEmpleado)
        {
            //hay que hacer el data table juntando los dos tipos de comida.
            return new DataTable();
        }
    }
}