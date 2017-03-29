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

        public void SaveProduct(InnovativeProduct prod) {
            if(prod.InnovativeProductID == 0) {
                context.InnovativeProducts.Add(prod);
            } else {
                InnovativeProduct dbProduct = context.InnovativeProducts.Where(p => p.InnovativeProductID == prod.InnovativeProductID).SingleOrDefault();
                if(dbProduct != null) {
                    dbProduct.Continuity = prod.Continuity;
                    dbProduct.DevelopmentStage = prod.DevelopmentStage;
                    dbProduct.MarketNoveltyDegree = prod.MarketNoveltyDegree;
                    dbProduct.MarketShare = prod.MarketShare;
                    dbProduct.NoveltyDegree = prod.NoveltyDegree;
                    dbProduct.Prevalence = prod.Prevalence;
                    dbProduct.ProductionCyclePlace = prod.ProductionCyclePlace;
                    dbProduct.productName = prod.productName;
                    dbProduct.Description = prod.Description;
                    dbProduct.CreatorID = dbProduct.CreatorID ?? prod.CreatorID;
                }
            }
            context.SaveChanges();
        }
    }
}
