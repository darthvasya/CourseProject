using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebCourse.Models;
using Microsoft.AspNetCore.Identity;

namespace WebCourse.Controllers.Api
{
    [Route("api/[controller]")]
    public class UsersController : Controller {

        private UserManager<User> _userManager;

        public UsersController(UserManager<User> usrMgr) {
            _userManager = usrMgr;
        }

        [HttpGet("{pattern}")]
        public object Get(string pattern){
            pattern = pattern.ToLower();
           return new {
                    Users = pattern == "all" ? 
                            _userManager.Users
                            .OrderByDescending(u => u.Joined)
                            :
                            _userManager.Users
                            .Where(n => n.Name.ToLower().Contains(pattern) || n.UserName.ToLower().Contains(pattern))
                            .OrderByDescending(u => u.Joined)
                };
        }
    }
}
