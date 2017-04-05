using System.Collections.Generic;
using System;
using System.Linq;

namespace WebCourse.Models.Repositories {
    public class EFNewsRepository : INewsRepository {
        private ApplicationDbContext context;

        public EFNewsRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IEnumerable<News> News => context.News;

        public void SaveNews(News news) {
            if(news.NewsID == 0) {
                news.PublicationDateTime = DateTime.UtcNow.AddHours(3);
                context.News.Add(news);
            } else {
                News dbNews = context.News.Where(n => n.NewsID == news.NewsID).FirstOrDefault();
                if(dbNews != null) {
                    dbNews.Content = news.Content;
                    dbNews.Title = news.Title;
                    dbNews.Preview = news.Preview;
                }
            }
            context.SaveChanges();
        }

        public News DeleteNews(int id){
            News dbNews = context.News.FirstOrDefault(n => n.NewsID == id);

            if(dbNews != null){
                context.News.Remove(dbNews);
                return dbNews;
            }

            return null;
        }
    }
}
