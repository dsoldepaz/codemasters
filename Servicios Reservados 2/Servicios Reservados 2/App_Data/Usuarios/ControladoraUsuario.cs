using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraUsuario
    {
        private static ControladoraBDUsuario controladoraBD;
        /*
         * Requiere: N/A
         * Efectúa : Inicializa las variables globales de la clase. 
         * Retorna : N/A
         */
        public ControladoraUsuario()
        {
            controladoraBD = new ControladoraBDUsuario();
        }



        internal DataTable solicitarRolesAsignados()
        {
            return controladoraBD.obtenerRolesAsignados();
        }

        internal DataTable solicitarUsuarios()
        {
            return controladoraBD.consultarUsuarios();
        }

        internal DataTable solicitarTodosRoles()
        {
            return controladoraBD.consultarTodosRoles();
        }

        /*
       * Efecto: encapsula los datos y los envía a la controladora para que sean insertados.
       * Requiere: un objeto con los datos.
       * Modifica: pasa los datos de un objeto a una entidad (encapsularlos).
      */
        public String[] agregarUsuario(Object[] datos)
        {
            EntidadUsuario entidad = new EntidadUsuario(datos);
            String[] resultado = controladoraBD.agregarUsuario(entidad);//llamado a la controladora de base de datos
            return resultado;
        }
    }
}