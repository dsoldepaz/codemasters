﻿using System;
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
        private AdaptadorBD adaptador;
        DataTable dt;

        public ControladoraBDComidaCampo()
        {
            adaptador = new AdaptadorBD();
            dt = new DataTable();
        }


        /*
        * Efecto: inserta la comida de campo selecionada en la tabla comida_campo.
        * Requiere: la entidad de la comida que se va a insertar
        * Modifica: table de comida_campo
        */
        public String[] agregarComidaCampo(EntidadComidaCampo entidad)
        {
            String[] respuesta = new String[3];
            String consultaSQL = "insert into servicios_reservados.comida_campo values('" + entidad.IdComidaCampo + "','" + entidad.IdEmpleado + "','" +
                entidad.IdReservacion + "','" + entidad.Fecha + "','" + entidad.Estado + "'," + entidad.Opcion + ",'" + entidad.Relleno + "','" + entidad.Pan + "','"
                + entidad.Bebida + "','" + entidad.TipoPago + "'," + entidad.Pax + ",'" + entidad.Hora + "', 0, '" + entidad.Estacion + "')";
            respuesta = adaptador.insertar(consultaSQL);
            List<String> lista = entidad.Adicionales;
            int cantAdicionales = lista.Count;
            if (cantAdicionales > 0)
            {
                String consultaId = "select MAX(idcomidacampo) from servicios_reservados.comida_campo";
                dt = adaptador.consultar(consultaId);
                int id = int.Parse(dt.Rows[0][0].ToString());
                Debug.WriteLine("id");
                for (int i = 0; i < cantAdicionales; i++)
                {
                    String insercion = "insert into servicios_reservados.adicional values(" + id + ",'" + lista[i] + "')";
                    respuesta = adaptador.insertar(insercion);
                }
            }
            return respuesta;
        }


        /*
     * Efecto: modifica la comida de campo selecionada en la tabla comida_campo.
     * Requiere: la entidad de la comida que se va a modificar y la entidad de la comida de campo consultada
     * Modifica: table de comida_campo
     */
        public String[] modificarComidaCampo(EntidadComidaCampo entidad, EntidadComidaCampo entidadVieja)
        {
            String[] respuesta = new String[3];
            String consultaSQL = "update servicios_reservados.comida_campo set idcomidacampo = '" + entidadVieja.IdComidaCampo + "', idempleado = '" + entidad.IdEmpleado + "', idreservacion = '" + entidad.IdReservacion + "', estado = '" + entidad.Estado + "', fecha = '" + entidad.Fecha + "', opcion = '" + entidad.Opcion + "', relleno = '" + entidad.Relleno + "', pan = '" + entidad.Pan + "', bebida = '" + entidad.Bebida + "', tipopago = '" + entidad.TipoPago + "', pax = '" + entidad.Pax + "', hora = '" + entidad.Hora + "', estacion = '" + entidad.Estacion + "' " +
                                      "where idcomidacampo = '" + entidadVieja.IdComidaCampo + "'";
            respuesta = adaptador.insertar(consultaSQL);
            String borrarAdicional = "delete from servicios_reservados.adicional where idcomidacampo = '" + entidadVieja.IdComidaCampo + "'";
            respuesta = adaptador.insertar(borrarAdicional);
            List<String> lista = entidad.Adicionales;
            int cant = entidad.Adicionales.Count();
            for (int i = 0; i < cant; i++)
            {
                String modAdicional = "insert into servicios_reservados.adicional values(" + entidadVieja.IdComidaCampo + ", '" + lista[i] + "')";
                respuesta = adaptador.insertar(modAdicional);
            }

            return respuesta;
        }



        /*
     * Efecto: consulta las comida de campo de un empleado
     * Requiere: el id del empleado a consultar.
     * Modifica: el grid donde se muestra la comida de campo
     */
        public DataTable getComidaEmpleado(String id)
        {
            String consultaSQL = "SELECT IDCOMIDACAMPO,'Comida de Campo', IDEMPLEADO, FECHA, TIPOPAGO, OPCION FROM servicios_reservados.COMIDA_CAMPO Where IDEMPLEADO = '" + id + "' and estado ='Activo'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }


     /*
     * Efecto: consulta las comida de campo de una reservación
     * Requiere: el id de la reservación y el id de la comida a consultar
     * Modifica: el grid de servicios donde se muestra la comida de campo
     */
        internal DataTable seleccionarComidaCampo(String id, String idComidaCampo)
        {
            String consultaSQL = "select * from servicios_reservados.comida_campo WHERE idreservacion = '" + id + "' and idcomidacampo = '" + idComidaCampo + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

       /*
     * Efecto: consulta las comida de campo de un empleado
     * Requiere: el id del empleado a consultar y el id de la comida.
     * Modifica: el grid donde se muestra la comida de campo
     */
        internal DataTable seleccionarComidaCampoEmpleado(String id, String idComidaCampo)
        {
            String consultaSQL = "select * from servicios_reservados.comida_campo WHERE idempleado = '" + id + "' and idcomidacampo = '" + idComidaCampo + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

      /*
     * Efecto: consulta los adicionales de una comida de campo.
     * Requiere: el id de la comida a consultar
     * Modifica: el grid donde se muestra la comida de campo
     */
        internal DataTable seleccionarAdicional(String idComidaCampo)
        {
            String consultaSQL = "select nombre from servicios_reservados.adicional WHERE idcomidacampo = '" + idComidaCampo + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /*
         * Efecto: actualiza el atributo estado de la tabla comida_campo de la comida de campo seleccionada
         * Requiere: el id de la reservacion seleccionada y el id de la comida extra seleccionado.
         * Modifica: table de comida_campo
         */
        public String[] cancelarComidaCampo(String idComidaCampo)
        {
            String[] respuesta = new String[3];
            String consultaSQL = "update servicios_reservados.comida_campo set estado = 'Cancelado'  where idcomidacampo = '" + idComidaCampo + "'";

            respuesta = adaptador.insertar(consultaSQL);
            return respuesta;
        }

        /*
         * Efecto: mantiene un registro de las veces que se consume una comida de campo
         * Requiere: el id de la reservacion asociada a la comida de campo.
         * Modifica: table de comida_campo
         */
        internal DataTable vecesConsumido(string idServ)
        {
            String consultaSQL = "select vecesconsumido from servicios_reservados.comida_campo where idcomidacampo ='" + idServ + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

         /*
         * Efecto: actualiza el registro de las veces que se consume una comida de campo
         * Requiere: el id de la reservacion asociada a la comida de campo.
         * Modifica: table de comida_campo
         */
        internal void actualizarVecesConsumido(string idServicio, int vecesConsumido)
        {
            String consultaSQL = "update servicios_reservados.comida_campo set vecesconsumido= " + vecesConsumido + " where idcomidacampo ='" + idServicio + "'";
            dt = adaptador.consultar(consultaSQL);
        }

        /*
         * Requiere: hilera con el identificador de la estacion, de la fecha inicio, de la fecha final
         * Efectua : Crea una consulta para consultar las comidas campo
         * Retorna : un arreglo de hileras con el resultado.
         */
        internal DataTable getComidasCampo(String estacion, String fechaInicio, String fechaFinal)
        {
            String consultaSQL = "select hora,opcion,pan,relleno,pax from servicios_reservados.comida_campo where estado ='Activo' and estacion= '" + estacion + "' and fecha >= '" + fechaInicio+"' and fecha <= '" + fechaFinal + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /*
         * Requiere: hilera con el identificador de la estacion, de la fecha inicio, de la fecha final
         * Efectua : Crea una consulta para consultar las bebidas de comida campo
         * Retorna : un arreglo de hileras con el resultado.
         */
        internal DataTable getBebidas(String estacion, String fechaInicio, String fechaFinal)
        {
            String consultaSQL = "select hora,bebida,pax from servicios_reservados.comida_campo where estado ='Activo' and bebida is not null and estacion= '" + estacion + "' and fecha >= '" + fechaInicio+"' and fecha <= '" + fechaFinal + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }
    }
}