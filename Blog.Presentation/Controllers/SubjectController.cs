using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DataAccessWrite.DTOs.Subject;
using Blog.DataAccessWrite.Utilites.Result;
using Blog.Domain.Entites;
using Blog.Service.Read;
using Blog.Service.Write;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
    
    public class SubjectController : BaseController
    {
        #region Constructor
        private ISubjectRepositoryRead _read;
        private ISubjectRepositoryWrite _write;

        public SubjectController(ISubjectRepositoryRead read, ISubjectRepositoryWrite write)
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
        public async Task<IActionResult> AddSubject([FromBody]SubjectViewModel subjectvm)
        {
            if (!ModelState.IsValid)
            {
                return JsonStatus.Error(new{info= "اطلاعات بدرستی وارد نشده است." });
            }

           
            try
            {

                
                Subject subject=new Subject()
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

    }
}