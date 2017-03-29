using System.Collections.Generic;

namespace WebCourse.Models.Repositories
{
    public interface ICertificateRepository {
        IEnumerable<Certificate> Certificates { get; }

        void SaveCertificate(Certificate model);

        Certificate DeleteCertificate(int id);
    }
}
