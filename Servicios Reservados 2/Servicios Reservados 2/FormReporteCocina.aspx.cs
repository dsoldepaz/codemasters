using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicios_Reservados_2
{
    public partial class FormReporteCocina : System.Web.UI.Page
    {
        private static ControladoraReporteCocina controladora = new ControladoraReporteCocina();
        private static String estacion;
        private String fechaInicio;
        private String fechaFinal;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList listaRoles = (ArrayList)Session["Roles"];
            string userid = (string)Session["username"];
            if (!IsPostBack)
            {

                estacion = "Las Cruces";
                fechaInicio = DateTime.Today.ToString("MM/dd/yyyy");
                fechaFinal = DateTime.Today.ToString("MM/dd/yyyy");
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                } if (!listaRoles.Contains("administrador sistema") && !listaRoles.Contains("encargado cocina") && !listaRoles.Contains("administrador global"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
                llenarGridTotal();
                llenarGridTurnos();
                llenarGridSnacks();
            }
        }

        protected void GridViewSnacks_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

            GridViewSnacks.PageIndex = e.NewPageIndex;
            GridViewSnacks.DataSource = Session["tablaS"];
            GridViewSnacks.DataBind();

        }

        protected void GridViewBebidas_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

            GridViewBebidas.PageIndex = e.NewPageIndex;
            GridViewBebidas.DataSource = Session["tablaB"];
            GridViewBebidas.DataBind();

        }


        /**
      * Requiere: n/a
      * Efectua: Crea la DataTable para desplegar.
      * retorna:  un dato del tipo DataTable con la estructura para consultar.
      */
        protected DataTable crearTablaTotal()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Tipo Servicio";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Total";
            tabla.Columns.Add(columna);

            GridViewTotal.DataSource = tabla;
            GridViewTotal.DataBind();

            return tabla;
        }

        /**
      * Requiere: n/a
      * Efectua: Crea la DataTable para desplegar.
      * retorna:  un dato del tipo DataTable con la estructura para consultar.
      */
        protected DataTable crearTablaTurnos()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Categoria";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Restaurante";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Comida Campo";
            tabla.Columns.Add(columna);

            GridViewTurnos.DataSource = tabla;
            GridViewTurnos.DataBind();

            return tabla;
        }

        /**
      * Requiere: n/a
      * Efectua: Crea la DataTable para desplegar.
      * retorna:  un dato del tipo DataTable con la estructura para consultar.
      */
        protected DataTable crearTablaSnacks()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Hora";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Tipo";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Descripción";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Total";
            tabla.Columns.Add(columna);

            GridViewSnacks.DataSource = tabla;
            GridViewSnacks.DataBind();

            return tabla;
        }
        /**
     * Requiere: n/a
     * Efectua: Crea la DataTable para desplegar.
     * retorna:  un dato del tipo DataTable con la estructura para consultar.
     */
        protected DataTable crearTablaBebidas()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Hora";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Tipo";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Descripción";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Total";
            tabla.Columns.Add(columna);

            GridViewBebidas.DataSource = tabla;
            GridViewBebidas.DataBind();

            return tabla;
        }
        /**
   * Requiere: n/a
   * Efectua: Llena la tabla  GridTotal
   * retorna:  N/A
   */
        protected void llenarGridTotal()
        {
            DataTable tabla = crearTablaTotal();
            String sigla = "";
            int desayunos = 0;
            int almuerzos = 0;
            int cena = 0;
            int queque = 0;
            int cafe = 0;
            int sandwich = 0;
            int galloPinto = 0;
            int jugo = 0;
            int agua = 0;
            int ensalada = 0;
            int mayonesa = 0;
            int confites = 0;
            int frutas = 0;
            int salsa = 0;
            int huevoDuro = 0;
            int galletas = 0;
            int platanos = 0;

            if (estacion == "Las Cruces")
            {
                sigla = "LC";
            }
            else if (estacion == "Palo Verde")
            {
                sigla = "PV";

            }
            else
            {
                sigla = "LS";
            }

            try
            {

                Object[] datos = new Object[2];

                //Obtiene los datos de las reservaciones que reservan las 3 comidas por dia
                DataTable turnosDiaTres = controladora.solicitarTurnoDiaTresComidas(sigla, fechaInicio, fechaFinal);

                if (turnosDiaTres.Rows.Count > 0)
                {
                    foreach (DataRow fila in turnosDiaTres.Rows)
                    {
                        desayunos = int.Parse(fila[1].ToString());
                    }
                }


                almuerzos = desayunos;
                cena = desayunos;
                //Obtiene los datos de reservaciones que reservan solo 2 comidas por dia
                DataTable turnosDiaDos = controladora.solicitarTurnoDiaDosComidas(sigla, fechaInicio, fechaFinal);
                if (turnosDiaDos.Rows.Count > 0)
                {
                    foreach (DataRow fila in turnosDiaDos.Rows)
                    {
                        String turno;
                        int cantidad;
                        turno = fila[0].ToString();
                        cantidad = (int.Parse(fila[2].ToString()));
                        if (turno == "ALMUERZO")
                        {
                            almuerzos += cantidad;
                            cena += cantidad;
                        }
                        else if (turno == "CENA")
                        {
                            desayunos += cantidad;
                            cena += cantidad;
                        }
                        else
                        {
                            desayunos += cantidad;
                            almuerzos += cantidad;
                        }

                    }
                }

                //Obtener reservaciones entrantes para calculos mas exactos de platos a cocinar
                DataTable reservaEntrante = controladora.reservaEntrante(sigla, fechaInicio, fechaFinal);

                if (reservaEntrante.Rows.Count > 0)
                {

                    foreach (DataRow fila in reservaEntrante.Rows)
                    {
                        String turno;
                        String tipoC;
                        int cantidad;
                        turno = fila[0].ToString();
                        tipoC = fila[1].ToString();
                        cantidad = (int.Parse(fila[3].ToString()));
                        if (turno == "ALMUERZO" && tipoC == "3 Comidas (" + sigla + ")")
                        {
                            desayunos = desayunos - cantidad;
                        }
                        else if (turno == "CENA")
                        {
                            if (tipoC == "3 Comidas (" + sigla + ")")
                            {
                                desayunos = desayunos - cantidad;
                                almuerzos = almuerzos - cantidad;
                            }
                            else
                            {
                                desayunos = desayunos - cantidad;
                            }

                        }


                    }

                }
                //solicitar datos de comidaExtra
                DataTable comidasE = controladora.solicitarCE(estacion, fechaInicio, fechaFinal);

                if (comidasE.Rows.Count > 0)
                {

                    foreach (DataRow fila in comidasE.Rows)
                    {
                        String tipoC;
                        int cantidad;
                        tipoC = fila[0].ToString();
                        cantidad = (int.Parse(fila[2].ToString()));
                        if (tipoC == "Desayuno")
                        {
                            desayunos += cantidad;
                        }
                        else if (tipoC == "Almuerzo")
                        {
                            almuerzos += cantidad;

                        }
                        else if (tipoC == "Cena")
                        {
                            cena += cantidad;
                        }
                        else if (tipoC == "Queque")
                        {
                            queque = cantidad;

                        }
                        else if (tipoC == "Café")
                        {
                            cafe = cantidad;
                        }


                    }

                }
                //solicitar datos de comida campo
                DataTable comidasC = controladora.solicitarCC(estacion, fechaInicio, fechaFinal);

                if (comidasC.Rows.Count > 0)
                {

                    foreach (DataRow fila in comidasC.Rows)
                    {
                        int opcion;
                        int cantidad;
                        opcion = int.Parse(fila[0].ToString());
                        cantidad = (int.Parse(fila[1].ToString()));
                        if (opcion == 1)
                        {
                            desayunos += cantidad;
                        }
                        else if (opcion == 2)
                        {
                            almuerzos += cantidad;

                        }
                        else if (opcion == 3)
                        {
                            cena += cantidad;
                        }
                        else if (opcion == 4)
                        {
                            sandwich = cantidad;

                        }
                        else if (opcion == 5)
                        {
                            galloPinto = cantidad;
                        }


                    }

                }

                //Obteber cantidad de comidas para empleado
                DataTable comidasEmpleado = controladora.getDesayunos(estacion, fechaInicio, fechaFinal);
                if (comidasEmpleado.Rows.Count > 0)
                {

                    foreach (DataRow fila in comidasEmpleado.Rows)
                    {
                        int cantidad;
                        cantidad = int.Parse(fila[1].ToString());
                        desayunos += cantidad;



                    }
                }
                //Obtiene los almuerzos
                comidasEmpleado = controladora.getAlmuerzos(estacion, fechaInicio, fechaFinal);
                if (comidasEmpleado.Rows.Count > 0)
                {

                    foreach (DataRow fila in comidasEmpleado.Rows)
                    {
                        int cantidad;
                        cantidad = int.Parse(fila[1].ToString());
                        almuerzos += cantidad;



                    }
                }
                //Obtiene las cenas      
                comidasEmpleado = controladora.getCenas(estacion, fechaInicio, fechaFinal);
                if (comidasEmpleado.Rows.Count > 0)
                {

                    foreach (DataRow fila in comidasEmpleado.Rows)
                    {
                        int cantidad;
                        cantidad = int.Parse(fila[1].ToString());
                        cena += cantidad;



                    }
                }
                //Obtener cantidad de bebidas
                DataTable bebidas = controladora.solicitarBebidas(estacion, fechaInicio, fechaFinal);

                if (bebidas.Rows.Count > 0)
                {

                    foreach (DataRow fila in bebidas.Rows)
                    {
                        String tipo;
                        int cantidad;
                        tipo = fila[0].ToString();
                        cantidad = (int.Parse(fila[1].ToString()));
                        if (tipo == "Agua")
                        {
                            agua = cantidad;
                        }
                        else
                        {
                            jugo = cantidad;
                        }

                    }

                }
                //Obtener cantidad de adicionales
                DataTable adicionales = controladora.solicitarAdicionales(estacion, fechaInicio, fechaFinal);

                if (adicionales.Rows.Count > 0)
                {

                    foreach (DataRow fila in adicionales.Rows)
                    {
                        String tipo;
                        int cantidad;
                        tipo = fila[0].ToString();
                        cantidad = (int.Parse(fila[1].ToString()));
                        if (tipo == "Ensalada")
                        {
                            ensalada = cantidad;
                        }
                        else if (tipo == "Mayonesa")
                        {
                            mayonesa = cantidad;

                        }
                        else if (tipo == "Confites")
                        {
                            confites = cantidad;
                        }
                        else if (tipo == "Frutas")
                        {
                            frutas = cantidad;

                        }
                        else if (tipo == "Salsa de tomate")
                        {
                            salsa = cantidad;
                        }

                        else if (tipo == "Huevos duros")
                        {
                            huevoDuro = cantidad;
                        }

                        else if (tipo == "Galletas")
                        {
                            galletas = cantidad;
                        }

                        else if (tipo == "Platanos")
                        {
                            platanos = cantidad;
                        }

                    }

                }
                //crea la tabla que se mostrara en pantalla
                for (int i = 0; i < 17; i++)
                {
                    switch (i)
                    {
                        case 0:
                            datos[0] = "Desayuno";
                            datos[1] = desayunos;
                            break;
                        case 1:
                            datos[0] = "Almuerzo";
                            datos[1] = almuerzos;
                            break;

                        case 2:
                            datos[0] = "Cena";
                            datos[1] = cena;
                            break;
                        case 3:
                            datos[0] = "Queque";
                            datos[1] = queque;
                            break;
                        case 4:
                            datos[0] = "Café";
                            datos[1] = cafe;
                            break;

                        case 5:
                            datos[0] = "Sandwich";
                            datos[1] = sandwich;
                            break;

                        case 6:
                            datos[0] = "Gallo Pinto";
                            datos[1] = galloPinto;
                            break;
                        case 7:
                            datos[0] = "Agua";
                            datos[1] = agua;
                            break;
                        case 8:
                            datos[0] = "Jugo";
                            datos[1] = jugo;
                            break;

                        case 9:
                            datos[0] = "Ensalada";
                            datos[1] = ensalada;
                            break;

                        case 10:
                            datos[0] = "Mayonesa";
                            datos[1] = mayonesa;
                            break;

                        case 11:
                            datos[0] = "Confites";
                            datos[1] = confites;
                            break;
                        case 12:
                            datos[0] = "Frutas";
                            datos[1] = frutas;
                            break;

                        case 13:
                            datos[0] = "Salsa de tomate";
                            datos[1] = salsa;
                            break;

                        case 14:
                            datos[0] = "Huevos Duros";
                            datos[1] = huevoDuro;
                            break;

                        case 15:
                            datos[0] = "Galletas";
                            datos[1] = galletas;
                            break;

                        case 16:
                            datos[0] = "Platanos";
                            datos[1] = platanos;
                            break;


                        default:
                            break;

                    }
                    tabla.Rows.Add(datos);
                }

                GridViewTotal.DataBind();


            }
            catch (Exception e)
            {
                Debug.WriteLine("No se pudo cargar el total de comidas");
            }

        }

        /**
        * Requiere: n/a
        * Efectua: Llena la tabla de GridSnacks
        * retorna:  N/A
        */
        protected void llenarGridSnacks()
        {
            DataTable tabla = crearTablaSnacks();
            String descripcion = "";
            Object[] datos = new Object[4];
            DataTable datosCC = controladora.getComidasCampo(estacion, fechaInicio, fechaFinal);
            if (datosCC.Rows.Count > 0)
            {

                foreach (DataRow fila in datosCC.Rows)
                {
                    int opcion = int.Parse(fila[1].ToString());
                    if (opcion == 4)
                    {
                        descripcion = fila[2].ToString() + " con relleno de " + fila[3].ToString();
                        datos[0] = fila[0].ToString();
                        datos[1] = "Sandwich";
                        datos[2] = descripcion;
                        datos[3] = fila[4].ToString();

                    }
                    else if (opcion == 5)
                    {
                        datos[0] = fila[0].ToString();
                        datos[1] = "Gallo Pinto";
                        datos[2] = "-";
                        datos[3] = fila[4].ToString();

                    }
                    tabla.Rows.Add(datos);
                }

            }

            DataTable datosCE = controladora.getComidasExtra(estacion, fechaInicio, fechaFinal);
            if (datosCC.Rows.Count > 0)
            {

                foreach (DataRow fila in datosCE.Rows)
                {

                    datos[0] = fila[0].ToString();
                    datos[1] = fila[1].ToString();
                    datos[2] = fila[2].ToString();
                    datos[3] = fila[3].ToString();
                    tabla.Rows.Add(datos);
                }

            }
            Session["tablaS"] = tabla;
            GridViewSnacks.DataBind();



        }
        /**
        * Requiere: n/a
        * Efectua: Llena la tabla  GridTurnos
        * retorna:  N/A
        */
        protected void llenarGridTurnos()
        {
            int desayunos = 0;
            int almuerzos = 0;
            int cenas = 0;
            int desayunosC = 0;
            int almuerzosC = 0;
            int cenasC = 0;

            Object[] datos = new Object[3];
            DataTable tabla = crearTablaTurnos();
            desayunos = Convert.ToInt32(GridViewTotal.Rows[0].Cells[1].Text);
            almuerzos = Convert.ToInt32(GridViewTotal.Rows[1].Cells[1].Text);
            cenas = Convert.ToInt32(GridViewTotal.Rows[2].Cells[1].Text);

            DataTable comidaCampo = controladora.solicitarCC(estacion, fechaInicio, fechaFinal);

            if (comidaCampo.Rows.Count > 0)
            {

                foreach (DataRow fila in comidaCampo.Rows)
                {
                    int opcion;
                    int cantidad;
                    opcion = int.Parse(fila[0].ToString());
                    cantidad = (int.Parse(fila[1].ToString()));
                    if (opcion == 1)
                    {
                        desayunosC = cantidad;
                        desayunos -= cantidad;
                    }
                    else if (opcion == 2)
                    {
                        almuerzosC = cantidad;
                        almuerzos -= cantidad;

                    }
                    else if (opcion == 3)
                    {
                        cenasC = cantidad;
                        cenas -= cantidad;
                    }



                }

            }

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        datos[0] = "Desayuno";
                        datos[1] = desayunos;
                        datos[2] = desayunosC;
                        break;
                    case 1:
                        datos[0] = "Almuerzo";
                        datos[1] = almuerzos;
                        datos[2] = almuerzosC;
                        break;

                    case 2:
                        datos[0] = "Cena";
                        datos[1] = cenas;
                        datos[2] = cenasC;
                        break;

                    default:
                        break;
                }
                tabla.Rows.Add(datos);
            }
            GridViewTurnos.DataBind();

        }
        protected void clickBuscar(object sender, EventArgs e)
        {
            DateTime mañana = DateTime.Now.AddDays(1);
            if (cbxFecha.Value.ToString() == "Día siguiente")
            {
                fechaInicio = mañana.ToString("MM/dd/yyyy");
                fechaFinal = mañana.ToString("MM/dd/yyyy");
            }

            if (cbxFecha.Value.ToString() == "Hoy")
            {
                fechaInicio = DateTime.Today.ToString("MM/dd/yyyy");
                fechaFinal = DateTime.Today.ToString("MM/dd/yyyy");
            }
            llenarGridTotal();
            llenarGridTurnos();
            llenarGridSnacks();
        }
        /*
         * Requiere: N/A
         * Efectua : Pide el numero de notificaciones a la controladora y lo actualiza en la interfaz grafica
         * Retoirna: N/A
         */
        private void obtenerNotificaciones()
        {
            int numNotificaciones = controladora.getNotificaciones();
            contador.InnerText = numNotificaciones + "";
            if (numNotificaciones > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('tiene " + numNotificaciones + " notificaciones nuevas');", true);
            }
        }
    }
}