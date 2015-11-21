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
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDropDowns();

                String ano = Request.QueryString["ano"];
                String semestre = Request.QueryString["semestre"];
                String id_disc = Request.QueryString["id_disc"];
                String mat_alu = Request.QueryString["mat_alu"];

                if (ano != null && semestre != null && id_disc != null && mat_alu != null)
                {
                    Models.Matricula matricula = controller().edit(Int32.Parse(ano), Int32.Parse(semestre), Int32.Parse(mat_alu), Int32.Parse(id_disc));

                    if (matricula == null)
                    {
                        Session["error_message"] = "Matricula não encontrada";
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        periodo_letivo.Text = matricula.ano + "/" + matricula.semestre;
                        disciplina.Text = matricula.id_disc.ToString();
                        aluno.Text = matricula.mat_alu.ToString();
                        nota01.Text = matricula.nota_01.ToString();
                        nota02.Text = matricula.nota_02.ToString();
                        nota03.Text = matricula.nota_03.ToString();
                        faltas01.Text = matricula.faltas_01.ToString();
                        faltas02.Text = matricula.faltas_02.ToString();
                        faltas03.Text = matricula.faltas_03.ToString();
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            bool saved;

            saved = update();

            if (saved)
            {
                Session["flash_message"] = "Notas/Faltas atualizadas com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao atualizar notas/faltas, tente novamente.";
            }
        }

        private bool update()
        {
            string[] periodoletivo = periodo_letivo.Text.Split('/');

            float notas_01 = (String.IsNullOrEmpty(nota01.Text)) ? notas_01 = 0 : notas_01 = float.Parse(nota01.Text);
            float notas_02 = (String.IsNullOrEmpty(nota02.Text)) ? notas_02 = 0 : notas_02 = float.Parse(nota02.Text);
            float notas_03 = (String.IsNullOrEmpty(nota03.Text)) ? notas_03 = 0 : notas_03 = float.Parse(nota03.Text);

            int faltas_01 = (String.IsNullOrEmpty(faltas01.Text)) ? faltas_01 = 0 : faltas_01 = Int32.Parse(faltas01.Text);
            int faltas_02 = (String.IsNullOrEmpty(faltas02.Text)) ? faltas_02 = 0 : faltas_02 = Int32.Parse(faltas02.Text);
            int faltas_03 = (String.IsNullOrEmpty(faltas03.Text)) ? faltas_03 = 0 : faltas_03 = Int32.Parse(faltas03.Text);

            return controller().update(Int32.Parse(periodoletivo[0]), Int32.Parse(periodoletivo[1]),
                                       Int32.Parse(aluno.Text), 
                                       Int32.Parse(disciplina.Text),
                                       notas_01, notas_02, notas_03,
                                       faltas_01, faltas_02, faltas_03);
        }

        private MatriculaController controller()
        {
            return new MatriculaController();
        }

        private void populateDropDowns()
        {
            DisciplinaHelper.populate(disciplina);
            AlunoHelper.populate(aluno);
        }
    }
}