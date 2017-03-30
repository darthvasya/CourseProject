using Microsoft.AspNetCore.Mvc;
using WebCourse.Models.Repositories;

namespace WebCourse.Controllers
{
    public class HomeController : Controller {
        private int _newsCount = 10;
        private INewsRepository _newsRepository;

        public HomeController(INewsRepository repo) {
            _newsRepository = repo;
        }

        public IActionResult Index() {
            ViewBag.Title = "Главная";
            return View();
        }
    }
}
