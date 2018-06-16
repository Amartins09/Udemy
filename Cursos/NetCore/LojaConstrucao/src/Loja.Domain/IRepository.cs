using System.Collections.Generic;

namespace Loja.Domain
{
    public interface IRepository<TEntity>{

        TEntity GetById(int Id);
        IEnumerable<TEntity> All();
        void Save(TEntity entity);
    }
}