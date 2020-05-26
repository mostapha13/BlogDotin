using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.PostClasses;
using Blog.Domain.PostClasses.DTOs;
using Blog.Domain.PostClasses.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.DataAccessQuery.PostClasses.Repository
{
    public class PostRepositoryQuery : IPostRepositoryQuery
    {

        #region Constructor
        private readonly SqlConnection _context;

        public PostRepositoryQuery(IConfiguration configuration)
        {
            _context = new SqlConnection(configuration["ConnectionStrings:QueryConnection"]);
        }

        #endregion



        #region GetAllPost

        public async Task<IEnumerable<Domain.PostClasses.Post>> GetAllPost()
        {
            return await _context.QueryAsync<Domain.PostClasses.Post>(@"SELECT * FROM dbo.Posts WHERE isDelete=0");
        }

        #endregion


        #region GetPostById
        public async Task<Domain.PostClasses.Post> GetPostById(long postId)
        {
            return await _context.QuerySingleOrDefaultAsync<Domain.PostClasses.Post>(@"SELECT * FROM dbo.Posts WHERE isDelete=0 AND id=@postId", new{ postId });
        }
        #endregion

        #region GetPostBySubjectId
        public async Task<IEnumerable<Domain.PostClasses.Post>> GetPostBySubjectId(long subjectId)
        {
            return await _context.QueryAsync<Domain.PostClasses.Post>("SELECT * FROM dbo.Posts WHERE isDelete=0 AND SubjectId=@subjectId", new { subjectId});
        }
        #endregion


        #region GetPostList

        public async Task<IEnumerable<PostListDTO>> GetPostList()
        {
            return await _context.QueryAsync<PostListDTO>("EXEC GetAllPostList");
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
