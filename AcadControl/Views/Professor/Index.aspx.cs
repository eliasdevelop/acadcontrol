﻿using System;
using AcadControl.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcadControl.Views.Professor
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadProfessores();
            }    
        }

        protected void ProfessoresList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Models.Professor professor = (Models.Professor)e.Row.DataItem;

                HyperLink edit = e.Row.Cells[2].Controls[0] as HyperLink;
                edit.NavigateUrl = "~/Views/Professor/Form.aspx?id=" + professor.id;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int professor_id = Int32.Parse(ProfessoresList.DataKeys[row.RowIndex]["id"].ToString());

            if (controller().delete(professor_id))
            {
                Session["flash_message"] = "Professor removido com sucesso";
            }
            else
            {
                Session["error_message"] = "Falha ao remover a professor, tente novamente.";
            }

            loadProfessores();
        }

        protected void Pesquisar_Click(object sender, EventArgs e)
        {
            int imat_alu = 0;

            if (Int32.TryParse(mat_alu.Text, out imat_alu))
            {
                ProfessoresList.DataSource = controller().find_by(nome_prof.Text, imat_alu);
            }
            else
            {
                ProfessoresList.DataSource = controller().find_by(nome_prof.Text, null);
            }
            
            ProfessoresList.DataBind();
        }

        private void loadProfessores()
        {
            ProfessoresList.DataSource = controller().index();
            ProfessoresList.DataBind();
        }

        private ProfessorController controller()
        {
            return new ProfessorController();
        }
    }
}