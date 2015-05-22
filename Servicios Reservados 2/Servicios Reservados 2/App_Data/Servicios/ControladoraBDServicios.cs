using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Servicios_Reservados_2.Servicios
{
    public class ControladoraBDServicios
    {

        private AdaptadorBD adaptador;
        DataTable dt;

        public ControladoraBDServicios()
        {
            adaptador = new AdaptadorBD();
            dt = new DataTable();
        }

        /**Efecto: Crea la consulta SQL que obtiene el numero de pax de la reservacion y la retorna en forma de datatable  
         * Requiere: id de la reservacion
         * Modifica: el dataTable dt
         */
        internal DataTable obtenerPax(String idNum)
        {
            String consultaSQL = "select PAX from reservas.vr_reservacion where numero = '" + idNum + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;

        }

        /*
         * Efecto: Crea la consulta SQL que obtiene el estado de una comida extra  
         * Requiere: id de la reservacion y id de la comida extra
         * Modifica: el dataTable dt
         */
        internal DataTable obtenerEstadoComidaExtra(String idReservacion, String idCE)
        {
            String consultaSQL = "select estado from servicios_reservados.servicio_especial where idreservacion = '" + idReservacion + "' and idserviciosextras = '" + idCE + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }


        /**Efecto: Crea la consulta SQL que obtiene el estado de una comida de campo  
         * Requiere: id de la comida de campo  
         * Modifica: el dataTable dt
         */
        internal DataTable obtenerEstadoComidaCampo(String idCC)
        {
            String consultaSQL = "select estado from servicios_reservados.comida_campo where idcomidacampo = '" + idCC + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /**Efecto: Crea la consulta SQL que obtiene las tuplas de los servicios de una reservacion y la retorna en forma de datatable  
         * Requiere: id de la reservaciones 
         * Modifica: el dataTable dt
         */
        internal DataTable solicitarServicios(String id)
        {
            String consultaSQL = "select s.idreservacion, e.idservicio, e.tipo, s.descripcion, s.hora, s.fecha, s.estado, s.pax from servicios_reservados.servicio_especial s JOIN servicios_reservados.servicios_extras e ON e.idservicio = s.idserviciosextras AND s.idreservacion= '" + id + "' and s.estado <>  'Cancelado'";
            dt = adaptador.consultar(consultaSQL);
            return dt;

        }

        internal DataTable solicitarComidaCampo(String id)
        {
            String consultaSQL = "select c.idcomidacampo, c.idreservacion, c.fecha, c.estado, c.opcion, c.relleno, c.pan, c.bebida, c.pax, c.hora from servicios_reservados.comida_campo c where c.idreservacion = '" + id + "' and c.estado <>  'Cancelado'";
            dt = adaptador.consultar(consultaSQL);
            return dt;

        }


        /**Efecto: Crea la consulta SQL que obtiene la tupla del servicio solicitado de la reservacion y la retorna en forma de datatable  
         * Requiere: id de la reservacion, id servicio
         * Modifica: el dataTable dt
         */
        internal DataTable seleccionarServicio(String id, String idserv)
        {
            String consultaSQL = "select * from servicios_reservados.servicio_especial where idreservacion = '" + id + "' and idserviciosextras = '" + idserv + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        internal DataTable seleccionarComidaCampo(String id, String idComidaCampo)
        {
            String consultaSQL = "select * from servicios_reservados.comida_campo WHERE idreservacion = '" + id + "' and idcomidacampo = '" + idComidaCampo + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        internal DataTable seleccionarAdicional(String idComidaCampo)
        {
            String consultaSQL = "select nombre from servicios_reservados.adicional WHERE idcomidacampo = '" + idComidaCampo + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /*
        * Efecto: actualiza el atributo estado de la tabla servicios_especiales de la comida extra seleccionada
        * Requiere: el id de la reservacion seleccionada y el id de la comida extra seleccionado.
        * Modifica: table de servicio_especial
       */
        public String[] cancelarComidaExtra(String idReservacion, String idComidaExtra)
        {
            String[] respuesta = new String[3];
            try
            {
                String consultaSQL = "update servicios_reservados.servicio_especial set estado = 'Cancelado'  where idReservacion = '" + idReservacion + "' and idserviciosextras = '" + idComidaExtra + "'";

                dt = adaptador.insertar(consultaSQL);

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
         * Efecto: actualiza el atributo estado de la tabla comida_campo de la comida de campo seleccionada
         * Requiere: el id de la reservacion seleccionada y el id de la comida extra seleccionado.
         * Modifica: table de servicio_especial
         */
        public String[] cancelarComidaCampo(String idCC)
        {
            String[] respuesta = new String[3];
            try
            {
                String consultaSQL = "update servicios_reservados.comida_campo set estado = 'Cancelado'  where idcomidacampo = '" + idCC + "'";

                dt = adaptador.insertar(consultaSQL);

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
        internal DataTable obtenerPaquete(string idReservacion)
        {
            String consultaSQL = "select ri.id, vr.nombre, ri.pax from reservas.reservacionitem ri, reservas.v_reservable vr where ri.reservacion ='" + idReservacion + "' and ri.reservable= vr.id and vr.categoria='ANURA7249245184.5851916019'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

    }
}