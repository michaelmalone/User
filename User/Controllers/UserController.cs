using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using User.Domain;
using User.Interfaces;

namespace User.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserSvc _userSvc;

        public UserController(ILogger<UserController> logger, IUserSvc userSvc)
        {
            _logger = logger;
            _userSvc = userSvc;
        }

        

        // : UserController/Create
        //[Authorize]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<AppUser>> CreateAsync(AppUser appUser)
        {
            //Validation 
            //save
            try
            {
                var user = await _userSvc.Create(appUser);
                return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed creating user {appUser.Name}", e);
                return await Task.FromResult(BadRequest());
            }

        }

        // : UserController/GetProducts
        //[Authorize]
        [HttpGet("products")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            //Validation 
            //save
            try
            {
                var products = await _userSvc.GetProducts();
                return Ok(products);
            }
            catch (Exception e)
            {
                _logger.LogError("Failed getting products.", e);
                return await Task.FromResult(BadRequest());
            }

        }
    }
}
