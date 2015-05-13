using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Diagnostics;

namespace Servicios_Reservados_2
{
    public class ControladoraBDComidaCampo
    {
        private AdaptadorComidaCampo adaptador;
        DataTable dt;

        public ControladoraBDComidaCampo()
        {
            adaptador = new AdaptadorComidaCampo();
            dt = new DataTable();
        }


    }
}