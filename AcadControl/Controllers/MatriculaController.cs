using System;
using AcadControl.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcadControl.Controllers
{
    public class MatriculaController : ApplicationController
    {
        public List<Matricula> index()
        {
            var con = db();

            return con.Matricula.ToList();
        }

        public bool create(int ano, int semestre, int mat_alu, int id_disciplina)
        {
            var con = db();

            Matricula matricula = new Matricula();
            matricula.ano = ano;
            matricula.semestre = semestre;
            matricula.mat_alu = mat_alu;
            matricula.id_disc = id_disciplina;
            matricula.nota_01 = 0;
            matricula.nota_02 = 0;
            matricula.nota_03 = 0;
            matricula.faltas_01 = 0;
            matricula.faltas_02 = 0;
            matricula.faltas_03 = 0;


            con.Matricula.Add(matricula);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public Matricula edit(int ano, int semestre, int mat_alu, int id_disciplina)
        {
            var con = db();

            return con.Matricula.Find(ano, semestre, mat_alu, id_disciplina);
        }

        public bool update(int ano, int semestre, int mat_alu, int id_disciplina, 
                           float nota01, float nota02, float nota03,
                           int faltas01, int faltas02, int faltas03)
        {
            var con = db();

            Matricula matricula = con.Matricula.Find(ano, semestre, mat_alu, id_disciplina);

            matricula.nota_01 = nota01;
            matricula.nota_02 = nota02;
            matricula.nota_03 = nota03;
            matricula.faltas_01 = faltas01;
            matricula.faltas_02 = faltas02;
            matricula.faltas_03 = faltas03;


            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public bool delete(int ano, int semestre, int mat_alu, int id_disciplina)
        {
            var con = db();

            Matricula matricula = con.Matricula.Find(ano, semestre, mat_alu, id_disciplina);
            con.Matricula.Remove(matricula);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }
    }
}