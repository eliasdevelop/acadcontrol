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

            return con.Curso.Where(Curso => Curso.nom_curso.Contains(nome) && 
                                            Curso.Professor.nom_prof.Contains(responsavel)).ToList();
        }

        public bool create(String nome, int tot_cred, String id_prof)
        {
            var con = db();

            Curso curso = new Curso();

            if (id_prof == "")
            {
                curso.id_prof = null;

                curso.nom_curso = nome;
                curso.tot_cred = tot_cred;

                con.Curso.Add(curso);

                int rows = con.SaveChanges();

                return rows.Equals(1);
            }
            else
            {
                if (validateProf(Int32.Parse(id_prof)))
                {
                    curso.id_prof = Int32.Parse(id_prof);

                    curso.nom_curso = nome;
                    curso.tot_cred = tot_cred;

                    con.Curso.Add(curso);

                    int rows = con.SaveChanges();

                    return rows.Equals(1);
                }
                else
                {
                    return false;
                }
            }
        }

        private bool validateProf(int id_prof)
        {
            var con = db();

            int countCursos = con.Curso.Where(Curso => Curso.id_prof == id_prof).Count();

            if (countCursos == 3)
            {
                return false;
            }
            else
            {
                return true;
            }
            
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