using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;

namespace Servicios_Reservados_2
{
    public class ControladoraBDUsuario
    {
        private AdaptadorBD adaptador;
        DataTable dt;
    /*
     * Requiere: N/A
     * Efectúa : inicializa las variables globales de la clase
     * retorna : N/A
     */
        public ControladoraBDUsuario()
        {
            adaptador = new AdaptadorBD();
            dt = new DataTable();
        }

        internal DataTable obtenerRolesDisponibles()
        {
            dt = new DataTable();
            String consultaSQL = "select nombre from rol";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        internal DataTable obtenerRolesAsignados()
        {
            dt = new DataTable();
            String consultaSQL = "select rol from usuariorol";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        internal DataTable consultarUsuarios()
        {
            dt = new DataTable();
            String consultaSQL = "select username, Nombre, estacion from usuario";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        internal DataTable consultarTodosRoles()
        {
            dt = new DataTable();
            String consultaSQL = "select nombre from rol";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }

        /*
        * Efecto: inserta en la tabla de usuarios
        * Requiere: la entidad de usuario (datos encapsulados)
        * Modifica: la tabla usuario 
       */
        public String[] agregarUsuario(EntidadUsuario entidad)
        {
            String[] respuesta = new String[3];
            string hashContrasena=LoginService.EncodePassword(entidad.Username);
            String consultaSQL = "insert into usuario values('" + entidad.Username + "','" + hashContrasena + "','" +
                    entidad.Correo + "', sysdate,'" + entidad.Estado + "','" + entidad.Estacion + "', 0,'" + entidad.Nombre + "')";

            respuesta = adaptador.insertar(consultaSQL);

            return respuesta;
        }

    }
}