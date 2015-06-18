using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraReporteCocina
    {
        private static ControladoraBDReporteCocina controladoraBD;

        public ControladoraReporteCocina()
        {
            controladoraBD = new ControladoraBDReporteCocina();
        }
        internal DataTable solicitarTurnos(String sigla)
        {
            return controladoraBD.solicitarTurnos(sigla);
        }

        
    }
}