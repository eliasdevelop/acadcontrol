using System;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.Disciplina
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String disciplina_id = Request.QueryString["id"];

                if (disciplina_id != null)
                {
                    Models.Disciplina disciplina = controller().edit(Int32.Parse(disciplina_id));

                    if (disciplina == null)
                    {
                        Session["error_message"] = "Disciplina não encontrado";
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        id.Value = disciplina_id;
                        nom_disc.Text = disciplina.nom_disc;
                        creditos.Text = disciplina.creditos.ToString();
                        tpo_disc.Text = disciplina.tpo_disc;
                        horas_obrig.Text = disciplina.horas_obrig.ToString();
                        limite_faltas.Text = disciplina.limite_faltas.ToString();
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            String disciplina_id = id.Value;
            bool saved;

            saved = disciplina_id == "" ? create() : update();

            if (saved)
            {
                Session["flash_message"] = "Disciplina salva com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar a disciplina, tente novamente.";
            }
        }

        private bool create()
        {
            return controller().create(nom_disc.Text, Int32.Parse(creditos.Text), tpo_disc.Text, Int32.Parse(horas_obrig.Text), Int32.Parse(limite_faltas.Text));
        }

        private bool update()
        {
            int disciplina_id = Int32.Parse(id.Value);
            return controller().update(disciplina_id, nom_disc.Text, Int32.Parse(creditos.Text), tpo_disc.Text, Int32.Parse(horas_obrig.Text), Int32.Parse(limite_faltas.Text));
        }

        private DisciplinaController controller()
        {
            return new DisciplinaController();
        }
    }
}