using System;
using AcadControl.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcadControl.Controllers
{
    public class TurmaController : ApplicationController
    {
        public List<Turma> index()
        {
            var con = db();

            return con.Turma.ToList();
        }

        public bool create(int ano, int semestre, int id_disc, int id_prof, int vagas)
        {
            var con = db();

            Turma turma = new Turma();
            turma.ano = ano;
            turma.semestre = semestre;
            turma.id_disc = id_disc;
            turma.id_prof = id_prof;
            turma.vagas = vagas;

            con.Turma.Add(turma);

            try
            {
                int rows = con.SaveChanges();
                return rows.Equals(1);
            }
            catch (Exception e)
            {
                return false;
            }
     
        }

        public Turma edit(int ano, int semestre, int id_disc)
        {
            var con = db();

            return con.Turma.Find(ano, semestre, id_disc);
        }


        public bool delete(int ano, int semestre, int id_disc)
        {
            var con = db();

            Turma turma = con.Turma.Find(ano, semestre, id_disc);
            con.Turma.Remove(turma);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }
    }
}