using System;
using AcadControl.Models;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AcadControl.Helpers
{
    public class PeriodoLetivoHelper
    {
        public static void populate(DropDownList element)
        {
            if (element.Items.Count == 1)
            {
                List<Periodo_Letivo> periodos = controller().index();
                foreach (Periodo_Letivo periodo in periodos)
                {
                    ListItem item = new ListItem();
                    item.Text = periodo.ano + "." + periodo.semestre;
                    item.Value = periodo.ano + "/" + periodo.semestre;
                    element.Items.Add(item);
                }
            }
        }

        private static PeriodoLetivoController controller()
        {
            return new PeriodoLetivoController();
        }
    }
}