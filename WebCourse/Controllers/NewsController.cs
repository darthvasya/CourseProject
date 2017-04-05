using Microsoft.AspNetCore.Mvc;
using WebCourse.Models.Repositories;
using WebCourse.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WebCourse.Controllers
{
    [Authorize(Roles= "Admin, Moderator")]
    public class NewsController : Controller {

        private INewsRepository _newsRepository;

        public NewsController(INewsRepository repo) {
            _newsRepository = repo;
        }

        
        public IActionResult Create() {
            ViewBag.Title = "Создание новой новости";
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

        [HttpPost]
        public IActionResult Delete(int id, string returnUrl){
            News deletedNews = _newsRepository.DeleteNews(id);
            if(deletedNews != null){
                TempData["Message"] = $"Новость '{deletedNews.Title}' успешна удалена.";
            } else {
                TempData["Danger"] = $"При удалении новости произошла ошибка. Повторите операцию позже.";
            }

            return Redirect(returnUrl);
        }
    }
}
