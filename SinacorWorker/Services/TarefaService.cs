using SinacorWorker.Domain;
using SinacorWorker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinacorWorker.Services
{
    public class TarefaService
    {        
        private readonly TarefaRepository _tarefaRepository;

        public TarefaService()
        {
            _tarefaRepository = TarefaRepository.GetInstance();
        }

        public void Save(Tarefa tarefa)
        {
            if (tarefa.Id == 0)
            {
                Insert(tarefa);
            }
            else
            {
                Update(tarefa);
            }
        }

        public void Insert(Tarefa tarefa)
        {
            _tarefaRepository.Insert(tarefa);
        }

        public void Update(Tarefa tarefa)
        {
            _tarefaRepository.Update(tarefa);
        }

        public void Delete(Tarefa tarefa)
        {
            _tarefaRepository.Delete(tarefa);
        }

        public IEnumerable<Tarefa> GetAll()
        {
            return _tarefaRepository.GetAll();
        }

        public Tarefa GetById(int id)
        {
            return _tarefaRepository.GetById(id);
        }
    }
}
