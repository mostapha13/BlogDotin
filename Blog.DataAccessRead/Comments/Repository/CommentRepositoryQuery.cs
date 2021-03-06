﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Blog.Domains.Comments;
using Blog.Domains.Comments.DTOs;
using Blog.Domains.Comments.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SqlConnection = System.Data.SqlClient.SqlConnection;

namespace Blog.DataAccessQueries.Comments.Repository
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
        public async Task<IEnumerable<Comment>> GetAllComment()
        {
            return await _context.QueryAsync<Comment>("SELECT * FROM dbo.Comments WHERE isDelete=0");
        }
        #endregion


        #region GetCommentById
        public async Task<Comment> GetCommentById(long CommentId)
        {
            return await _context.QuerySingleOrDefaultAsync<Comment>(@"SELECT * FROM dbo.Comments WHERE  isDelete=0 AND Id=@CommentId", new { CommentId });
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
