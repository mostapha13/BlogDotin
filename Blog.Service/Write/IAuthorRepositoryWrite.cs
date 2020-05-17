using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Entites;

namespace Blog.Service.Write
{
   public interface IAuthorRepositoryWrite:IDisposable
   {

       Task AddAuthor(Author author);
      // Task UpdateAuthor(Author author);
       void RemoveAuthor(Author author);
      // Task RemoveAuthorById(long authorId);

       Task Save();
   }
}
