using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.SubjectClasses;

namespace Blog.Service.Write
{
    public interface ISubjectRepositoryWrite : IDisposable
    {

        Task AddSubject(Subject subject);
        // Task UpdateSubject(Subject subject);
        void RemoveSubject(Subject subject);
        // Task RemoveSubjectById(long subjectId);
        Task Save();
    }
}
