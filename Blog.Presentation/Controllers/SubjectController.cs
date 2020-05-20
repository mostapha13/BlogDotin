using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.SubjectClasses;
using Blog.Domain.SubjectClasses.Command;
using Blog.Domain.SubjectClasses.DTOs;
using Blog.Domain.SubjectClasses.Query;
using Blog.Presentation.Utilites.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    
    public class SubjectController : BaseController
    {
        #region Constructor
        private ISubjectRepositoryQuery _read;
        private ISubjectRepositoryCommand _write;

        public SubjectController(ISubjectRepositoryQuery read, ISubjectRepositoryCommand write)
        {
            _read = read;
            _write = write;
        } 
        #endregion

        #region GetAllSubject
        [HttpGet("GetAllSubject")]
        public async Task<IActionResult> GetAllSubject()
        {
            try
            {
                return JsonStatus.Success(await _read.GetAllSubject());
            }
            catch (Exception)
            {
                return JsonStatus.Error(new{info= "خطایی رخ داده است" });
            }
        }
        #endregion

        #region AddSubject
        [HttpPost("AddSubject")]
        public async Task<IActionResult> AddSubject([FromBody] Domain.SubjectClasses.DTOs.Subject subjectvm)
        {
            if (!ModelState.IsValid)
            {
                return JsonStatus.Error(new{info= "اطلاعات بدرستی وارد نشده است." });
            }

           
            try
            {


                Domain.SubjectClasses.Subject subject=new Domain.SubjectClasses.Subject()
                {
                    Title = subjectvm.Title
                };
                await _write.AddSubject(subject);
                await _write.Save();
                return JsonStatus.Success();
            }
            catch (Exception)
            {
                return JsonStatus.Error(new{info= "خطایی رخ داده است" });
            }
        }
        #endregion

        #region RemoveSubject
        [HttpGet("RemoveSubject/{id}")]
        public async Task<IActionResult> RemoveSubject(int id)
        {

            var subject =await _read.GetSubjectById(id);
            if (subject == null)
            {
                return JsonStatus.Error(new{info= "اطلاعات بدرستی وارد نشده است." });
            }
            try
            {
                _write.RemoveSubject(subject);
               await _write.Save();
               return JsonStatus.Success();

            }
            catch (Exception)
            {
                return JsonStatus.Error(new{info= "خطایی رخ داده است" });
            }
        }

        #endregion

        #region AllSubjectPost
        [HttpGet("AllSubjectPost/{id}")]
        public async Task<IActionResult> AllSubjectPost(long id)
        {
            try
            {
                return JsonStatus.Success(await _read.GetAllSubjectPost(id));
            }
            catch (Exception)
            {
                return JsonStatus.Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion


        #region GetAuthorForComboBox

        [HttpGet("GetSubjectForComboBox")]
        public async Task<IActionResult> GetSubjectForComboBox()
        {
            var subjectListCombo=await _read.GetSubjectForComboBox();

            List<SubjectForCombobox> subjectList=new List<SubjectForCombobox>();

            foreach (var subject in subjectListCombo)
            {
                subjectList.Add(new SubjectForCombobox()
                {
                    Id = subject.Id,
                    Title = subject.Title
                });

            }

            return new ObjectResult(subjectList);
        }

        #endregion
    }
}