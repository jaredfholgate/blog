﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class BlogRepository: IBlogRepository
    {        
        private readonly List<Article> _articles;


        public BlogRepository(List<Article> articles)
        {
            _articles = articles;
        }

        public Article GetArticle(string id)
        {
           return _articles.Single(o => o.Id == id || o.UrlTitle == id);
        }

        public IEnumerable<Article> GetArticles()
        {
          return _articles;
        }
    }
}