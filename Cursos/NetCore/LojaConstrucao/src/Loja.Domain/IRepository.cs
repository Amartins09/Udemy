namespace Loja.Domain
{
    public interface IRepository<TEntity>{

        TEntity GetById(int Id);

        void Save(TEntity entity);
    }
}