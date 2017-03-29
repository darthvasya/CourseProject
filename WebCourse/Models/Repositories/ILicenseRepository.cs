using System.Collections.Generic;

namespace WebCourse.Models.Repositories
{
    public interface ILicenseRepository {
        IEnumerable<License> Licenses { get; }

        void SaveLicense(License model);

        License DeleteLicense(int id);
    }
}
