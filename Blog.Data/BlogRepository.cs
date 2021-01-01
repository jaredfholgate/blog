using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class BlogRepository: IDocumentDbRepository<Article>
    {        
        private readonly List<Article> _articles;


        public BlogRepository(List<Article> articles)
        {
            _articles = articles;
        }

        public async Task<Article> GetItemAsync(string id)
        {
            return new Article();
        }

        public async Task<IEnumerable<Article>> GetItemsAsync()
        {
            return new List<Article>();
        }
    }
}