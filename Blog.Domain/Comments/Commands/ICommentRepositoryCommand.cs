using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domains.Comments.Commands
{
   public interface ICommentRepositoryCommand:IDisposable
   {
       Task AddComment(Comment comment);

       void UpdateComment(Comment comment);

      Task RemoveComment(Comment comment);

     // Task RemoveCommentById(long commentId);
      Task Save();
   }
}
