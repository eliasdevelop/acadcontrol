using System;
using AcadControl.Helpers;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.Matriz
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadMatrizes();
                populateDropDown();
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int id_curso = Int32.Parse(MatrizList.DataKeys[row.RowIndex]["id_curso"].ToString());
            int id_disc = Int32.Parse(MatrizList.DataKeys[row.RowIndex]["id_disc"].ToString());

            if (controller().delete(id_curso, id_disc))
            {
                Session["flash_message"] = "Matriz removida com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover a matriz, tente novamente.";
            }

            loadMatrizes();
        }

        protected void Pesquisar_Click(object sender, EventArgs e)
        {

            MatrizList.DataSource = controller().find_by(periodo.Text, curso.Text, disciplina.Text);
            MatrizList.DataBind();
        }

        private void loadMatrizes()
        {
            MatrizList.DataSource = controller().index();
            MatrizList.DataBind();
        }

        private MatrizController controller()
        {
            return new MatrizController();
        }

        private void populateDropDown()
        {
            CursoHelper.populate(curso);
            DisciplinaHelper.populate(disciplina);
        }
    }
}