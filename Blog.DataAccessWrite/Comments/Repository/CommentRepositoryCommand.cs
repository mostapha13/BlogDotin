using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.DataAccessCommands.Context;
using Blog.Domains.Comments;
using Blog.Domains.Comments.Commands;

namespace Blog.DataAccessCommands.Comments.Repository
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
        public async Task RemoveComment(Comment comment)
        {
            comment.IsDelete = true;
            UpdateComment(comment);
            
           await Save();

            // _context.Comments.Remove(comment);
        }
        #endregion


        #region UpdateComment

        public void UpdateComment(Comment comment)
        {
            _context.Comments.Update(comment);
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
