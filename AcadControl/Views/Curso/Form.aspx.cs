using System;
using AcadControl.Controllers;
using AcadControl.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.Curso
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateDropDown();

            if (!IsPostBack)
            {
                String curso_id = Request.QueryString["id"];

                if (curso_id != null)
                {
                    Models.Curso curso = controller().edit(Int32.Parse(curso_id));

                    if (curso == null)
                    {
                        Session["error_message"] = "Curso não encontrado";
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        id.Value = curso_id;
                        nom_curso.Text = curso.nom_curso;
                        tot_cred.Text = curso.tot_cred.ToString();
                        professor.Text = curso.id_prof.ToString();
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            String curso_id = id.Value;
            bool saved;

            saved = curso_id == "" ? create() : update();

            if (saved)
            {
                Session["flash_message"] = "Curso salvo com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar o curso, tente novamente.";
            }
        }

        private bool create()
        {
            return controller().create(nom_curso.Text, Int32.Parse(tot_cred.Text), professor.Text);
        }

        private bool update()
        {
            int curso_id = Int32.Parse(id.Value);
            return controller().update(curso_id, nom_curso.Text, Int32.Parse(tot_cred.Text), professor.Text);
        }


        private CursoController controller()
        {
            return new CursoController();
        }

        private void populateDropDown()
        {
            ProfessorHelper.populate(professor);
        }
    }
}