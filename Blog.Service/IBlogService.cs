using Blog.Data;
using System.Collections.Generic;

namespace Blog.Service
{
  public interface IBlogService
    {
       IEnumerable<Article> GetArticles();
       Article GetArticle(string id);
    }
}
