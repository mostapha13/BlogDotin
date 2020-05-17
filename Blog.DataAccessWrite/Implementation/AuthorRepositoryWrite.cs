using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Context;
using Blog.Domain.Entites;
using Blog.Service.Write;

namespace Blog.DataAccessWrite.Implementation
{

public class AuthorRepositoryWrite : IAuthorRepositoryWrite
{
        #region Constructor
        private readonly BlogContext _context;

        public AuthorRepositoryWrite(BlogContext context)
        {
            _context = context;
        } 
        #endregion


        #region AddAuthor
        public async Task AddAuthor(Author author)
        {
            await _context.Authors.AddAsync(author);
        }
        #endregion

         
        #region RemoveAuthor
        public void RemoveAuthor(Author author)
        {
              _context.Remove(author);
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
