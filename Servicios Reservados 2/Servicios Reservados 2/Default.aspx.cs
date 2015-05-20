using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicios_Reservados_2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //seguridad
            Recepcionista.Visible=false;
            Cocina.Visible=false;      
            string userid = (string)Session["username"];
            ArrayList listaRoles = (ArrayList)Session["Roles"];


            if (!IsPostBack)
            {
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                }
                if (listaRoles.Contains("admin") || listaRoles.Contains("recepcion"))
                {
                    Recepcionista.Visible = true;
                }
                if (listaRoles.Contains("admin") || listaRoles.Contains("cocina"))
                {
                    Cocina.Visible = true;
                }
                
            }

        }
    }
}