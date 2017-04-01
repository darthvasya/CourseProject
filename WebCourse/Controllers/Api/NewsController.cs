using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebCourse.Models.Repositories;

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
                            .OrderBy(n => n.PublicationDateTime)
                            .Reverse()
                            .Skip((page - 1) * _newsCount)
                            .Take(_newsCount),
                    CurrentPage = page,
                    TotalItems = _newsRepository.News.Count(),
                    ItemsPerPage = _newsCount
                };
        }
    }
}
