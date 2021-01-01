using Blog.Service;
using Blog.UI.Models;
using Markdig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.UI.Controllers
{
  public class ArticleController : Controller
  {
    private readonly IBlogService _service;

    public ArticleController(IBlogService service)
    {
      _service = service;
    }

    [Route("Blog/{id}")]
    [AllowAnonymous]
    public IActionResult Read(string id)
    {
      var viewModel = new ArticleReadViewModel();
      var article = _service.GetArticle(id);
      viewModel.Article = article;
      viewModel.ParsedContent = Markdown.ToHtml(article.Content, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build()).Replace("<code class=\"language-", "<code class=\"line-numbers language-");
      return View("Index", viewModel);
    }
  }
}