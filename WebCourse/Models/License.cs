using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCourse.Models {
    public class License {

        public int LicenseID { get; set; }

        [Required(ErrorMessage = "Выберите дату выдачи лицензии")]
        [Display(Name = "Дата выдачи лицензии:")]
        public DateTime LicensingDate { get; set; }

        [Required(ErrorMessage = "Введите описание лицензии")]
        [Display(Name = "Описание лицензии:")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите кем была выдана лицензия")]
        [Display(Name = "Кем выдана:")]
        public string WhoGave { get; set; }

        [Required(ErrorMessage = "Введите номер лицензии")]
        [Display(Name = "Номер лицензии:")]
        public string LicenseNumber { get; set; }

        [ForeignKey("CompanyId")]
        public int CompanyID { get; set; }

        public string CreatorID { get; set; }
    }
}
