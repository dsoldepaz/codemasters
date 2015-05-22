using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicios_Reservados_2
{
    public partial class FormTiquete : System.Web.UI.Page
    {
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
                llenarInfoServicio();
                llenarGridTiquetes();
            }
        }

        private void llenarGridTiquetes()
        {
            throw new NotImplementedException();
        }

        private void llenarInfoServicio()
        {
            throw new NotImplementedException();
        }
        protected void clickAgregar(object sender, EventArgs e)
        {

        }
        protected void seleccionarTiquete(object sender, EventArgs e)
        {
           /* if (idServ[GridServicios.SelectedIndex].Contains("S"))
            {
                controladora.seleccionarServicio(ids[0], idServ[GridServicios.SelectedIndex]);
            }
            else
            {
                controladora.seleccionarComidaCampo(ids[0], idServ[GridServicios.SelectedIndex]);
            }*/

        }
        protected void clickQuitar(object sender, EventArgs e)
        {

        }
        protected void clickActivar(object sender, EventArgs e)
        {

        }
    }
}