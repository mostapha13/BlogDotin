using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.DataAccessCommand.Context;
using Blog.Domain.SubjectClasses;
using Blog.Domain.SubjectClasses.Commands;

namespace Blog.DataAccessCommand.SubjectClasses.Repository
{
    public class SubjectRepositoryCommand : ISubjectRepositoryCommand
    {
        #region Constructor
        private readonly BlogContext _context;

        public SubjectRepositoryCommand(BlogContext context)
        {
            _context = context;
        }

        #endregion

        #region AddSubject
        public async Task AddSubject(Subject subject)
        {
           
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
