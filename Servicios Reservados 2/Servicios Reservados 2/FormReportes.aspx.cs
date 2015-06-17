using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicios_Reservados_2
{
	public partial class FormReportes : System.Web.UI.Page
	{
        private static ControladoraReportes controladora = new ControladoraReportes();

		protected void Page_Load(object sender, EventArgs e)
		{
            ArrayList listaRoles = (ArrayList)Session["Roles"];
            string userid = (string)Session["username"];
            if (!IsPostBack)
            {
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                } if (!listaRoles.Contains("administrador local") && !listaRoles.Contains("recepcion") &&!listaRoles.Contains("administrador global"))
                {
                    Response.Redirect("ErrorPermiso.aspx");
                }
            }
		}



	}
}