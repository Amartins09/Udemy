using System.Threading.Tasks;

namespace Loja.Domain.Account{

    public interface IAuthentication
    {
        Task<bool> Authenticate(string email, string password);
        Task Logout();
    }
}
