using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Entites;
using Blog.Service.DTOs;

namespace Blog.Service.Read
{
   public interface ISubjectRepositoryRead:IDisposable
   {
       Task<IEnumerable<Subject>> GetAllSubject();

       Task<Subject> GetSubjectById(int subjectId);


       Task<IEnumerable<Subject>> GetSubjectForComboBox();
       Task<IEnumerable<AllSubjectPostViewModel>> GetAllSubjectPost(long subjectId);
   }
}
