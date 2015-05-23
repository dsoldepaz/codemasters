using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2{
    public class EntidadServicios
    {
        private String idRes;
        private String id;
        private String categoria;
        private String estado;
        private String hora;
        private String fecha;
        private int pax;


        public EntidadServicios(string idRes, string id, string categoria, String hora, String fecha, string estado, int pax)
        {
            this.idRes = idRes;
            this.id = id;
            this.categoria = categoria;
            this.estado = estado;
            this.hora = hora;
            this.fecha = fecha;
            this.pax = pax;
        }
        public String IdRes
        {
            get { return idRes; }
            set { idRes = value; }
        }
        public String Id {
            get { return id; } 
            set { id = value;}
        }
        public String Categoria        {
            get { return categoria; }
            set { categoria = value; }
        }
        public String Estado {
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
            set { fecha = value;}
        }
        public int Pax {
            get { return pax; } 
            set { pax = value;}
        }
    }
   

}