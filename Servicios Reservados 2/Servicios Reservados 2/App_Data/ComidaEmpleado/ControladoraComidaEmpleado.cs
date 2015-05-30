﻿using Servicios_Reservados_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;

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
        public String[] agregar(String idEmpleado, List<DateTime> fechasReserva, char[] turnos, bool pagado, String notas)
        {
            EntidadComidaEmpleado nuevo = new EntidadComidaEmpleado(idEmpleado, fechasReserva, turnos, pagado, notas, -1);
            return controladoraBD.agregar(nuevo);
        }

        internal void modificar(EntidadComidaEmpleado seleccionada, string idEmpleado, List<DateTime> fechasReserva, char[] turnos, bool pagado, String notas)
        {
            EntidadComidaEmpleado nuevo = new EntidadComidaEmpleado(idEmpleado, fechasReserva, turnos, pagado, notas, seleccionada.IdComida);
            controladoraBD.modificar(seleccionada, nuevo);
        }

        internal EntidadComidaEmpleado consultar(int idReservacion)
        {
            List<DateTime> list = new List<DateTime>();
            char[] turnos = new char[3];
            DataTable dt = controladoraBD.getInformacionReservacionEmpleado(idReservacion);
            //IDEMPLEADO, FECHA, PAGADO, NOTAS, DESAYUNO, ALMUERZO, CENA, IDCOMIDAEMPLEADO

            //list.Add(DateTime.ParseExact(dt.Rows[0][1].ToString(), "g", System.Globalization.CultureInfo.InvariantCulture));//{8/20/2015 12:00:00 AM}
            turnos[0] = dt.Rows[0][4].ToString().ToCharArray(0, 1)[0];
            turnos[1] = dt.Rows[0][5].ToString().ToCharArray(0, 1)[0];
            turnos[2] = dt.Rows[0][6].ToString().ToCharArray(0, 1)[0];
            bool pagado = (dt.Rows[0][2].ToString().Equals("T"));
            String notas = dt.Rows[0][3].ToString();
            DateTime fecha; 
            DateTime.TryParse(dt.Rows[0][1].ToString(),out fecha);
            list.Add(fecha);
            EntidadComidaEmpleado consultada = new EntidadComidaEmpleado(dt.Rows[0][0].ToString(), list, turnos, pagado, notas, Int32.Parse(dt.Rows[0][7].ToString()));
            //String idEmpleado, List<DateTime> fechasReserva, bool[] turnos, bool pagado, String notas, int id = -1
            return consultada;
        }

        internal void eliminar(EntidadComidaEmpleado entidadComidaEmpleado)
        {
            controladoraBD.cancelar(entidadComidaEmpleado);
        }

        internal DataTable getComidaEmpleado(string idEmpleado)
        {
            return controladoraBD.getReservacionesEmpleado(idEmpleado);
        }
    }
}