using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebCourse.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;
using WebCourse.Models.ViewModels;
using WebCourse.Infrastructure;

namespace WebCourse.Controllers {

    public class AccountController : Controller {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> usrMgr, SignInManager<User> signInMgr) {
            _userManager = usrMgr;

            _signInManager = signInMgr;
        }

        public async Task<ViewResult> ConfirmEmail(string userId, string token) {
            User user = _userManager.FindByIdAsync(userId).Result;
            IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded) {
                return View(true);
            } else {
                return View(false);
            }
        }

        [Authorize]
        public async Task<RedirectResult> LogOut(string returnUrl = "/") {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        public ViewResult Registration() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Registration(RegistrationModel model) {
            if(ModelState.IsValid){
                if(model.Pass1 != model.Pass2){
                    ModelState.AddModelError("", "Введенные вами пароли не совпадают");
                    return View(model);
                }

                User user = new User{
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Pass1);

                if(result.Succeeded){
                    TempData["Message"] = "Регистрация завершена успешно";
                    string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    string mailMessage = $"Регистрация завершена. Для подтверждения регистрации перейдите по ссылке -> {Url.Action("ConfirmEmail", "Account", new {userId = user.Id, token = token}, protocol:HttpContext.Request.Scheme)}";
                    await MyExtensions.SendEmailAsync(user.Email, "Подтверждение регистрации", mailMessage);
                    return RedirectToAction("index", "home");
                } else {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        public ViewResult Login(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model){
            if (ModelState.IsValid) {
                User user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null) {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded) {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Почта или пароль были введены неверно");
            return View(model);
        }

        public IActionResult AccessDenied() {
            return View();
        }
    }
}
