using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class EntidadComidaEmpleado
    {
        private String idEmpleado;
        private List<DateTime> fechas;
        private bool[] turnos;//[0] Desayuno [1] Almuerzo [2] Cena
        private bool pagado;
        private String notas;

        public EntidadComidaEmpleado(String idEmpleado, List<DateTime> fechasReserva, bool[] turnos, bool pagado, String notas){
            this.idEmpleado=idEmpleado;
            fechas = new List<DateTime>();
            foreach ( DateTime fecha in fechasReserva){
                fechas.Add(fecha);
            }
            this.turnos = new bool[3];
            this.turnos[0] = turnos[0];
            this.turnos[1] = turnos[1];
            this.turnos[2] = turnos[2];
            this.pagado = pagado;
        }
        public String IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }
        public List<DateTime> Fechas
        {
            get { return fechas; }
            set { fechas = value;}
        }
        public bool[] Turnos
        {
            get { return Turnos; }
            set { turnos = value; }
        }
        public bool Pagado
        {
            set { pagado = value; }
            get { return pagado; }
        }
        public String Notas
        {
            set { notas = value; }
            get { return notas;  }
        }
    }
}