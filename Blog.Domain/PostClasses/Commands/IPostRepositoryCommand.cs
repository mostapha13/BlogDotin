using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.PostClasses;

namespace Blog.Domain.PostClasses.Commands
{
    public interface IPostRepositoryCommand : IDisposable
    {
        Task AddPost(Post post);
        void UpdatePost(Post post);
        Task RemovePost(Post post);
        //  Task RemovePostById(long postId);

        Task Save();
    }
}
