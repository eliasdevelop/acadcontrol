using System;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.Matricula
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadMatriculas();
            }
        }

        protected void MatriculasList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Models.Matricula matricula = (Models.Matricula)e.Row.DataItem;

                HyperLink edit = e.Row.Cells[3].Controls[0] as HyperLink;
                edit.NavigateUrl = "~/Views/Matricula/Edit.aspx?ano=" + matricula.ano + 
                                                               "&semestre=" + matricula.semestre +
                                                               "&id_disc=" + matricula.id_disc +
                                                               "&mat_alu=" + matricula.mat_alu;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int ano = Int32.Parse(MatriculasList.DataKeys[row.RowIndex]["ano"].ToString());
            int semestre = Int32.Parse(MatriculasList.DataKeys[row.RowIndex]["semestre"].ToString());
            int id_disc = Int32.Parse(MatriculasList.DataKeys[row.RowIndex]["id_disc"].ToString());
            int mat_alu = Int32.Parse(MatriculasList.DataKeys[row.RowIndex]["mat_alu"].ToString());

            if (controller().delete(ano, semestre, mat_alu, id_disc))
            {
                Session["flash_message"] = "Matricula removida com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover a matricula, tente novamente.";
            }

            loadMatriculas();
        }

        private void loadMatriculas()
        {
            MatriculasList.DataSource = controller().index();
            MatriculasList.DataBind();
        }

        private MatriculaController controller()
        {
            return new MatriculaController();
        }
    }
}