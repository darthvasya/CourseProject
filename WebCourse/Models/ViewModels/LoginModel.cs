using System.ComponentModel.DataAnnotations;

namespace WebCourse.Models.ViewModels {
    public class LoginModel {

        [Required(ErrorMessage = "Введите свой email")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль:")]
        [UIHint("Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
