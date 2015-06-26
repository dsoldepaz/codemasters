using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicios_Reservados_2
{
    public partial class FormReestablecer : System.Web.UI.Page
    {
        ControladoraUsuario controladora = new ControladoraUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = (string)Session["username"];
            if (!IsPostBack)
            {
                if (userid == "" || userid == null)
                {
                    Response.Redirect("~/Ingresar.aspx");
                }                
            }         
       }

        protected void clickReestablecer(object sender, EventArgs e)
        {
            string username = (string)Session["username"];
            String[] error = controladora.reestablecerContrasena(username, txtContraseña.Text);
            if ("danger".Equals(error[0]))
            {
                mostrarMensaje(error[0], error[1], error[2]); // se muestra el resultado
            }
            Response.Redirect("Default");
        }
        protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje)
        {
            alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
            labelTipoAlerta.Text = alerta + " ";
            labelAlerta.Text = mensaje;
            alertAlerta.Attributes.Remove("hidden");
            this.SetFocus(alertAlerta);
        }
    }
}