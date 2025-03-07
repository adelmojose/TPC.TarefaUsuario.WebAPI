using TPC.TarefaUsuario.API.Core.Services;
using TPC.TarefaUsuario.API.Core.Data.Entity;
using TPC.TarefaUsuario.API.Core.Services.Interface;
using TPC.TarefaUsuario.API.Core.Repositories.Interface;

namespace TPC.TarefaUsuario.API.Core.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public Usuario Add(Usuario entity)
        {
          
                return _usuarioRepository.Add(entity);

        }

        public Usuario FindById(int id)
        {
           
                return _usuarioRepository.FindById(id);

     
        }

        public IEnumerable<Usuario> ListAll()
        {
            return _usuarioRepository.List();
        }
    }
}
