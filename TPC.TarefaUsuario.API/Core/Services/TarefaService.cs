using TPC.TarefaUsuario.API.Core.Data.Entity;
using TPC.TarefaUsuario.API.Core.Repositories.Interface;
using TPC.TarefaUsuario.API.Core.Services.Interface;

namespace TPC.TarefaUsuario.API.Core.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public Tarefa Add(Tarefa entity)
        {
            return _tarefaRepository.Add(entity);
        }

        public Tarefa FindById(int id)
        {
            return _tarefaRepository.FindById(id);
        }

        public IEnumerable<Tarefa> ListAll()
        {
            return _tarefaRepository.List();
        }

        public IEnumerable<Tarefa> ListForUsuario(int usuarioId)
        {
            return _tarefaRepository.Find(d=> d.UsuarioId == usuarioId).ToList();
        }
    }
}
