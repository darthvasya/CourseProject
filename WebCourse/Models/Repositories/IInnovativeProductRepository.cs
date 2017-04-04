using System.Collections.Generic;

namespace WebCourse.Models.Repositories
{
    public interface IInnovativeProductRepository {
        IEnumerable<InnovativeProduct> InnovativeProducts { get; }

        InnovativeProduct SaveProduct(InnovativeProduct prod);

        InnovativeProduct DeleteProduct(int prodID);
    }
}
