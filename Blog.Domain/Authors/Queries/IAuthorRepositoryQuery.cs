using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domains.Authors.Queries
{
  public interface IAuthorRepositoryQuery:IDisposable
  {
      Task<IEnumerable<Author>> GetAllAuthor();

      Task<Author> GetAuthorById(long authorId);

      Task<bool> IsEmailExist(string email);

      Task<bool> IsUserNameExist(string userName);

      Task<IEnumerable<Author>> GetAllAuthorForCombobox();

  }
}
