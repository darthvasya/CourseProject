using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebCourse.Models.Repositories;
using WebCourse.Models;
using System;

namespace WebCourse.Controllers.Api
{
    [Route("api/[controller]")]
    public class ProductsController : Controller {

        private const int _productsCount = 10;

        private IInnovativeProductRepository _productsRepository;

        public ProductsController(IInnovativeProductRepository repo) {
            _productsRepository = repo;
        }

        [HttpGet("{pattern}")]
        public object SearchProducts(string pattern){
            pattern = pattern.ToLower();

            return new {
                    Products = pattern == "all" ? 
                            _productsRepository.InnovativeProducts
                            .Select(p => new {id = p.InnovativeProductID, stage = Enum.GetName(typeof(DevelopmentStage), p.DevelopmentStage), cycle = Enum.GetName(typeof(ProductionCyclePlace), p.ProductionCyclePlace), name = p.productName})
                            .OrderByDescending(p => p.id)
                            :
                            _productsRepository.InnovativeProducts
                            .Where(n => n.productName.ToLower().Contains(pattern) || 
                                n.ProductionCyclePlace.ToString().ToLower().Contains(pattern) || 
                                n.Continuity.ToString().ToLower().Contains(pattern) || 
                                n.DevelopmentStage.ToString().ToLower().Contains(pattern) || 
                                n.MarketNoveltyDegree.ToString().ToLower().Contains(pattern) || 
                                n.MarketShare.ToString().ToLower().Contains(pattern) || 
                                n.NoveltyDegree.ToString().ToLower().Contains(pattern) || 
                                n.Prevalence.ToString().ToLower().Contains(pattern))
                            .Select(p => new {id = p.InnovativeProductID, stage = Enum.GetName(typeof(DevelopmentStage), p.DevelopmentStage), cycle = Enum.GetName(typeof(ProductionCyclePlace), p.ProductionCyclePlace), name = p.productName})
                            .OrderByDescending(p => p.id)
                };
        }
    }
}
