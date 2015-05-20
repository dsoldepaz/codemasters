using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Diagnostics;

namespace Servicios_Reservados_2
{
    public class ControladoraBDComidaCampo
    {
        private AdaptadorComidaCampo adaptador;
        DataTable dt;

        public ControladoraBDComidaCampo()
        {
            adaptador = new AdaptadorComidaCampo();
            dt = new DataTable();
        }

        public String[] agregarComidaCampo(EntidadComidaCampo entidad)
        {
            String[] respuesta = new String[3];
            try
            {
                String consultaSQL = "insert into servicios_reservados.comida_campo values('" + entidad.IdComidaCampo + "','" + entidad.IdEmpleado + "','" +
                    entidad.IdReservacion + "','" + entidad.Fecha + "','" + entidad.Estado + "'," + entidad.Opcion + ",'" + entidad.Relleno + "','" + entidad.Pan + "','" 
                    + entidad.Bebida + "','" + entidad.TipoPago + "'," + entidad.Pax + ",'" + entidad.Hora + "')";
                Debug.WriteLine(consultaSQL);
                adaptador.insertar(consultaSQL);
                List<String> lista = entidad.Adicionales;
                int cantAdicionales = lista.Count;
                String consultaId = "select MAX(idcomidacampo) from servicios_reservados.comida_campo";
                dt = adaptador.consultar(consultaId);
                for (int i = 0; i < cantAdicionales; i++)
                {
                    String insercion ="insert into servicios_reservados.adicional values("+dt.Rows[0][0]+",'"+lista[i]+"')"; 
                }
                respuesta[0] = "success";
                respuesta[1] = "Exito. ";
                respuesta[2] = "El usuario se ha insertado exitosamente";
            }
            catch (SqlException e)
            {
                    respuesta[0] = "danger";
                    respuesta[1] = "Error. ";
                    respuesta[2] = "No se pudo agregar el servicio extra";
                

            }
            
            return respuesta;
        }

    }
}