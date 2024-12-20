using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;
using User.Domain;

namespace User.Interfaces
{
    public interface IUserSvc
    {
        
        Task<AppUser> Create(AppUser user);

        Task<Product[]> GetProducts(int maxItems = 10, CancellationToken cancellationToken = default);
    }
}
