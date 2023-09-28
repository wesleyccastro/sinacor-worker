using SinacorWorker.Context;
using SinacorWorker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinacorWorker.Repositories
{
    public sealed class TarefaRepository
    {        
        private static TarefaRepository _instance = null;
        private static readonly object padlock = new object();

        private TarefaRepository()
        {
            
        }

        public static TarefaRepository GetInstance()
        {
            if (_instance != null) return _instance;
            lock (padlock)
            {
                if (_instance == null)
                {
                    _instance = new TarefaRepository();
                }
                return _instance;
            }
        }

        public void Insert(Tarefa tarefa)
        {
            using (var context = new AppDbContext())
            {
                context.Tarefas.Add(tarefa);
                context.SaveChanges();
            }
        }

        public void Update(Tarefa tarefa)
        {
            using (var context = new AppDbContext())
            {
                context.Tarefas.Update(tarefa);
                context.SaveChanges();
            }
        }

        public void Delete(Tarefa tarefa)
        {
            using (var context = new AppDbContext())
            {
                context.Tarefas.Remove(tarefa);
                context.SaveChanges();
            }
        }

        public Tarefa GetById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Tarefas.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Tarefa> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Tarefas.ToList();
            }
        }
    }
}
