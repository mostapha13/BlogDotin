using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Blog.Domains.Posts.DTOs;

namespace Blog.Domains.Posts.Queries
{
   public interface IPostRepositoryQuery:IDisposable
   {

       Task<IEnumerable<Post>> GetAllPost();

       Task<IEnumerable<Post>> GetPostBySubjectId(long subjectId);

       Task<Post> GetPostById(long postId);

       Task<IEnumerable<PostListDTO>> GetPostList();

   }
}
