using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicios_Reservados_2
{
    public partial class Notificaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarNotificaciones();
        }
        protected void llenarNotificaciones(){
            DataTable tabla = crearTablaComidaEmpleado();
            Object[] datos = new Object[8];
            datos[0] = "10:53 am";
            datos[1] = "Comida Empleado";
            datos[2] = "Almuerzo";
            datos[3] = "Reservado";
            datos[4] = "Cancelado";
            datos[5] = "Cancelacion";
            datos[6] = "Retraso en tour por el bosque";
            datos[7] = "254";
            tabla.Rows.Add(datos);
            GridNotificaciones.DataBind();
        }
        /**
        * Requiere: n/a
        * Efectua: Crea la DataTable para desplegar.
        * retorna:  un dato del tipo DataTable con la estructura para consultar.
        */
                //SELECT IDCOMIDAEMPLEADO,'Comida regular',IDEMPLEADO,FECHA,PAGADO
        protected DataTable crearTablaComidaEmpleado()//consultar
        {
            DataTable tabla = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Hora";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Tipo De Servicio";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Campo Modificado";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Valor Anterior";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Valor Actual";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Tipo";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Motivo";
            tabla.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Numero de Reserva / carne de empleado";
            tabla.Columns.Add(columna);

            GridNotificaciones.DataSource = tabla;
            GridNotificaciones.DataBind();

            return tabla;
        }
    }
}