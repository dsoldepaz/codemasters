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

        public ControladoraServicios()
        {
            controladora = new ControladoraBDServicios();
            controladoraReserv = new ControladoraReservaciones();
            controladoraCE = new ControladoraComidaExtra();

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
            
            Object[] dato = new Object[2]; 
            dato[0] = pax.Rows[0][0].ToString();
            dato[1] = idSelected();
            controladoraCE.guardarReservacionSeleccionada(dato);//enviamos la información a la controladora de comida extra

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
    }
}