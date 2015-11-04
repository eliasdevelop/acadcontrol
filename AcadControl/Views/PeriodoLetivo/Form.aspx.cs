using System;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.PeriodoLetivo
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                String periodo_ano = Request.QueryString["ano"];
                String periodo_semestre = Request.QueryString["semestre"];

                if (periodo_ano != null && periodo_semestre != null)
                {
                    Models.Periodo_Letivo periodo_letivo = controller().edit(Int32.Parse(periodo_ano), Int32.Parse(periodo_semestre));

                    if (periodo_letivo == null)
                    {
                        Session["error_message"] = "Periodo Letivo não encontrado";
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        id.Value = periodo_ano;
                        ano.Text = periodo_letivo.ano.ToString();
                        semestre.Text = periodo_letivo.semestre.ToString();
                        dat_ini.Text = periodo_letivo.dat_ini.ToString("dd/MM/yyyy");
                        dat_fim.Text = periodo_letivo.dat_fim.ToString("dd/MM/yyyy");
                    }
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            String ano_id = id.Value;
            bool saved;

            saved = ano_id == "" ? create() : update();

            if (saved)
            {
                Session["flash_message"] = "Periodo Letivo salvo com sucesso";
                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["error_message"] = "Falha ao salvar o periodo letivo, tente novamente.";
            }
        }

        private bool create()
        {
            return controller().create(Int32.Parse(ano.Text), Int32.Parse(semestre.Text), DateTime.Parse(dat_ini.Text), DateTime.Parse(dat_fim.Text));
        }

        private bool update()
        {
            return controller().update(Int32.Parse(ano.Text), Int32.Parse(semestre.Text), DateTime.Parse(dat_ini.Text), DateTime.Parse(dat_fim.Text));
        }

        private PeriodoLetivoController controller()
        {
            return new PeriodoLetivoController();
        }
    }
}