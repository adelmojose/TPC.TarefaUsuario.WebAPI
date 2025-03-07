namespace TPC.TarefaUsuario.API.Core.Services.Interface
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        TEntity FindById(int id);

        IEnumerable<TEntity> ListAll();

    }
}
