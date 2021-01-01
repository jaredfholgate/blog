using Blog.Data;
using System.Collections.Generic;

namespace Blog.Service
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
          _blogRepository = blogRepository;
        }

        public IEnumerable<Article> GetArticles()
        {
          return _blogRepository.GetArticles();
        }

        public Article GetArticle(string id)
        {
          return _blogRepository.GetArticle(id);
        }
    }
}
