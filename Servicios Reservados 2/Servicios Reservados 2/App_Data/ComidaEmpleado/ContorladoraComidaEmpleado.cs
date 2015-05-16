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

namespace Servicios_Reservados_2
{
    public class ContorladoraComidaEmpleado
    {
        private ControladoraEmpleado controlEmpleado = new ControladoraEmpleado();
        public DataTable getComidasEmpleado(int idEmpleado)
        {
            //Hay que consultar en la base de datos.
            return new DataTable();
        }
        public EntidadEmpleado getInformacionDelEmpleado(String idEmpleado)
        {
            controlEmpleado.seleccionarEmpleado(idEmpleado);
            return controlEmpleado.getEmpleadoSeleccionado();
        } 

    }
}