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
      public static EntidadReservaciones servicios;
      public static ControladoraReservaciones controladoraReserv;
      FormComidaExtra formCE;

      public static EntidadComidaExtra servicioSeleccionado;
      public static Object[] datos;
       
      public ControladoraComidaExtra()
        {
            controladoraBD = new ControladoraBDComidaExtra();
            controladoraReserv = new ControladoraReservaciones();
            formCE = new FormComidaExtra();
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

      public String[] eliminarServicioExtra(String idReservacion, String idComidaExtra) 
      {
          String[] resultado = controladoraBD.eliminarServicioExtra(idReservacion, idComidaExtra);
          return resultado;
      }

      public EntidadReservaciones informacionServicio()
      {
          servicios = controladoraReserv.getReservacionSeleccionada();

          return servicios;

      }
      
        public void guardarServicioSeleccionado(Object[] dato)
        {
            servicioSeleccionado = new EntidadComidaExtra(dato);
            datos = dato;
        }

        public EntidadComidaExtra servicioSeleccionados()
        {
            return servicioSeleccionado;
        }

        public Object[] objeto()
        {
            return datos;
        }

        public String consultarTipo(String id)
        {
            DataTable aux = controladoraBD.consultarTipo(id);
            return aux.Rows[0][0].ToString();
        }
    }
}