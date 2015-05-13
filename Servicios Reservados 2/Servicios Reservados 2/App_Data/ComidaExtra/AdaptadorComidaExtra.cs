using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Diagnostics;
using System.Data;
using System.Data.OracleClient;

namespace Servicios_Reservados_2
{
    public class AdaptadorComidaExtra
    {

        OleDbConnection adaptador;

        DataTable dt;
        public AdaptadorComidaExtra()
        {
             adaptador = new OleDbConnection("Provider= MSDAORA;Data Source=10.1.4.93;User ID=servicios_reservados;Password=servicios;Unicode=True");     
        }

        /*
        * Consultar se utiliza para enviar una string SQL con una consulta y el adaptador se encarga de realizar la consulta directamente en la base de datos.  
        */
        internal DataTable consultar(String consultaSQL)
        {
            dt = new DataTable();
            adaptador.Open();
            OleDbDataAdapter od = new OleDbDataAdapter(consultaSQL, adaptador);
            od.Fill(dt);
            adaptador.Close();
            return dt;
        }

       /*
       * Insertar se utiliza para enviar una string SQL con una inserción y el adaptador se encarga de realizar la inserción directamente en la base de datos.  
       */
        internal DataTable insertar(String consultaSQL)
        {
            dt = new DataTable();
            adaptador.Open();
            OleDbCommand od = new OleDbCommand(consultaSQL, adaptador);
            od.ExecuteNonQuery();
            adaptador.Close();
            return dt;
        }
    }
}

