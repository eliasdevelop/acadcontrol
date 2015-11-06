using System;
using AcadControl.Controllers;
using AcadControl.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.Matriz
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CursoHelper.populate(curso);
                DisciplinaHelper.populateCheckbox(disciplinas);
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {

            bool saved = controller().gerarMatriz(disciplinas, Int32.Parse(curso.Text), Int32.Parse(periodo.Text));
            if (saved)
            {
                Session["flash_message"] = "Matriz salva com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar a matriz, tente novamente.";
            }

        }

        private MatrizController controller()
        {
            return new MatrizController();
        }
    }
}