using System;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.Curso
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadCursos();
        }

        protected void CursosList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Models.Curso curso = (Models.Curso)e.Row.DataItem;

                HyperLink edit = e.Row.Cells[3].Controls[0] as HyperLink;
                edit.NavigateUrl = "~/Views/Curso/Form.aspx?id=" + curso.id;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int curso_id = Int32.Parse(CursosList.DataKeys[row.RowIndex]["id"].ToString());

            if (controller().delete(curso_id))
            {
                Session["flash_message"] = "Curso removido com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover o curso, tente novamente.";
            }

            loadCursos();
        }

        protected void Pesquisar_Click(object sender, EventArgs e)
        {

            CursosList.DataSource = controller().find_by(nom_curso.Text, responsavel.Text);
            CursosList.DataBind();
        }

        private void loadCursos()
        {
            CursosList.DataSource = controller().index();
            CursosList.DataBind();
        }

        private CursoController controller()
        {
            return new CursoController();
        }
    }
}