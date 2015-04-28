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
    public class ControladoraComidaExtra
    {
      private ControladoraBDComidaExtra controladoraBD;
      private ControladoraReservaciones controladoraBDreserv;
       
      public ControladoraComidaExtra()
        {
            controladoraBD = new ControladoraBDComidaExtra();
        }

      public DataTable solicitarTipo() {
          DataTable tipos = controladoraBD.solicitarTipos();
          return tipos;
      }

    
      public String[] agregarServicioExtra(Object[] datos)
      {
          EntidadComidaExtra entidad = new EntidadComidaExtra(datos);
          String[] resultado = controladoraBD.agregarServicioExtra(entidad);//llamado a la controladora de base de datos
          return resultado;
      }

      public String[] modificarServicioExtra(Object[] datos, EntidadComidaExtra entidadVieja)
      {
          EntidadComidaExtra entidad = new EntidadComidaExtra(datos);
          String[] resultado = controladoraBD.modificarServicioExtra(entidad, entidadVieja);//llamado a la controladora de base de datos
          return resultado;
      }

    }

}