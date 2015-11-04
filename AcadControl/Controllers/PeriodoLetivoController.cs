using System;
using AcadControl.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcadControl.Controllers
{
    public class PeriodoLetivoController : ApplicationController
    {
        public List<Periodo_Letivo> index()
        {
            var con = db();

            return con.Periodo_Letivo.ToList();
        }

        public List<Periodo_Letivo> find_by(String ano, String semestre, String dat_ini, String dat_fim)
        {
            var con = db();
           

            if (ano == "" && semestre == "" && dat_ini == "" && dat_fim == "")
            {
                return con.Periodo_Letivo.ToList();
            }
            else
            {
                return con.Periodo_Letivo.ToList();
                //return con.Periodo_Letivo.SqlQuery("SELECT * FROM Periodo_Letivo WHERE ano = {0} AND semestre = {1} AND dat_ini = {3} AND dat_fim = {4}", ano, semestre, dat_ini, dat_fim).ToList();
            }
        }

        public bool create(int ano, int semestre, DateTime dat_ini, DateTime dat_fim)
        {
            var con = db();

            Periodo_Letivo periodo_letivo = new Periodo_Letivo();

            periodo_letivo.ano = ano;
            periodo_letivo.semestre = semestre;
            periodo_letivo.dat_ini = dat_ini;
            periodo_letivo.dat_fim = dat_fim;
            
            con.Periodo_Letivo.Add(periodo_letivo);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public Periodo_Letivo edit(int ano, int semestre)
        {
            var con = db();

            return con.Periodo_Letivo.Find(ano, semestre);
        }

        public bool update(int ano, int semestre, DateTime dat_ini, DateTime dat_fim)
        {
            var con = db();

            Periodo_Letivo periodo_letivo = con.Periodo_Letivo.Find(ano, semestre);

            periodo_letivo.dat_ini = dat_ini;
            periodo_letivo.dat_fim = dat_fim;

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public bool delete(int ano, int semestre)
        {
            var con = db();

            Periodo_Letivo periodo_letivo = con.Periodo_Letivo.Find(ano, semestre);
            con.Periodo_Letivo.Remove(periodo_letivo);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }
    }
}