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
        private DateTime fechaHoy;         
        private AdaptadorReservaciones adaptador;
        DataTable dt;
    /*
     * Requiere: N/A
     * Efectúa : inicializa las variables globales de la clase
     * retorna : N/A
     */
        public ControladoraBDReservaciones()
        {
            adaptador = new AdaptadorReservaciones();
            dt = new DataTable();
            fechaHoy = DateTime.Today;
        }
        /*
         * Requiere: N/A
         * Efectúa : Obtiene la fecha actual. Crea la consulta para obtener las cosultas activas con la fecha actual. Guarda en una tabla de datos el resultado a la consulta al adaptador.
         * Retorna : la tabla de datos con el resultado de la consulta.
         */
        internal DataTable consultarTodasReservaciones() {
            String fechaLocal = fechaHoy.ToString("MM/dd/yyyy");
            String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero, c.nombre, r.entra, r.sale from reservas.reservacion r, reservas.anfitriona a, reservas.estacion e, reservas.contacto c WHERE sale >= TO_DATE('"+fechaLocal+"','MM/dd/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.estado = 'CNF' and r.solicitante = c.id  order by sale asc";
            dt = adaptador.consultar(consultaSQL);
            
            return dt;
        }
        /*
         * Requiere: una hilera con el identificador de reservación a consultar.
         * Efectúa : Crea la hilera de consulta concatenando el identificador. Guarda en una tabla de datos el resultado de la consulta que se hizo con el adaptador de base de datos.
         * retorna : La tabla de datos con los resultados de  la consulta.
         */
        internal DataTable consultarUnaReservacion(String id)
        {
            String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero, c.nombre, r.entra, r.sale FROM reservas.reservacion r, reservas.anfitriona a, reservas.estacion e,reservas.contacto c WHERE r.id = '" + id + "' and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id  order by entra desc";
            dt = adaptador.consultar(consultaSQL);

            return dt;
        }

        /*
         * Requiere: N/A
         * Efectúa : Crea la hilera de consulta de las anfitrionas. Lo guarda en una tabla de datos 
         * retorna : La tabla de datos con los resultados de  la consulta.
         */
        internal DataTable solicitarAnfitriones(){
            String consultaSQL = "select  nombre from reservas.anfitriona";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }
        /*
         * Requiere: N/A
         * Efectúa : Crea la hilera de consulta de las estaciones. Lo guarda en una tabla de datos 
         * retorna : La tabla de datos con los resultados de  la consulta.
         */
        internal DataTable solicitarEstaciones()
        {
            String consultaSQL = "select  nombre from reservas.estacion";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /*
         * Requiere: un identificador de reservación.
         * Efectúa : Crea la hilera de consulta de la información concatenándolo al identificador de la reservación. Crea una tabala de datos donde almacena el resultado de la consulta.
         * retorna : La tabla de datos con los resultados de  la consulta.
         */
        internal DataTable solicitarInfo(String id)
        {
            String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero, c.nombre, r.entra, r.sale FROM reservas.reservacion r, reservas.anfitriona a, reservas.estacion e,reservas.contacto c WHERE r.id = '" + id + "' and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id  order by sale asc";
            dt = adaptador.consultar(consultaSQL);
            return dt;

        }

        /**Efecto: Crea la consulta SQL que obtiene el numero de pax de la reservacion y la retorna en forma de datatable  
         * Requiere: id de la reservacion
         * Modifica: el dataTable dt
         */
        internal DataTable obtenerPax(String idNum)
        {
            String consultaSQL = "select PAX from reservas.vr_reservacion where numero = '" + idNum + "'";
            dt = adaptador.consultar(consultaSQL);
            return dt;

        }

        /*
         * Requiere: Hilera con la Anfitriona seleccionada, Hilera con la estación seleccionada y una hilera con el solicitante. 
         * Efectúa : Crea la hilera de consulta a partir de los parámetros dados, valida uno a uno cuáles son diferentes de vacío y estos los agrega como parámetros a la consulta. Una vez creada la consulta, la efectúa con el adaptador y gurada el resultado en una tabla de datos.
         * retorna : La tabla de datos con los resultados de  la consulta.
         */
        internal DataTable consultarReservaciones(String anfitriona,String estacion, String solicitante){
            String fechaLocal = fechaHoy.ToString("dd/MM/yyyy");
            if (anfitriona.CompareTo("vacio") != 0 && estacion.CompareTo("vacio") != 0 && solicitante.CompareTo("vacio") != 0){
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservas.reservacion r, reservas.anfitriona a, reservas.estacion e,reservas.contacto c WHERE sale >= TO_DATE('" + fechaLocal + "','MM/dd/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and a.nombre ='" + anfitriona + "' and e.nombre= '" + estacion + "' and LOWER(c.nombre) like '%" + solicitante + "%' and r.estado = 'CNF' order by sale asc";
                dt = adaptador.consultar(consultaSQL);
            }
            else if (anfitriona.CompareTo("vacio") != 0 && estacion.CompareTo("vacio") != 0 && solicitante.CompareTo("vacio") == 0)
            {
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservas.reservacion r, reservas.anfitriona a, reservas.estacion e,reservas.contacto c WHERE sale >= TO_DATE('" + fechaLocal + "','MM/dd/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and a.nombre ='" + anfitriona + "' and e.nombre= '" + estacion + "' and r.estado = 'CNF'  order by sale asc";
                dt = adaptador.consultar(consultaSQL);
            
            }
            else if (anfitriona.CompareTo("vacio") != 0 && estacion.CompareTo("vacio") == 0 && solicitante.CompareTo("vacio") != 0)
            {
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservas.reservacion r, reservas.anfitriona a, reservas.estacion e,reservas.contacto c WHERE sale >= TO_DATE('" + fechaLocal + "','MM/dd/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and a.nombre ='" + anfitriona + "' and LOWER(c.nombre) like '%" + solicitante + "%' and r.estado = 'CNF' order by sale asc";
                dt = adaptador.consultar(consultaSQL);
            }
            else if (anfitriona.CompareTo("vacio") == 0 && estacion.CompareTo("vacio") != 0 && solicitante.CompareTo("vacio") != 0)
            {
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservas.reservacion r, reservas.anfitriona a, reservas.estacion e,reservas.contacto c WHERE sale >= TO_DATE('" + fechaLocal + "','MM/dd/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and e.nombre= '" + estacion + "' and LOWER(c.nombre) like '%" + solicitante + "%' and r.estado = 'CNF' order by sale asc";
                dt = adaptador.consultar(consultaSQL);
            }
            else if (anfitriona.CompareTo("vacio") != 0 && estacion.CompareTo("vacio") == 0 && solicitante.CompareTo("vacio") == 0)
            {
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservas.reservacion r, reservas.anfitriona a, reservas.estacion e,reservas.contacto c WHERE sale >= TO_DATE('" + fechaLocal + "','MM/dd/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and a.nombre ='" + anfitriona + "' and r.estado = 'CNF' order by sale asc";
                dt = adaptador.consultar(consultaSQL);
            }
            else if (anfitriona.CompareTo("vacio") == 0 && estacion.CompareTo("vacio") != 0 && solicitante.CompareTo("vacio") == 0)
            {
                Debug.WriteLine("si calcula bien este paso");
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservas.reservacion r, reservas.anfitriona a, reservas.estacion e,reservas.contacto c WHERE sale >= TO_DATE('" + fechaLocal + "','MM/dd/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and e.nombre= '" + estacion + "' and r.estado = 'CNF' order by sale asc";
                dt = adaptador.consultar(consultaSQL);
            }

            else if (anfitriona.CompareTo("vacio") == 0 && estacion.CompareTo("vacio") == 0 && solicitante.CompareTo("vacio") != 0)
            {
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservas.reservacion r, reservas.anfitriona a, reservas.estacion e,reservas.contacto c WHERE sale >= TO_DATE('" + fechaLocal + "','MM/dd/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and  LOWER(c.nombre) like '%" + solicitante + "%' and r.estado = 'CNF' order by sale asc";
                dt = adaptador.consultar(consultaSQL);
            }

            else if (anfitriona.CompareTo("vacio") != 0 && estacion.CompareTo("vacio") != 0 && solicitante.CompareTo("vacio") == 0)
            {
                String consultaSQL = "select r.id, a.nombre, e.nombre, r.numero,c.nombre, r.entra, r.sale from reservas.reservacion r, reservas.anfitriona a, reservas.estacion e,reservas.contacto c WHERE sale >= TO_DATE('" + fechaLocal + "','MM/dd/yyyy') and a.id = r.anfitriona  and r.estacion = e.id and r.solicitante = c.id and a.nombre ='" + anfitriona + "' and e.nombre= '" + estacion + "' and r.estado = 'CNF' order by sale asc";
                dt = adaptador.consultar(consultaSQL);
            }
           
            return dt;
        }
        
    }
}