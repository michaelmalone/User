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

        

        // GET: UserController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<AppUser> Create(AppUser appUser)
        {
            //Validation 
            //save
            try
            {
                var user = _userSvc.Create(appUser);
                return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed creating user {appUser.Name}", e);
                return BadRequest();
            }

        }
    }
}
