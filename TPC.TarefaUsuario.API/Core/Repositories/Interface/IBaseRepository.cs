﻿using TPC.TarefaUsuario.API.Core.Data.Entity;
using System.Linq.Expressions;

namespace TPC.TarefaUsuario.API.Core.Repositories.Interface
{
    public interface IBaseRepository <TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> List();
        TEntity FindById(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Delete(TEntity entity);
    }
}
