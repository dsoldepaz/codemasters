using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicios_Reservados_2
{
    public partial class FormServirPlatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void clickVerificar(object sender, EventArgs e)
        {

            ControladoraBDComedor controladora;
            controladora = new ControladoraBDComedor();

            Object[] o = controladora.consultarNotasTiquete(tiquete.Value);

            clienteArea.InnerText = o[0].ToString();
            anfitrionaArea.InnerText = o[1].ToString();
            estacionArea.InnerText = o[2].ToString();
            servidoArea.InnerText = o[3].ToString();
            notasArea.InnerText = o[4].ToString();

        }


    }
}