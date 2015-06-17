﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class EntidadUsuario
    {
        private String username;
        private String nombre;
        private String correo;
        private String estado;
        List<string> rol;
        
        public EntidadUsuario(Object[] datos)
        {
            this.username = datos[0].ToString();
            this.nombre = datos[1].ToString();
            this.correo = datos[2].ToString();
            this.estado = datos[3].ToString();
            this.rol = (List<string>)datos[4];                     
        }

        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public List<string> Rol
        {
            get { return rol; }
            set { rol = value; }
        }
       
    }
}