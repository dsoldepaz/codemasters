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
    public class ControladoraComidaEmpleado
    {
        private ControladoraEmpleado controlEmpleado = new ControladoraEmpleado();
        private ControladoraBDComidaEmpleado controladoraBD = new ControladoraBDComidaEmpleado();

        public EntidadEmpleado getInformacionDelEmpleado(String idEmpleado)
        {
            controlEmpleado.seleccionarEmpleado(idEmpleado);
            return controlEmpleado.getEmpleadoSeleccionado();
        }
        public void agregar(String idEmpleado, List<DateTime> fechasReserva, bool[] turnos)
        {
            EntidadComidaEmpleado nuevo = new EntidadComidaEmpleado( idEmpleado,  fechasReserva, turnos, false);
            controladoraBD.agregar(nuevo);
        }

        internal void modificar(EntidadComidaEmpleado seleccionada, string idEmpleado, List<DateTime> fechasReserva, bool[] turnos)
        {
            EntidadComidaEmpleado nuevo = new EntidadComidaEmpleado(idEmpleado, fechasReserva, turnos,false);
            controladoraBD.modificar(seleccionada, nuevo);
        }

        internal EntidadComidaEmpleado consultar(string p, DateTime fechaElegida)
        {
            List<DateTime> list = new List<DateTime>();
            list.Add(fechaElegida);
            bool [] turnos = new bool[3];
            DataTable dt= controladoraBD.getTurnosCancelado(p, fechaElegida);

            turnos[0]= (dt.Rows[0][0].ToString().Equals("R")||dt.Rows[0][0].ToString().Equals("C"));
            turnos[1]= (dt.Rows[0][1].ToString().Equals("R")||dt.Rows[0][1].ToString().Equals("C"));
            turnos[2]= (dt.Rows[0][2].ToString().Equals("R")||dt.Rows[0][2].ToString().Equals("C"));

            bool pagado = (dt.Rows[0][3].ToString().Equals("T"));
            EntidadComidaEmpleado consultada= new EntidadComidaEmpleado(p, list,turnos, pagado);
            return consultada;
        }
    }
}