using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domains.Comments.DTOs;

namespace Blog.Domains.Comments.Queries
{
   public interface ICommentRepositoryQuery:IDisposable
   {
       Task<IEnumerable<Comment>> GetAllComment();

       Task<Comment> GetCommentById(long CommentId);
       Task<IEnumerable<CommentListDTO>> GetAllCommentList();

   }
}
