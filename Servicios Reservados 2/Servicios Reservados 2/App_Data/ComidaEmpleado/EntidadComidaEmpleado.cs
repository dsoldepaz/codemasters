using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class EntidadComidaEmpleado
    {
        //IDEMPLEADO*, FECHA*, PAGADO*, NOTAS*, DESAYUNO*, ALMUERZO*, CENA*, IDCOMIDAEMPLEADO*     
        internal int idComida
        {
            get { return idComida; }
            set { idComida = value; }
        }
        internal String idEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }
        internal List<DateTime> fechas
        {
            get { return fechas; }
            set { fechas = value;}
        }
        internal bool[] turnos//[0] Desayuno [1] Almuerzo [2] Cena
                    {
            get { return turnos; }
            set { turnos = value; }
        }

        internal bool pagado
        {
            set { pagado = value; }
            get { return pagado; }
        }
        internal String notas
        {
            set { notas = value; }
            get { return notas; }
        }

        public EntidadComidaEmpleado(String idEmpleado, List<DateTime> fechasReserva, bool[] turnos, bool pagado, String notas, int id = -1)
        {
            this.idComida = id;
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

    }
}