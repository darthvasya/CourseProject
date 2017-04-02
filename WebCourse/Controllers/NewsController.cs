using Microsoft.AspNetCore.Mvc;
using WebCourse.Models.Repositories;
using WebCourse.Models;
using System.Linq;

namespace WebCourse.Controllers
{
    public class NewsController : Controller {

        private INewsRepository _newsRepository;

        public NewsController(INewsRepository repo) {
            _newsRepository = repo;
        }

        public IActionResult Create() {
            return View("Edit", new News());
        }

        public IActionResult Edit(int id) {
            News news = _newsRepository.News.Where(n => n.NewsID == id).SingleOrDefault();
            ViewBag.Title = $"Редактирование новости: {news.Title}";
            return View(news);
        }

        [HttpPost]
        public IActionResult Edit(News news) {
            if (ModelState.IsValid) {
                _newsRepository.SaveNews(news);
            } else {
                return View(news);
            }
            return RedirectToAction("index", "home");
        }
    }
}
