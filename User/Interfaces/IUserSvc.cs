using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;
using User.Domain;

namespace User.Interfaces
{
    public interface IUserSvc
    {
        
        public AppUser Create(AppUser user);


    }
}
