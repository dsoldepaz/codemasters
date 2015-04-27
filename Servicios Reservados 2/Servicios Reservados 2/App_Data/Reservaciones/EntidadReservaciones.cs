using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class EntidadReservaciones
    {
        private String id;
        private String anfitriona;
        private String estacion;
        private String numero;
        private String solicitante;
        private DateTime fechaInicio;
        private DateTime fechaSalida;

        public EntidadReservaciones(String id, String anfitriona, String estacion, String numero, String solicitante, DateTime fechaInicio, DateTime fechaSalida)
        {
            Id = id;
            Anfitriona = anfitriona;
            Estacion = estacion;
            Numero = numero;
            Solicitante = solicitante;
            FechaInicio = fechaInicio;
            FechaSalida = fechaSalida;
                
        } 

        public String Id {
            get { return id; } 
            set { id = value;}
        }
        public String Anfitriona {
            get { return anfitriona; }
            set { anfitriona = value; }
        }
        public String Estacion {
            get { return estacion; } 
            set { estacion = value;}
        }
        public String Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public DateTime FechaInicio {
            get { return fechaInicio; } 
            set { fechaInicio = value;}
        }
        public DateTime FechaSalida {
            get { return fechaSalida; } 
            set { fechaSalida = value;}
        }
        public String Solicitante {
            get { return solicitante; } 
            set { solicitante = value;}
        }
    }
   

}