using System.Collections.Generic;

namespace Blog.Data
{
  public interface IBlogRepository
  {
    Article GetArticle(string id);
    IEnumerable<Article> GetArticles();
  }
}
