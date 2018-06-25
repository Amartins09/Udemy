using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Loja.Domain.Account;

namespace Loja.Data.Identity
{
    public class ApplicationUser : IdentityUser, IUser
    {
        
    }
}
