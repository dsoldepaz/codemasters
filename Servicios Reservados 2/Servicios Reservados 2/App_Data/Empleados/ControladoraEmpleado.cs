using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Servicios_Reservados_2
{
    public class ControladoraEmpleado
    {
        
        private static EntidadEmpleado empleadoSeleccionado;
        private static ControladoraBDEmpleado controladoraBD;
        /*
         * Requiere: N/A
         * Efectúa : Inicializa las variables globales de la clase. 
         * Retorna : N/A
         */
        public ControladoraEmpleado()
        {
            controladoraBD = new ControladoraBDEmpleado();
        }

        internal DataTable consultarEmpleados(String nombre, String iden)
        {

            DataTable empleados = controladoraBD.consultarEmpleados(nombre, iden);
            return empleados;
        }

        internal DataTable solicitarTodosEmpleados()
        {
            DataTable todas = controladoraBD.solicitarTodosEmpleados();

            return todas;

        }
    }
    
}