using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.AuthorClasses;
using Blog.Domain.AuthorClasses.Commands;
using Blog.Domain.AuthorClasses.DTOs;
using Blog.Domain.AuthorClasses.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Blog.Presentation.Controllers
{
    public class AuthorController : BaseController
    {
        #region Constructor
        private readonly IAuthorRepositoryQuery _read;
        private readonly IAuthorRepositoryCommand _write;

        public AuthorController(IAuthorRepositoryQuery read, IAuthorRepositoryCommand write)
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

                return Success(await _read.GetAllAuthor());
            }
            catch (Exception)
            {
                return Error(new { info = "خطایی رخ داده است" });
            }
        }
        #endregion

        #region GetAuthorById
        [HttpGet("GetAuthorById/{id}")]
        public async Task<IActionResult> GetAuthorById(long id)
        {
            try
            {
                return Success(await _read.GetAuthorById(id));
            }
            catch (Exception)
            {
                return Error(new { info = "خطایی رخ داده است" });
            }
        }


        #endregion

        #region AddAuthor

        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor([FromBody] Domain.AuthorClasses.DTOs.AuthorDTO author)
        {
            if (!ModelState.IsValid)
            {
                return Error(new { info = "اطلاعات بدرستی وارد نشده است." });
            }

            try
            {
                if (await _read.IsEmailExist(author.Email.Trim().ToLower()))
                {
                    return Error(new { info = "ایمیل وارد شده تکراری می باشد." });
                }

                if (await _read.IsUserNameExist(author.UserName.Trim().ToLower()))
                {
                    return Error(new { info = "نام کاربری وارد شده تکراری می باشد." });
                }
                Domain.AuthorClasses.Author auth = new Domain.AuthorClasses.Author()
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    UserName = author.UserName.Trim().ToLower(),
                    Email = author.Email.Trim().ToLower(),
                    

                };
                await _write.AddAuthor(auth);
                await _write.Save();
                return Success();
            }
            catch (Exception)
            {
                return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion

        #region RemoveAuthor
        [HttpGet("RemoveAuthor/{authorId}")]
        public async Task<IActionResult> RemoveAuthor(int authorId)
        {
            var author = await _read.GetAuthorById(authorId);
            if (author == null)
            {
                return Error(new { info = "کاربری یافت نشد." });
            }
            try
            {
                _write.RemoveAuthor(author);
                await _write.Save();
                return Success();
            }
            catch (Exception)
            {
                return Error(new { info = "خطایی رخ داده است" });
            }
        }
        #endregion

        #region EditAuthor

        [HttpPost("EditAuthor")]
        public async Task<IActionResult> EditAuthor(AuthorForEditDTO authorEdit)
        {
            if (!ModelState.IsValid)
            {
                return Error(new { info = "اطلاعات بدرستی وارد نشده است." });

            }

            
            try
            {

                Domain.AuthorClasses.Author author=new Domain.AuthorClasses.Author()
                {
                    Id = authorEdit.Id,
                    CreateDate = authorEdit.CreateDate,
                    Email = authorEdit.Email.Trim().ToLower(),
                    FirstName = authorEdit.FirstName,
                    LastName = authorEdit.LastName,
                  
                    UserName = authorEdit.UserName,
                    UpdateDate = DateTime.Now
                };

                _write.UpdateAuthor(author);
                await _write.Save();
                return Success();
            }
            catch (Exception)
            {
                return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion

        #region AuthorForComboBox

        [HttpGet("GetAuthorForComboBox")]
        public async Task<IActionResult> GetAuthorForComboBox()
        {
            var listAuthor = await _read.GetAllAuthorForCombobox();

            List<AuthorForComboboxDTO> listAuthorCombo = new List<AuthorForComboboxDTO>();
            foreach (var author in listAuthor)
            {
                listAuthorCombo.Add(new AuthorForComboboxDTO()
                {
                    Id = author.Id,
                    FullName = author.FirstName + ' ' + author.LastName
                });
            }

            return new ObjectResult(listAuthorCombo);

            //  return new JsonResult(JsonConvert.SerializeObject(listAuthorCombo));
        }

        #endregion



    }
}
