using System;
using AcadControl.Helpers;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.Aluno
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadAlunos();
            populateDropDown();
        }

        protected void AlunosList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Models.Aluno aluno = (Models.Aluno)e.Row.DataItem;

                HyperLink edit = e.Row.Cells[3].Controls[0] as HyperLink;
                edit.NavigateUrl = "~/Views/Aluno/Form.aspx?mat_alu=" + aluno.mat_alu;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int mat_alu = Int32.Parse(AlunosList.DataKeys[row.RowIndex]["mat_alu"].ToString());

            if (controller().delete(mat_alu))
            {
                Session["flash_message"] = "Aluno removida com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover o aluno, tente novamente.";
            }

            loadAlunos();
        }

        protected void Pesquisar_Click(object sender, EventArgs e)
        {

            AlunosList.DataSource = controller().find_by(nome_alu.Text, mat_alu.Text, curso.Text);
            AlunosList.DataBind();
        }

        private void loadAlunos()
        {
            AlunosList.DataSource = controller().index();
            AlunosList.DataBind();
        }

        private AlunoController controller()
        {
            return new AlunoController();
        }

        private void populateDropDown()
        {
            CursoHelper.populate(curso);
        }

    }
}