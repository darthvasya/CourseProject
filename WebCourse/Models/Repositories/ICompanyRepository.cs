using System.Collections.Generic;

namespace WebCourse.Models.Repositories
{
    public interface ICompanyRepository {
        IEnumerable<Company> Companies { get; }

        void SaveCompany(Company company);

        Company DeleteCompany(int companyID);
    }
}
