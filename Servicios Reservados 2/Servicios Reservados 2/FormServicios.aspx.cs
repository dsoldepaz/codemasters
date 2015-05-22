using Servicios_Reservados_2.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Collections;

namespace Servicios_Reservados_2
{
    public partial class FormServicios : System.Web.UI.Page
    {
        private ControladoraServicios controladora = new ControladoraServicios();
        private static DataTable reservacion = new DataTable();
        private static String[] ids;
        private static String[] idServ;
        public static int modo;
        public static int i = 0;
        public static String tipo;
        public static String categoria = "Comida Extra";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList listaRoles = (ArrayList)Session["Roles"];
            string userid = (string)Session["username"];
            if (!IsPostBack)
            {
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                }
                if (!listaRoles.Contains("admin") && !listaRoles.Contains("recepcion"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
                llenarCampos();
                llenarGridServicios();
            }
        }
        
        protected void clickAceptar(object sender, EventArgs e)
        {
            //rec = controladora.prueba("ANURA0310112004.095646531");
            //if (rec.Rows.Count > 0)
            //{ // si hay un valor
            //  string num = rec.Rows[0][8].ToString();
            //nombreReservacion.Value = num;
            //Debug.WriteLine(num);
            //}
        }

      
        /*Efecto: Llena los campos con la informacion de la reserva
         * Requiere: NA
         * Modifica: el valor de los campos en la interfaz
         */
        protected void llenarCampos()
        {
            DataTable pax = controladora.obtenerPax(controladora.idNumSelected());
            txtAnfitriona.Value = controladora.informacionServicio().Anfitriona;
            txtEstacion.Value = controladora.informacionServicio().Estacion;
            txtNombre.Value = controladora.informacionServicio().Solicitante;
            fechaInicio.Value = controladora.informacionServicio().FechaInicio.ToString("dd/MM/yyyy");
            fechaFinal.Value = controladora.informacionServicio().FechaSalida.ToString("dd/MM/yyyy");
            txtPax.Value = pax.Rows[0][0].ToString();
        }

        /*Efecto: Crea la tabla de servicios
         * Requiere: NA
         * Modifica: la tabla servicios, si la reservacion tiene servicios asociados
         * */
        void llenarGridServicios()
        {
            DataTable tabla = crearTablaServicios();
         //   DataTable tablaCampo = crearTablaComidaCampo();

            try
            {

                Object[] datos = new Object[7];
               // DataTable paquete = controladora.solicitarPaquete(controladora.idSelected());// se consultan todos
                DataTable servicios = controladora.solicitarServicios(controladora.idSelected());// se consultan todos
                DataTable comidaCampo = controladora.solicitarComidaCampo(controladora.idSelected());// se consultan todos   
                
                ids = new String[servicios.Rows.Count + comidaCampo.Rows.Count + 1]; //crear el vector para ids en el grid
                idServ = new String[servicios.Rows.Count + comidaCampo.Rows.Count + 1];

                /*if (paquete.Rows.Count > 0)
                {
                    foreach (DataRow fila in paquete.Rows)
                    {                       
                        idServ[i] = fila[1].ToString();
                        datos[0] = "Paquete reservación";
                        datos[1] = fila[2].ToString();//obtener los datos a mostrar
                        datos[2] = fila[3].ToString();
                        datos[3] = fila[4].ToString();
                        datos[4] = fila[5].ToString();//DateTime.Parse(fila[5].ToString());
                        datos[5] = fila[6].ToString();
                        datos[6] = fila[7].ToString();
                        tabla.Rows.Add(datos);// cargar en la tabla los datos de cada proveedor
                        i++;
                    }
                }*/



                if (servicios.Rows.Count > 0)
                {
                   
                   

                    foreach (DataRow fila in servicios.Rows)
                    {
                        ids[i] = fila[0].ToString();// guardar el id para su posterior consulta
                        idServ[i] = fila[1].ToString();
                        datos[0] = "Comida Extra";
                        datos[1] = fila[2].ToString();//obtener los datos a mostrar
                        datos[2] = fila[3].ToString();
                        datos[3] = fila[4].ToString();
                        datos[4] = fila[5].ToString();//DateTime.Parse(fila[5].ToString());
                        datos[5] = fila[6].ToString();
                        datos[6] = fila[7].ToString();
                        tabla.Rows.Add(datos);// cargar en la tabla los datos de cada proveedor
                        i++;
                    }
                }
      

                int j = i;
                if (comidaCampo.Rows.Count > 0)
                {
                  

                    foreach (DataRow fila in comidaCampo.Rows)
                    {
                       
                        idServ[j] = fila[0].ToString();
                        ids[j] = fila[1].ToString();
                        datos[0] = "Comida Campo";
                        if (int.Parse(fila[4].ToString()) == 1)
                        {
                            datos[1] = "Sandwich";
                        }
                        else
                        {
                            datos[1] = "Gallo Pinto";
                        }
                        datos[2] = fila[5].ToString();
                        datos[3] = fila[9].ToString();
                        datos[4] = fila[2].ToString();//DateTime.Parse(fila[5].ToString());
                        datos[5] = fila[3].ToString();
                        datos[6] = fila[8].ToString();
                        tabla.Rows.Add(datos);// cargar en la tabla los datos de cada proveedor
                        j++;
                    }
                }
                

                GridServicios.DataBind();
                
            }
            catch (Exception e)
            {
                Debug.WriteLine("No se pudo cargar las reservaciones");
            }
        }

        /**
     * Requiere: n/a
     * Efectua: Crea la DataTable para desplegar.
     * retorna:  un dato del tipo DataTable con la estructura para consultar.
     */
        protected DataTable crearTablaServicios()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Categoría";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Tipo";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Descripcion";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Hora";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Fecha";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Estado";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Pax";
            tabla.Columns.Add(columna);

            GridServicios.DataSource = tabla;
            GridServicios.DataBind();

            return tabla;
        }



        /*Efecto: obtiene el id del servicio seleccionado y de la reservacion a la que pertence el servicio 
         * Requiere: parametros evento de la interfaz grafica
         * Modifica: NA
         */
        protected void seleccionarServicio(object sender, EventArgs e)
        {
            if (idServ[GridServicios.SelectedIndex].Contains("S")) 
            {
                controladora.seleccionarServicio(ids[0], idServ[GridServicios.SelectedIndex]);
            }
            else {
                controladora.seleccionarComidaCampo(ids[0], idServ[GridServicios.SelectedIndex]);
            }
           
        }
        /*
         * Efecto: llama al metodo modificarServicio de la controladora y redirecciona la pagina al formComidaExtra
         * Requiere: parametros evento de la interfaz grafica
         * Modifica: la variable global modo.
         */
        protected void modificarServicio(object sender, EventArgs e)
        {
            modo = 2; //modificar es 2
            Response.Redirect("FormComidaExtra");
        }

        /*
        * Efecto: capta el evento del botón para agregar una comida extra, cambia el modo y redirige a la interfaz de comida extra.
        * Requiere: presionar el botón.
        * Modifica: la variable global modo.
        */
        protected void clickAgregarServicio(object sender, EventArgs e)
        {
            modo = 1; 
            Response.Redirect("FormComidaExtra");
        }

        /*
       * Efecto: capta el evento del botón para cancelar una comida extra, cambia el modo y redirige a la interfaz de comida extra.
       * Requiere: presionar el botón.
       * Modifica: la variable global modo.
       */
        protected void clickEliminarServicio(object sender, EventArgs e)
        {
            modo = 3; 
            Response.Redirect("FormComidaExtra");
        }

        /*
       * Efecto: capta el evento del botón para consultar una comida extra, cambia el modo y redirige a la interfaz de comida extra.
       * Requiere: presionar el botón.
       * Modifica: la variable global modo.
       */
        protected void clickConsultarServicio(object sender, EventArgs e) 
        {
            if (idServ[GridServicios.SelectedIndex].Contains("S"))
            {
                modo = 0;
                Response.Redirect("FormComidaExtra"); ;
            }
            else {
                FormComidaCampo.modo = 4;
                Response.Redirect("FormComidaCampo");
            }
          

        }
        protected void clickActivarTiquetes(object sender, EventArgs e)
        {
            Response.Redirect("FormTiquete");
        }

    }
}