using Servicios_Reservados_2.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Diagnostics;
using System.Web.UI.WebControls;

namespace Servicios_Reservados_2
{
    public partial class FormServicios : System.Web.UI.Page
    {
        private ControladoraServicios controladora = new ControladoraServicios();
        private static DataTable reservacion = new DataTable();
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Debug.Write("esot es:" + controladora.informacionServicio().Anfitriona);
            llenarCampos();
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
       
        protected void llenarCampos()
        {
            txtAnfitriona.Value = controladora.informacionServicio().Anfitriona;
            txtEstacion.Value = controladora.informacionServicio().Estacion;
            txtNombre.Value = controladora.informacionServicio().Solicitante;
            fechaInicio.Value = controladora.informacionServicio().FechaInicio.ToString();
            fechaFinal.Value= controladora.informacionServicio().FechaSalida.ToString();
        }

        
        
    }
}