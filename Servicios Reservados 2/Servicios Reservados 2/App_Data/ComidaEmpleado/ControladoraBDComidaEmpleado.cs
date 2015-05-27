﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraBDComidaEmpleado
    {
        private AdaptadorComidaEmpleado adaptador = new AdaptadorComidaEmpleado();
       /*
        * Requiere: Una Entidad Comida Empleado con los datos a insertar
        * Efectua: Crea la insercion a traves de los datos proporcionados en la entidad encapsulada e inserta los datos a traves del adaptador.
        * Retorna: Un arreglo de hileras con el mensaje de confirmacion u error de la consulta.
        */
        public String[] agregar(EntidadComidaEmpleado nuevo)
        {
            String [] resultado = new String[3];
            String turnos = ", desayuno = ";
            turnos +=(nuevo.turnos[0]) ?  "'R'" : "'N'";
            turnos += ", almuerzo = ";
            turnos += (nuevo.turnos[1]) ? "'R'" : "'N'";
            turnos += ", cena = ";
            turnos += (nuevo.turnos[1]) ? "'R';" : "'N';";
            try{
                foreach (DateTime fecha in nuevo.fechas)
                {
                    String insercion = "Insert into Reserva_EMPLEADO values " + "idEmpleado = " + nuevo.idEmpleado + ", ";
                    insercion += "fecha = " + fecha.ToString() +" Consumido = F"+ turnos;
                    adaptador.insertar(insercion);
                    resultado[0] = "SUCCESS";
                    resultado[1] = "Exito: ";
                    resultado[2] = "Los datos se guardaron correctamente.";
                }
            }catch (Exception e){
                resultado[0]="DANGER";
                resultado[1]="ERROR: ";
                resultado[2]="No se pudo insertar el elemento, por favor verifique los datos";
            }
            return resultado;
        }
        /*
         * Requiere: Una entidad de comida Empleado con los datos antiguos y una Entidad de comida empleado con los datos encapsulados.
         * Efectua : Crea una consulta de actualizacion de los datos y lo actualiza en la base de datos.
         * Retorna : Retorna: Un arreglo de hileras con el mensaje de confirmacion u error de la consulta.
         */
        internal String[] modificar(EntidadComidaEmpleado seleccionada, EntidadComidaEmpleado nuevo)
        {
            String[] resultado = new String[3];
            try
            {
                foreach (DateTime fecha in nuevo.fechas)
                {
                    DataTable actual = adaptador.consultar("SELECT DESAYUNO, ALMUERZO, CENA FROM FROM RESERVA_EMPLEADO Where idcomidaempleado ="+seleccionada.idComida+";");
                    string update = "UPDATE RESERVA_EMPLEADO SET";
                    if (actual.Rows[0][0].ToString().CompareTo("C") == 0 && !nuevo.turnos[0])//DESAYUNO
                    {//Si ya se sirvio no se puede cancelar. 
                        throw new Exception();
                    }
                    else
                    {
                        
                        //R = Reservado C= Consumido N=No reservado X=Cancelado
                        if (actual.Rows[0][0].ToString().CompareTo("R")==0 )///&& )
                        {
                            update +="Desayuno ='X'";
                        }

                    }
                     /* ---------------------------------------------------------------------
                      * NO ESTA LISTO
                     * +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                     * *********************************************************************
                     */
                    update += "WHERE IDCOMIDAEMPLEADO ="+seleccionada.idComida+";";
                    adaptador.insertar(update);
                    resultado[0] = "SUCCESS";
                    resultado[1] = "Exito: ";
                    resultado[2] = "Los datos se Modificaron correctamente.";
                }
            }
            catch (Exception e)
            {
                resultado[0] = "DANGER";
                resultado[1] = "ERROR: ";
                resultado[2] = "No se pudo modificar el elemento, por favor verifique los datos, No se puede cancelar comidas que ya han sido servidas.";
            }
            return resultado;
        }
        /*
         * Requiere: una hilera con el identificador del empleado y una fecha con la fecha que se quiere consultar.
         * Efectua : Crea una consulta para consultar los datos individuales de una reservacion de comida de empleado. 
         * Retorna : un data table con los estados de la  reservacion de los turnos y si ya fue pagado.
        */
        internal DataTable getInformacionReservacionEmpleado(int idReservacionComida)
        {
            string consulta = "SELECT IDEMPLEADO, FECHA, PAGADO, NOTAS, DESAYUNO, ALMUERZO, CENA, IDCOMIDAEMPLEADO  FROM RESERVA_EMPLEADO Where idcomidaempleado ="+idReservacionComida+";";
            DataTable dt = adaptador.consultar(consulta);
            return dt;
        }

        internal DataTable getReservacionesEmpleado(string idEmpleado)
        {
            DataTable dt = new DataTable();
            String consulta = "SELECT IDCOMIDAEMPLEADO,'Comida regular',IDEMPLEADO,FECHA,PAGADO FROM servicios_reservados.RESERVA_EMPLEADO WHERE IDEMPLEADO = '" + idEmpleado + "'AND FECHA >= ADD_MONTHS(SYSDATE, - 1) ";
            dt = adaptador.consultar(consulta);
            return dt;
        }
    }
}