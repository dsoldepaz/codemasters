using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraEmpleadoReserva
    {
        private ControladoraEmpleado controladoraEmpleado;
        private ControladoraComidaEmpleado controladoraComidaEmpleado;
        private ControladoraComidaCampo controladoraComidaCampo;
        private static EntidadServicios seleccionada;
        public ControladoraEmpleadoReserva()
        {
            controladoraEmpleado = new ControladoraEmpleado();
            controladoraComidaEmpleado = new ControladoraComidaEmpleado();
            controladoraComidaCampo = new ControladoraComidaCampo();
        }

        public DataTable obtenerComidaCampo(String id)
        {
            return controladoraComidaCampo.getComidaEmpleado(id);
                    

        }
        public DataTable obtenerTabla(String idEmpleado)
        {
           return  controladoraComidaEmpleado.getComidaEmpleado(idEmpleado);
           
        }
        public EntidadEmpleado obtenerEmpleado(string idEmpleado)
        {
            controladoraEmpleado.seleccionarEmpleado(idEmpleado);
            return controladoraEmpleado.getEmpleadoSeleccionado();
        }

        internal EntidadServicios crearServicio(string idEmpleado, int p)
        {
            
            return seleccionada;
        }
    }
}