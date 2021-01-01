using Blog.Data;

namespace Blog.UI.Models
{
  public class ArticleReadViewModel
  {
    public Article Article { get; set; }
    public string ParsedContent { get; set; }
  }
}