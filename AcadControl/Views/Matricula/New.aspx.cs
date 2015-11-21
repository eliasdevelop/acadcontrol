using System;
using AcadControl.Controllers;
using AcadControl.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.Matricula
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PeriodoLetivoHelper.populate(periodo_letivo);
                DisciplinaHelper.populate(disciplina);
                AlunoHelper.populate(aluno);
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string[] periodoletivo = periodo_letivo.Text.Split('/');

            bool saved = controller().create(Int32.Parse(periodoletivo[0]), Int32.Parse(periodoletivo[1]), Int32.Parse(aluno.Text), Int32.Parse(disciplina.Text));

            if (saved)
            {
                Session["flash_message"] = "Matricula salva com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar a matricula, tente novamente.";
            }

        }

        private MatriculaController controller()
        {
            return new MatriculaController();
        }
    }
}