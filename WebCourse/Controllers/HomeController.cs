using Microsoft.AspNetCore.Mvc;
using WebCourse.Models.Repositories;

namespace WebCourse.Controllers
{
    public class HomeController : Controller {
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
