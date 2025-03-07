using TPC.TarefaUsuario.API.Core.Data.Entity;
using TPC.TarefaUsuario.API.Core.Data;
using TPC.TarefaUsuario.API.Core.Repositories.Interface;

namespace TPC.TarefaUsuario.API.Core.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataBaseContext dbContext) : base(dbContext)
        {

        }
    
    }
}
