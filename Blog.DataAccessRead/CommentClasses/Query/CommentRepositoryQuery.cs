using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.CommentClasses;
using Blog.Domain.CommentClasses.DTOs;
using Blog.Domain.CommentClasses.Query;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.DataAccessRead.CommentClasses.Query
{
    public class CommentRepositoryQuery : ICommentRepositoryQuery
    {
        #region Constructor
        private readonly SqlConnection _context;

        public CommentRepositoryQuery(IConfiguration configuration)
        {
            _context = new SqlConnection(configuration["ConnectionStrings:QueryConnection"]);
        } 
        #endregion



        #region GetAllComment
        public async Task<IEnumerable<Domain.CommentClasses.Comment>> GetAllComment()
        {
            return await _context.QueryAsync<Domain.CommentClasses.Comment>("SELECT * FROM dbo.Comments");
        }
        #endregion


        #region GetCommentById
        public async Task<Domain.CommentClasses.Comment> GetCommentById(long CommentId)
        {
            return await _context.QuerySingleOrDefaultAsync<Domain.CommentClasses.Comment>(@"SELECT * FROM dbo.Comments WHERE Id=@CommentId", new { CommentId });
        }
        #endregion

        #region GetAllCommentList

        public async Task<IEnumerable<CommentListDTO>> GetAllCommentList()
        {
            return await _context.QueryAsync<CommentListDTO>("EXEC GetAllCommentList");
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
