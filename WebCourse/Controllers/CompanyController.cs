using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebCourse.Models;
using WebCourse.Models.ViewModels;
using WebCourse.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using WebCourse.Infrastructure;

namespace WebCourse.Controllers {
    [Authorize]
    public class CompanyController : Controller {
        private ICompanyRepository _repository;
        private ILicenseRepository _licenseRepository;
        private UserManager<User> _userManager;
        private int _companiesCount = 25;

        public CompanyController(ICompanyRepository repo, ILicenseRepository licenseRepo, UserManager<User> usrMgr) {
            _repository = repo;
            _licenseRepository = licenseRepo;
            _userManager = usrMgr;
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            Company company = _repository.DeleteCompany(id);

            if(company != null) {
                TempData["Message"] = $"Предприятие '{company.Name}' успешно удалено";
            } else {
                TempData["Danger"] = $"При удалении предприятия '{company.Name}' произошла ошибка";
            }

            return RedirectToAction("MyProfile", "User");
        }

        public async Task<IActionResult> Index(int companyId) {
            User user = null;
            Company company = _repository.Companies.Where(c => c.CompanyID == companyId).SingleOrDefault();
            if (company != null) {
                user = await _userManager.FindByIdAsync(company.CreatorID);
                company.Licenses = _licenseRepository.Licenses.Where(l => l.CompanyID == companyId).ToList();
                ViewBag.Title = company.Name;
                return View(new CompanyViewModel {
                    Company = company,
                    User = user,
                    IsMyCompany = (company.CreatorID == await HttpContext.GetCurrentUserIdAsync(_userManager) || HttpContext.User.IsInRole("Admin"))
                });
            } else {
                return new NotFoundResult();
            }
        }

        public IActionResult Edit(int companyId) {
            Company company = _repository.Companies.Where(c => c.CompanyID == companyId).FirstOrDefault();
            ViewBag.Title = $"Изменение предприятия: {company.Name}";
            return View(company);

        }

        [HttpPost]
        public IActionResult Edit(Company model) {
            if (ModelState.IsValid) {
                _repository.SaveCompany(model);
                TempData["Message"] = $"Предприятие '{model.Name}' было сохранено";
                return RedirectToAction(nameof(Index), new {companyId = model.CompanyID});
            } else {
                return View(model);
            }
        }

        public async Task<ViewResult> Create() {
            ViewBag.Title = "Создание Предприятия";
            return View("Edit", new Company { CreatorID = await HttpContext.GetCurrentUserIdAsync(_userManager) });
        }
    }
}
