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
        private static EntidadComidaCampo comidaSeleccionada;
        public static Object[] entidad;
        public static Object[] adicional;
        
        public ControladoraComidaCampo()
        {
            controladoraBD = new ControladoraBDComidaCampo();
           
        }

        public void guardarComidaSeleccionada(Object[] dato)
        {
            entidad = dato;
        }

        public void guardarAdicional(Object[] datos)
        {
            adicional = datos;
        }
        public String[] agregarComidaCampo(Object[] dato)
        {
            EntidadComidaCampo nuevaComidaCampo = new EntidadComidaCampo(dato);
            String[] resultado = controladoraBD.agregarComidaCampo(nuevaComidaCampo);
            return resultado;
        }

        public Object[] entidadSeleccionada()
        {
            return entidad;
        }

        public Object[] adicionalSeleccionado()
        {
            return adicional;
        }
    }
}