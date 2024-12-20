using User.Adapters;
using User.Domain;
using User.Interfaces;
using User.Persistence;

namespace User.Services
{

    public class UserSvc : IUserSvc
    {
        private ILogger<IUserSvc> _logger;
        private readonly IProductSvcAdapter _productAdapter;

        //private IAppDbContext _appDbContext;

        private IList<AppUser> _users;

        public UserSvc(ILogger<IUserSvc> logger, IProductSvcAdapter productAdapter) 
        {
            _logger = logger;
            this._productAdapter = productAdapter;
            //_appDbContext = dbContext;
            _users = new List<AppUser>();
        }

        public async Task<AppUser> Create(AppUser user)
        {
            //_appDbContext.AppUsers.Add(user);
            //_appDbContext.SaveChanges();
            _users.Add(user);
            return user;
        }

        public async Task<Product[]> GetProducts(int maxItems = 10, CancellationToken cancellationToken = default)
        {
            return await _productAdapter.GetProducts(maxItems, cancellationToken);
        }
    }
}
