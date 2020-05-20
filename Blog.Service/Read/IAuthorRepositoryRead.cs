using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.AuthorClasses;

namespace Blog.Service.Read
{
  public interface IAuthorRepositoryRead:IDisposable
  {
      Task<IEnumerable<Author>> GetAllAuthor();

      Task<Author> GetAuthorById(long authorId);

      Task<bool> IsEmailExist(string email);

      Task<bool> IsUserNameExist(string userName);

      Task<IEnumerable<Author>> GetAllAuthorForCombobox();

  }
}
