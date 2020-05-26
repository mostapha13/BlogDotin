using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.CommentClasses;

namespace Blog.Domain.CommentClasses.Commands
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
