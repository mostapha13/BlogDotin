using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Entites;
using Blog.Service.DTOs;

namespace Blog.Service.Read
{
   public interface ICommentRepositoryRead:IDisposable
   {
       Task<IEnumerable<Comment>> GetAllComment();

       Task<Comment> GetCommentById(long CommentId);
       Task<IEnumerable<CommentListViewModel>> GetAllCommentList();

   }
}
