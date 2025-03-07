using TPC.TarefaUsuario.API.Core.Repositories;
using TPC.TarefaUsuario.API.Core.Data;
using TPC.TarefaUsuario.API.Core.Data.Entity;
using TPC.TarefaUsuario.API.Core.Repositories.Interface;

namespace TPC.TarefaUsuario.API.Core.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(DataBaseContext dbContext) : base(dbContext)
        {

        }
    
    }
}
