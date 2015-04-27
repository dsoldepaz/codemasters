using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;



namespace Servicios_Reservados_2
{
    public class ControladoraBDcomedor
    {

        private AdaptadorReservaciones adaptador;
        DataTable dt;
        
        public ControladoraBDcomedor()
        {
            adaptador = new AdaptadorReservaciones();
            dt = new DataTable();

        }

        internal Object[] consultarNotasTiquete(String numero) {
            String consultaSQL = "SELECT SOLICITANTE,ANFITRIONA,ESTACION,NOTAS FROM RESERVACION WHERE (ID = (SELECT RESERVACION FROM RESERVACIONITEM WHERE (ID = (SELECT IDRESERVACIONITEM FROM PAX WHERE (IDCLIENTE = "+numero+" )))))";
                
            dt = adaptador.consultar(consultaSQL);

            Object[] contenedor= new Object[4];


            if (dt.Rows.Count > 0) {
                foreach (DataRow fila in dt.Rows) {
                    contenedor[0]= fila[0].ToString();
                    contenedor[1]= fila[1].ToString();
                    contenedor[2]= fila[2].ToString();
                    contenedor[3]= fila[3].ToString();
                }
            }

          consultaSQL = "select contacto.nombre cliente,anfitriona.siglas anfitriona, estacion.nombre estacion,reservado_pax.consumido servido "+
                          "from reservado_pax,contacto,estacion,anfitriona "+
                          " where contacto.id='"+contenedor[0]+"' "+
                          " and anfitriona.id='"+contenedor[1]+"' "+
                          " and estacion.id='"+contenedor[2]+"' "+
                          " and reservado_pax.idcliente='"+numero+"' ";

          dt = adaptador.consultar(consultaSQL);

          Object[] result = new Object[5];


          if (dt.Rows.Count > 0)
          {
              foreach (DataRow fila in dt.Rows)
              {
                  result[0] = fila[0].ToString();
                  result[1] = fila[1].ToString();
                  result[2] = fila[2].ToString();
                  result[3] = fila[3].ToString();
                  result[4] = contenedor[3];
              }
          }


          return result;
        }
    }
}