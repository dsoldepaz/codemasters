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
         * Efecto: Consulta todas las estaciones que se encuentran en la base de datos
         * Requiere: n/a
         * Modifica: el DataTable que retorna 
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
         * Requiere: los filtros de estación, anfitriona  y fechas.
         * Modifica : el DataTable que retorna 
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
      * Requiere: los parametros de estación y fechas.
      * Modifica : el DataTable que retorna 
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
      * Requiere: los parametros de anfitriona y fechas
      * Modifica : el DataTable que retorna 
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
   * Requiere: el parametros de fechas
   * Modifica : el DataTable que retorna 
   */
        internal DataTable obtenerComidaPaxFechas(int opcion, String fecha, String fechaFinal)
        { //comida campo reservacion con solo fechas.
            DataTable comidaCampo;

            String consultaSQL = "select distinct campo.fecha, sum(campo.pax), sum(vecesconsumido) from (reservas.vr_reservacion vista JOIN reservas.reservacion reserva ON vista.numero = reserva.numero) JOIN comida_campo campo ON reserva.id = campo.idreservacion WHERE opcion = " + opcion + " and to_date(campo.fecha, 'MM/dd/yyyy') <= to_date('" + fechaFinal + "', 'MM/dd/yyyy') and to_date(campo.fecha, 'MM/dd/yyyy') >= to_date('" + fecha + "', 'MM/dd/yyyy') group by campo.fecha";
            comidaCampo = adaptador.consultar(consultaSQL);
            return comidaCampo;
        }

        /* 
         * Efecto: crea consulta para una comida de campo de un empleado utilizando filtros de estación y fechas
         * Requiere: los parametros de estación y fechas
         * Modifica : el DataTable que retorna 
         */
        internal DataTable obtenerComidaPaxEmp(String estacion, int opcion, String fecha, String fechaFinal) //comida campo con todo empleado o solo con estacion y fecha porque anfitriones siempre ESINTRO
        {
            DataTable comidaCampoEmp;

            String consultaSQL = "select distinct fecha, sum(pax), sum(vecesconsumido) from comida_campo where estacion = '" + estacion + "' and opcion = " + opcion + " and to_date(fecha, 'MM/dd/yyyy') <= to_date('" + fechaFinal + "', 'MM/dd/yyyy') and to_date(fecha, 'MM/dd/yyyy') >= to_date('" + fecha + "', 'MM/dd/yyyy') and idempleado is not null group by fecha";
            comidaCampoEmp = adaptador.consultar(consultaSQL);
            return comidaCampoEmp;
        }

        /* 
         * Efecto: crea consulta para una comida de campo de un empleado utilizando filtros de fechas
         * Requiere: parametro de fechas
         * Modifica : el DataTable que retorna 
         */
        internal DataTable obtenerComidaPaxEmpFechas(int opcion, String fecha, String fechaFinal) //comida campo empleado con solo fechas o con anfitriona, pero siempre es ESINTRO.
        {
            DataTable comidaCampoEmp;

            String consultaSQL = "select distinct fecha, sum(pax), sum(vecesconsumido) from comida_campo where opcion = " + opcion + " and to_date(fecha, 'MM/dd/yyyy') <= to_date('" + fechaFinal + "', 'MM/dd/yyyy') and to_date(fecha, 'MM/dd/yyyy') >= to_date('" + fecha + "', 'MM/dd/yyyy') and idempleado is not null group by fecha";
            comidaCampoEmp = adaptador.consultar(consultaSQL);
            return comidaCampoEmp;
        }

        /* 
         * Efecto: crea consulta para una comida de un empleado utilizando filtros de estación y fechas
         * Requiere: los paremtros de estación y fechas
         * Modifica: el DataTable que retorna 
         */
        internal DataTable obtenerComidaEmp(String estacion, String opcion, String fecha, String fechaFinal) //comida campo empleado con todo o con solo estacion y fechas.
        {
            DataTable comidaCampoEmp;

            String consultaSQL = "select distinct fecha, count(" + opcion + "), count(vecesconsumido) from reserva_empleado where " + opcion + " = 'R' and fecha >= to_date('" + fecha + "', 'mm/dd/yyyy') and fecha <= to_date('" + fechaFinal + "', 'mm/dd/yyyy') and estacion ='" + estacion + "'group by fecha";
            comidaCampoEmp = adaptador.consultar(consultaSQL);
            return comidaCampoEmp;
        }


       /* 
         * Efecto: crea consulta para una comida de un empleado utilizando filtros de fechas
         * Requiere: los paremtros de fechas
         * Modifica: el DataTable que retorna 
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
         * Modifica : el DataTable que retorna 
         */
        internal DataTable obtenerComidaExtraFechas(String opcion, String fecha, String fechaFinal, int consulta)
        {
            DataTable comidaExtra;
            String consultaSQL = "";
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
         * Modifica : el DataTable que retorna 
         */
        internal DataTable obtenerComidaExtraEstacionAnfitrionaFecha(String estacion, String opcion, int anfitriona, String fecha, String fechaFinal, int consulta)
        {
            DataTable comidaExtra;
            String consultaSQL = "";
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
         * Modifica : el DataTable que retorna 
         */
        internal DataTable obtenerComidaExtraEstacionFecha(String estacion, String opcion, String fecha, String fechaFinal, int consulta)
        {
            DataTable comidaExtra;
            String consultaSQL = "";
            if (consulta == 1)
            {
                consultaSQL = "select distinct s.fecha, sum(s.pax), sum(s.vecesconsumido) from ((RESERVAS.reservacion r join RESERVAS.vr_reservacion vr on r.numero = vr.numero ) join servicio_especial s on s.idreservacion " +
                   "= r.id) join servicios_extras se on se.idservicio = s.idserviciosextras where to_date(s.fecha,'mm/dd/yyyy') >= to_date('" + fecha + "','mm/dd/yyyy') and " +
                   "to_date(s.fecha,'mm/dd/yyyy') <= to_date('" + fechaFinal + "','mm/dd/yyyy') and vr.estacion = '" + estacion + "' and se.tipo = '" + opcion + "' group by s.fecha";
            }
            else
            {
                consultaSQL = "select distinct s.fecha, sum(s.pax), sum(s.vecesconsumido) from ((RESERVAS.reservacion r join RESERVAS.vr_reservacion vr on r.numero = vr.numero ) join servicio_especial s on s.idreservacion " +
                "= r.id) join servicios_extras se on se.idservicio = s.idserviciosextras where to_date(s.fecha,'mm/dd/yyyy') >= to_date('" + fecha + "','mm/dd/yyyy') and " +
                   "to_date(s.fecha,'mm/dd/yyyy') <= to_date('" + fechaFinal + "','mm/dd/yyyy') and vr.estacion = '" + estacion + "' and se.tipo <> 'Cena' and se.tipo <> 'Desayuno' and se.tipo <> 'Almuerzo' group by s.fecha";
            }
            comidaExtra = adaptador.consultar(consultaSQL);
            return comidaExtra;
        }

        /* 
         * Efecto: crea la consulta que filtra comida extra por anfitriona y fecha.
         * Requiere: la entrada de las variables que realizan el filtrado.
         * Modifica : el DataTable que retorna 
         */
        internal DataTable obtenerComidaExtraAnfitrionaFecha(String opcion, int anfitriona, String fecha, String fechaFinal, int consulta)
        {
            DataTable comidaExtra;
            String consultaSQL = "";
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

        //estacion y fecha

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica: el DataTable que retorna 
         */
        internal DataTable solicitarTurnoDiaTresComidasEstacionFecha(String sigla, String inicio, String final)
        {
            DataTable dt;
            String consultaSQL = "select count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra <= TO_DATE('" + inicio + "','MM/dd/yyyy') and v.sale >= TO_DATE('" + final + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and vr.nombre = '3 Comidas (" + sigla + ")'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica: el DataTable que retorna 
         */
        internal DataTable reservaEntranteEstacionFecha(String sigla, String inicio, String final)
        {
            DataTable dt;
            String consultaSQL = "";
            if (inicio == final)
            {
                consultaSQL = "select r.primera_comida,vr.nombre,count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra = TO_DATE('" + inicio + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and (vr.nombre = '3 Comidas (" + sigla + ")' or vr.nombre = '2 Comidas (" + sigla + ")') group by r.primera_comida,vr.nombre";
            }
            else
            {

            }
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica: el DataTable que retorna 
         */
        internal DataTable solicitarTurnoDiaDosComidasEstacionFecha(String sigla, String inicio, String final)
        {
            DataTable dt;
            String consultaSQL = "select r.primera_comida, count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra <= TO_DATE('" + inicio + "','MM/dd/yyyy') and v.sale >= TO_DATE('" + final + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and vr.nombre = '2 Comidas (" + sigla + ")' group by r.primera_comida";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        //anfitriona y fecha

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica: el DataTable que retorna 
         */
        internal DataTable solicitarTurnoDiaTresComidasAnfitrionaFecha(int anfitriona, String inicio, String final)
        {
            DataTable dt;
            String consultaSQL = "select count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra <= TO_DATE('" + inicio + "','MM/dd/yyyy') and v.sale >= TO_DATE('" + final + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and vr.nombre like '3 Comidas%' and v.idanfitriona = " + anfitriona;
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /* 
 * Efecto: 
 * Requiere: 
 * Modifica: el DataTable que retorna 
 */
        internal DataTable reservaEntranteAnfitrionaFecha(int anfitriona, String inicio, String final)
        {
            DataTable dt;
            String consultaSQL = "";
            if (inicio == final)
            {
                consultaSQL = "select r.primera_comida,vr.nombre,count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra = TO_DATE('" + inicio + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and (vr.nombre like '3 Comidas%' or vr.nombre like '2 Comidas%') and v.idanfitriona = " + anfitriona + "group by r.primera_comida,vr.nombre";
            }
            else
            {

            }
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica: el DataTable que retorna 
         */
        internal DataTable solicitarTurnoDiaDosComidasAnfitrionaFecha(int anfitriona, String inicio, String final)
        {
            DataTable dt;
            String consultaSQL = "select r.primera_comida, count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra <= TO_DATE('" + inicio + "','MM/dd/yyyy') and v.sale >= TO_DATE('" + final + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and vr.nombre like '2 Comidas%' and v.idanfitriona = " + anfitriona+" group by r.primera_comida";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        //estacion, fecha y anfitriona

        /* 
 * Efecto: 
 * Requiere: 
 * Modifica: el DataTable que retorna 
 */
        internal DataTable solicitarTurnoDiaTresComidasEstacionAnfitrionaFecha(String sigla, String inicio, String final, int anfitriona)
        {
            DataTable dt;
            String consultaSQL = "select count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra <= TO_DATE('" + inicio + "','MM/dd/yyyy') and v.sale >= TO_DATE('" + final + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and vr.nombre = '3 Comidas (" + sigla + ")' and v.idanfitriona = " + anfitriona;
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica: el DataTable que retorna 
         */
        internal DataTable reservaEntranteEstacionAnfitrionaFecha(String sigla, String inicio, String final, int anfitriona)
        {
            DataTable dt;
            String consultaSQL = "";
            if (inicio == final)
            {
                consultaSQL = "select r.primera_comida,vr.nombre,count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra = TO_DATE('" + inicio + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and (vr.nombre = '3 Comidas (" + sigla + ")' or vr.nombre = '2 Comidas (" + sigla + ")') and v.idanfitriona = " + anfitriona + " group by r.primera_comida,vr.nombre";
            }
            else
            {

            }
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica: el DataTable que retorna 
         */
        internal DataTable solicitarTurnoDiaDosComidasEstacionAnfitrionaFecha(String sigla, String inicio, String final, int anfitriona)
        {
            DataTable dt;
            String consultaSQL = "select r.primera_comida, count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra <= TO_DATE('" + inicio + "','MM/dd/yyyy') and v.sale >= TO_DATE('" + final + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and vr.nombre = '2 Comidas (" + sigla + ")' and v.idanfitriona = " + anfitriona + " group by r.primera_comida";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        //solo fechas

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica: el DataTable que retorna 
         */
        internal DataTable solicitarTurnoDiaTresComidasFecha(String inicio, String final)
        {
            DataTable dt;
            String consultaSQL = "select count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra <= TO_DATE('" + inicio + "','MM/dd/yyyy') and v.sale >= TO_DATE('" + final + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and vr.nombre like '3 Comidas%'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /* 
 * Efecto: 
 * Requiere: 
 * Modifica: el DataTable que retorna 
 */
        internal DataTable reservaEntranteFecha(String inicio, String final)
        {
            DataTable dt;
            String consultaSQL = "";
            if (inicio == final)
            {
                consultaSQL = "select r.primera_comida,vr.nombre,count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra = TO_DATE('" + inicio + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and (vr.nombre like '3 Comidas%' or vr.nombre like '2 Comidas%') group by r.primera_comida,vr.nombre";
            }
            else
            {

            }
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /* 
         * Efecto: 
         * Requiere: 
         * Modifica: el DataTable que retorna 
         */
        internal DataTable solicitarTurnoDiaDosComidasFecha(String inicio, String final)
        {
            DataTable dt;
            String consultaSQL = "select r.primera_comida, count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra <= TO_DATE('" + inicio + "','MM/dd/yyyy') and v.sale >= TO_DATE('" + final + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and vr.nombre like '2 Comidas%' group by r.primera_comida";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }
    }
}