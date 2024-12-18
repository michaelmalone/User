using User.Domain;
using User.Interfaces;
using User.Persistence;

namespace User.Services
{

    public class UserSvc : IUserSvc
    {
        private ILogger _logger;
        //private IAppDbContext _appDbContext;

        private IList<AppUser> _users;

        public UserSvc(ILogger logger) 
        {
            _logger = logger;
            //_appDbContext = dbContext;
            _users = new List<AppUser>();
        }

        public AppUser Create(AppUser user)
        {
            //_appDbContext.AppUsers.Add(user);
            //_appDbContext.SaveChanges();
            _users.Add(user);
            return user;
        }
    }
}
