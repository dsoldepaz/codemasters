﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicios_Reservados_2
{
    public partial class FormComidasEmpleado : System.Web.UI.Page
    {
        public static List<DateTime> list = new List<DateTime>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void fechaDeEntradaCalendario_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsSelected == true)
            {
                list.Add(e.Day.Date);
            }
            Session["SelectedDates"] = list;
        }


        protected void fechaDeEntradaCalendario_SelectionChanged(object sender, EventArgs e)
        {
            if (Session["SelectedDates"] != null)
            {
                List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
                foreach (DateTime dt in newList)
                {
                    fechaDeEntradaCalendario.SelectedDates.Add(dt);
                }
                list.Clear();
            }
        }
        protected void fechaDeEntrada_ServerClick(object sender, EventArgs e)
        {
            fechaDeEntradaCalendario.Visible = !(fechaDeEntradaCalendario.Visible);
        }
        /*
         *  Requiere: N/A.
         *  Efectúa:  Rellena el formulario con la informacion del empleado.
         *  Retrona:  N/A
         */
        protected void ConsultarEmpleado()
        {

        }
        /*
         *  Requiere: Controladores de eventos de la interfaz.
         *  Efectúa:  Cambia el contenido de la tabla al índice seleccionado.
         *  Retrona:  N/A
         */
        protected void GridViewReservaciones_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {

            GridViewReservaciones.PageIndex = e.NewPageIndex;
            GridViewReservaciones.DataSource = Session["tablaa"];
            GridViewReservaciones.DataBind();

        }
    }
}