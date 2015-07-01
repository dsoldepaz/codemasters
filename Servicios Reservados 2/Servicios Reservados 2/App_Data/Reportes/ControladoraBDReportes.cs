using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraBDReportes
    {
        AdaptadorBD adaptador = new AdaptadorBD();

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica : 
         */
        internal DataTable cargarEstaciones()
        {
            DataTable estaciones;
            String consultaSQL = "select nombre from reservas.estacion";
            estaciones = adaptador.consultar(consultaSQL);
            return estaciones;
        }

        /* 
         * Efecto: crea consulta para una comida campo de una reservacion utilizando todos los filtros.
         * Requiere: 
         * Modifica : 
         */
        internal DataTable obtenerComidaPax(String estacion, int opcion, int anfitriona, String fecha, String fechaFinal) //comida campo con todo reservacin
        {
            DataTable comidaCampo;

            String consultaSQL = "select distinct campo.fecha, sum(campo.pax), sum(vecesconsumido) from (reservas.vr_reservacion vista JOIN reservas.reservacion reserva ON vista.numero = reserva.numero) JOIN comida_campo campo ON reserva.id = campo.idreservacion WHERE opcion = " + opcion + " and vista.estacion = '" + estacion + "' and vista.idanfitriona = " + anfitriona + " and to_date(campo.fecha, 'MM/dd/yyyy') <= to_date('" + fechaFinal + "', 'MM/dd/yyyy') and to_date(campo.fecha, 'MM/dd/yyyy') >= to_date('" + fecha + "', 'MM/dd/yyyy') group by campo.fecha";
            comidaCampo = adaptador.consultar(consultaSQL);
            return comidaCampo;
        }

        /* 
      * Efecto: crea consulta para una comida campo de una reservacion utilizando el filtro de estacion y fechas.
      * Requiere: 
      * Modifica : 
      */
        internal DataTable obtenerComidaPaxEstacionFecha(String estacion, int opcion, String fecha, String fechaFinal) //comida campo con todo reservacin
        {
            DataTable comidaCampo;

            String consultaSQL = "select distinct campo.fecha, SUM(campo.pax), SUM(campo.vecesconsumido) from (reservas.vr_reservacion vista JOIN reservas.reservacion reserva ON vista.numero = reserva.numero) JOIN comida_campo campo ON reserva.id = campo.idreservacion WHERE opcion = " + opcion + " and vista.estacion = '" + estacion + "' and to_date(campo.fecha, 'MM/dd/yyyy') <= to_date('" + fechaFinal + "', 'MM/dd/yyyy') and to_date(campo.fecha, 'MM/dd/yyyy') >= to_date('" + fecha + "', 'MM/dd/yyyy') group by campo.fecha";
            comidaCampo = adaptador.consultar(consultaSQL);
            return comidaCampo;
        }

        /* 
      * Efecto: crea consulta para una comida campo de una reservacion utilizando filtro de anfitriona y fechas.
      * Requiere: 
      * Modifica : 
      */
        internal DataTable obtenerComidaPaxAnfitrionaFecha(int opcion, int anfitriona, String fecha, String fechaFinal) //comida campo reservacion con anfitriona y fechas
        {
            DataTable comidaCampo;

            String consultaSQL = "select distinct campo.fecha, SUM(campo.pax), SUM(campo.vecesconsumido) from (reservas.vr_reservacion vista JOIN reservas.reservacion reserva ON vista.numero = reserva.numero) JOIN comida_campo campo ON reserva.id = campo.idreservacion WHERE opcion =  " + opcion + " and vista.idanfitriona = " + anfitriona + "  and to_date(campo.fecha, 'MM/dd/yyyy') <= to_date('" + fechaFinal + "', 'MM/dd/yyyy') and to_date(campo.fecha, 'MM/dd/yyyy') >= to_date('" + fecha + "', 'MM/dd/yyyy') group by campo.fecha";
            comidaCampo = adaptador.consultar(consultaSQL);
            return comidaCampo;
        }

        /* 
   * Efecto: crea consulta para una comida campo de una reservacion utilizando filtro solo de fechas.
   * Requiere: 
   * Modifica : 
   */
        internal DataTable obtenerComidaPaxFechas(int opcion, String fecha, String fechaFinal){ //comida campo reservacion con solo fechas.
            DataTable comidaCampo;

            String consultaSQL = "select distinct campo.fecha, sum(campo.pax), sum(vecesconsumido) from (reservas.vr_reservacion vista JOIN reservas.reservacion reserva ON vista.numero = reserva.numero) JOIN comida_campo campo ON reserva.id = campo.idreservacion WHERE opcion = " + opcion + " and to_date(campo.fecha, 'MM/dd/yyyy') <= to_date('" + fechaFinal + "', 'MM/dd/yyyy') and to_date(campo.fecha, 'MM/dd/yyyy') >= to_date('" + fecha + "', 'MM/dd/yyyy') group by campo.fecha";
            comidaCampo = adaptador.consultar(consultaSQL);
            return comidaCampo;
        }

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica : 
         */
        internal DataTable obtenerComidaPaxEmp(String estacion, int opcion, String fecha, String fechaFinal) //comida campo con todo empleado o solo con estacion y fecha porque anfitriones siempre ESINTRO
        {
            DataTable comidaCampoEmp;

            String consultaSQL = "select distinct fecha, sum(pax), sum(vecesconsumido) from comida_campo where estacion = '" + estacion + "' and opcion = " + opcion + " and to_date(fecha, 'MM/dd/yyyy') <= to_date('" + fechaFinal + "', 'MM/dd/yyyy') and to_date(fecha, 'MM/dd/yyyy') >= to_date('" + fecha + "', 'MM/dd/yyyy') and idempleado is not null group by fecha";
            comidaCampoEmp = adaptador.consultar(consultaSQL);
            return comidaCampoEmp;
        }
       
        internal DataTable obtenerComidaPaxEmpFechas(int opcion, String fecha, String fechaFinal) //comida campo empleado con solo fechas o con anfitriona, pero siempre es ESINTRO.
        {
            DataTable comidaCampoEmp;

            String consultaSQL = "select distinct fecha, sum(pax), sum(vecesconsumido) from comida_campo where opcion = " + opcion + " and to_date(fecha, 'MM/dd/yyyy') <= to_date('" + fechaFinal + "', 'MM/dd/yyyy') and to_date(fecha, 'MM/dd/yyyy') >= to_date('" + fecha + "', 'MM/dd/yyyy') and idempleado is not null group by fecha";
            comidaCampoEmp = adaptador.consultar(consultaSQL);
            return comidaCampoEmp;
        }

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica: 
         */
        internal DataTable obtenerComidaEmp(String estacion, String opcion, String fecha, String fechaFinal) //comida campo empleado con todo o con solo estacion y fechas.
        {
            DataTable comidaCampoEmp;

            String consultaSQL = "select distinct fecha, count(" + opcion + "), count(vecesconsumido) from reserva_empleado where " + opcion + " = 'R' and fecha >= to_date('" + fecha + "', 'mm/dd/yyyy') and fecha <= to_date('" + fechaFinal + "', 'mm/dd/yyyy') and estacion ='" + estacion + "'group by fecha";
            comidaCampoEmp = adaptador.consultar(consultaSQL);
            return comidaCampoEmp;
        }
        /* 
      * Efecto: 
      * Requiere: 
      * Modifica: 
      */
        internal DataTable obtenerComidaEmpFechas(String opcion, String fecha, String fechaFinal) //comida campo empleado con fechas o solo con anfitriona y fechas porque anfitriona = ESINTRO.
        {
            DataTable comidaCampoEmp;

            String consultaSQL = "select distinct fecha, count(" + opcion + "), count(vecesconsumido) from reserva_empleado where " + opcion + " = 'R' and fecha >= to_date('" + fecha + "', 'mm/dd/yyyy') and fecha <= to_date('" + fechaFinal + "', 'mm/dd/yyyy') group by fecha";
            comidaCampoEmp = adaptador.consultar(consultaSQL);
            return comidaCampoEmp;
        }
     
        /* 
         * Efecto: crea la consulta que filtra comida extra por un rango de fecha.
         * Requiere: la entrada de las variables que realizan el filtrado.
         * Modifica : N/A
         */
        internal DataTable obtenerComidaExtraFechas(String opcion, String fecha, String fechaFinal, int consulta)
        {
            DataTable comidaExtra;
            String consultaSQL="";
            if (consulta == 1)
            {
                consultaSQL = "select distinct s.fecha, sum(s.pax), sum(s.vecesconsumido) from servicio_especial s join servicios_extras se on se.idservicio = s.idserviciosextras where to_date(s.fecha,'mm/dd/yyyy') >= to_date('" + fecha + "','mm/dd/yyyy') and " +
                            "to_date(s.fecha,'mm/dd/yyyy') <= to_date('" + fechaFinal + "','mm/dd/yyyy') and se.tipo = '" + opcion + "' group by s.fecha";
            }
            else
            {
                consultaSQL = "select distinct s.fecha, sum(s.pax), sum(s.vecesconsumido) from servicio_especial s join servicios_extras se on se.idservicio = s.idserviciosextras where to_date(s.fecha,'mm/dd/yyyy') >= to_date('" + fecha + "','mm/dd/yyyy') and " +
                            "to_date(s.fecha,'mm/dd/yyyy') <= to_date('" + fechaFinal + "','mm/dd/yyyy') and se.tipo <> 'Cena' and se.tipo <> 'Desayuno' and se.tipo <> 'Almuerzo' group by s.fecha";
            }


            comidaExtra = adaptador.consultar(consultaSQL);
            return comidaExtra;
        }

        /* 
         * Efecto: crea la consulta que filtra comida extra por anfitriona, estación y fecha.
         * Requiere: la entrada de las variables que realizan el filtrado.
         * Modifica : N/A
         */
        internal DataTable obtenerComidaExtraEstacionAnfitrionaFecha(String estacion, String opcion, int anfitriona, String fecha, String fechaFinal, int consulta)
        {
            DataTable comidaExtra;
            String consultaSQL="";
            if (consulta == 1)
            {
                consultaSQL = "select distinct s.fecha, sum(s.pax), sum(s.vecesconsumido) from ((RESERVAS.reservacion r join RESERVAS.vr_reservacion vr on r.numero = vr.numero ) join servicio_especial s on s.idreservacion = r.id) join " +
                    "servicios_extras se on se.idservicio = s.idserviciosextras where to_date(s.fecha,'mm/dd/yyyy') >= to_date('" + fecha + "','mm/dd/yyyy') and " +
                    "to_date(s.fecha,'mm/dd/yyyy') <= to_date('" + fechaFinal + "','mm/dd/yyyy') and r.anfitriona=" + anfitriona + " and vr.estacion = '" + estacion + "' and se.tipo = '" + opcion + "' group by s.fecha";
            }
            else
            {
                consultaSQL = "select distinct s.fecha, sum(s.pax), sum(s.vecesconsumido) from ((RESERVAS.reservacion r join RESERVAS.vr_reservacion vr on r.numero = vr.numero ) join servicio_especial s on s.idreservacion = r.id) join " +
                    "servicios_extras se on se.idservicio = s.idserviciosextras where to_date(s.fecha,'mm/dd/yyyy') >= to_date('" + fecha + "','mm/dd/yyyy') and " +
                    "to_date(s.fecha,'mm/dd/yyyy') <= to_date('" + fechaFinal + "','mm/dd/yyyy') and r.anfitriona=" + anfitriona + " and vr.estacion = '" + estacion + "' and se.tipo <> 'Cena' and se.tipo <> 'Desayuno' and se.tipo <> 'Almuerzo' group by s.fecha";
            }
            comidaExtra = adaptador.consultar(consultaSQL);
            return comidaExtra;
        }

        /* 
         * Efecto: crea la consulta que filtra comida extra por estaciòn y fecha.
         * Requiere: la entrada de las variables que realizan el filtrado.
         * Modifica : N/A
         */
        internal DataTable obtenerComidaExtraEstacionFecha(String estacion, String opcion, String fecha, String fechaFinal, int consulta)
        {
            DataTable comidaExtra;
            String consultaSQL="";
            if (consulta == 1)
            {
                consultaSQL = "select distinct s.fecha, sum(s.pax), sum(s.vecesconsumido) from ((RESERVAS.reservacion r join RESERVAS.vr_reservacion vr on r.numero = vr.numero ) join servicio_especial s on s.idreservacion " +
                   "= r.id) join servicios_extras se on se.idservicio = s.idserviciosextras where to_date(s.fecha,'mm/dd/yyyy') >= to_date('" + fecha + "','mm/dd/yyyy') and" +
                   "to_date(s.fecha,'mm/dd/yyyy') <= to_date('" + fechaFinal + "','mm/dd/yyyy') and vr.estacion = '" + estacion + "' and se.tipo = '" + opcion + "' group by s.fecha";
            }
            else
            {
                consultaSQL = "select distinct s.fecha, sum(s.pax), sum(s.vecesconsumido) from ((RESERVAS.reservacion r join RESERVAS.vr_reservacion vr on r.numero = vr.numero ) join servicio_especial s on s.idreservacion " +
                "= r.id) join servicios_extras se on se.idservicio = s.idserviciosextras where to_date(s.fecha,'mm/dd/yyyy') >= to_date('" + fecha + "','mm/dd/yyyy') and" +
                   "to_date(s.fecha,'mm/dd/yyyy') <= to_date('" + fechaFinal + "','mm/dd/yyyy') and vr.estacion = '" + estacion + "' and se.tipo <> 'Cena' and se.tipo <> 'Desayuno' and se.tipo <> 'Almuerzo' group by s.fecha";
            }
            comidaExtra = adaptador.consultar(consultaSQL);
            return comidaExtra;
        }

        /* 
         * Efecto: crea la consulta que filtra comida extra por anfitriona y fecha.
         * Requiere: la entrada de las variables que realizan el filtrado.
         * Modifica : N/A
         */
        internal DataTable obtenerComidaExtraAnfitrionaFecha(String opcion, int anfitriona, String fecha, String fechaFinal, int consulta)
        {
            DataTable comidaExtra;
            String consultaSQL="";
            if (consulta == 1)
            {
                consultaSQL = "select distinct s.fecha, sum(s.pax), sum(s.vecesconsumido) from (servicio_especial s join RESERVAS.reservacion r on s.idreservacion = r.id)join servicios_extras se on se.idservicio = " +
               "s.idserviciosextras where to_date(s.fecha,'mm/dd/yyyy') >= to_date('" + fecha + "','mm/dd/yyyy') and " +
               "to_date(s.fecha,'mm/dd/yyyy') <= to_date('" + fechaFinal + "','mm/dd/yyyy') and r.anfitriona=" + anfitriona + " and se.tipo = '" + opcion + "' group by s.fecha";
            }
            else
            {
                consultaSQL = "select distinct s.fecha, sum(s.pax), sum(s.vecesconsumido) from (servicio_especial s join RESERVAS.reservacion r on s.idreservacion = r.id)join servicios_extras se on se.idservicio = " +
               "s.idserviciosextras where to_date(s.fecha,'mm/dd/yyyy') >= to_date('" + fecha + "','mm/dd/yyyy') and " +
               "to_date(s.fecha,'mm/dd/yyyy') <= to_date('" + fechaFinal + "','mm/dd/yyyy') and r.anfitriona=" + anfitriona + " and se.tipo <> 'Cena' and se.tipo <> 'Desayuno' and se.tipo <> 'Almuerzo' group by s.fecha";
            }
            comidaExtra = adaptador.consultar(consultaSQL);
            return comidaExtra;
        }

    }
}