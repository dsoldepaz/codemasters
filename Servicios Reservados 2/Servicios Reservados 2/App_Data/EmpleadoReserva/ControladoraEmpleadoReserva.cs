using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraEmpleadoReserva
    {
        private ControladoraEmpleado controladoraEmpleado;
        private ControladoraComidaEmpleado controladoraComidaEmpleado;
        private ControladoraComidaCampo controladoraComidaCampo;
        public ControladoraEmpleadoReserva()
        {
            controladoraEmpleado = new ControladoraEmpleado();
            controladoraComidaEmpleado = new ControladoraComidaEmpleado();
            controladoraComidaCampo = new ControladoraComidaCampo();
        }

        public DataTable obtenerTabla(String idEmpleado)
        {
            DataTable tabla = new DataTable();
            DataTable tablaComidaCampo = controladoraComidaCampo.getComidaEmpleado(idEmpleado);
            DataTable tablaComidaEmpleado = controladoraComidaEmpleado.getComidaEmpleado(idEmpleado);
            //hay que hacer el data table juntando los dos tipos de comida.
            return tabla;
        }
        public EntidadEmpleado obtenerEmpleado(string idEmpleado)
        {
            controladoraEmpleado.seleccionarEmpleado(idEmpleado);
            return controladoraEmpleado.getEmpleadoSeleccionado();
        }
    }
}