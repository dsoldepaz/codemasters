using Servicios_Reservados_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Servicios_Reservados_2
{
    public class ControladoraComidaCampo
    {
        private ControladoraBDComidaCampo controladoraBD;//instancia de la controladora de BD comida extra.
        private ControladoraReservaciones controladoraReserv;
        private ControladoraEmpleado controladoraEmp;
        public static EntidadComidaCampo comidaCampoConsultada;
        private static List<String> adicionales;

        public ControladoraComidaCampo()
        {
            controladoraBD = new ControladoraBDComidaCampo();
            controladoraReserv = new ControladoraReservaciones();
            controladoraEmp = new ControladoraEmpleado();

        }


          /*
          * Efecto: envia a encapsular la comida de campo a insertar
          * Requiere: el id de la comida de campo y la reservación a la que pertenece
          * Modifica: la entidadConsultada
          */
        public EntidadComidaCampo guardarComidaSeleccionada(String id, String idServ)
        {
            DataTable comidaCampo = controladoraBD.seleccionarComidaCampo(id, idServ);
            DataTable adicional = controladoraBD.seleccionarAdicional(idServ);
            adicionales = new List<String>();

            Object[] nuevoComidaC = new Object[13];

            nuevoComidaC[0] = comidaCampo.Rows[0][0];
            nuevoComidaC[1] = comidaCampo.Rows[0][1];
            nuevoComidaC[2] = comidaCampo.Rows[0][2];
            nuevoComidaC[3] = comidaCampo.Rows[0][3];
            nuevoComidaC[4] = comidaCampo.Rows[0][4];
            nuevoComidaC[5] = comidaCampo.Rows[0][5];
            nuevoComidaC[6] = comidaCampo.Rows[0][6];
            nuevoComidaC[7] = comidaCampo.Rows[0][7];
            nuevoComidaC[8] = comidaCampo.Rows[0][8];
            nuevoComidaC[9] = comidaCampo.Rows[0][9];
            nuevoComidaC[10] = comidaCampo.Rows[0][10];
            nuevoComidaC[11] = comidaCampo.Rows[0][11];
            nuevoComidaC[12] = comidaCampo.Rows[0][12];
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


            comidaCampoConsultada = new EntidadComidaCampo(nuevoComidaC, adicionales);
            return comidaCampoConsultada;
        }

        /*
        * Efecto: encapsula la comida de campo a consultar
        * Requiere: el id de la comida de campo y la reservación a la que pertenece
        * Modifica: la entidadConsultada
        */
        public EntidadComidaCampo consultarComidaCampoSeleccionada(String id, String idServicio)
        {
            DataTable comidaCampo = controladoraBD.seleccionarComidaCampoEmpleado(id, idServicio);
            DataTable adicional = controladoraBD.seleccionarAdicional(idServicio);
            adicionales = new List<String>();

            Object[] nuevoComidaC = new Object[13];

            nuevoComidaC[0] = comidaCampo.Rows[0][0];
            nuevoComidaC[1] = comidaCampo.Rows[0][1];
            nuevoComidaC[2] = comidaCampo.Rows[0][2];
            nuevoComidaC[3] = comidaCampo.Rows[0][3];
            nuevoComidaC[4] = comidaCampo.Rows[0][4];
            nuevoComidaC[5] = comidaCampo.Rows[0][5];
            nuevoComidaC[6] = comidaCampo.Rows[0][6];   //relleno
            nuevoComidaC[7] = comidaCampo.Rows[0][7];  //pan
            nuevoComidaC[8] = comidaCampo.Rows[0][8];
            nuevoComidaC[9] = comidaCampo.Rows[0][9];
            nuevoComidaC[10] = comidaCampo.Rows[0][10];
            nuevoComidaC[11] = comidaCampo.Rows[0][11];
            nuevoComidaC[12] = comidaCampo.Rows[0][12];
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


            comidaCampoConsultada = new EntidadComidaCampo(nuevoComidaC, adicionales);
            return comidaCampoConsultada;
        }


        /*
        * Efecto: solicita la información de las comidas de campo empleado
        * Requiere: el id del empleado
        * Modifica: el DataTable que retorna
        */
        public DataTable getComidaEmpleado(String id)
        {
            DataTable dt = controladoraBD.getComidaEmpleado(id);
            return dt;
        }

        /*
        * Efecto: se encarga de agregar una comida de campo 
        * Requiere: la información de la comida a agregar más la lista de adicionales
        * Modifica: la entidadComidaCampo
        */
        public String[] agregarComidaCampo(Object[] dato, List<String> lista)
        {
            EntidadComidaCampo nuevaComidaCampo = new EntidadComidaCampo(dato, lista);
            String[] resultado = controladoraBD.agregarComidaCampo(nuevaComidaCampo);
            return resultado;
        }

        /*
        * Efecto: se encarga de modificar una comida de campo 
        * Requiere: la información de la comida a modificar, la lista de adicionales y la entidadConsultada
        * Modifica: la entidadComidaCampo
        */
        public String[] modificarComidaCampo(Object[] dato, List<String> lista, EntidadComidaCampo entidadConsultada)
        {
            EntidadComidaCampo nuevaComidaCampo = new EntidadComidaCampo(dato, lista);
            String[] resultado = controladoraBD.modificarComidaCampo(nuevaComidaCampo, entidadConsultada);
            return resultado;
        }

        /*
        * Efecto: encapsula la comida de campo seleccionada 
        * Requiere: n/a
        * Modifica: la entidadComidaCampo
        */
        public EntidadComidaCampo entidadSeleccionada()
        {
            return comidaCampoConsultada;
        }

        /*
         * Efecto: recibe el id de la comida de campo y lo manda a cancelar a la controladora de BD.
         * Requiere: el id.
         * Modifica: la tabla de comida_campo.
         */
        internal String[] cancelarComidaCampo(String id)
        {
            String[] resultado = controladoraBD.cancelarComidaCampo(id);
            return resultado;
        }

        /*
         * Efecto: recibe el id de la comida de campo y lo manda a cancelar a la controladora de BD.
         * Requiere: el id.
         * Modifica: la tabla de comida_campo.
         */
        public EntidadReservaciones reservConsultada()
        {
            return controladoraReserv.getReservacionSeleccionada();
        }


        /*
         * Efecto: solicita la cantidad de personas en una reservación
         * Requiere: el id de la reservación
         * Modifica: el string PAX
         */
        public String paxReserv(String id)
        {
            String pax = controladoraReserv.obtenerPax(id);
            return pax;

        }

        /*
         * Efecto: solicita la cantidad de veces que se ha consumido un servicio
         * Requiere: el id del servicio
         * Modifica: el DataTable que retorna
         */
        internal DataTable solicitarVecesConsumido(string idServicio)
        {
            return controladoraBD.vecesConsumido(idServicio);
        }


        /*
         * Efecto: actualiza la cantidad de veces que se ha consumido un servicio
         * Requiere: el id del servicio y la cantidad de veces consumido
         * Modifica: el DataTable que retorna
         */
        internal void actualizarVecesConsumido(string idServicio, int vecesConsumido)
        {
            controladoraBD.actualizarVecesConsumido(idServicio, vecesConsumido);
        }


        /*
         * Efecto: solicita la entidad de la reservacion consultada
         * Requiere:n/a
         * Modifica: la entidad de reservaciones
         */
        internal EntidadReservaciones infoServicioRes()
        {
            return controladoraReserv.getReservacionSeleccionada();

        }


        /*
         * Efecto: solicita la entidad de empleado consultado
         * Requiere: n/a
         * Modifica: la entidad de empleado
         */
        internal EntidadEmpleado infoServicioEmp()
        {
            return controladoraEmp.getEmpleadoSeleccionado();
        }

        /*
       * Requiere: hilera con el identificador de la estacion, de la fecha inicio, de la fecha final
       * Efectua : llama a getComidasCampo de la controladora de base de datos con el parametro dado. 
       * Retorna :  El datatable retornado por la controladora.
       */
        internal DataTable getComidasCampo(String estacion, String inicio, String final)
        {
            return controladoraBD.getComidasCampo(estacion, inicio, final);
        }

        /*
      * Requiere: hilera con el identificador de la estacion, de la fecha inicio, de la fecha final
      * Efectua : llama a getBebidas de la controladora de base de datos con el parametro dado. 
      * Retorna :  El datatable retornado por la controladora.
      */
        internal DataTable getBebidas(String estacion, String inicio, String final)
        {
            return controladoraBD.getBebidas(estacion, inicio, final);
        }
    }
}