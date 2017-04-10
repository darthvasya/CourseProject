using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebCourse.Models;
using WebCourse.Models.Repositories;
using System.Linq;
using System.Threading.Tasks;
using System;

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
            return View(_userManager.Users.Where(u => u.EmailConfirmed).OrderByDescending(u => u.Joined).Take(10));
        }

        public IActionResult News(){
            ViewBag.Title = "Административная панель | Новости";
            ViewBag.Cog = "Новости";
            ViewBag.Manage = "Управление";
            return View();
        }

        public ViewResult Users(){
            ViewBag.Title = "Административная панель | Пользователи";
            ViewBag.Cog = "Пользователи";
            ViewBag.Manage = "Управление";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id){
            User user = await _userManager.FindByIdAsync(id);
            if(user != null){
                await _userManager.DeleteAsync(user);
                TempData["Message"] = $"Пользователь {user.UserName} успешно удален из базы данных";
                return RedirectToAction(nameof(Users));
            }
            TempData["Danger"] = "При удалении пользователся произошла ошибка.";
            return RedirectToAction(nameof(Users));
        }

        [HttpPost]
        public async Task<IActionResult> BlockUser(string id, int hours){
            User user = await _userManager.FindByIdAsync(id);
            if(user != null){
                string successMessage = $"Пользователь {user.UserName} заблокирован на {hours} часов.";
                DateTimeOffset? offset = DateTime.UtcNow.AddHours(hours);
                if(hours == 0){
                    offset = null;
                    successMessage = $"Пользователь {user.UserName} разблокирован";
                }
                IdentityResult result = await _userManager.SetLockoutEndDateAsync(user, offset);
                if(result.Succeeded){
                    TempData["Message"] = successMessage;
                } else {
                    TempData["Danger"] = "При блокировке пользователя произошла ошибка";
                }
            }
            return RedirectToAction(nameof(Users));
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

        public IActionResult Products(){
            ViewBag.Title = "Административная панель | Продукты";
            ViewBag.Cog = "Продукты";
            ViewBag.Manage = "Управление";
            return View();
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id){
            InnovativeProduct product = _productRepository.DeleteProduct(id);
            if(product != null){
                TempData["Message"] = $"Продукт '{product.productName}' успешно удален";
            } else {
                TempData["Danger"] = "При удалении продукта произошла ошибка.";
            }
            return RedirectToAction(nameof(Products));
        }
    }
}
