﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Blog.Domains.Authors;
using Blog.Domains.Authors.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SqlConnection = System.Data.SqlClient.SqlConnection;

namespace Blog.DataAccessQueries.Authors.Repository
{
   public class AuthorRepositoryQuery: IAuthorRepositoryQuery
    {
        #region Constructor
        private readonly SqlConnection _context;

        public AuthorRepositoryQuery(IConfiguration configuration)
        {
            _context = new SqlConnection(configuration["ConnectionStrings:QueryConnection"]);
        }
        #endregion



        #region GetAllAuthor
        public async Task<IEnumerable<Author>> GetAllAuthor()
        {
            return await _context.QueryAsync<Author>("SELECT * FROM dbo.Authors where isDelete=0");
        }
        #endregion



        #region GetAuthorById

        public async Task<Author> GetAuthorById(long authorId)
        {
            return await _context.QuerySingleOrDefaultAsync<Author>("SELECT * FROM dbo.Authors where isDelete=0 and id=@authorId", new { @authorId =authorId});
        }

        #endregion



        #region IsEmailExist

        public async Task<bool> IsEmailExist(string email)
        {
            var user =await _context.QuerySingleOrDefaultAsync("SELECT * FROM dbo.Authors WHERE isDelete=0 and Email=@email", new{ @email =email.ToLower().Trim()});

            if (user!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion



        #region IsUserNameExist

        public async Task<bool> IsUserNameExist(string userName)
        {
            var user = await _context.QuerySingleOrDefaultAsync<int>("SELECT count(*) FROM dbo.Authors WHERE isDelete=0 and UserName=@userName", new{ @userName = userName .ToLower().Trim()});
            if (user>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region GetAllAuthorForCombobox

        public async Task<IEnumerable<Author>> GetAllAuthorForCombobox()
        {
            return await _context.QueryAsync<Author>("SELECT * FROM dbo.Authors where isDelete=0");
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
