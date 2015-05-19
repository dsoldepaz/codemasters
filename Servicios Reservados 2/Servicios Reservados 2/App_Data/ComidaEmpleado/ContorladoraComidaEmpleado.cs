using Servicios_Reservados_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Servicios_Reservados_2
{
    public class ContorladoraComidaEmpleado
    {
        private ControladoraEmpleado controlEmpleado = new ControladoraEmpleado();
        private ControladoraBDComidaEmpleado controladoraBD = new ControladoraBDComidaEmpleado();
        public DataTable getComidasEmpleado(String idEmpleado)
        {
            return controladoraBD.getComidasEmpleado(idEmpleado);
        }
        public EntidadEmpleado getInformacionDelEmpleado(String idEmpleado)
        {
            controlEmpleado.seleccionarEmpleado(idEmpleado);
            return controlEmpleado.getEmpleadoSeleccionado();
        }
        public void agregar(String idEmpleado, List<DateTime> fechasReserva, bool[] turnos)
        {
            EntidadComidaEmpleado nuevo = new EntidadComidaEmpleado( idEmpleado,  fechasReserva, turnos);
            controladoraBD.agregar(nuevo);
        }

        internal void modificar(EntidadComidaEmpleado seleccionada, string idEmpleado, List<DateTime> fechasReserva, bool[] turnos)
        {
            EntidadComidaEmpleado nuevo = new EntidadComidaEmpleado(idEmpleado, fechasReserva, turnos);
            controladoraBD.modificar(seleccionada, nuevo);
        }
    }
}