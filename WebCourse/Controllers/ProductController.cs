using Microsoft.AspNetCore.Mvc;
using WebCourse.Models.Repositories;
using WebCourse.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebCourse.Models.ViewModels;
using WebCourse.Infrastructure;

namespace WebCourse.Controllers
{
    public class ProductController : Controller {
        private IInnovativeProductRepository _productsRepository;
        private UserManager<User> _userManager;
        private ICertificateRepository _certificateRepository;

        public ProductController(IInnovativeProductRepository repo, UserManager<User> usrMgr, ICertificateRepository certificatRepo) {
            _productsRepository = repo;
            _userManager = usrMgr;
            _certificateRepository = certificatRepo;

        }

        public IActionResult Index() {
            ViewBag.Title = "Инновационные продукты";
            return View();
        }


        public async Task<IActionResult> Create(){
            ViewBag.Title = "Создание продукта";
            return View("Edit", new InnovativeProduct { CreatorID = await HttpContext.GetCurrentUserIdAsync(_userManager)});
        }

        public IActionResult Edit(int id){
            InnovativeProduct product = _productsRepository.InnovativeProducts
                .Where(p => p.InnovativeProductID == id)
                .FirstOrDefault();
            ViewBag.Title = $"Изменение продукта: {product.productName}";
            return View(product);
        }

        public async Task<IActionResult> Product(int id){
            User user = null;
            InnovativeProduct product = _productsRepository.InnovativeProducts.Where(p => p.InnovativeProductID == id).SingleOrDefault();
            if (product != null) {
                user = await _userManager.FindByIdAsync(product.CreatorID);
                ViewBag.Title = $"Инновационный продукт: {product.productName}";
            } else {
                return new NotFoundResult();
            }
            product.Certificates = _certificateRepository.Certificates.Where(c => c.InnovativeProductID == id).ToList();

            return View(new ProductViewModel {
                Product = product,
                User = user,
                CanEdit = (product.CreatorID == await HttpContext.GetCurrentUserIdAsync(_userManager) || HttpContext.User.IsInRole("Admin"))
            });
        }

        [HttpPost]
        public IActionResult Edit(InnovativeProduct product){
            if(ModelState.IsValid){
               product = _productsRepository.SaveProduct(product);
            } else {
                return View(product);
            }
            return RedirectToAction("Product", new {id = product.InnovativeProductID});
        }

        public ViewResult List(){
            ViewBag.Title = "Инновационные продукты";
            return View();
        }
    }
}
