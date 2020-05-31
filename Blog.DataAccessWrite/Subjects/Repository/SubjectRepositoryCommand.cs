using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.DataAccessCommands.Context;
using Blog.Domains.Subjects;
using Blog.Domains.Subjects.Commands;

namespace Blog.DataAccessCommands.Subjects.Repository
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

        public async Task RemoveSubject(Subject subject)
        {

            subject.IsDelete = true;
            UpdateSubject(subject);
           await Save();
             
        }

        #endregion

        #region UpdateSubject

        public void UpdateSubject(Subject subject)
        {
            _context.Subjects.Update(subject);
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
