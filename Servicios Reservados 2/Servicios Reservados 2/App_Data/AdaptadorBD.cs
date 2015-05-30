using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Diagnostics;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace Servicios_Reservados_2
{
    public class AdaptadorBD
    {

        OleDbConnection adaptador;

        DataTable dt;
        public AdaptadorBD()
        {
            iniciarAdaptador();
        }

        /*
        * Consultar se utiliza para enviar una string SQL con una consulta y el adaptador se encarga de realizar la consulta directamente en la base de datos.  
        */
        internal DataTable consultar(String consultaSQL)
        {
            dt = new DataTable();
            iniciarAdaptador();
            adaptador.Open();
            OleDbDataAdapter od = new OleDbDataAdapter(consultaSQL, adaptador);
            od.Fill(dt);
            adaptador.Close();
            return dt;
        }

       /*
       * Insertar se utiliza para enviar una string SQL con una inserción y el adaptador se encarga de realizar la inserción directamente en la base de datos.  
       */
        internal String[] insertar(String consultaSQL)
        {
            String[] respuesta = new String[3];
            try
            {
                iniciarAdaptador();
                adaptador.Open();
                OleDbCommand od = new OleDbCommand(consultaSQL, adaptador);
                od.ExecuteNonQuery();
                adaptador.Close();

                respuesta[0] = "success";
                respuesta[1] = "Exito. ";
                respuesta[2] = "La comida extra se ha eliminado exitosamente";
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
        private void iniciarAdaptador()
        {
            adaptador = new OleDbConnection("Provider= MSDAORA;Data Source=10.1.4.93;User ID=servicios_reservados;Password=servicios;Unicode=True");
        }
    }
}

