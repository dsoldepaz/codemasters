using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_Reservados_2
{
    public class ControladoraBDComidaEmpleado
    {

        public String[] agregar(EntidadComidaEmpleado nuevo)
        {
            String [] resultado = new String[3];
            String turnos = ", desayuno = " + nuevo.Turnos[0] + ", almuerzo = " + nuevo.Turnos[1] + ", cena = " + nuevo.Turnos[2] + " ;";
            try{
                foreach (DateTime fecha in nuevo.Fechas)
                {
                    String insercion = "Insert into NOMBREDELATABLA values " + "idEmpleado = " + nuevo.IdEmpleado+", ";
                    insercion += "fechaDeInicio = " + fecha.ToString() + turnos;
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
    
internal System.Data.DataTable getComidasEmpleado(string idEmpleado)
{
 	return new System.Data.DataTable();
}
internal void modificar(EntidadComidaEmpleado seleccionada, EntidadComidaEmpleado nuevo)
{
    throw new NotImplementedException();
}
    }
}