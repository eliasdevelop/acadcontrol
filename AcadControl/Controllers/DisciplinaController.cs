using System;
using AcadControl.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcadControl.Controllers
{
    public class DisciplinaController : ApplicationController
    {
        public List<Disciplina> index()
        {
            var con = db();

            return con.Disciplina.ToList();
        }

        public List<Disciplina> find_by(String nome, String tipo)
        {
            var con = db();

            return con.Disciplina.Where(Disciplina => Disciplina.nom_disc.Contains(nome) && 
                                                      Disciplina.tpo_disc.Contains(tipo)).ToList();
        }

        public bool create(String nome, int creditos, String tipo_disc, int horas_obrig, int limite_faltas)
        {
            var con = db();

            Disciplina disciplina = new Disciplina();
            disciplina.nom_disc = nome;
            disciplina.creditos = creditos;
            disciplina.tpo_disc = tipo_disc;
            disciplina.horas_obrig = horas_obrig;
            disciplina.limite_faltas = limite_faltas;

            con.Disciplina.Add(disciplina);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public Disciplina edit(int id)
        {
            var con = db();

            return con.Disciplina.Find(id);
        }

        public bool update(int id, String nome, int creditos, String tipo_disc, int horas_obrig, int limite_faltas)
        {
            var con = db();

            Disciplina disciplina = con.Disciplina.Find(id);
            disciplina.nom_disc = nome;
            disciplina.creditos = creditos;
            disciplina.tpo_disc = tipo_disc;
            disciplina.horas_obrig = horas_obrig;
            disciplina.limite_faltas = limite_faltas;

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public bool delete(int id)
        {
            var con = db();

            Disciplina disciplina = con.Disciplina.Find(id);
            con.Disciplina.Remove(disciplina);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }
    }
}