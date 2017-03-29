using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCourse.Models {
    public class Certificate {

        public int CertificateID { get; set; }

        [Required(ErrorMessage = "Выберите дату выдачи сертификата")]
        [Display(Name = "Дата выдачи сертификата:")]
        public DateTime CertificatingDate { get; set; }

        [Display(Name = "Описание сертификата:")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите кем была выдан сертификат")]
        [Display(Name = "Кем выдан:")]
        public string WhoGave { get; set; }

        [Required(ErrorMessage = "Введите номер сертификата")]
        [Display(Name = "Номер сертификата:")]
        public string CertificateNumber { get; set; }

        [ForeignKey("InnovativeProductId")]
        public int InnovativeProductID { get; set; }

        public string CreatorID { get; set; }
    }
}
