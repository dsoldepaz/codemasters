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
        private static EntidadServicios seleccionado;
        private static EntidadComidaCampo comidaSeleccionada;
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

        internal EntidadServicios crearServicio(string idEmpleado, int idServicio, string fechaServ, String notas)
        {
            
            seleccionado = new EntidadServicios(idEmpleado, "empleado", idServicio.ToString(), "PonerCategoria", fechaServ, "ponerconsumido", 1, notas);
            return seleccionado;
        }
        internal EntidadComidaCampo consultarComidaCampoSeleccionada(string idEmpleado, String idServicio)
        {
            return controladoraComidaCampo.consultarComidaCampoSeleccionada(idEmpleado, idServicio);
            
        }
        internal EntidadServicios servicioSeleccionado()
        {
            return seleccionado;
        }

        internal void activarTiquete()
        {
            ControladoraTiquete.setServicio(seleccionado);
        }
    }
}