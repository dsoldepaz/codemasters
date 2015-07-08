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
        /*
         * Requiere: N/A
         * Efectúa : selecciona los roles asignados
         * retorna : N/A
         */
        internal DataTable obtenerRoles()
        {
            dt = new DataTable();
            String consultaSQL = "select rol from usuariorol";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }
        /*
        * Requiere: N/A
        * Efectúa : selecciona la informacion de todos los usuarios
        * retorna : N/A
        */
        internal DataTable consultarUsuarios()
        {
            dt = new DataTable();
            String consultaSQL = "select username, Nombre, estacion, activo from usuario";
            dt = adaptador.consultar(consultaSQL);
            return dt;
        }
        /*
     * Requiere: N/A
     * Efectúa : selecciona la informacion de todos los roles
     * retorna : N/A
     */
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
        public String[] agregarUsuario(EntidadUsuario entidad, String contrasena)
        {
            String[] respuesta = new String[3];
            String consultaSQL = "insert into usuario values('" + entidad.Username + "','" + contrasena + "','" +
                    entidad.Correo + "', sysdate,'" + entidad.Estado + "','" + entidad.Estacion + "', 1,'" + entidad.Nombre + "')";
            respuesta = adaptador.insertar(consultaSQL);

            return respuesta;
        }

        /*
        * Efecto: inserta en la tabla de usuariorol
        * Requiere: la entidad de usuario (datos encapsulados), el rol
        * Modifica: la tabla usuariorol
       */
        public String[] agregarUsuarioRol(string usuario, string rol)
        {
            String[] respuesta = new String[3];
            String consultaSQL = "insert into usuariorol values('" + usuario + "','" + rol + "')";
            respuesta = adaptador.insertar(consultaSQL);
            return respuesta;
        }

        /*
        * Efecto: consulta la informacion de un usuario
        * Requiere: seleccion de un usuario
        * Modifica: nada
       */
        internal DataTable consultarUsuario(string usernameSeleccionado)
        {
            dt = new DataTable();
            String consultaSQL = "select username, Nombre, email, activo, estacion from usuario where username='" + usernameSeleccionado + "'";
            return adaptador.consultar(consultaSQL);
        }
        /*
        * Efecto: consulta los roles de un usuario
        * Requiere: seleccion de un usuario
        * Modifica: nada
       */
        internal DataTable consultarUsuarioRol(string usernameSeleccionado)
        {
            dt = new DataTable();
            String consultaSQL = "select rol from usuariorol where usuario='" + usernameSeleccionado + "'";
            return adaptador.consultar(consultaSQL);
        }
        /*
        * Efecto: modifica la informacion de un usuario
        * Requiere: seleccion de un usuario
        * Modifica: la tabla de usuarios
        */
        internal string[] modificarUsuario(EntidadUsuario entidad)
        {
            String[] respuesta = new String[3];
            String consultaSQL = "update usuario set nombre='" + entidad.Nombre + "', email='" + entidad.Correo + "', activo=" + entidad.Estado +
                ", estacion='" + entidad.Estacion + "' where username='" + entidad.Username + "'";
            respuesta = adaptador.insertar(consultaSQL);
            return respuesta;
        }
        /*
        * Efecto: borra todos los roles de un usuario
        * Requiere: seleccion de un usuario
        * Modifica: la tabla de roles de usuario
        */
        internal string[] limpiarRoles(string usernameSeleccionado)
        {
            String[] respuesta = new String[3];
            String consultaSQL = "delete from usuariorol where usuario='" + usernameSeleccionado + "'";
            respuesta = adaptador.insertar(consultaSQL);
            return respuesta;
        }
        /*
        * Efecto: desactiva un usuario
        * Requiere: seleccion de un usuario
        * Modifica: la tabla de usuarios
        */
        internal string[] desactivarUsuario(string username)
        {
            String[] respuesta = new String[3];
            String consultaSQL = "update usuario set activo =" + 0 + " where username='" + username + "'";
            respuesta = adaptador.insertar(consultaSQL);
            return respuesta;
        }

        /*
        * Efecto: actualiza la contrase;a de un usuario
        * Requiere: seleccion de un usuario, nueva contrse;a
        * Modifica: la tabla usuario
        */
        internal string[] actualizarContrasena(string username, string contrasena)
        {
            String[] respuesta = new String[3];
            String consultaSQL = "update usuario set contrasena ='" + contrasena + "', reestablecer=0 where username='" + username + "'";
            respuesta = adaptador.insertar(consultaSQL);
            return respuesta;
        }
        /*
        * Efecto: reestablece la contrase;a de un usuario
        * Requiere: seleccion de un usuario, contrase;a 
        * Modifica: la tabla usuario
        */
        internal string[] reestablecerContrasena(string username, string contrasena)
        {
            String[] respuesta = new String[3];
            String consultaSQL = "update usuario set contrasena ='" + contrasena + "', reestablecer=1 where username='" + username + "'";
            respuesta = adaptador.insertar(consultaSQL);
            return respuesta;
        }
        /*
         * Requiere: parametros: estación, nombre de usuario y nombre
         * Modifica : nada
         * retorna : DataTable con la lista de usuarios filtardos
         */
        internal DataTable seleccionarUsuariosFiltro(string estacion, string nombreUsuario, string nombre)
        {
            dt = new DataTable();
            String consultaSQL = "select username, Nombre, estacion, activo from usuario";
            //en caso de filtros
            if (!"".Equals(estacion) && "".Equals(nombreUsuario) && "".Equals(nombre))//un flitro
            {
                consultaSQL = "select username, Nombre, estacion, activo from usuario where estacion='" + estacion + "'";
            }
            else if ("".Equals(estacion) && !"".Equals(nombreUsuario) && "".Equals(nombre))
            {
                consultaSQL = "select username, Nombre, estacion, activo from usuario where LOWER(username) like '%" + nombreUsuario.ToLower() + "%'";
            }
            else if ("".Equals(estacion) && "".Equals(nombreUsuario) && !"".Equals(nombre))
            {
                consultaSQL = "select username, Nombre, estacion, activo from usuario where LOWER(nombre) like '%" + nombre.ToLower() + "%'";
            }
            else if (!"".Equals(estacion) && !"".Equals(nombreUsuario) && "".Equals(nombre))//dos filtros
            {
                consultaSQL = "select username, Nombre, estacion, activo from usuario where estacion='" + estacion + "' and LOWER(username) like '%" + nombreUsuario.ToLower() + "%'";
            }
            else if (!"".Equals(estacion) && "".Equals(nombreUsuario) && !"".Equals(nombre))
            {
                consultaSQL = "select username, Nombre, estacion, activo from usuario where estacion='" + estacion + "' and LOWER(nombre) like '%" + nombre.ToLower() + "%'";
            }
            else if ("".Equals(estacion) && !"".Equals(nombreUsuario) && !"".Equals(nombre))
            {
                consultaSQL = "select username, Nombre, estacion, activo from usuario where LOWER(username) like '%" + nombreUsuario.ToLower() + "%' and LOWER(nombre) like '%" + nombre.ToLower() + "%'";
            }
            else if (!"".Equals(estacion) && !"".Equals(nombreUsuario) && !"".Equals(nombre))//tres filtros
            {
                consultaSQL = "select username, Nombre, estacion, activo from usuario where estacion='" + estacion + "' and LOWER(username) like '%" + nombreUsuario.ToLower() + "%' and LOWER(nombre) like '%" + nombre.ToLower() + "%'";
            }

            return adaptador.consultar(consultaSQL);
        }
    }
}