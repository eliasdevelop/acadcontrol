using System;
using AcadControl.Controllers;
using AcadControl.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.Aluno
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateDropDown();

            if (!IsPostBack)
            {
                String mat_alu_id = Request.QueryString["mat_alu"];

                if (mat_alu_id != null)
                {
                    Models.Aluno aluno = controller().edit(Int32.Parse(mat_alu_id));

                    if (aluno == null)
                    {
                        Session["error_message"] = "Aluno não encontrado";
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        mat_alu.Value = mat_alu_id;
                        nom_alu.Text = aluno.nom_alu;
                        curso.Text = aluno.id_curso.ToString();
                        dat_nasc.Text = aluno.dat_nasc.ToString("dd/MM/yyyy");
                        mgp.Text = aluno.mgp.ToString();
                        tot_cred.Text = aluno.tot_cred.ToString();
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            String mat_alu_id = mat_alu.Value;
            bool saved;

            saved = mat_alu_id == "" ? create() : update();

            if (saved)
            {
                Session["flash_message"] = "Aluno salvo com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar o aluno, tente novamente.";
            }
        }

        private bool create()
        {
            return controller().create(nom_alu.Text, DateTime.Parse(dat_nasc.Text), Int32.Parse(curso.Text));
        }

        private bool update()
        {
            int mat_alu_id = Int32.Parse(mat_alu.Value);
            return controller().update(mat_alu_id, nom_alu.Text, DateTime.Parse(dat_nasc.Text), Int32.Parse(curso.Text));
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