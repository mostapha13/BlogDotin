using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.PostClasses;
using Blog.Domain.PostClasses.DTOs;

namespace Blog.Domain.PostClasses.Query
{
   public interface IPostRepositoryQuery:IDisposable
   {

       Task<IEnumerable<Post>> GetAllPost();

       Task<IEnumerable<Post>> GetPostBySubjectId(long subjectId);

       Task<Post> GetPostById(long postId);

       Task<IEnumerable<PostList>> GetPostList();

   }
}
