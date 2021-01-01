using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data
{
  public interface IDocumentDbRepository<T> where T : class, IDocument
  {
    Task<T> GetItemAsync(string id);
    Task<IEnumerable<T>> GetItemsAsync();
  }
}
