using System;
using AcadControl.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcadControl.Controllers 
{
    public class AlunoController : ApplicationController
    {
        public List<Aluno> index()
        {
            var con = db();

            return con.Aluno.ToList();
        }

        public List<Aluno> find_by(String nome, String matricula, String id_curso)
        {
            var con = db();

            int? mat, curso = 0;

            mat = (String.IsNullOrEmpty(matricula)) ? mat = null : mat = Int32.Parse(matricula);
            curso = (String.IsNullOrEmpty(id_curso)) ? curso = null : curso = Int32.Parse(id_curso);

            return con.Aluno.Where(Aluno => Aluno.nom_alu.Contains(nome) &&
                                            (!mat.HasValue || Aluno.mat_alu == mat.Value) &&
                                            (!curso.HasValue || Aluno.id_curso == curso.Value)).ToList();
        }

        public bool create(String nom_alu, DateTime dat_nasc, int id_curso)
        {
            var con = db();

            Aluno aluno = new Aluno();
            aluno.nom_alu = nom_alu;
            aluno.dat_nasc = dat_nasc;
            aluno.id_curso = id_curso;
            aluno.tot_cred = 0;
            aluno.mgp = 0;     
            aluno.mat_alu = gerarMatricula();

            con.Aluno.Add(aluno);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public Aluno edit(int mat_alu)
        {
            var con = db();

            return con.Aluno.Find(mat_alu);
        }

        public bool update(int mat_alu, String nom_alu, DateTime dat_nasc, int id_curso)
        {
            var con = db();

            Aluno aluno = con.Aluno.Find(mat_alu);
            aluno.nom_alu = nom_alu;
            aluno.dat_nasc = dat_nasc;
            aluno.id_curso = id_curso;

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public bool delete(int mat_alu)
        {
            var con = db();

            Aluno aluno = con.Aluno.Find(mat_alu);
            con.Aluno.Remove(aluno);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        private int gerarMatricula()
        {
            var con = db();

            DateTime dataHoje = DateTime.Today;
            int ano = dataHoje.Year;
            int count = con.Aluno.Count() + 1;
            String matricula;

            if (dataHoje.Month < 7)
            {
                matricula = ano.ToString() + '1' + count.ToString();
            }
            else
            {
                matricula = ano.ToString() + '2' + count.ToString();
            }

            return Int32.Parse(matricula);
        }
    }
}