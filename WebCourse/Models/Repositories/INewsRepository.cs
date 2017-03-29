using System.Collections.Generic;

namespace WebCourse.Models.Repositories {
    public interface INewsRepository {
        IEnumerable<News> News { get; }
        void SaveNews(News news);
    }
}
