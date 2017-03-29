using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebCourse.Models {
    public class InnovativeProduct {

        public int InnovativeProductID { get; set; }

        [Required(ErrorMessage = "Введите название продукта")]
        [Display(Name = "Название продукта:")]
        public string productName { get; set; }

        [Required(ErrorMessage = "Выберите стадию разработки продукта")]
        [Display(Name = "Стадия разработки:")]
        public DevelopmentStage DevelopmentStage { get; set; }

        [Required(ErrorMessage = "Выберите распространенность продукта")]
        [Display(Name = "Распространенность продукта:")]
        public Prevalence Prevalence { get; set; }

        [Required(ErrorMessage = "Выберите место в производственном цикле")]
        [Display(Name = "Место в производственном цикле:")]
        public ProductionCyclePlace ProductionCyclePlace { get; set; }

        [Required(ErrorMessage = "Выберите преемственность продукта")]
        [Display(Name = "Преемственность:")]
        public Continuity Continuity { get; set; }

        [Required(ErrorMessage = "Выберите ожидаемый охват доли рынка")]
        [Display(Name = "Ожидаемый охват доли рынка:")]
        public MarketShare MarketShare { get; set; }

        [Required(ErrorMessage = "Выберите степень новизны/инновационный потенциал")]
        [Display(Name = "Степень новизны/инновационный потенциал:")]
        public NoveltyDegree NoveltyDegree { get; set; }

        [Required(ErrorMessage = "Выберите степень новизны для рынка")]
        [Display(Name = "Степень новизны для рынка:")]
        public MarketNoveltyDegree MarketNoveltyDegree { get; set; }

        [Display(Name = "Описание продукта:")]
        public string Description { get; set; }

        public List<Certificate> Certificates { get; set; }

        public string CreatorID { get; set; }
    }
}
