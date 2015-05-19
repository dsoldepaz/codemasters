using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class EntidadComidaCampo
    {
        private String idComidaCampo;
        private String idEmpleado;
        private String idReservacion;
        private String fecha;
        private String estado;
        private int opcion;
        private String relleno;
        private String pan;
        private String bebida;
        private String tipoPago;
        private int pax;
        private String hora;


        public EntidadComidaCampo(Object[] datos)
        {
            this.idComidaCampo = datos[0].ToString();
            this.idEmpleado = datos[1].ToString();
            this.idReservacion = datos[2].ToString();
            this.fecha = datos[3].ToString();
            this.estado = datos[4].ToString();
            this.opcion = int.Parse(datos[5].ToString());
            this.relleno = datos[6].ToString();
            this.pan = datos[7].ToString();
            this.bebida = datos[8].ToString();
            this.tipoPago = datos[9].ToString();
            Debug.WriteLine(datos[10].ToString());
            this.pax = int.Parse(datos[10].ToString());
            this.hora = datos[11].ToString();
        }

        public String IdComidaCampo
        {
            get { return IdComidaCampo; }
            set { IdComidaCampo = value; }
        }

        public String IdEmpleado
        {
            get { return IdEmpleado; }
            set { IdEmpleado = value; }
        }

        public String IdReservacion
        {
            get { return IdReservacion; }
            set { IdReservacion = value; }
        }

        public String Fecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }

        public String Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }
        public String Opcion
        {
            get { return Opcion; }
            set { Opcion = value; }
        }
        public String Relleno
        {
            get { return Relleno; }
            set { Relleno = value; }
        }
        public int Pan
        {
            get { return Pan; }
            set { Pan = value; }
        }
        public String Bebida
        {
            get { return Bebida; }
            set { Bebida = value; }
        }
        public String TipoPago
        {
            get { return TipoPago; }
            set { TipoPago = value; }
        }
        public int Pax
        {
            get { return Pax; }
            set { Pax = value; }
        }
        public String Hora
        {
            get { return Hora; }
            set { Hora = value; }
        }
    }
}