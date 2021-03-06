using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebCourse.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;
using WebCourse.Models.ViewModels;
using WebCourse.Infrastructure;
using System;

namespace WebCourse.Controllers {

    public class AccountController : Controller {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> usrMgr, SignInManager<User> signInMgr) {
            _userManager = usrMgr;

            _signInManager = signInMgr;
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token) {
            User user = _userManager.FindByIdAsync(userId).Result;
            IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded) {
                TempData["Message"] = "Почта успешно подтверждена";
                return RedirectToAction("index", "home");
            } else {
                TempData["Danger"] = "Ошибка. Обратитесь в службу поддержки";
                return RedirectToAction("index", "home");
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
                    UserName = model.UserName,
                    Email = model.Email,
                    Joined = DateTime.Now
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
                if(user == null){
                    user = await _userManager.FindByNameAsync(model.Email);
                }

                if (user != null) {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded) {
                        return RedirectToAction("Index", "Home");
                    } else if (result.IsLockedOut) {
                        TempData["Danger"] = $"Ваш аккаунт заблокирован до: {user.LockoutEnd.ToString()}";
                        return RedirectToAction(nameof(Login));
                    }
                }
            }
            ModelState.AddModelError("", "Почта или пароль были введены неверно");
            return View(model);
        }

        public IActionResult AccessDenied() {
            TempData["Danger"] = "В доступе отказано";
            return RedirectToAction("Index", "Home");
        }

        // логин через вк\фэйсбук\гугл
        [AllowAnonymous]
        public IActionResult ExternalLogin(string returnUrl, string authType) {
            if (Request.Cookies["Identity.External"] != null) {
                Response.Cookies.Delete("Identity.External");
            }
            string redirectUrl = Url.Action("ExternalResponse", "Account", new { returnUrl = returnUrl });

            AuthenticationProperties properties = _signInManager.ConfigureExternalAuthenticationProperties(authType, redirectUrl);
            return new ChallengeResult(authType, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalResponse(string returnUrl = "/") {
            if (Request.Cookies["Identity.External"] != null) {
                Response.Cookies.Delete("Identity.External");
            }
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null) {
                TempData["Danger"] = "Ошибка. Возможно почта которая используется в данной соц. сети уже зарегистрирована у нас.";
                return RedirectToAction(nameof(Login));
            }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);

            if (result.Succeeded) {
                return Redirect(returnUrl);
            } else if(result.IsLockedOut){
                User user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                TempData["Danger"] = $"Ваш аккаунт заблокирован до: {user.LockoutEnd.Value.UtcDateTime.AddHours(3).ToString()}";
                return RedirectToAction(nameof(Login));
            } else {
                User user = new User();
                user.Email = info.Principal.FindFirst(ClaimTypes.Email).Value;
                user.UserName = info.Principal.FindFirst(ClaimTypes.NameIdentifier).Value;
                if(info.LoginProvider == "Vkontakte"){
                    user.Name = info.Principal.FindFirst(ClaimTypes.GivenName).Value + " " + info.Principal.FindFirst(ClaimTypes.Surname).Value;
                } else {
                    user.Name = info.Principal.FindFirst(ClaimTypes.Name).Value;
                }
                user.EmailConfirmed = true;
                user.Joined = DateTime.Now;

                IdentityResult identityResult = await _userManager.CreateAsync(user);
                if (identityResult.Succeeded) {
                    identityResult = await _userManager.AddLoginAsync(user, info);
                    if (identityResult.Succeeded) {
                        await _signInManager.SignInAsync(user, false);
                        return Redirect(returnUrl);
                    }
                }
                TempData["Danger"] = "Ошибка. Возможно почта которая используется в данной соц. сети уже зарегистрирована у нас.";
                return RedirectToAction(nameof(Login));
            }
        }
    }
}
