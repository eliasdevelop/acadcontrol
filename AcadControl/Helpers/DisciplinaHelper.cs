using System;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AcadControl.Helpers
{
    public class DisciplinaHelper
    {

        public static void populate(DropDownList element)
        {
            if (element.Items.Count == 1)
            {
                element.DataSource = controller().index();
                element.AppendDataBoundItems = true;
                element.DataTextField = "nom_disc";
                element.DataValueField = "id";
                element.DataBind();
            }
        }

        public static void populateCheckbox(CheckBoxList element)
        {
            element.DataSource = controller().index();
            element.AppendDataBoundItems = true;
            element.DataTextField = "nom_disc";
            element.DataValueField = "id";
            element.DataBind();
        }

        private static DisciplinaController controller()
        {
            return new DisciplinaController();
        }
    }
}