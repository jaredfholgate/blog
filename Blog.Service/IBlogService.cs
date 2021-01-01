using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Data;

namespace Blog.Service
{
    public interface IBlogService
    {
       Task<IEnumerable<Article>> GetArticles();
    }
}
