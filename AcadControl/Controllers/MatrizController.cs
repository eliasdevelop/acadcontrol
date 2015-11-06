using System;
using System.Web.UI.WebControls;
using AcadControl.Models;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace AcadControl.Controllers
{
	public class MatrizController : ApplicationController
    {
        public List<Matriz> index()
        {
            var con = db();

            return con.Matriz.ToList();
        }

        public List<Matriz> find_by(String periodo, String id_curso, String id_disciplina)
        {
            var con = db();

            int? periodo_v, id_curso_v, id_disciplina_v;

            periodo_v = (String.IsNullOrEmpty(periodo)) ? periodo_v = null : periodo_v = Int32.Parse(periodo);
            id_curso_v = (String.IsNullOrEmpty(id_curso)) ? id_curso_v = null : id_curso_v = Int32.Parse(id_curso);
            id_disciplina_v = (String.IsNullOrEmpty(id_disciplina)) ? id_disciplina_v = null : id_disciplina_v = Int32.Parse(id_disciplina);


            return con.Matriz.Where(Matriz => (!periodo_v.HasValue || Matriz.periodo == periodo_v.Value) &&
                                              (!id_curso_v.HasValue || Matriz.id_curso == id_curso_v.Value) &&
                                              (!id_disciplina_v.HasValue || Matriz.id_disc == id_disciplina_v.Value)).ToList();

        }

        public bool gerarMatriz(CheckBoxList disciplinas, int id_curso, int periodo)
        {        
            using (TransactionScope transaction = new TransactionScope())
            {
                var con = db();
                try
                {
                    foreach (ListItem item in disciplinas.Items)
                    {
                        if (item.Selected)
                        {
                            Matriz matriz = new Matriz();

                            matriz.id_curso = id_curso;
                            matriz.id_disc = Int32.Parse(item.Value);
                            matriz.periodo = periodo;

                            con.Matriz.Add(matriz);

                            con.SaveChanges();
                        }
                    }
                    transaction.Complete();
                    return true;
                }
                catch(Exception)
                {
                    return false; 
                }
            }
        }

        public Matriz edit(int id_curso, int id_disc)
        {
            var con = db();

            return con.Matriz.Find(id_curso, id_disc);
        }

        public bool delete(int id_curso, int id_disc)
        {
            var con = db();

            Matriz matriz = con.Matriz.Find(id_curso, id_disc);
            con.Matriz.Remove(matriz);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }
    }
}