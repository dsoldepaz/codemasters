using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraBDComidaEmpleado
    {
        private AdaptadorBD adaptador = new AdaptadorBD();
        /*
         * Requiere: Una Entidad Comida Empleado con los datos a insertar
         * Efectua: Crea la insercion a traves de los datos proporcionados en la entidad encapsulada e inserta los datos a traves del adaptador.
         * Retorna: Un arreglo de hileras con el mensaje de confirmacion u error de la consulta.
         */
        public String[] agregar(EntidadComidaEmpleado nuevo)
        {
            String[] resultado = new String[3];
            String turnos = ", desayuno = ";
            turnos += "'" + (nuevo.Turnos[0]) + "'";
            turnos += ", almuerzo = ";
            turnos += "'" + (nuevo.Turnos[1]) + "'";
            turnos += ", cena = ";
            turnos += "'" + (nuevo.Turnos[1]) + "'";
            try
            {
                foreach (DateTime fecha in nuevo.Fechas)
                {
                    //Crea la sentencia en sql para insertar.
                    String insercion = "Insert into Reserva_EMPLEADO values " + "idEmpleado = " + nuevo.IdEmpleado + ", ";
                    insercion += "fecha = to_date('" + fecha.ToString("dd.MM.yyyy HH:mm:ss") + "' ,'DD.MM.YYYY hh24:mi:ss') , Consumido = F," + "notas = '" + nuevo.Notas + "'" + turnos;


                    adaptador.insertar(insercion);//inserta en la db
                    resultado[0] = "SUCCESS";
                    resultado[1] = "Exito: ";
                    resultado[2] = "Los datos se guardaron correctamente.";
                }
            }
            catch (Exception e)
            {
                resultado[0] = "DANGER";
                resultado[1] = "ERROR: ";
                resultado[2] = "No se pudo insertar el elemento, por favor verifique los datos";
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
                foreach (DateTime fecha in nuevo.Fechas)
                {
                    string update = "UPDATE RESERVA_EMPLEADO SET";
                    if (seleccionada.Turnos[0] == 'C' && nuevo.Turnos[0] != 'C')//DESAYUNO
                    {//Si ya se sirvio no se puede cancelar. 
                        throw new Exception();
                    }
                    else
                    {
                        update += "Desayuno = '" + nuevo.Turnos[0] + "' ,";
                        //R = Reservado C= Consumido N=No reservado X=Cancelado

                    }
                    if (seleccionada.Turnos[1] == 'C' && nuevo.Turnos[1] != 'C')//ALMUERZO
                    {//Si ya se sirvio no se puede cancelar. 
                        throw new Exception();
                    }
                    else
                    {
                        update += "Almuerzo = '" + nuevo.Turnos[1] + "' ,";
                        //R = Reservado C= Consumido N=No reservado X=Cancelado

                    }
                    if (seleccionada.Turnos[2] == 'C' && nuevo.Turnos[2] != 'C')//CENA
                    {//Si ya se sirvio no se puede cancelar. 
                        throw new Exception();
                    }
                    else
                    {
                        update += "CENA = '" + nuevo.Turnos[1] + "', pagado =";
                        //R = Reservado C= Consumido N=No reservado X=Cancelado

                    }
                    update += (nuevo.Pagado) ? "'T'," : "'F',";//Si esta o no pagado.
                    update += " notas = '" + nuevo.Notas + "' "; // predicado del update completo.

                    //----------------------------------------------------------------------
                    update += "WHERE IDCOMIDAEMPLEADO =" + seleccionada.IdComida ;
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
            string consulta = "SELECT IDEMPLEADO, FECHA, PAGADO, NOTAS, DESAYUNO, ALMUERZO, CENA, IDCOMIDAEMPLEADO  FROM RESERVA_EMPLEADO Where idcomidaempleado =" + idReservacionComida ;
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
        internal String[] cancelar(EntidadComidaEmpleado entidadComidaEmpleado)
        {
            String[] resultado = new String[3];

            try
            {
                if (entidadComidaEmpleado.Turnos[0] == 'C' || entidadComidaEmpleado.Turnos[1] == 'C' || entidadComidaEmpleado.Turnos[2] == 'C')//si alguna ya fue consumida
                {
                    throw new Exception(); //no se puede cancelar

                }
                else
                {
                    String update = "UPDATE RESERVA_EMPLEADO SET Desayuno ='X', Almuerzo ='X', cena='X' WHERE IDCOMIDAEMPLEADO = " + entidadComidaEmpleado.IdComida ;
                    resultado[0] = "SUCCESS";
                    resultado[1] = "Exito: ";
                    resultado[2] = "Los datos se Modificaron correctamente.";
                }
            }
            catch (Exception e)
            {

                resultado[0] = "DANGER";
                resultado[1] = "ERROR: ";
                resultado[2] = "No se pudo cancelar el elemento, por favor verifique los datos, No se puede cancelar comidas que ya han sido servidas.";
            }
            return resultado;
        }
    }
}