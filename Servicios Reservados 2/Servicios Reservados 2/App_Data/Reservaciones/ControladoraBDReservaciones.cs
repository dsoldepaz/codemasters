using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;

namespace Servicios_Reservados_2
{
    public class ControladoraBDReservaciones
    {
         
        private AdaptadorReservaciones adaptador;
        DataTable dt;
        public ControladoraBDReservaciones()
        {
            adaptador = new AdaptadorReservaciones();
            dt = new DataTable();
        }
        internal DataTable consultarTodasReservaciones() {
            String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero, c.nombre, r.entra, r.sale from reservacion r, anfitriona a, estacion e,contacto c WHERE entra >= TO_DATE('26/JAN/2017','dd/mon/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id  order by entra desc";
            dt = adaptador.consultar(consultaSQL);
            
            return dt;
        }
        internal DataTable consultarUnaReservacion(String id)
        {
            String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero, c.nombre, r.entra, r.sale FROM reservacion r, anfitriona a, estacion e,contacto c WHERE r.id = '"+id+"' and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id  order by entra desc";
            dt = adaptador.consultar(consultaSQL);

            return dt;
        }
        internal DataTable solicitarAnfitriones(){
            String consultaSQL = "select  nombre from anfitriona";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        internal DataTable solicitarEstaciones()
        {
            String consultaSQL = "select  nombre from estacion";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /*veamis*/
        internal DataTable solicitarInfo(String id)
        {
            String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero, c.nombre, r.entra, r.sale FROM reservacion r, anfitriona a, estacion e,contacto c WHERE r.id = '" + id + "' and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id  order by entra desc";
            dt = adaptador.consultar(consultaSQL);
            return dt;

        }


        internal DataTable consultarReservaciones(String anfitriona,String estacion, String solicitante){
            
            if (anfitriona.CompareTo("vacio") != 0 && estacion.CompareTo("vacio") != 0 && solicitante.CompareTo("vacio") != 0){
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservacion r, anfitriona a, estacion e,contacto c WHERE entra >= TO_DATE('26/JAN/2017','dd/mon/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and a.nombre ='"+anfitriona+"' and e.nombre= '"+estacion+"' and c.nombre like '%"+solicitante+"%' order by entra desc";
                dt = adaptador.consultar(consultaSQL);
            }
            else if (anfitriona.CompareTo("vacio") != 0 && estacion.CompareTo("vacio") != 0 && solicitante.CompareTo("vacio") == 0)
            {
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservacion r, anfitriona a, estacion e,contacto c WHERE entra >= TO_DATE('26/JAN/2017','dd/mon/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and a.nombre ='" + anfitriona + "' and e.nombre= '" + estacion + "'  order by entra desc";
                dt = adaptador.consultar(consultaSQL);
            
            }
            else if (anfitriona.CompareTo("vacio") != 0 && estacion.CompareTo("vacio") == 0 && solicitante.CompareTo("vacio") != 0)
            {
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservacion r, anfitriona a, estacion e,contacto c WHERE entra >= TO_DATE('26/JAN/2017','dd/mon/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and a.nombre ='" + anfitriona + "' and c.nombre like '%" + solicitante + "%' order by entra desc";
                dt = adaptador.consultar(consultaSQL);
            }
            else if (anfitriona.CompareTo("vacio") == 0 && estacion.CompareTo("vacio") != 0 && solicitante.CompareTo("vacio") != 0)
            {
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservacion r, anfitriona a, estacion e,contacto c WHERE entra >= TO_DATE('26/JAN/2017','dd/mon/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and e.nombre= '" + estacion + "' and c.nombre like '%" + solicitante + "%' order by entra desc";
                dt = adaptador.consultar(consultaSQL);
            }
            else if (anfitriona.CompareTo("vacio") != 0 && estacion.CompareTo("vacio") == 0 && solicitante.CompareTo("vacio") == 0)
            {
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservacion r, anfitriona a, estacion e,contacto c WHERE entra >= TO_DATE('26/JAN/2017','dd/mon/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and a.nombre ='" + anfitriona + "' order by entra desc";
                dt = adaptador.consultar(consultaSQL);
            }
            else if (anfitriona.CompareTo("vacio") == 0 && estacion.CompareTo("vacio") != 0 && solicitante.CompareTo("vacio") == 0)
            {
                Debug.WriteLine("si calcula bien este paso");
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservacion r, anfitriona a, estacion e,contacto c WHERE entra >= TO_DATE('26/JAN/2017','dd/mon/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and e.nombre= '" + estacion + "' order by entra desc";
                dt = adaptador.consultar(consultaSQL);
            }

            else if (anfitriona.CompareTo("vacio") == 0 && estacion.CompareTo("vacio") == 0 && solicitante.CompareTo("vacio") != 0)
            {
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservacion r, anfitriona a, estacion e,contacto c WHERE entra >= TO_DATE('26/JAN/2017','dd/mon/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and  c.nombre like '%" + solicitante + "%' order by entra desc";
                dt = adaptador.consultar(consultaSQL);
            }

            else if (anfitriona.CompareTo("vacio") != 0 && estacion.CompareTo("vacio") != 0 && solicitante.CompareTo("vacio") == 0)
            {
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservacion r, anfitriona a, estacion e,contacto c WHERE entra >= TO_DATE('26/JAN/2017','dd/mon/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and a.nombre ='" + anfitriona + "' and e.nombre= '" + estacion + "' order by entra desc";
                dt = adaptador.consultar(consultaSQL);
            }
           
            return dt;
        }
        
    }
}