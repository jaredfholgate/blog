using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.UI.Models
{
  public class ArticleSummaryViewModel
  {
    public string Id { get; set; }
    public string Title { get; set; }
    public string ParsedSummary { get; set; }
    public string Author { get; set; }
    public string Tags { get; set; }
    public string Category { get; set; }
    public DateTime Date { get; set; }
    public bool Published { get; set; }
  }
}
