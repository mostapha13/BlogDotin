using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.PostClasses;
using Blog.Service.DTOs;

namespace Blog.Service.Read
{
   public interface IPostRepositoryRead:IDisposable
   {

       Task<IEnumerable<Post>> GetAllPost();

       Task<IEnumerable<Post>> GetPostBySubjectId(long subjectId);

       Task<Post> GetPostById(long postId);

       Task<IEnumerable<PostListViewModel>> GetPostList();

   }
}
