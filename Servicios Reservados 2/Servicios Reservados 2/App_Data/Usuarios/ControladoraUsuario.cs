﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraUsuario
    {
        EntidadUsuario entidadSeleccionada = null;
        public static String usuarioActual;

        private static ControladoraBDUsuario controladoraBD;
        /*
         * Requiere: N/A
         * Efectúa : Inicializa las variables globales de la clase. 
         * Modifica : N/A
         */
        public ControladoraUsuario()
        {
            controladoraBD = new ControladoraBDUsuario();
        }
        /*
         * Requiere: N/A
         * Efectúa : devuelve los roles asignados
         * Modifica : N/A
         */
        internal DataTable solicitarRolesAsignados()
        {
            return controladoraBD.obtenerRoles();
        }
        /*
         * Requiere: N/A
         * Efectúa : devuelve la lista de usuarios
         * Modifica : N/A
         */
        internal DataTable solicitarUsuarios()
        {
            return controladoraBD.consultarUsuarios();
        }
        /*
         * Requiere: N/A
         * Efectúa : devuelve la lista de todos los roles
         * Modifica : N/A
         */
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
            String hashContrasena = LoginService.EncodePassword(string.Concat(entidad.Username, entidad.Username));
            String[] resultado = controladoraBD.agregarUsuario(entidad, hashContrasena);//llamado a la controladora de base de datos
            foreach(string rol in entidad.Rol){
                controladoraBD.agregarUsuarioRol(entidad.Username, rol);
            }
            return resultado;
        }
        /*
        * Efecto: Solicita a la base de datos el usuario seleccionado
        * Requiere: username
        * Modifica: nada
        */
        internal EntidadUsuario solicitarUsuario(string usernameSeleccionado)
        {
             DataTable tablaUsuario =controladoraBD.consultarUsuario(usernameSeleccionado);
             DataTable tablaRol = controladoraBD.consultarUsuarioRol(usernameSeleccionado);             

             Object[] usuario = new Object[6];// objeto en el que se almacenan los datos para enviar a encapsular.
             usuario[0] = tablaUsuario.Rows[0][0].ToString();//username
             usuario[1] = tablaUsuario.Rows[0][1].ToString();//nombre
             usuario[2] = tablaUsuario.Rows[0][2].ToString();//correo
             usuario[3] = tablaUsuario.Rows[0][3].ToString();//estado
             usuario[4] = tablaUsuario.Rows[0][4].ToString();//estacion

             List<string> rol = new List<string>();
             for (int i = 0; i < tablaRol.Rows.Count; i++ )
             {
                 rol.Add(tablaRol.Rows[i][0].ToString());
             }
             usuario[5] = rol;
             entidadSeleccionada = new EntidadUsuario(usuario);

             return entidadSeleccionada;
        }
        /*
      * Efecto: Actuliza los datos del usuario
      * Requiere: los datos del usuario modificado
      * Modifica: Los datos del usuario mediante llamada a la base de datos
     */
        internal string[] modificarUsuario(object[] nuevoUsuario)
        {
            EntidadUsuario entidad = new EntidadUsuario(nuevoUsuario);
            String[] resultado = controladoraBD.modificarUsuario(entidad);//llamado a la controladora de base de datos
            controladoraBD.limpiarRoles(entidad.Username);
            foreach (string rol in entidad.Rol)
            {
                controladoraBD.agregarUsuarioRol(entidad.Username, rol);
            }
            return resultado;
        }
        /*
        * Efecto: desactiva el usuario seleccionado
        * Requiere: username
        * Modifica: nada
        */
        internal string[] desactivarUsuario(string username)        {

            return controladoraBD.desactivarUsuario(username); 
        }
        /*
        * Efecto: reestablece la contrase;a del usuario seleccionado
        * Requiere: username, nueva contrase;a
        * Modifica: nada
        */
        internal string[] reestablecerContrasena(String username, String contrasena)
        {
            string hashContrasena = LoginService.EncodePassword(string.Concat(username, contrasena));
            return controladoraBD.reestablecerContrasena(username, hashContrasena);
        }
        /*
        * Efecto: actualiza la contrase;a del usuario seleccionado
        * Requiere: username, nueva contrase;a
        * Modifica: nada
        */
        internal string[] actualizarContrasena(String username, String contrasena)
        {
            string hashContrasena = LoginService.EncodePassword(string.Concat(username, contrasena));
            return controladoraBD.actualizarContrasena(username, hashContrasena);
        }
        /*
        * Efecto: devuelve la lista de los usuarios basandose en el filtro seleccionado
        * Requiere: la estacion, el username y el nombre de la persona 
        * Modifica: nada
        */
        internal DataTable solicitarUsuariosFiltro(string estacion, string nombreUsuario, string nombre)
        {
            return controladoraBD.seleccionarUsuariosFiltro(estacion, nombreUsuario, nombre);
        }
    }
}