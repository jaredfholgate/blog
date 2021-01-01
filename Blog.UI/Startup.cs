using Blog.Data;
using Blog.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Blog.UI
{
  public class Startup
  {
    private readonly IWebHostEnvironment _env;

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
      Configuration = configuration;
      _env = env;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddTransient<IBlogService, BlogService>();
      var articlesPath = Path.Combine(_env.WebRootPath, "articles");
      var articleFiles = Directory.GetFiles(articlesPath,"*.json");
      var articles = new List<Article>();
      foreach(var articleFile in articleFiles)
      {
        var json = File.ReadAllText(articleFile);
        try
        {
          var article = JsonConvert.DeserializeObject<Article>(json);
          if(string.IsNullOrWhiteSpace(article.Content))
          {
            article.Content = File.ReadAllText(articleFile.Replace("json", "md"));
          }
          articles.Add(article);
        }
        catch { }
      }
      
      services.AddSingleton<IBlogRepository>(new BlogRepository(articles));
      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
          app.UseDeveloperExceptionPage();
      }
      else
      {
          app.UseExceptionHandler("/Home/Error");
          //app.UseHsts();
      }
      app.UseHttpsRedirection();
      app.UseStaticFiles(new StaticFileOptions
      {
        OnPrepareResponse = ctx =>
        {
          const int durationInSeconds = 60 * 60 * 24 * 31;
          ctx.Context.Response.Headers[HeaderNames.CacheControl] =
            "public,max-age=" + durationInSeconds;
        }
      });
      app.UseStaticFiles(new StaticFileOptions
      {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @".well-known")),
        RequestPath = new PathString("/.well-known"),
        ServeUnknownFileTypes = true
      });

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
          endpoints.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
