using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using Blog.Data;
using Blog.Service;
using Blog.UI.Models;
using Markdig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.UI.Controllers
{
  public class HomeController : Controller
  {
    private readonly IBlogService _blogService;

    public HomeController(IBlogService blogService)
    {
      _blogService = blogService;
    }

    public IActionResult Index()
    {
      var articles = _blogService.GetArticles();
      var articleSummary = GetArticleSummaryViewModel(articles);
      return View(articleSummary);
    }

    [Route("rss")]
    [ResponseCache(Duration = 1200)]
    [HttpGet]
    public IActionResult Rss()
    {
      var url = Url.Action("Index", "Home");
      var feed = new SyndicationFeed("Jared Holgate Blog", "Jared Holgate's Blog Articles.", new Uri(url,UriKind.Relative), "RSSUrl", DateTime.Now)
      {
        Copyright = new TextSyndicationContent($"{DateTime.Now.Year} Jared Holgate")
      };

      var items = new List<SyndicationItem>();
      var postings = _blogService.GetArticles();
      foreach (var item in postings)
      {
        var postUrl = Url.Action("Read", "Article", new { id = item.UrlTitle }, HttpContext.Request.Scheme);
        var title = item.Title;
        var description = item.Summary;
        items.Add(new SyndicationItem(title, description, new Uri(postUrl), item.UrlTitle, item.Date));
      }
      feed.Items = items;
      var settings = new XmlWriterSettings
      {
        Encoding = Encoding.UTF8,
        NewLineHandling = NewLineHandling.Entitize,
        NewLineOnAttributes = true,
        Indent = true        
      };
      using var stream = new MemoryStream();
      using (var xmlWriter = XmlWriter.Create(stream, settings))
      {
        var rssFormatter = new Rss20FeedFormatter(feed, false);
        rssFormatter.WriteTo(xmlWriter);
        xmlWriter.Flush();
      }
      return File(stream.ToArray(), "application/rss+xml; charset=utf-8");
    }

    private static List<ArticleSummaryViewModel> GetArticleSummaryViewModel(IEnumerable<Article> articles)
    {
      var articleSummary = new List<ArticleSummaryViewModel>();
      articleSummary.AddRange(articles.OrderByDescending(o => o.Date).ThenByDescending(o => o.Id).Select(o => new ArticleSummaryViewModel
      {
        Id = o.Id,
        Author = o.Author,
        ParsedSummary = Markdown.ToHtml(o.Summary ?? string.Empty, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build()),
        Title = o.Title,
        Date = o.Date,
        Category = o.Category,
        Tags = o.Tags,
        Published = o.Published,
        UrlTitle = o.UrlTitle
      }));
      return articleSummary;
    }

    [AllowAnonymous]
    [Route("AboutMe")]
    public IActionResult About()
    {
      return View();
    }

    [AllowAnonymous]
    public IActionResult Error()
    {
      return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }

    [AllowAnonymous]
    [Route("sitemap.xml")]
    public IActionResult SiteMapXml()
    {
      var siteMapTemplate = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<urlset
      xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9""
      xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
      xsi:schemaLocation=""http://www.sitemaps.org/schemas/sitemap/0.9
            http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd"">
<url>
  <loc>https://www.jaredholgate.co.uk/</loc>
  <changefreq>daily</changefreq>
  <priority>1.00</priority>
</url>
<url>
  <loc>https://www.jaredholgate.co.uk/AboutMe</loc>
  <changefreq>daily</changefreq>
  <priority>0.90</priority>
</url>
<url>
  <loc>https://www.jaredholgate.co.uk/rss</loc>
  <changefreq>daily</changefreq>
  <priority>0.90</priority>
</url>
{0}
</urlset>";


      var articles = _blogService.GetArticles();
      var articleNodes = articles.Select(o => $@"<url>
  <loc>https://www.jaredholgate.co.uk/Blog/{o.UrlTitle}</loc>
  <changefreq>daily</changefreq>
  <priority>0.80</priority>
</url>");

      var allArticleNdes = string.Join(Environment.NewLine, articleNodes);
      var xml = string.Format(siteMapTemplate, allArticleNdes);
      return Content(xml, "application/xml", Encoding.UTF8);
    }
  }
}