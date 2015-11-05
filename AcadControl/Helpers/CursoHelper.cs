using System;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AcadControl.Helpers
{
    public class CursoHelper
    {
        public static void populate(DropDownList element)
        {
            if (element.Items.Count == 1)
            {
                element.DataSource = controller().index();
                element.AppendDataBoundItems = true;
                element.DataTextField = "nom_curso";
                element.DataValueField = "id";
                element.DataBind();
            }
        }

        private static CursoController controller()
        {
            return new CursoController();
        }
    }

}