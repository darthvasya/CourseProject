using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebCourse.Models.Repositories;
using WebCourse.Models;

namespace WebCourse.Controllers.Api
{
    [Route("api/[controller]")]
    public class NewsController : Controller {

        private const int _newsCount = 2;

        private INewsRepository _newsRepository;

        public NewsController(INewsRepository repo) {
            _newsRepository = repo;
        }

        [HttpGet("{page}")]
        public object Get(int page){
           return new {
                    News = _newsRepository.News
                            .Where(n => n.Published)
                            .OrderByDescending(n => n.PublicationDateTime)
                            .Skip((page - 1) * _newsCount)
                            .Take(_newsCount),
                    CurrentPage = page,
                    TotalItems = _newsRepository.News.Count(),
                    ItemsPerPage = _newsCount
                };
        }

        [HttpGet("SearchNews/{pattern}")]
        public object SearchNews(string pattern){
            pattern = pattern.ToLower();
           return new {
                    News = pattern == "all" ? 
                            _newsRepository.News
                            .OrderByDescending(n => n.PublicationDateTime)
                            :
                            _newsRepository.News
                            .Where(n => n.Title.ToLower().Contains(pattern))
                            .OrderByDescending(n => n.PublicationDateTime)
                };
        }

        [HttpGet("SingleNews/{id}")]
        public News GetSingleNews(int id){
            return _newsRepository.News.Where(n => n.NewsID == id).SingleOrDefault();
        }
    }
}
