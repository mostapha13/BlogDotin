using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domains.Subjects.Commands
{
    public interface ISubjectRepositoryCommand : IDisposable
    {

        Task AddSubject(Subject subject);
         void UpdateSubject(Subject subject);
        Task RemoveSubject(Subject subject);
        // Task RemoveSubjectById(long subjectId);
        Task Save();
    }
}
