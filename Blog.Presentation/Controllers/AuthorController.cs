﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domains.Authors.Commands.AddAuthor;
using Blog.Domains.Authors.Commands.EditAuthor;
using Blog.Domains.Authors.Commands.RemoveAuthor;
using Blog.Domains.Authors.DTOs;
using Blog.Domains.Authors.Queries.GetAllAuthor;
using Blog.Domains.Authors.Queries.GetAuthorById;
using Blog.Domains.Authors.Queries.GetAuthorForComboBox;
using Blog.Domains.Enums;
using Blog.Presentation.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;


namespace Blog.Presentation.Controllers
{

    [CustomAction]
    public class AuthorController : BaseController
    {
        #region Constructor

        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region GetAllAuthour

        [HttpGet("GetAllAuthor")]
        public async Task<IActionResult> GetAllAuthor()
        {
            var query = new GetAllAuthorQuery();
            var result = await _mediator.Send(query);

            return result != null ? Success(result) : Error(new { info = "خطایی رخ داده است" });

        }
        #endregion

        #region GetAuthorById
        [HttpGet("GetAuthorById/{id}")]
        public async Task<IActionResult> GetAuthorById(long id)
        {

            var query = new GetAuthorByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? Success(new { data = result }) : Error(new { info = "کاربری یافت نشد" });

        }


        #endregion

        #region AddAuthor

        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor([FromBody] AddAuthorCommand author)
        {
            if (!ModelState.IsValid)
            {

                Log.ForContext("Message", "AddAuthor")
                    .ForContext("Error", "ModelStateNotValid").Error($"Error: ** AddAuthor");

                return Error(new { info = "اطلاعات بدرستی وارد نشده است." });
            }

            var result = await _mediator.Send(new AddAuthorCommand
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                Email = author.Email,
                UserName = author.UserName
            });



            switch (result)
            {
                case ResultStatus.EmailExist:
                    return Error(new { info = "ایمیل وارد شده تکراری می باشد." });

                case ResultStatus.UserNameExist:
                    return Error(new { info = "نام کاربری وارد شده تکراری می باشد." });

                case ResultStatus.Success:
                    return Success();

                default:
                    return Error(new { info = "خطایی رخ داده است" });
            }


        }

        #endregion

        #region RemoveAuthor
        [HttpGet("RemoveAuthor/{authorId}")]
        public async Task<IActionResult> RemoveAuthor(int authorId)
        {
         
            var author = new RemoveAuthorCommand(authorId);
            var result = await _mediator.Send(author);

            switch (result)
            {
                case ResultStatus.NotFound:
                    return Error(new { info = "کاربری یافت نشد." });
                case ResultStatus.Success:
                    return Success();
                default:
                    return Error(new { info = "خطایی رخ داده است" });
            }


        }
        #endregion

        #region EditAuthor

        [HttpPost("EditAuthor")]
        public async Task<IActionResult> EditAuthor(EditAuthorCommand authorEdit)
        {


     
            if (!ModelState.IsValid)
            {

                Log.ForContext("Message", "EditAuthor")
                    .ForContext("Error", "ModelstateIsNotValid")
                    .Error($"Error: ** EditAuthor");
                return Error(new { info = "اطلاعات بدرستی وارد نشده است." });

            }


            var result = await _mediator.Send(authorEdit);
            switch (result)
            {
                case ResultStatus.Success:
                    return Success();

                default:
                    return Error(new { info = "خطایی رخ داده است" });
            }



        }

        #endregion

        #region AuthorForComboBox

        [HttpGet("GetAuthorForComboBox")]
        public async Task<IActionResult> GetAuthorForComboBox()
        {

            var query = new GetAuthorForComboBoxQuery();
            var result = await _mediator.Send(query);

            return result == null ? null : new ObjectResult(result);
        }

        #endregion



    }
}
