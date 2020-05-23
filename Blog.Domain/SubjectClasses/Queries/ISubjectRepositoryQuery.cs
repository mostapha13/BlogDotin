using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.SubjectClasses;
using Blog.Domain.SubjectClasses.DTOs;

namespace Blog.Domain.SubjectClasses.Queries
{
   public interface ISubjectRepositoryQuery:IDisposable
   {
       Task<IEnumerable<Subject>> GetAllSubject();

       Task<Subject> GetSubjectById(int subjectId);


       Task<IEnumerable<Subject>> GetSubjectForComboBox();
       Task<IEnumerable<AllSubjectDTO>> GetAllSubjectPost(long subjectId);
   }
}
