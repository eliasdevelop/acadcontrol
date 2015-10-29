using System;
using AcadControl.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcadControl.Controllers
{
    public class CursoController : ApplicationController
    {
        public List<Curso> index()
        {
            var con = db();

            return con.Curso.ToList();
        }

        public List<Curso> find_by(String nome, String responsavel)
        {
            var con = db();

            if (nome == "" && responsavel == "")
            {
                return con.Curso.ToList();
            }
            else
            {
                return con.Curso.Where(Curso => Curso.nom_curso.Contains(nome) && Curso.Professor.nom_prof.Contains(responsavel)).ToList();
            }
        }

        public bool create(String nome, int tot_cred, String id_prof)
        {
            var con = db();

            Curso curso = new Curso();
            curso.nom_curso = nome;
            curso.tot_cred = tot_cred;
            
            if (id_prof == "")
            {
                curso.id_prof = null;
            }
            else
            {
                curso.id_prof = Int32.Parse(id_prof);
            }

            con.Curso.Add(curso);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public Curso edit(int id)
        {
            var con = db();

            return con.Curso.Find(id);
        }

        public bool update(int id, String nome, int tot_cred, String id_prof)
        {
            var con = db();

            Curso curso = con.Curso.Find(id);
            curso.nom_curso = nome;
            curso.tot_cred = tot_cred;

            if (id_prof == "")
            {
                curso.id_prof = null;
            }
            else
            {
                curso.id_prof = Int32.Parse(id_prof);
            }

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public bool delete(int id)
        {
            var con = db();

            Curso curso = con.Curso.Find(id);
            con.Curso.Remove(curso);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }
    }
}