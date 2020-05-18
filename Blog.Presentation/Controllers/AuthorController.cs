using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DataAccessWrite.DTOs.Author;
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

        [HttpGet("GetAllAuthour")]
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

        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor([FromBody]AuthorViewModel author)
        {
            if (!ModelState.IsValid)
            {
                return JsonStatus.Error(new{info= "اطلاعات بدرستی وارد نشده است." });
            }
            
            try
            {
                if (await _read.IsEmailExist(author.Email.Trim().ToLower()))
                {
                    return JsonStatus.Error(new { info = "ایمیل وارد شده تکراری می باشد." });
                }

                if (await _read.IsUserNameExist(author.UserName.Trim().ToLower()))
                {
                    return JsonStatus.Error(new { info = "نام کاربری وارد شده تکراری می باشد." });
                }
                Author auth=new Author()
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    UserName=author.UserName.Trim().ToLower(),
                    Email = author.Email.Trim().ToLower(),
                    IsDelete = false

                };
                await _write.AddAuthor(auth);
                await _write.Save();
                return JsonStatus.Success();
            }
            catch (Exception e)
            {
                return JsonStatus.Error(new{info= "حطایی رخ داده است" });
            }
        }

        #endregion

        #region RemoveAuthor
        [HttpGet("RemoveAuthor/{authorId}")]
        public async Task<IActionResult> RemoveAuthor(int authorId)
        {
            var author = await _read.GetAuthorById(authorId);
            if (author==null)
            {
                return JsonStatus.Error(new{info= "کاربری یافت نشد." });
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
