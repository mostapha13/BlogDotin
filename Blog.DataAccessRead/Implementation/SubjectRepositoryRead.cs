using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Context;
using Blog.Domain.Entites;
using Blog.Service.DTOs;
using Blog.Service.Read;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.DataAccessRead.Implementation
{
    public class SubjectRepositoryRead : ISubjectRepositoryRead
    {
        #region Constructor
        private SqlConnection _context;

        public SubjectRepositoryRead(IConfiguration configuration)
        {
            _context = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        }

        #endregion


        #region GetAllSubject
        public async Task<IEnumerable<Subject>> GetAllSubject()
        {
            return await _context.QueryAsync<Subject>(
                @"SELECT Subjects.*,
                    (SELECT COUNT(*) FROM dbo.Posts
                    WHERE dbo.Posts.SubjectId=dbo.Subjects.id) AS CntPost
                    FROM dbo.Subjects");
        }
        #endregion

        #region GetAllSubjectPost


        public async Task<IEnumerable<AllSubjectPostViewModel>> GetAllSubjectPost(long subjectId=1)
        {

            return await _context.QueryAsync<AllSubjectPostViewModel>("EXEC GetAllSubjectPost @subjectId",new{ @subjectId = subjectId });
        }

        #endregion

        #region GetSubjectById
        public async Task<Subject> GetSubjectById(int subjectId)
      {
          return await _context.QuerySingleOrDefaultAsync<Subject>("SELECT * FROM dbo.Subjects WHERE id=@subjectId",new{ @subjectId =subjectId});

      }


        #endregion


        #region GetSubjectForComboBox

        public async Task<IEnumerable<Subject>> GetSubjectForComboBox()
        {
            return await _context.QueryAsync<Subject>("SELECT * FROM dbo.Subjects");
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
