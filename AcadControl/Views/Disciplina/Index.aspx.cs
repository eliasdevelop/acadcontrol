using System;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.Disciplina
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadDisciplinas();
        }

        protected void DisciplinasList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Models.Disciplina disciplina = (Models.Disciplina)e.Row.DataItem;

                HyperLink edit = e.Row.Cells[3].Controls[0] as HyperLink;
                edit.NavigateUrl = "~/Views/Disciplina/Form.aspx?id=" + disciplina.id;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int disciplina_id = Int32.Parse(DisciplinasList.DataKeys[row.RowIndex]["id"].ToString());

            if (controller().delete(disciplina_id))
            {
                Session["flash_message"] = "Disciplina removida com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover a disciplina, tente novamente.";
            }

            loadDisciplinas();
        }

        protected void Pesquisar_Click(object sender, EventArgs e)
        {

            DisciplinasList.DataSource = controller().find_by(nome_disc.Text, tpo_disc.Text);
            DisciplinasList.DataBind();
        }

        private void loadDisciplinas()
        {
            DisciplinasList.DataSource = controller().index();
            DisciplinasList.DataBind();
        }

        private DisciplinaController controller()
        {
            return new DisciplinaController();
        }
    }
}