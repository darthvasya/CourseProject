using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebCourse.Models;
using WebCourse.Models.Repositories;
using System.Linq;

namespace WebCourse.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    public class AdminController : Controller {

        private INewsRepository _newsRepository;
        private IInnovativeProductRepository _productRepository;
        private ICompanyRepository _companyRepository;
        private UserManager<User> _userManager;

        public AdminController(INewsRepository newsRepo, IInnovativeProductRepository prodRepo, ICompanyRepository compRepo, UserManager<User> usrMgr) {
            _companyRepository = compRepo;
            _newsRepository = newsRepo;
            _productRepository = prodRepo;
            _userManager = usrMgr;
        }

        public IActionResult Index() {
            ViewBag.Title = "Административная панель | Главная";
            ViewBag.Cog = "Главная";
            ViewBag.Manage = "Сводка";
            return View(_userManager.Users.OrderByDescending(u => u.Joined).Take(10));
        }

        public IActionResult News(){
            ViewBag.Title = "Административная панель | Новости";
            return View();
        }
    }
}
