namespace WebCourse.Models.ViewModels {
    public class ProductViewModel {
        public InnovativeProduct Product { get; set; }
        public User User { get; set; }
        public bool CanEdit { get; set; }
    }
}