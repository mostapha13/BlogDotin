using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Context;
using Blog.Domain.Entites;
using Blog.Service.DTOs;
using Blog.Service.Read;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.DataAccessRead.Implementation
{
    public class CommentRepositoryRead : ICommentRepositoryRead
    {
        #region Constructor
        private readonly SqlConnection _context;

        public CommentRepositoryRead(IConfiguration configuration)
        {
            _context = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        } 
        #endregion



        #region GetAllComment
        public async Task<IEnumerable<Comment>> GetAllComment()
        {
            return await _context.QueryAsync<Comment>("SELECT * FROM dbo.Comments");
        }
        #endregion


        #region GetCommentById
        public async Task<Comment> GetCommentById(long CommentId)
        {
            return await _context.QuerySingleOrDefaultAsync<Comment>(@"SELECT * FROM dbo.Comments WHERE Id=@CommentId", new { CommentId });
        }
        #endregion

        #region GetAllCommentList

        public async Task<IEnumerable<CommentListViewModel>> GetAllCommentList()
        {
            return await _context.QueryAsync<CommentListViewModel>("EXEC GetAllCommentList");
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
