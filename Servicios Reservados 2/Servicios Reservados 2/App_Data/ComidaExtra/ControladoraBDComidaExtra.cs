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

        internal DataTable solicitarTipos() {
            String consultaSQL = "select IDSERVICIO, tipo from Servicios_Extras";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        internal DataTable consultarTipo(String id)
        {
            String consultaSQL = "select tipo from Servicios_Extras where idServicio = '" + id +"'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }


        public String[] agregarServicioExtra(EntidadComidaExtra entidad)
        {
            String[] respuesta = new String[3];
            try
            {
                String consultaSQL = "insert into servicio_especial values('" + entidad.IdReservacion + "','" + entidad.IdServiciosExtras + "'," + 
                    entidad.Pax + ",'" + entidad.Fecha + "','" + entidad.Consumido + "','" + entidad.Descripcion + "','" + entidad.Hora + "')";
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

        public String[] modificarServicioExtra(EntidadComidaExtra entidad, EntidadComidaExtra entidadVieja)
        {
            String[] respuesta = new String[3];
            try
            {
                String consultaSQL = "update servicio_especial set pax =" + "'" + entidad.Pax + "', fecha = '"+ entidad.Fecha + "', consumido = '" + entidad.Consumido + "', descripcion = '" + entidad.Descripcion + "', hora = '" + entidad.Hora + "'" +
                                      "where idreservacion = '" + entidadVieja.IdReservacion + "' and idserviciosextras = '" + entidadVieja.IdServiciosExtras + "';"; 

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

        public String[] eliminarServicioExtra(String idReservacion, String idComidaExtra)
        {
            String[] respuesta = new String[3];
            try
            {
                String consultaSQL = "delete servicio_especial where idReservacion =" + idReservacion + "and idserviciosextras = " + idComidaExtra;

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

    }
}