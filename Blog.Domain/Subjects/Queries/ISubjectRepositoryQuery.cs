using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Threading.Tasks;
using Blog.Domains.Subjects;
using Blog.Domains.Subjects.DTOs;

namespace Blog.Domains.Subjects.Queries
{
   public interface ISubjectRepositoryQuery:IDisposable
   {
       Task<IEnumerable<Subject>> GetAllSubject();

       Task<Subject> GetSubjectById(int subjectId);


       Task<IEnumerable<Subject>> GetSubjectForComboBox();
       Task<IEnumerable<AllSubjectDTO>> GetAllSubjectPost(long subjectId);
   }
}
