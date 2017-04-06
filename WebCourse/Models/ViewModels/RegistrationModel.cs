
using System.ComponentModel.DataAnnotations;

namespace WebCourse.Models.ViewModels{
    public class RegistrationModel{
        
        [Required(ErrorMessage = "Введите свое имя")]
        [Display(Name = "Имя:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите UserName")]
        [Display(Name = "UserName:")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Введите свою электронную почту")]
        [Display(Name = "Email:")]
        [EmailAddress(ErrorMessage = "Введите действительный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль:")]
        [UIHint("Password")]
        public string Pass1 { get; set; }

        [Required(ErrorMessage = "Введите пароль еще раз")]
        [Display(Name = "Подтвердите пароль:")]
        [UIHint("Password")]
        public string Pass2 { get; set; }

    }
}