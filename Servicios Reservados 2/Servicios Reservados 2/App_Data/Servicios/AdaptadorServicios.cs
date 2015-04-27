using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
namespace Servicios_Reservados_2.Servicios
{
    public class AdaptadorServicios
    {
         OleDbConnection adaptador;
        DataTable dt;
        public AdaptadorServicios(){
             adaptador = new OleDbConnection("Provider= MSDAORA;Data Source=10.1.4.93;User ID=reservas;Password=reservas;Unicode=True");
             dt = new DataTable();

       
        }
        internal DataTable prueba(String id)
        {
            adaptador.Open();
            OleDbDataAdapter od = new OleDbDataAdapter("select * from RESERVACIONITEM where ID = '" + id + "'", adaptador);
            od.Fill(dt);
            adaptador.Close();
            return dt;
        }
    }
}