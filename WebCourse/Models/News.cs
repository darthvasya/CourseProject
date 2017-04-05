using System;
using System.ComponentModel.DataAnnotations;

namespace WebCourse.Models {
    public class News {

        public int NewsID { get; set; }

        [Display(Name = "Содержимое:")]
        [Required(ErrorMessage = "Введите содержимое новости")]
        public string Content { get; set; }

        [Display(Name = "Название:")]
        [Required(ErrorMessage = "Введите название новости")]
        public string Title { get; set; }

        [Display(Name = "Превью:")]
        [Required(ErrorMessage = "Введите превью")]
        public string Preview { get; set; }

        public DateTime PublicationDateTime { get; set; }

        public bool Published { get; set; }


    }
}
