using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Blog.UI.Models;
using Markdig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.UI.Controllers
{
  public class ArticleController : Controller
  {
    private readonly IDocumentDbRepository<Article> _repository;

    public ArticleController(IDocumentDbRepository<Article> repository)
    {
      _repository = repository;
    }

    [Route("Blog/{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> Read(string id)
    {
      var viewModel = new ArticleReadViewModel();
      var article = await _repository.GetItemAsync(id);
      viewModel.Article = article;
      viewModel.ParsedContent = Markdown.ToHtml(article.Content, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build()).Replace("<code class=\"language-", "<code class=\"line-numbers language-");
      return View("Index", viewModel);
    }
  }
}