using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraBDReporteCocina
    {
        private AdaptadorBD adaptador;
        DataTable dt;
        
        public ControladoraBDReporteCocina()
        {
            adaptador = new AdaptadorBD();
            dt = new DataTable();
            
        }

        internal DataTable solicitarTurnoDiaTresComidas(String sigla,String inicio, String final)
        {
            
            String consultaSQL = "select count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra <= TO_DATE('" + inicio + "','MM/dd/yyyy') and v.sale >= TO_DATE('" + final + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and vr.nombre = '3 Comidas (" + sigla + ")'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }
        internal DataTable reservaEntrante(String sigla, String inicio, String final)
        {
            String consultaSQL="";
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

        internal DataTable solicitarTurnoDiaDosComidas(String sigla, String inicio, String final)
        {
            
            String consultaSQL = "select r.primera_comida, count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra <= TO_DATE('" + inicio + "','MM/dd/yyyy') and v.sale >= TO_DATE('" + final + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and vr.nombre = '2 Comidas (" + sigla + ")' group by r.primera_comida";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        internal DataTable solicitarCE(String estacion, String inicio, String final)
        {
            String consultaSQL="";
            if(inicio==final){
                consultaSQL = "select e.tipo,count(*),sum(s.pax) from servicios_reservados.servicio_especial s join servicios_reservados.servicios_extras e on s.idserviciosextras=e.idservicio join reservas.reservacion r on s.idreservacion=r.id join reservas.vr_reservacion v ON v.numero = r.numero where s.estado = 'Activo' and v.estacion='"+estacion+"' and s.fecha= '"+inicio+"' group by e.tipo";
            }
            else{

            }
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }
    }
}