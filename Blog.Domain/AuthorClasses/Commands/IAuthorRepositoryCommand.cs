using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.AuthorClasses;

namespace Blog.Domain.AuthorClasses.Commands
{
   public interface IAuthorRepositoryCommand : IDisposable
   {

       Task AddAuthor(Author author);
       void UpdateAuthor(Author author);
       void RemoveAuthor(Author author);

      // Task RemoveAuthorById(long authorId);

       Task Save();
   }
}
