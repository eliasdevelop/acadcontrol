using System;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.Professor
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String professor_id = Request.QueryString["id"];

                if (professor_id != null)
                {
                    Models.Professor professor = controller().edit(Int32.Parse(professor_id));

                    if (professor == null)
                    {
                        Session["error_message"] = "Professor não encontrado";
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        id.Value = professor_id;
                        nom_prof.Text = professor.nom_prof;
                        mat_prof.Text = professor.mat_prof.ToString();
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            String professor_id = id.Value;
            bool saved;

            saved = professor_id == "" ? create() : update();

            if (saved)
            {
                Session["flash_message"] = "Professor salvo com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar a professor, tente novamente.";
            }
        }

        private bool create()
        {
            return controller().create(nom_prof.Text, Int32.Parse(mat_prof.Text));
        }

        private bool update()
        {
            int professor_id = Int32.Parse(id.Value);
            return controller().update(professor_id, nom_prof.Text, Int32.Parse(mat_prof.Text));
        }

        private ProfessorController controller()
        {
            return new ProfessorController();
        }
    }
}