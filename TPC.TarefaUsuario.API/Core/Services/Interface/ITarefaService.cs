using TPC.TarefaUsuario.API.Core.Data.Entity;

namespace TPC.TarefaUsuario.API.Core.Services.Interface
{
    public interface ITarefaService : IBaseService<Tarefa>
    {
        IEnumerable<Tarefa> ListForUsuario(int usuarioId);
    }
}
