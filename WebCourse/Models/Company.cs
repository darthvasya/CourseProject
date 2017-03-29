using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebCourse.Models {
    public class Company {

        public int CompanyID { get; set; }

        [Required(ErrorMessage = "Введите название предприятия")]
        [Display(Name = "Название:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите вебсайт предприятия")]
        [Display(Name = "Вебсайт:")]
        public string Website { get; set; }

        [Required(ErrorMessage = "Введите телефон предприятия")]
        [Display(Name = "Телефон:")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Введите электронную почту предприятия")]
        [Display(Name = "Электронная почта:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Выберите отрасль предприятия")]
        [Display(Name = "Отрасль предприятия:")]
        public Branch Branch { get; set; }

        [Required(ErrorMessage = "Выберите тип собственности предприятия")]
        [Display(Name = "Тип собственности:")]
        public PropertyType PropertyType { get; set; }

        [Required(ErrorMessage = "Введите город")]
        [Display(Name = "Город:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Введите адрес")]
        [Display(Name = "Адрес:")]
        public string Address { get; set; }

        public List<License> Licenses { get; set; }
        public string CreatorID { get; set; }
    }
}
