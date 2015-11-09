using System;
using AcadControl.Controllers;
using AcadControl.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.Turma
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDropDowns();

                String ano = Request.QueryString["ano"];
                String semestre = Request.QueryString["semestre"];
                String id_disc = Request.QueryString["id_disc"];

                if (ano != null && semestre != null && id_disc != null)
                {
                    Models.Turma turma = controller().edit(Int32.Parse(ano), Int32.Parse(semestre), Int32.Parse(id_disc));

                    if (turma == null)
                    {
                        Session["error_message"] = "Turma não encontrada";
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        periodo_letivo.Text = turma.ano + "/" + turma.semestre;
                        disciplina.Text = turma.id_disc.ToString();
                        professor.Text = turma.id_prof.ToString();
                        vagas.Text = turma.vagas.ToString();
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            bool saved;

            saved =  create();

            if (saved)
            {
                Session["flash_message"] = "Turma salva com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar a turma, tente novamente.";
            }
        }

        private bool create()
        {
            string[] periodoletivo = periodo_letivo.Text.Split('/');

            return controller().create(Int32.Parse(periodoletivo[0]), Int32.Parse(periodoletivo[1]), Int32.Parse(disciplina.Text), Int32.Parse(professor.Text), Int32.Parse(vagas.Text));
        }

        private TurmaController controller()
        {
            return new TurmaController();
        }

        private void populateDropDowns()
        {
            DisciplinaHelper.populate(disciplina);
            ProfessorHelper.populate(professor);
            PeriodoLetivoHelper.populate(periodo_letivo);
        }
    }
}