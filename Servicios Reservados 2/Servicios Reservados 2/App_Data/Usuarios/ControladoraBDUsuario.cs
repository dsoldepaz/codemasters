﻿using System;
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
            String consultaSQL = "select username, Nombre, estacion, estado from usuario";
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
            string hashContrasena = LoginService.EncodePassword(string.Concat(entidad.Username, entidad.Username));
            String consultaSQL = "insert into usuario values('" + entidad.Username + "','" + hashContrasena + "','" +
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


        internal DataTable consultarUsuario(string usernameSeleccionado)
        {
            dt = new DataTable();
            String consultaSQL = "select username, Nombre, email, activo, estacion from usuario where username='" + usernameSeleccionado + "'";
            return adaptador.consultar(consultaSQL);
        }
        internal DataTable consultarUsuarioRol(string usernameSeleccionado)
        {
            dt = new DataTable();
            String consultaSQL = "select rol from usuariorol where usuario='" + usernameSeleccionado + "'";
            return adaptador.consultar(consultaSQL);
        }
    }
}