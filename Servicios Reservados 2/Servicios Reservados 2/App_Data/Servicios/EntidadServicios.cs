using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2.Servicios
{
    public class EntidadSerivicios
    {
        private String id;
        private String anfitriona;
        private String estacion;
        private String nombre;
        private DateTime fechaInicio;
        private DateTime fechaSalida;
        private int pax;

        public EntidadSerivicios(Object[] datos)
        {
            


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
        public DateTime FechaInicio {
            get { return fechaInicio; } 
            set { fechaInicio = value;}
        }
        public DateTime FechaSalida {
            get { return fechaSalida; } 
            set { fechaSalida = value;}
        }
        public int Pax {
            get { return pax; } 
            set { pax = value;}
        }
        public String Nombre {
            get { return nombre; } 
            set { nombre = value;}
        }
    }
   

}