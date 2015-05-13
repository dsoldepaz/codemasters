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
      private ControladoraBDComidaExtra controladoraBD;//instancia de la controladora de BD comida extra.
      public static EntidadReservaciones servicios;
      public static ControladoraReservaciones controladoraReserv;
       
      public static EntidadComidaExtra servicioSeleccionado;//instancia entidad comida extra.
      public static int paxSeleccionados;
       
      public ControladoraComidaExtra()
        {
            controladoraBD = new ControladoraBDComidaExtra();
            controladoraReserv = new ControladoraReservaciones();
        }
      /*
         * Efecto: solicita a la controladora de BD los diferentes tipos de comida extra.
         * Requiere: 
         * Modifica: 
        */
      public DataTable solicitarTipo() {
          DataTable tipos = controladoraBD.solicitarTipos();
          return tipos;
      }

      /*
       * Efecto: encapsula los datos y los envía a la controladora para que sean insertados.
       * Requiere: un objeto con los datos.
       * Modifica: pasa los datos de un objeto a una entidad (encapsularlos).
      */
      public String[] agregarServicioExtra(Object[] datos)
      {
          EntidadComidaExtra entidad = new EntidadComidaExtra(datos);
          String[] resultado = controladoraBD.agregarServicioExtra(entidad);//llamado a la controladora de base de datos
          return resultado;
      }

      /*
       * Efecto: encapsula los datos de la entidad y los envía a la controladora para que sean insertados.
       * Requiere: un objeto con los datos y la entidad vieja a modificar.
       * Modifica: pasa los datos de un objeto a una entidad (encapsularlos).
      */
      public String[] modificarServicioExtra(Object[] datos, EntidadComidaExtra entidadVieja)
      {
          EntidadComidaExtra entidad = new EntidadComidaExtra(datos);
          String[] resultado = controladoraBD.modificarServicioExtra(entidad, entidadVieja);//llamado a la controladora de base de datos
          return resultado;
      }

      /*
       * Efecto: recibe los ids y los manda a la controladora de BD para eliminar el servicio.
       * Requiere: los ids.
       * Modifica:
      */
      public String[] eliminarServicioExtra(String idReservacion, String idComidaExtra) 
      {
          String[] resultado = controladoraBD.eliminarServicioExtra(idReservacion, idComidaExtra);
          return resultado;
      }

      /*
       * Efecto: obtener el id de la reservación consultada.
       * Requiere: la consulta de una reservación.
       * Modifica: la variable servicios.
      */
      public EntidadReservaciones informacionServicio()
      {
          servicios = controladoraReserv.getReservacionSeleccionada();
          return servicios;

      }

      /*
       * Efecto: comuncación con la controladora de servicios para guardar el servicio seleccionado.
       * Requiere: la entrada de los datos.
       * Modifica: la variable servicioSeleccionado, en la que se almacena el servicio consultado.
      */
      public void guardarServicioSeleccionado(Object[] dato)
      {
          servicioSeleccionado = new EntidadComidaExtra(dato);
      }

      /*
       * Efecto: comuncación con la controladora de servicios para guardar los pax de la reservación seleccionada.
       * Requiere: la entrada de los datos.
       * Modifica: la variable paxSeleccionados, en la que se almacena el servicio consultado.
       */
      public void guardarPaxsSeleccionado(int pax)
      {
          paxSeleccionados = pax;
      }

      /*
       * Efecto: devuelve la entidad consultada.
       * Requiere: que la entidad esté inicializada.
       * Modifica: 
      */
      public EntidadComidaExtra servicioSeleccionados()
      {
          return servicioSeleccionado;
      }

      /*
       * Efecto: devuelve loa pax consultados.
       * Requiere: que la variable pax esté inicializada.
       * Modifica: 
       */
      public int paxSeleccionado()
      {
          return paxSeleccionados;
      }


      /*
       * Efecto: consulta el tipo de comida extra de un id específico.
       * Requiere: que la entidad esté inicializada.
       * Modifica: el datatable aux, que se llena con el tipo seleccionado. 
      */
        public String consultarTipo(String id)
        {
            DataTable aux = controladoraBD.consultarTipo(id);
            return aux.Rows[0][0].ToString();
        }
    }
}