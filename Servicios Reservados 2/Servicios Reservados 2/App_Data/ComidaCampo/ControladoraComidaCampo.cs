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
        public static EntidadComidaCampo comidaSeleccionada;

        
        public ControladoraComidaCampo()
        {
            controladoraBD = new ControladoraBDComidaCampo();
           
        }

        public void guardarComidaSeleccionada(Object[] dato)
        {
         comidaSeleccionada = new EntidadComidaCampo(dato);
            
        }

        public String[] agregarComidaCampo(Object[] dato)
        {
            EntidadComidaCampo nuevaComidaCampo = new EntidadComidaCampo(dato);
            String[] resultado = controladoraBD.agregarComidaCampo(nuevaComidaCampo);
            return resultado;
        }

        public EntidadComidaCampo entidadSeleccionada()
        {
            return comidaSeleccionada;
        }
    }
}