using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class EntidadServicios
    {
        private String idSolicitante;
        private String tipoSolicitante;
        private String idServicio;
        private String categoria;
        private String estado;
        private String hora;
        private String fecha;
        private int pax;


        public EntidadServicios(String idSol, String tipoSolicitante, String id, String categoria, String hora, String fecha, String estado, int pax)
        {
            this.idSolicitante = idSol;
            this.tipoSolicitante = tipoSolicitante;
            this.idServicio = id;
            this.categoria = categoria;
            this.estado = estado;
            this.hora = hora;
            this.fecha = fecha;
            this.pax = pax;
        }
        public String IdSolicitante
        {
            get { return idSolicitante; }
            set { idSolicitante = value; }
        }
        public String TipoSolicitante
        {
            get { return tipoSolicitante; }
            set { tipoSolicitante = value; }
        }
        public String IdServicio
        {
            get { return idServicio; }
            set { idServicio = value; }
        }
        public String Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public String Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        public String Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public int Pax
        {
            get { return pax; }
            set { pax = value; }
        }
    }


}