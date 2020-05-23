using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.CommentClasses;
using Blog.Domain.CommentClasses.DTOs;

namespace Blog.Domain.CommentClasses.Queries
{
   public interface ICommentRepositoryQuery:IDisposable
   {
       Task<IEnumerable<Comment>> GetAllComment();

       Task<Comment> GetCommentById(long CommentId);
       Task<IEnumerable<CommentListDTO>> GetAllCommentList();

   }
}
