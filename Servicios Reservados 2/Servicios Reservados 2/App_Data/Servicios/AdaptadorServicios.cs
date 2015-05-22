using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;


namespace Servicios_Reservados_2
{
    public class AdaptadorServicios
    {
        OracleConnection adaptador = new OracleConnection();
        DataTable dt;
        public AdaptadorServicios()
        {
            adaptador.ConnectionString = "Data Source=10.1.4.93;User ID=servicios_reservados;Password=servicios;Unicode=True";


        }
        /**Efecto: Se comunica con la BD para obtener los datos de la misma 
         * Requiere: La consulta SQL
         * Modifica: el dataTable dt
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
       * Insertar se utiliza para enviar una string SQL con una inserción y el adaptador se encarga de realizar la inserción directamente en la base de datos.  
       */
        internal DataTable insertar(String consultaSQL)
        {
            dt = new DataTable();
            /*adaptador.Open();
            OleDbCommand od = new OleDbCommand(consultaSQL, adaptador);
            od.ExecuteNonQuery();
            adaptador.Close();*/
            return dt;
        }
    }
}