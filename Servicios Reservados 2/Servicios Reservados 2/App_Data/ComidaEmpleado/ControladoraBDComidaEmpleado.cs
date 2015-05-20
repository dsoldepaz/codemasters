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
        private AdaptadorComidaEmpleado adaptador = new AdaptadorComidaEmpleado();
        public String[] agregar(EntidadComidaEmpleado nuevo)
        {
            String [] resultado = new String[3];
            String turnos = ", desayuno = ";
            turnos +=(nuevo.Turnos[0]) ?  "'R'" : "'N'";
            turnos += ", almuerzo = ";
            turnos += (nuevo.Turnos[1]) ? "'R'" : "'N'";
            turnos += ", cena = ";
            turnos += (nuevo.Turnos[1]) ? "'R';" : "'N';";
            try{
                foreach (DateTime fecha in nuevo.Fechas)
                {
                    String insercion = "Insert into Reserva_EMPLEADO values " + "idEmpleado = " + nuevo.IdEmpleado + ", ";
                    insercion += "fecha = " + fecha.ToString() +" Consumido = F"+ turnos;
                    //EXECUTE NON QUERY
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
  
        internal void modificar(EntidadComidaEmpleado seleccionada, EntidadComidaEmpleado nuevo)
        {
            throw new NotImplementedException();
        }
        /*
         * 
         * 
         * Retorna: un data table con los estados de la  reservacion de los turnos y si ya fue pagado.
        */
        internal DataTable getInformacionReservacionEmpleado(string id, DateTime fechaElegida)
        {
            string consulta = "Select Desayuno, Almuerzo, Cena, pagado, notas FROM Reserva_EMPLEADO WHERE IDEMPLEADO = '" + id + "' AND fecha = " + fechaElegida + ";";
            DataTable dt = adaptador.consultar(consulta);
            return dt;
        }
    }
}