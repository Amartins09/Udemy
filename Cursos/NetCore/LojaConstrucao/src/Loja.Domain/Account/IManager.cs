using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Account{

    public interface IManager{
        Task<bool> CreateAsync(string email, string password, string role);
        List<IUser> ListAll();
    }
}