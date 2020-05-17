using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Context;
using Blog.Domain.Entites;
using Blog.Service.Read;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.DataAccessRead.Implementation
{
   public class AuthorRepositoryRead: IAuthorRepositoryRead
    {
        #region Constructor
        private SqlConnection _context;

        public AuthorRepositoryRead(IConfiguration configuration)
        {
            _context = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        }
        #endregion



        #region GetAllAuthor
        public async Task<IEnumerable<Author>> GetAllAuthor()
        {
            return await _context.QueryAsync<Author>("SELECT * FROM dbo.Authors");
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
