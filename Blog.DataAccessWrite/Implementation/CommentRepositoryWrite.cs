using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Context;
using Blog.Domain.Entites;
using Blog.Service.Write;

namespace Blog.DataAccessWrite.Implementation
{
    public class CommentRepositoryWrite : ICommentRepositoryWrite
    {
        #region Constructor
        private readonly BlogContext _context;

        public CommentRepositoryWrite(BlogContext context)
        {
            _context = context;
        } 
        #endregion


        #region AddComment

        public async Task AddComment(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        } 
        #endregion



        #region RemoveComment
        public void RemoveComment(Comment comment)
        {
            _context.Comments.Remove(comment);
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
