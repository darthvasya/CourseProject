using System.Collections.Generic;
using System.Linq;

namespace WebCourse.Models.Repositories
{
    public class EFInnovativeProductRepository : IInnovativeProductRepository {
        private ApplicationDbContext context;

        public EFInnovativeProductRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IEnumerable<InnovativeProduct> InnovativeProducts => context.InnovativeProducts;

        public InnovativeProduct DeleteProduct(int prodID) {
            InnovativeProduct product = context.InnovativeProducts.Where(p => p.InnovativeProductID == prodID).SingleOrDefault();

            if(product != null) {
                Certificate[] certificates = context.Certificates.Where(c => c.InnovativeProductID == prodID).ToArray();
                context.Certificates.RemoveRange(certificates);
                context.InnovativeProducts.Remove(product);
                context.SaveChanges();
            }

            return product;
        }

        public InnovativeProduct SaveProduct(InnovativeProduct prod) {
            InnovativeProduct returnProd = null;
            if(prod.InnovativeProductID == 0) {
                context.InnovativeProducts.Add(prod);
            } else {
                 returnProd = context.InnovativeProducts.Where(p => p.InnovativeProductID == prod.InnovativeProductID).SingleOrDefault();
                if(returnProd != null) {
                    returnProd.Continuity = prod.Continuity;
                    returnProd.DevelopmentStage = prod.DevelopmentStage;
                    returnProd.MarketNoveltyDegree = prod.MarketNoveltyDegree;
                    returnProd.MarketShare = prod.MarketShare;
                    returnProd.NoveltyDegree = prod.NoveltyDegree;
                    returnProd.Prevalence = prod.Prevalence;
                    returnProd.ProductionCyclePlace = prod.ProductionCyclePlace;
                    returnProd.productName = prod.productName;
                    returnProd.Description = prod.Description;
                    returnProd.CreatorID = returnProd.CreatorID ?? prod.CreatorID;
                }
            }
            context.SaveChanges();
            if(returnProd == null){
                returnProd = context.InnovativeProducts.OrderByDescending(p => p.InnovativeProductID).First();
            }
            return returnProd;
        }
    }
}
