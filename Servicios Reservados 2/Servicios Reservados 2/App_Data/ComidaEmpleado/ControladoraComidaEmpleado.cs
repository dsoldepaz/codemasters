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
        public void agregar(String idEmpleado, List<DateTime> fechasReserva, bool[] turnos, bool pagado, String notas)
        {
            EntidadComidaEmpleado nuevo = new EntidadComidaEmpleado( idEmpleado,  fechasReserva, turnos,   pagado,  notas);
            controladoraBD.agregar(nuevo);
        }

        internal void modificar(EntidadComidaEmpleado seleccionada, string idEmpleado, List<DateTime> fechasReserva, bool[] turnos, bool pagado, String notas)
        {
            EntidadComidaEmpleado nuevo = new EntidadComidaEmpleado(idEmpleado, fechasReserva, turnos, pagado, notas);
            controladoraBD.modificar(seleccionada, nuevo);
        }

        internal EntidadComidaEmpleado consultar(int idReservacion)
        {
            List<DateTime> list = new List<DateTime>();
            bool [] turnos = new bool[3];
            DataTable dt = controladoraBD.getInformacionReservacionEmpleado(idReservacion);
            //IDEMPLEADO, FECHA, PAGADO, NOTAS, DESAYUNO, ALMUERZO, CENA, IDCOMIDAEMPLEADO

            turnos[0]= (dt.Rows[0][4].ToString().Equals("R")||dt.Rows[0][0].ToString().Equals("C"));
            turnos[1]= (dt.Rows[0][5].ToString().Equals("R")||dt.Rows[0][1].ToString().Equals("C"));
            turnos[2]= (dt.Rows[0][6].ToString().Equals("R")||dt.Rows[0][2].ToString().Equals("C"));

            bool pagado = (dt.Rows[0][3].ToString().Equals("T"));
            String notas =dt.Rows[0][4].ToString();
            EntidadComidaEmpleado consultada= new EntidadComidaEmpleado(id, list,turnos, pagado, notas);
            return consultada;
        }

        internal void eliminar(EntidadComidaEmpleado entidadComidaEmpleado)
        {
            throw new NotImplementedException();
        }

        internal DataTable getComidaEmpleado(string idEmpleado)
        {
            return controladoraBD.getReservacionesEmpleado(idEmpleado);
        }
    }
}