using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public async Task<IActionResult> GetAllSubject()
        {
            try
            {
                return JsonStatus.Success(await _read.GetAllSubject());
            }
            catch (Exception)
            {
                return JsonStatus.Error("خطایی رخ داده است");
            }
        }
        #endregion

        #region AddSubject
        [HttpPost]
        public async Task<IActionResult> AddSubject(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return JsonStatus.Error("اطلاعات بدرستی وارد نشده است.");
            }
            try
            {
                await _write.AddSubject(subject);
                await _write.Save();
                return JsonStatus.Success();
            }
            catch (Exception)
            {
                return JsonStatus.Error("خطایی رخ داده است");
            }
        }
        #endregion

        #region RemoveSubject
        [HttpPost]
        public async Task<IActionResult> RemoveSubject(Subject subject)
        {
            if (subject == null)
            {
                return JsonStatus.Error("اطلاعات بدرستی وارد نشده است.");
            }
            try
            {
                _write.RemoveSubject(subject);
               await _write.Save();
               return JsonStatus.Success();

            }
            catch (Exception)
            {
                return JsonStatus.Error("خطایی رخ داده است");
            }
        }

        #endregion

    }
}