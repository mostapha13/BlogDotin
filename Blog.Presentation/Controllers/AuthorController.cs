using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.AuthorClasses;
using Blog.Domain.AuthorClasses.Commands;
using Blog.Domain.AuthorClasses.DTOs;
using Blog.Domain.AuthorClasses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;


namespace Blog.Presentation.Controllers
{
    public class AuthorController : BaseController
    {
        #region Constructor
        private readonly IAuthorRepositoryQuery _read;
        private readonly IAuthorRepositoryCommand _write;
        private readonly IMediator _mediator;


        public AuthorController(IAuthorRepositoryQuery read, IAuthorRepositoryCommand write, IMediator mediator)
        {
            _read = read;
            _write = write;
            _mediator = mediator;
        }
        #endregion

        #region GetAllAuthour

        [HttpGet("GetAllAuthour")]
        public async Task<IActionResult> GetAllAuthour()
        {
            string functionName = "GetAllAuthour:Get";
            Log.Information(functionName);
            try
            {
                return Success(await _read.GetAllAuthor());


            }
            catch (Exception e)
            {

                Log.Error($"Error::{e.Message} ** {functionName}");
                return Error(new { info = "خطایی رخ داده است" });
            }
        }
        #endregion

        #region GetAuthorById
        [HttpGet("GetAuthorById/{id}")]
        public async Task<IActionResult> GetAuthorById(long id)
        {

            string functionName = "GetAuthorById:Get:" + id;
            Log.Information(functionName);
            try
            {
                return Success(await _read.GetAuthorById(id));
            }
            catch (Exception e)
            {
                Log.Error($"Error:{e.Message} ** {functionName}");
                return Error(new { info = "خطایی رخ داده است" });
            }
        }


        #endregion

        #region AddAuthor

        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor([FromBody] Domain.AuthorClasses.DTOs.AuthorDTO author)
        {
            string functionName = "AddAuthor:Post:" + JsonConvert.SerializeObject(author);
            Log.Information(functionName);
            if (!ModelState.IsValid)
            {

                Log.Error($"Error: ** {functionName}");

                return Error(new { info = "اطلاعات بدرستی وارد نشده است." });
            }

            try
            {
                if (await _read.IsEmailExist(author.Email.Trim().ToLower()))
                {
                    Log.Error($"Error: ** {functionName}");
                    return Error(new { info = "ایمیل وارد شده تکراری می باشد." });
                }

                if (await _read.IsUserNameExist(author.UserName.Trim().ToLower()))
                {
                    Log.Error($"Error: ** {functionName}");
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
            catch (Exception e)
            {

                Log.Error($"Error:{e.Message} ** {functionName}");
                return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion

        #region RemoveAuthor
        [HttpGet("RemoveAuthor/{authorId}")]
        public async Task<IActionResult> RemoveAuthor(int authorId)
        {
            string functionName = "RemoveAuthor:Get:" + authorId;
            Log.Information(functionName);
            var author = await _read.GetAuthorById(authorId);
            if (author == null)
            {

                Log.Error($"Error: ** {functionName}");
                return Error(new { info = "کاربری یافت نشد." });
            }
            try
            {
                _write.RemoveAuthor(author);
                await _write.Save();
                return Success();
            }
            catch (Exception e)
            {
                Log.Error($"Error:{e.Message} ** {functionName}");
                return Error(new { info = "خطایی رخ داده است" });
            }
        }
        #endregion

        #region EditAuthor

        [HttpPost("EditAuthor")]
        public async Task<IActionResult> EditAuthor(AuthorForEditDTO authorEdit)
        {


            string functionName = "EditAuthor:Post" + JsonConvert.SerializeObject(authorEdit);
            Log.Information(functionName);
            if (!ModelState.IsValid)
            {

                Log.Error($"Error: ** {functionName}");
                return Error(new { info = "اطلاعات بدرستی وارد نشده است." });

            }


            try
            {

                Domain.AuthorClasses.Author author = new Domain.AuthorClasses.Author()
                {
                    Id = authorEdit.Id,
                    CreateDate = authorEdit.CreateDate,
                    Email = authorEdit.Email.Trim().ToLower(),
                    FirstName = authorEdit.FirstName,
                    LastName = authorEdit.LastName,

                    UserName = authorEdit.UserName,
                   
                };

                _write.UpdateAuthor(author);
                await _write.Save();
                return Success();
            }
            catch (Exception e)
            {
                Log.Error($"Error:{e.Message} ** {functionName}");
                return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion

        #region AuthorForComboBox

        [HttpGet("GetAuthorForComboBox")]
        public async Task<IActionResult> GetAuthorForComboBox()
        {
            string functionName = "GetAuthorForComboBox:Get";
            Log.Information(functionName);

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
