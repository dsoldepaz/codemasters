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

        /*OleDbConnection adaptador;

        DataTable dt;
        public AdaptadorBD()
        {
            iniciarAdaptador();
        }

        /*
        * Consultar se utiliza para enviar una string SQL con una consulta y el adaptador se encarga de realizar la consulta directamente en la base de datos.  
        *
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
        *
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
            catch (OleDbException e)
            {
                int r = e.ErrorCode;

                if (r == -2147217873)
                {

                    respuesta[0] = "danger";
                    respuesta[1] = "Error. ";
                    respuesta[2] = "La informacion ingresada ya existe";
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
         * */

        OracleConnection adaptador= new OracleConnection();
        DataTable dt;
        /*
         * Requiere: N/A
         * Efectúa : Crea la hilera de conección con la base de datos.
         * Retorna : N/A
         */
        public AdaptadorBD()
        {
             adaptador.ConnectionString = "Data Source=10.1.4.93;User ID=servicios_reservados;Password=servicios;Unicode=True";   
        }
        /*
         * Requiere: Una hilera con la consulta a realizar.
         * Efectúa : Crea una conección con la base de datos hace la consulta a la base de datos, cierra la conección. Llena una tabla de datos con el resultado
         * Retorna : la tabla de datos con el resultado de la consulta.
         */
        internal DataTable consultar(String consultaSQL)
        {
            dt = new DataTable();
            adaptador.Open();
            OracleCommand comando = adaptador.CreateCommand();
            comando.CommandText = consultaSQL;
            OracleDataReader reader = comando.ExecuteReader();
            dt.Load(reader);           
            adaptador.Close();
            return dt;
        }

        /*
         * Efecto: ejecuta la consultaSQL en la base de datos.
         * Requiere: la entrada de la consulta.
         * Modifica: la base de datos.
         */
        internal String[] insertar(String consultaSQL)
        {
            String[] respuesta = new String[3];
            try
            {
                adaptador.Open();
                OracleCommand comando = new OracleCommand(consultaSQL, adaptador);
                comando.ExecuteNonQuery();
                adaptador.Close();

                respuesta[0] = "success";
                respuesta[1] = "Exito. ";
                respuesta[2] = "La comida extra se ha eliminado exitosamente";
            }
            catch (OracleException e)
            {
                int r = e.ErrorCode;

                if (r == -2147217873)
                {

                    respuesta[0] = "danger";
                    respuesta[1] = "Error. ";
                    respuesta[2] = "La informacion ingresada ya existe";
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

