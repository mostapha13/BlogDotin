using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Context;
using Blog.Domain.SubjectClasses;
using Blog.Service.Write;

namespace Blog.DataAccessWrite.Implementation
{
    public class SubjectRepositoryWrite : ISubjectRepositoryWrite
    {
        #region Constructor
        private readonly BlogContext _context;

        public SubjectRepositoryWrite(BlogContext context)
        {
            _context = context;
        }

        #endregion

        #region AddSubject
        public async Task AddSubject(Subject subject)
        {
            subject.CreateDate=DateTime.Now;
            subject.UpdateDate = subject.CreateDate;
            await _context.Subjects.AddAsync(subject);
        }

        #endregion

        #region RemoveSubject

        public void RemoveSubject(Subject subject)
        {
            _context.Subjects.Remove(subject);
        }

        #endregion

        #region Save
        public async Task Save()
        {
            await _context.SaveChangesAsync();
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
