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

            int? ano_v, semestre_v;
            DateTime? dat_ini_v, dat_fim_v;

            ano_v = (String.IsNullOrEmpty(ano)) ? ano_v = null : ano_v = Int32.Parse(ano);
            semestre_v = (String.IsNullOrEmpty(semestre)) ? semestre_v = null : semestre_v = Int32.Parse(semestre);
            dat_ini_v = (String.IsNullOrEmpty(dat_ini)) ? dat_ini_v = null : dat_ini_v = DateTime.Parse(dat_ini);
            dat_fim_v = (String.IsNullOrEmpty(dat_fim)) ? dat_fim_v = null : dat_fim_v = DateTime.Parse(dat_fim);

            return con.Periodo_Letivo.Where(Periodo_Letivo =>  (!ano_v.HasValue || Periodo_Letivo.ano == ano_v.Value) &&
                                                               (!semestre_v.HasValue || Periodo_Letivo.semestre == semestre_v.Value) &&
                                                               (!dat_ini_v.HasValue || Periodo_Letivo.dat_ini == dat_ini_v.Value) &&
                                                               (!dat_fim_v.HasValue || Periodo_Letivo.dat_fim == dat_fim_v.Value)).ToList();

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