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
        public static EntidadComidaCampo comidaCampo;
        public static Object[] adicional;
        
        public ControladoraComidaCampo()
        {
            controladoraBD = new ControladoraBDComidaCampo();
           
        }

        public void guardarComidaSeleccionada(Object[] dato, List<String> lista)
        {
            comidaCampo = new EntidadComidaCampo(dato,lista);
        }

        public DataTable getComidaEmpleado(String id) {
            DataTable dt = controladoraBD.getComidaEmpleado(id);
            return dt;
        }
       public String[] agregarComidaCampo(Object[] dato,List<String> lista)
        {
            EntidadComidaCampo nuevaComidaCampo = new EntidadComidaCampo(dato,lista);
            String[] resultado = controladoraBD.agregarComidaCampo(nuevaComidaCampo);
            return resultado;
        }

        public EntidadComidaCampo entidadSeleccionada()
        {
            return comidaCampo;
        }

        public Object[] adicionalSeleccionado()
        {
            return adicional;
        }
    }
}