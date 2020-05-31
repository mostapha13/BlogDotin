using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domains.Authors.Commands
{
   public interface IAuthorRepositoryCommand : IDisposable
   {

       Task AddAuthor(Author author);
       void UpdateAuthor(Author author);
       Task RemoveAuthor(Author author);

      // Task RemoveAuthorById(long authorId);

       Task Save();

   }
}
