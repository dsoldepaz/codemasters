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
        private static String[] extra;
        public List<String> adicionales;



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

        internal void seleccionarComidaCampo(String id, String idServ)
        {
            DataTable comidaCampo = controladora.seleccionarComidaCampo(id, idServ);
            DataTable adicional = controladora.seleccionarAdicional(idServ);
            adicionales = new List<String>();
           
            Object[] nuevoComidaC = new Object[12];

            nuevoComidaC[0] = comidaCampo.Rows[0][0];
            nuevoComidaC[1] = comidaCampo.Rows[0][1];
            nuevoComidaC[2] = comidaCampo.Rows[0][2];
            nuevoComidaC[3] = comidaCampo.Rows[0][3];
            nuevoComidaC[4] = comidaCampo.Rows[0][4];
            nuevoComidaC[5] = comidaCampo.Rows[0][5];
            nuevoComidaC[7] = comidaCampo.Rows[0][6];
            nuevoComidaC[6] = comidaCampo.Rows[0][7];
            nuevoComidaC[8] = comidaCampo.Rows[0][8];
            nuevoComidaC[9] = comidaCampo.Rows[0][9];
            nuevoComidaC[10] = comidaCampo.Rows[0][10];
            nuevoComidaC[11] = comidaCampo.Rows[0][11];
             int i = 0;
             if (adicional.Rows.Count > 0)
             {
                 foreach (DataRow fila in adicional.Rows)
                 {
                     String ad = adicional.Rows[i][0].ToString();
                     adicionales.Add(ad);
                     i++;
                     
                 }
             }


           controladoraComidaCampo.guardarComidaSeleccionada(nuevoComidaC, adicionales);
           //controladoraComidaCampo.guardarAdicional(nuevoAdicional);
        }

        internal DataTable solicitarPaquete(string p)
        {
            throw new NotImplementedException();
        }
    }
}