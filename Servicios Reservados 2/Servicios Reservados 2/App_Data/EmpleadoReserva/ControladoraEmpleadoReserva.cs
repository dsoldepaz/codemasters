﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraEmpleadoReserva
    {
        private ControladoraEmpleado controladoraEmpleado;
        private ControladoraComidaEmpleado controladoraComidaEmpleado;
        private ControladoraComidaCampo controladoraComidaCampo;
        public ControladoraEmpleadoReserva()
        {
            controladoraEmpleado = new ControladoraEmpleado();
            controladoraComidaEmpleado = new ControladoraComidaEmpleado();
            controladoraComidaCampo = new ControladoraComidaCampo();
        }

        public DataTable obtenerTabla(String idEmpleado)
        {
            DataTable tabla = new DataTable();
            DataTable tablaComidaCampo = controladoraComidaCampo.getComidaEmpleado(idEmpleado);
            DataTable tablaComidaEmpleado = controladoraComidaEmpleado.getComidaEmpleado(idEmpleado);
            Object[] datos = new Object[4];

            foreach (DataRow fila in tablaComidaEmpleado.Rows)
            {
                //SELECT IDCOMIDAEMPLEADO,IDEMPLEADO,FECHA,PAGADO
                datos[0] = fila[0].ToString(); //IDCOMIDAEMPLEADO
                datos[1] = fila[1].ToString(); //Tipo
                datos[2] = fila[2].ToString(); //IDEMPLEADO
                datos[3] = fila[3].ToString(); //FECHA
                datos[4] = (fila[4].ToString().CompareTo("T")==0)?"Efectivo":"Deduccion de Salario" ; //PAGADO es un valor booleano a nivel logico.

                tabla.Rows.Add(datos);
            }
             return tabla;
        }
        public EntidadEmpleado obtenerEmpleado(string idEmpleado)
        {
            controladoraEmpleado.seleccionarEmpleado(idEmpleado);
            return controladoraEmpleado.getEmpleadoSeleccionado();
        }
    }
}