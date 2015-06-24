﻿using System;
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
        private DateTime fechaHoy;
        public ControladoraBDReporteCocina()
        {
            adaptador = new AdaptadorBD();
            dt = new DataTable();
            fechaHoy = DateTime.Today;
        }

        internal DataTable solicitarTurnoDiaTresComidas(String sigla)
        {
            String fechaLocal = fechaHoy.ToString("MM/dd/yyyy");
            String consultaSQL = "select count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra <= TO_DATE('" + fechaLocal + "','MM/dd/yyyy') and v.sale >= TO_DATE('" + fechaLocal + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and vr.nombre = '3 Comidas (" + sigla + ")'";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }
        internal DataTable reservaEntrante(String sigla)
        {
            String fechaLocal = fechaHoy.ToString("MM/dd/yyyy");
            String consultaSQL = "select r.primera_comida,count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra = TO_DATE('" + fechaLocal + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and (vr.nombre = '3 Comidas (" + sigla + ")' or vr.nombre = '2 Comidas (" + sigla + ")') group by r.primera_comida";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        internal DataTable solicitarTurnoDiaDosComidas(String sigla)
        {
            String fechaLocal = fechaHoy.ToString("MM/dd/yyyy");
            String consultaSQL = "select r.primera_comida, count(*),SUM(v.pax) as cantidad_de_pax FROM reservas.vr_reservacion v JOIN reservas.reservacion r ON v.numero = r.numero JOIN reservas.reservacionitem ri ON r.id = ri.reservacion JOIN reservas.v_reservable vr ON ri.reservable= vr.id WHERE v.entra <= TO_DATE('" + fechaLocal + "','MM/dd/yyyy') and v.sale >= TO_DATE('" + fechaLocal + "','MM/dd/yyyy') and  v.estado = 'CNF' and vr.categoria='ANURA7249245184.5851916019' and vr.nombre = '2 Comidas (" + sigla + ")' group by r.primera_comida";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }
    }
}