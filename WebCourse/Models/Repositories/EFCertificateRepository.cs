using System.Collections.Generic;
using System.Linq;

namespace WebCourse.Models.Repositories
{
    public class EFCertificateRepository : ICertificateRepository {
        private ApplicationDbContext context;

        public EFCertificateRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IEnumerable<Certificate> Certificates => context.Certificates;

        public Certificate DeleteCertificate(int id) {
            Certificate dbCertificate = context.Certificates.Where(c => c.CertificateID == id).SingleOrDefault();
            if(dbCertificate != null) {
                context.Certificates.Remove(dbCertificate);
                context.SaveChanges();
            }
            return dbCertificate;
        }

        public void SaveCertificate(Certificate model) {
            if(model.CertificateID == 0) {
                context.Certificates.Add(model);
            } else {
                Certificate dbCertificate = context.Certificates.Where(c => c.CertificateID == model.CertificateID).SingleOrDefault();
                if(dbCertificate != null) {
                    dbCertificate.CertificateNumber = model.CertificateNumber;
                    dbCertificate.CertificatingDate = model.CertificatingDate;
                    dbCertificate.Description = model.Description;
                    dbCertificate.WhoGave = model.WhoGave;
                }
            }
            context.SaveChanges();
        }
    }
}

