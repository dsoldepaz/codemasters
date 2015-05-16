using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Diagnostics;

namespace Servicios_Reservados_2
{
    public class ControladoraBDComidaExtra
    {
        private AdaptadorComidaExtra adaptador;
        DataTable dt;

        public ControladoraBDComidaExtra()
        {
            adaptador = new AdaptadorComidaExtra();
            dt = new DataTable();
        }

        /*
         * Efecto: solicita el IdServicio y tipo desde la tabla Servicios_Extras.
         * Requiere:
         * Modifica: datatable que realiza la consulta. 
        */
        internal DataTable solicitarTipos() {
            String consultaSQL = "select IDSERVICIO, tipo from servicios_reservados.Servicios_Extras";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /*
         * Efecto: solicita el tipo desde la tabla Servicios_Extras de acuerdo al id del servicio seleccionado.
         * Requiere: el id del tipo seleccionado 
         * Modifica: datatable que realiza la consulta. 
        */
        internal DataTable consultarTipo(String id)
        {
            String consultaSQL = "select tipo from servicios_reservados.Servicios_Extras where idServicio = '" + id + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /*
        * Efecto: inserta en la table de servicio_especial los datos de la comida extra insertada
        * Requiere: la entidad de comida extra (datos encapsulados)
        * Modifica: la tabla servicio_especial 
       */
        public String[] agregarServicioExtra(EntidadComidaExtra entidad)
        {
            String[] respuesta = new String[3];
            try
            {
                String consultaSQL = "insert into servicios_reservados.servicio_especial values('" + entidad.IdReservacion + "','" + entidad.IdServiciosExtras + "'," +
                    entidad.Pax + ",'" + entidad.Fecha + "','" + entidad.Consumido + "','" + entidad.Descripcion + "','" + entidad.TipoPago + "','" + entidad.Hora + "')";

                adaptador.insertar(consultaSQL);
               
                respuesta[0] = "success";
                respuesta[1] = "Exito. ";
                respuesta[2] = "El usuario se ha insertado exitosamente";
            }
            catch (SqlException e)
            {
                int r = e.Number;

                if (r == 2627)
                {
                    
                    respuesta[0] = "danger";
                    respuesta[1] = "Error. ";
                    respuesta[2] = "Informacion ingresada ya existe";
                }
                else
                {
                    
                    respuesta[0] = "danger";
                    respuesta[1] = "Error. ";
                    respuesta[2] = "No se pudo agregar el servicio extra";
                }

            }
            return respuesta;
        }

        /*
        * Efecto: modifica los datos de la comida extra seleccionada.
        * Requiere: la entidad de comida extra modificada, y la entidad "vieja", la entidad consultada.
        * Modifica: la table de servicio_especial.
       */
        public String[] modificarServicioExtra(EntidadComidaExtra entidad, EntidadComidaExtra entidadVieja)
        {
            String[] respuesta = new String[3];
            try
            {
                String consultaSQL = "update servicios_reservados.servicio_especial set pax =" + "'" + entidad.Pax + "', fecha = '" + entidad.Fecha + "', estado = '" + entidad.Consumido + "', descripcion = '" + entidad.Descripcion + "', hora = '" + entidad.Hora + "', tipo_pago = '" + entidad.TipoPago + "', idserviciosextras = '" + entidad.IdServiciosExtras +"'" +
                                      "where idreservacion = '" + entidadVieja.IdReservacion + "' and idserviciosextras = '" + entidadVieja.IdServiciosExtras + "'";

                adaptador.insertar(consultaSQL);
               
                respuesta[0] = "success";
                respuesta[1] = "Exito. ";
                respuesta[2] = "El usuario se ha insertado exitosamente";
            }
            catch (SqlException e)
            {
                int r = e.Number;

                if (r == 2627)
                {
                    respuesta[0] = "danger";
                    respuesta[1] = "Error. ";
                    respuesta[2] = "Informacion ingresada ya existe";
                }
                else
                {
                    respuesta[0] = "danger";
                    respuesta[1] = "Error. ";
                    respuesta[2] = "No se pudo agregar el servicio extra";
                }
            }
            return respuesta;
        }

        /*
        * Efecto: elimina los datos seleccionados de la tabla de servicios_especial
        * Requiere: el id de la reservacion seleccionada y el id de la comida extra seleccionado.
        * Modifica: table de servicio_especial
       */
        public String[] eliminarServicioExtra(String idReservacion, String idComidaExtra)
        {
            String[] respuesta = new String[3];
            try
            {
                String consultaSQL = "update servicios_reservados.servicio_especial set consumido = 'Cancelado'  where idReservacion = '" + idReservacion + "' and idserviciosextras = '" + idComidaExtra + "'";

                adaptador.insertar(consultaSQL);

                respuesta[0] = "success";
                respuesta[1] = "Exito. ";
                respuesta[2] = "El usuario se ha insertado exitosamente";
            }
            catch (SqlException e)
            {
                int r = e.Number;

                if (r == 2627)
                {

                    respuesta[0] = "danger";
                    respuesta[1] = "Error. ";
                    respuesta[2] = "Informacion ingresada ya existe";
                }
                else
                {

                    respuesta[0] = "danger";
                    respuesta[1] = "Error. ";
                    respuesta[2] = "No se pudo agregar el servicio extra";
                }

            }
            return respuesta;
        }

        /*
         * Efecto: solicita las fechas de inicio y fin de una reservación específica.
         * Requiere: entrada del id.
         * Modifica: datatable que realiza la consulta. 
        */
        internal DataTable consultarFechas(String id)
        {
            String consultaSQL = "select entra, sale from reservas.reservacion where id='" + id + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }
    }
}