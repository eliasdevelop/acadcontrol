using System;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.PeriodoLetivo
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadPeriodosLetivos();
        }

        protected void PeriodoLetivoList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Models.Periodo_Letivo periodo_letivo = (Models.Periodo_Letivo)e.Row.DataItem;

                HyperLink edit = e.Row.Cells[3].Controls[0] as HyperLink;
                edit.NavigateUrl = "~/Views/PeriodoLetivo/Form.aspx?ano=" + periodo_letivo.ano + "&semestre=" + periodo_letivo.semestre;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int periodo_ano = Int32.Parse(PeriodoLetivoList.DataKeys[row.RowIndex]["ano"].ToString());
            int periodo_semestre = Int32.Parse(PeriodoLetivoList.DataKeys[row.RowIndex]["semestre"].ToString());

            if (controller().delete(periodo_ano, periodo_semestre))
            {
                Session["flash_message"] = "PeriodoLetivo removido com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover o periodoLetivo, tente novamente.";
            }

            loadPeriodosLetivos();
        }

        protected void Pesquisar_Click(object sender, EventArgs e)
        {

            PeriodoLetivoList.DataSource = controller().find_by(ano.Text, semestre.Text, dat_ini.Text, dat_fim.Text);
            PeriodoLetivoList.DataBind();
        }

        private void loadPeriodosLetivos()
        {
            PeriodoLetivoList.DataSource = controller().index();
            PeriodoLetivoList.DataBind();
        }

        private PeriodoLetivoController controller()
        {
            return new PeriodoLetivoController();
        }
    }
}