using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.DataAccessCommand.Context;
using Blog.Domain.PostClasses;
using Blog.Domain.PostClasses.Commands;

namespace Blog.DataAccessCommand.PostClasses.Repository
{
    public class PostRepositoryCommand : IPostRepositoryCommand
    {
        #region Constructor
        private readonly BlogContext _context;

        public PostRepositoryCommand(BlogContext context)
        {
            _context = context;
        } 
        #endregion

        #region AddPost

        public async Task AddPost(Post post)
        {
            post.CreateDate=DateTime.Now;
            post.UpdateDate = post.CreateDate;
            await _context.Posts.AddAsync(post);
        }

        #endregion


        #region RemovePost
        public async Task RemovePost(Post post)
        {
            post.IsDelete = true;
            UpdatePost(post);
           await Save();

            // _context.Remove(post);
        }

        #endregion

        #region UpdatePost

        public void UpdatePost(Post post)
        {
             _context.Posts.Update(post);
        }

        #endregion

        #region Save
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        #endregion


        #region Dispose
        public void Dispose()
        {
            _context?.Dispose();
        } 
        #endregion
    }
}
