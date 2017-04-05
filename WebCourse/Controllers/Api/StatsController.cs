using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebCourse.Models;
using WebCourse.Models.Repositories;

namespace WebCourse.Controllers.Api
{
    [Route("api/[controller]")]
    public class StatsController : Controller {

        private const int _newsCount = 2;

        private INewsRepository _newsRepository;
        private ICompanyRepository _companyRepository;
        private IInnovativeProductRepository _productRepository;
        private UserManager<User> _userManager;

        public StatsController(INewsRepository newsRepo, ICompanyRepository companyRepo, IInnovativeProductRepository productRepo, UserManager<User> usrMgr) {
            _newsRepository = newsRepo;
            _companyRepository = companyRepo;
            _productRepository = productRepo;
            _userManager = usrMgr;
        }

        [HttpGet]
        public object Get(){
           return new {
                    stats = new {
                        newsCount = _newsRepository.News.Count(),
                        companiesCount = _companyRepository.Companies.Count(),
                        productsCount = _productRepository.InnovativeProducts.Count(),
                        usersCount = _userManager.Users.Count()
                    },
                    lastProducts = _productRepository.InnovativeProducts
                        .OrderByDescending(p => p.InnovativeProductID)
                        .Take(5),
                    lastCompanies = _companyRepository.Companies
                        .OrderByDescending(c => c.CompanyID)
                        .Take(5)
                };
        }
    }
}
