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
            adaptador.ConnectionString = "Data Source=10.1.4.93;User ID=grupo01;Password=servicios123;Unicode=True";


        }
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
    }
}