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
            ViewBag.Cog = "Новости";
            ViewBag.Manage = "Управление";
            return View();
        }

        public IActionResult CreateNews() {
            ViewBag.Title = "Создание новой новости";
            ViewBag.Cog = "Новости";
            ViewBag.Manage = "Создание";
            return View("EditNews", new News());
        }

        public IActionResult EditNews(int id){
            News news = _newsRepository.News.Where(n => n.NewsID == id).SingleOrDefault();
            ViewBag.Title = $"Редактирование новости: {news.Title}";
            ViewBag.Cog = "Новости";
            ViewBag.Manage = $"Изменение новости: {news.Title}";
            return View(news);
        }

        [HttpPost]
        public IActionResult EditNews(News news) {
            if (ModelState.IsValid) {
                _newsRepository.SaveNews(news);
            } else {
                return View(news);
            }
            return RedirectToAction("News", "Admin");
        }

        [HttpPost]
        public IActionResult DeleteNews(int id){
            News deletedNews = _newsRepository.DeleteNews(id);
            if(deletedNews != null){
                TempData["Message"] = $"Новость '{deletedNews.Title}' успешна удалена.";
            } else {
                TempData["Danger"] = $"При удалении новости произошла ошибка. Повторите операцию позже.";
            }

            return RedirectToAction(nameof(News));
        }

        
    }
}
