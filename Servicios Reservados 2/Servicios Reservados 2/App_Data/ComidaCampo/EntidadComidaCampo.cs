﻿using System;
using System.Collections.Generic;
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
        private String consumido;
        private int opcion;
        private String relleno;
        private String pan;
        private String bebida;
        private String tipoPago;
        private String idAdicional_ComidaCampo;
        
        
        public EntidadComidaCampo(Object[] datos)
        {
            this.idComidaCampo = datos[0].ToString();
            this.idEmpleado = datos[1].ToString();
            this.idReservacion = datos[2].ToString();
            this.fecha = datos[3].ToString();
            this.consumido = datos[4].ToString();
            this.opcion = int.Parse(datos[5].ToString());
            this.relleno = datos[6].ToString();
            this.pan = datos[7].ToString();
            this.bebida = datos[8].ToString();
            this.tipoPago = datos[9].ToString();
            this.idAdicional_ComidaCampo = datos[10].ToString();
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

        public String Consumido
        {
            get { return consumido; }
            set { consumido = value; }
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
        public String IdAdicional_ComidaCampo
        {
            get { return IdAdicional_ComidaCampo; }
            set { IdAdicional_ComidaCampo = value; }
        }
      



}
}