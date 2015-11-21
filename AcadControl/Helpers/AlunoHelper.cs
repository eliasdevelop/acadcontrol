using System;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AcadControl.Helpers
{
    public class AlunoHelper
    {
        public static void populate(DropDownList element)
        {
            if (element.Items.Count == 1)
            {
                element.DataSource = controller().index();
                element.AppendDataBoundItems = true;
                element.DataTextField = "nom_alu";
                element.DataValueField = "mat_alu";
                element.DataBind();
            }
        }

        private static AlunoController controller()
        {
            return new AlunoController();
        }
    }
}