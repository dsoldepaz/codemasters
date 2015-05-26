﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class EntidadTiquete
    {
        private int numero;
        private String idServicio;
        private int consumido;
        private String solicitante;
        private String categoria;
        private String notas;

        /*
         * Requiere:
         * Efectúa : Inicializa las variables globales de la clase con los parámetros.
         * Retorna : N/A.
         */
        public EntidadTiquete(int numero, String idServicio, int consumido, String solicitante, String categoria, String notas)
        {
            this.numero = numero;
            this.idServicio = idServicio;
            this.consumido = consumido;
            this.solicitante = solicitante;
            this.categoria = categoria;
            this.notas = notas;

        }
        /*
         * Requiere: una Hilera con el valor nuevo
         * Efectúa : Asigna a la variable global id con el parámetro
         * Retorna : El valor de la variable global id
         */
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        /*
         * Requiere: una Hilera con el valor nuevo
         * Efectúa : Asigna a la variable global Anftritriona con el parámetro
         * Retorna : El valor de la variable global Anfitriona
         */
        public String IdServicio
        {
            get { return idServicio; }
            set { idServicio = value; }
        }
        /*
         * Requiere: una Hilera con el valor nuevo
         * Efectúa : Asigna a la variable global Estación con el parámetro
         * Retorna : El valor de la variable global Estación
         */
        public int Consumido
        {
            get { return consumido; }
            set { consumido = value; }
        }
        /*
         * Requiere: una Hilera con el valor nuevo
         * Efectúa : Asigna a la variable global Numero con el parámetro
         * Retorna : El valor de la variable global Numero
         */
        public String Solicitante
        {
            get { return solicitante; }
            set { solicitante = value; }
        }
        /*
         * Requiere: una Fecha con el valor nuevo
         * Efectúa : Asigna a la variable global FechaInicio con el parámetro
         * Retorna : El valor de la variable global FechaInicio
         */
        public String Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public String Notas
        {
            get { return notas; }
            set { notas = value; }
        }
    }


}