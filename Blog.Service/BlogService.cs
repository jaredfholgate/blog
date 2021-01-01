using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Data;

namespace Blog.Service
{
    public class BlogService : IBlogService
    {
      private readonly IDocumentDbRepository<Article> _blogRepository;

      public BlogService(IDocumentDbRepository<Article> blogRepository)
      {
        _blogRepository = blogRepository;
      }

      public async Task<IEnumerable<Article>> GetArticles()
      {
        return await _blogRepository.GetItemsAsync();
      }
    }
}
