using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.DataAccessCommand.Context;
using Blog.Domain.CommentClasses;
using Blog.Domain.CommentClasses.Commands;

namespace Blog.DataAccessCommand.CommentClasses.Repository
{
    public class CommentRepositoryCommand : ICommentRepositoryCommand
    {
        #region Constructor
        private readonly BlogContext _context;

        public CommentRepositoryCommand(BlogContext context)
        {
            _context = context;
        } 
        #endregion


        #region AddComment

        public async Task AddComment(Comment comment)
        {
            comment.CreateDate=DateTime.Now;
            comment.UpdateDate = comment.CreateDate;
            await _context.Comments.AddAsync(comment);
        } 
        #endregion



        #region RemoveComment
        public void RemoveComment(Comment comment)
        {
            comment.IsDelete = true;
            
            Save();

            // _context.Comments.Remove(comment);
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
