using Blog.Domain.Entites;
using Blog.Service.Write;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Context;

namespace Blog.DataAccessWrite.Implementation
{
    public class PostRepositoryWrite : IPostRepositoryWrite
    {
        #region Constructor
        private readonly BlogContext _context;

        public PostRepositoryWrite(BlogContext context)
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
        public void RemovePost(Post post)
        {
            _context.Remove(post);
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
