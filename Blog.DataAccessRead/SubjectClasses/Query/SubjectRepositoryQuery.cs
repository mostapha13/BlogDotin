using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.SubjectClasses;
using Blog.Domain.SubjectClasses.DTOs;
using Blog.Domain.SubjectClasses.Query;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.DataAccessRead.SubjectClasses.Query
{
    public class SubjectRepositoryQuery : ISubjectRepositoryQuery
    {
        #region Constructor
        private readonly SqlConnection _context;

        public SubjectRepositoryQuery(IConfiguration configuration)
        {
            _context = new SqlConnection(configuration["ConnectionStrings:QueryConnection"]);
        }

        #endregion


        #region GetAllSubject
        public async Task<IEnumerable<Domain.SubjectClasses.Subject>> GetAllSubject()
        {
            return await _context.QueryAsync<Domain.SubjectClasses.Subject>(
                @"SELECT Subjects.*,
                    (SELECT COUNT(*) FROM dbo.Posts
                    WHERE dbo.Posts.SubjectId=dbo.Subjects.id) AS CntPost
                    FROM dbo.Subjects");
        }
        #endregion

        #region GetAllSubjectPost


        public async Task<IEnumerable<AllSubject>> GetAllSubjectPost(long subjectId=1)
        {

            return await _context.QueryAsync<AllSubject>("EXEC GetAllSubjectPost @subjectId",new{ @subjectId = subjectId });
        }

        #endregion

        #region GetSubjectById
        public async Task<Domain.SubjectClasses.Subject> GetSubjectById(int subjectId)
      {
          return await _context.QuerySingleOrDefaultAsync<Domain.SubjectClasses.Subject>("SELECT * FROM dbo.Subjects WHERE id=@subjectId",new{ subjectId = subjectId });

      }


        #endregion


        #region GetSubjectForComboBox

        public async Task<IEnumerable<Domain.SubjectClasses.Subject>> GetSubjectForComboBox()
        {
            return await _context.QueryAsync<Domain.SubjectClasses.Subject>("SELECT * FROM dbo.Subjects");
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
