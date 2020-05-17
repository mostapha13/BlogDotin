using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DataAccessWrite.Utilites.Result;
using Blog.Domain.Entites;
using Blog.Service.Read;
using Blog.Service.Write;
using Microsoft.AspNetCore.Mvc;


namespace Blog.Presentation.Controllers
{
    public class AuthorController : BaseController
    {
        #region Constructor
        private IAuthorRepositoryRead _read;
        private IAuthorRepositoryWrite _write;

        public AuthorController(IAuthorRepositoryRead read, IAuthorRepositoryWrite write)
        {
            _read = read;
            _write = write;
        } 
        #endregion

        #region GetAllAuthour

        [HttpGet]
        public async Task<IActionResult> GetAllAuthour()
        {
            try
            {
                return JsonStatus.Success(await _read.GetAllAuthor());
            }
            catch (Exception)
            {
                return JsonStatus.Error(new{info= "خطایی رخ داده است" });
            }
        }
        #endregion

        #region AddAuthor

        [HttpPost]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return JsonStatus.Error(new{info= "اطلاعات بدرستی وارد نشده است." });
            }
            
            try
            {
                await _write.AddAuthor(author);
                await _write.Save();
                return JsonStatus.Success();
            }
            catch (Exception)
            {
                return JsonStatus.Error(new{info= "حطایی رخ داده است" });
            }
        }

        #endregion

        #region RemoveAuthor
        [HttpPost]
        public async Task<IActionResult> RemoveAuthor(Author author)
        {
            if (author==null)
            {
                return JsonStatus.Error(new{info= "اطلاعات بدرستی وارد نشده است." });
            }
            try
            {
                _write.RemoveAuthor(author);
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
