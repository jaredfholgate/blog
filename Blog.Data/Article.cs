using System;

namespace Blog.Data
{
    public class Article : IDocument
    {
        public Article()
        {
            ArticleType = Constants.DefaultDocumentType;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Tags { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public bool Published { get; set; }
        public string ArticleType { get; set; }
    }
}