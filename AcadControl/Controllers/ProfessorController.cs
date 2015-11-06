using System;
using AcadControl.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcadControl.Controllers
{
    public class ProfessorController : ApplicationController
    {
        public List<Professor> index()
        {
            var con = db();

            return con.Professor.ToList();
        }

        public List<Professor> find_by(String nome, int? matricula)
        {
            var con = db();

            return con.Professor.Where(Professor => Professor.nom_prof.Contains(nome) && 
                                                    (!matricula.HasValue || Professor.mat_prof == matricula.Value)).ToList();    
        }

        public bool create(String nom_prof, int mat_prof)
        {
            var con = db();

            Professor professor = new Professor();
            professor.nom_prof = nom_prof;
            professor.mat_prof = mat_prof;

            con.Professor.Add(professor);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public Professor edit(int id)
        {
            var con = db();

            return con.Professor.Find(id);
        }

        public bool update(int id, String nom_prof, int mat_prof)
        {
            var con = db();

            Professor professor = con.Professor.Find(id);
            professor.nom_prof = nom_prof;
            professor.mat_prof = mat_prof;

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public bool delete(int id)
        {
            var con = db();

            Professor professor = con.Professor.Find(id);
            con.Professor.Remove(professor);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }
    }
}