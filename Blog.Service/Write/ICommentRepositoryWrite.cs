using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.CommentClasses;

namespace Blog.Service.Write
{
   public interface ICommentRepositoryWrite:IDisposable
   {
       Task AddComment(Comment comment);

      // Task UpdateComment(Comment comment);

      void RemoveComment(Comment comment);

     // Task RemoveCommentById(long commentId);
      Task Save();
   }
}
