using System.Collections.Generic;
using System.Linq;

namespace WebCourse.Models.Repositories
{
    public class EFCompanyRepository : ICompanyRepository {

        private ApplicationDbContext context;

        public EFCompanyRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IEnumerable<Company> Companies => context.Companies;

        public Company DeleteCompany(int companyID) {
            Company dbCompany = context.Companies.Where(c => c.CompanyID == companyID).SingleOrDefault();
            if(dbCompany != null) {
                License[] licenses = context.Licenses.Where(l => l.CompanyID == companyID).ToArray();
                context.Licenses.RemoveRange(licenses);
                context.Companies.Remove(dbCompany);
                context.SaveChanges();
            }
            return dbCompany;
        }

        public void SaveCompany(Company company) {
            if(company.CompanyID == 0) {
                context.Companies.Add(company);
            } else {
                Company dbCompany = context.Companies.Where(c => c.CompanyID == company.CompanyID).SingleOrDefault();
                if(dbCompany != null) {
                    dbCompany.Address = company.Address;
                    dbCompany.Branch = company.Branch;
                    dbCompany.City = company.City;
                    dbCompany.CreatorID = dbCompany.CreatorID ?? company.CreatorID;
                    dbCompany.Email = company.Email;
                    dbCompany.Name = company.Name;
                    dbCompany.Phone = company.Phone;
                    dbCompany.PropertyType = company.PropertyType;
                    dbCompany.Website = company.Website;
                }
            }
            context.SaveChanges();
        }
    }
}
