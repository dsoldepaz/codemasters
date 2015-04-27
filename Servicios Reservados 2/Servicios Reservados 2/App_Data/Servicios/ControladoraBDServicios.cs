using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

namespace Servicios_Reservados_2.Servicios
{
    public class ControladoraBDServicios
    {
         
        private AdaptadorServicios adaptador;
        DataTable dt;
        public ControladoraBDServicios()
        {
            adaptador = new AdaptadorServicios();
            dt = new DataTable();
        }
        internal DataTable prueba(String id) {

            dt = adaptador.prueba(id);            
            return dt;
        }


    }
}