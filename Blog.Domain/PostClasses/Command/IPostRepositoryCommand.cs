using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.PostClasses;

namespace Blog.Domain.PostClasses.Command
{
    public interface IPostRepositoryCommand:IDisposable
    {
        Task AddPost(Post post);
        //  Task UpdatePost(Post post);
        void RemovePost(Post post);
      //  Task RemovePostById(long postId);

        Task Save();
    }
}
