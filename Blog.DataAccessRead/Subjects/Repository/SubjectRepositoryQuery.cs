using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Blog.Domains.Subjects;
using Blog.Domains.Subjects.DTOs;
using Blog.Domains.Subjects.Queries;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;

namespace Blog.DataAccessQueries.Subjects.Repository
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
        public async Task<IEnumerable<Subject>> GetAllSubject()
        {
            return await _context.QueryAsync<Subject>(
                @"SELECT Subjects.*,
                    (SELECT COUNT(*) FROM dbo.Posts  WHERE IsDelete=0
                    AND dbo.Posts.SubjectId=dbo.Subjects.id) AS CntPost
                    FROM dbo.Subjects  WHERE IsDelete=0 ");
        }
        #endregion

        #region GetAllSubjectPost


        public async Task<IEnumerable<AllSubjectDTO>> GetAllSubjectPost(long subjectId=1)
        {

            return await _context.QueryAsync<AllSubjectDTO>("EXEC GetAllSubjectPost @subjectId",new{ @subjectId = subjectId });
        }

        #endregion

        #region GetSubjectById
        public async Task<Subject> GetSubjectById(int subjectId)
      {
          return await _context.QuerySingleOrDefaultAsync<Subject>("SELECT * FROM dbo.Subjects WHERE isDelete=0 AND id=@subjectId", new{ subjectId = subjectId });

      }


        #endregion


        #region GetSubjectForComboBox

        public async Task<IEnumerable<Subject>> GetSubjectForComboBox()
        {
            return await _context.QueryAsync<Subject>("SELECT * FROM dbo.Subjects WHERE isDelete=0");
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
