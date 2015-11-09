using System;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.Turma
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadTurmas();
            }     
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int turma_ano = Int32.Parse(TurmasList.DataKeys[row.RowIndex]["ano"].ToString());
            int turma_semestre = Int32.Parse(TurmasList.DataKeys[row.RowIndex]["semestre"].ToString());
            int turma_id_disc = Int32.Parse(TurmasList.DataKeys[row.RowIndex]["id_disc"].ToString());

            if (controller().delete(turma_ano, turma_semestre, turma_id_disc))
            {
                Session["flash_message"] = "Turma removida com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover o turma, tente novamente.";
            }

            loadTurmas();
        }

        private void loadTurmas()
        {
            TurmasList.DataSource = controller().index();
            TurmasList.DataBind();
        }

        private TurmaController controller()
        {
            return new TurmaController();
        }
    }
}