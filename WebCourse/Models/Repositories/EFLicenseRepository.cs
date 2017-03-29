using System.Collections.Generic;
using System.Linq;

namespace WebCourse.Models.Repositories
{
    public class EFLicenseRepository : ILicenseRepository {
        private ApplicationDbContext context;

        public EFLicenseRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IEnumerable<License> Licenses => context.Licenses;

        public License DeleteLicense(int id) {
            License dbLicense = context.Licenses.Where(l => l.LicenseID == id).SingleOrDefault();

            if(dbLicense != null) {
                context.Licenses.Remove(dbLicense);
                context.SaveChanges();
            }
            return dbLicense;
        }

        public void SaveLicense(License model) {
            if(model.LicenseID == 0) {
                context.Licenses.Add(model);
            } else {
                License dbLicense = context.Licenses.Where(l => l.LicenseID == model.LicenseID).SingleOrDefault();
                if(dbLicense != null) {
                    dbLicense.Description = model.Description;
                    dbLicense.LicenseNumber = model.LicenseNumber;
                    dbLicense.LicensingDate = model.LicensingDate;
                    dbLicense.WhoGave = model.WhoGave;
                }
            }

            context.SaveChanges();
        }
    }
}
