using System.Threading.Tasks;

namespace Loja.Domain{
    public interface IUnitOfWork{

        Task Commit();
    }
}