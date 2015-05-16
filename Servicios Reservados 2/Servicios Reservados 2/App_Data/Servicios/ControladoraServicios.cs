using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Diagnostics;
using System.Web;



namespace Servicios_Reservados_2.Servicios
{
    public class ControladoraServicios
    {
        public static EntidadReservaciones servicios;
        private ControladoraBDServicios controladora;
        public static ControladoraReservaciones controladoraReserv;
        public static ControladoraComidaExtra controladoraCE;
        public static ControladoraComidaCampo controladoraComidaCampo;


        public ControladoraServicios()
        {
            controladora = new ControladoraBDServicios();
            controladoraReserv = new ControladoraReservaciones();
            controladoraCE = new ControladoraComidaExtra();
            controladoraComidaCampo = new ControladoraComidaCampo();
        }

        public EntidadReservaciones informacionServicio() {
            servicios = controladoraReserv.getReservacionSeleccionada();
           
          return servicios;

        }

        public String idSelected()
        {
            String idReserv = controladoraReserv.getReservacionSeleccionada().Id;
            return idReserv;

        }

        public String idNumSelected()
        {
            string idNum = controladoraReserv.getReservacionSeleccionada().Numero;
            return idNum;

        }

        internal DataTable obtenerPax(String id)
        {
            DataTable pax = controladora.obtenerPax(id);
            
            int paxSelect = int.Parse(pax.Rows[0][0].ToString());
            controladoraCE.guardarPaxsSeleccionado(paxSelect);//enciamos la información a la controladora de comida extra

            return pax;

        }

        internal DataTable solicitarServicios(String id)
        {
            DataTable servicios = controladora.solicitarServicios(id);
            return servicios;

        }

        internal DataTable solicitarComidaCampo(String id) 
        {
            DataTable comidaCampo = controladora.solicitarComidaCampo(id);
            return comidaCampo;
        }

        internal void seleccionarServicio(String id, String idServ)
        {
            DataTable servicios = controladora.seleccionarServicio(id, idServ);

            Object[] nuevoServicio = new Object[8];

            nuevoServicio[0] = servicios.Rows[0][0];
            nuevoServicio[1] = servicios.Rows[0][1];
            nuevoServicio[2] = servicios.Rows[0][3];
            nuevoServicio[3] = servicios.Rows[0][4];
            nuevoServicio[4] = servicios.Rows[0][5];
            nuevoServicio[5] = servicios.Rows[0][2];
            nuevoServicio[7] = servicios.Rows[0][6];
            nuevoServicio[6] = servicios.Rows[0][7];

            controladoraCE.guardarServicioSeleccionado(nuevoServicio);
        }

        internal void seleccionarComidaCampo(String id, String idComidaCampo)
        {
            DataTable comidaCampo = controladora.seleccionarComidaCampo(id, idComidaCampo);

            Object[] nuevoComidaC = new Object[12];

            nuevoComidaC[0] = comidaCampo.Rows[0][1];
            nuevoComidaC[2] = comidaCampo.Rows[0][2];
            nuevoComidaC[3] = comidaCampo.Rows[0][3];
            nuevoComidaC[4] = comidaCampo.Rows[0][4];
            nuevoComidaC[5] = comidaCampo.Rows[0][5];
            nuevoComidaC[6] = comidaCampo.Rows[0][6];
            nuevoComidaC[7] = comidaCampo.Rows[0][7];
            nuevoComidaC[8] = comidaCampo.Rows[0][8];
            nuevoComidaC[10] = comidaCampo.Rows[0][9];
            nuevoComidaC[11] = comidaCampo.Rows[0][10];

            controladoraComidaCampo.guardarComidaSeleccionada(nuevoComidaC);
        }
    }
}