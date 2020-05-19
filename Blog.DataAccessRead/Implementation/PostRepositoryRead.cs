using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    public class PostRepositoryRead : IPostRepositoryRead
    {

        #region Constructor
        private readonly SqlConnection _context;

        public PostRepositoryRead(IConfiguration configuration)
        {
            _context = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        }

        #endregion



        #region GetAllPost

        public async Task<IEnumerable<Post>> GetAllPost()
        {
            return await _context.QueryAsync<Post>(@"SELECT * FROM dbo.Posts");
        }

        #endregion


        #region GetPostById
        public async Task<Post> GetPostById(long postId)
        {
            return await _context.QuerySingleOrDefaultAsync<Post>(@"SELECT * FROM dbo.Posts WHERE id=@postId",new{postId});
        }
        #endregion

        #region GetPostBySubjectId
        public async Task<IEnumerable<Post>> GetPostBySubjectId(long subjectId)
        {
            return await _context.QueryAsync<Post>("SELECT * FROM dbo.Posts WHERE SubjectId=@subjectId",new { subjectId});
        }
        #endregion


        #region GetPostList

        public async Task<IEnumerable<PostListViewModel>> GetPostList()
        {
            return await _context.QueryAsync<PostListViewModel>("EXEC GetAllPostList");
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
