using System.Collections.Generic;

namespace WebCourse.Models.Repositories
{
    public interface IInnovativeProductRepository {
        IEnumerable<InnovativeProduct> InnovativeProducts { get; }

        void SaveProduct(InnovativeProduct prod);

        InnovativeProduct DeleteProduct(int prodID);
    }
}
