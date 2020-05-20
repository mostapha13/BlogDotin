using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.DataAccessCommand.Context;
using Blog.Domain.AuthorClasses;
using Blog.Domain.AuthorClasses.Command;

namespace Blog.DataAccessCommand.AuthorClasses.Command
{

    public class AuthorRepositoryCommand : IAuthorRepositoryCommand
    {
        #region Constructor
        private readonly BlogContext _context;

        public AuthorRepositoryCommand(BlogContext context)
        {
            _context = context;
        }
        #endregion


        #region AddAuthor
        public async Task AddAuthor(Author author)
        {
            author.CreateDate = DateTime.Now;
            author.UpdateDate = author.CreateDate;

            await _context.Authors.AddAsync(author);
        }
        #endregion


        #region RemoveAuthor
        public void RemoveAuthor(Author author)
        {
            _context.Remove(author);
        }
        #endregion

        #region UpdateAuthor

        public void  UpdateAuthor(Author author)
        {
             _context.Authors.Update(author);
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
