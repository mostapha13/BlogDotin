﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.CommentClasses;
using Blog.Domain.CommentClasses.Commands;
using Blog.Domain.CommentClasses.DTOs;
using Blog.Domain.CommentClasses.Queries;
using Blog.Domain.Enum;
using Blog.Service.CommentClasses.Commands;
using Blog.Service.CommentClasses.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Presentation.Controllers
{

    public class CommentController : BaseController
    {
        #region Constructor
       
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
           
            _mediator = mediator;
        }
        #endregion

        #region GetAllComment

        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            var query = new GetAllCommentQuery();
            var result = await _mediator.Send(query);

            return result == null ? Error() : Success(result);

        }

        #endregion


        #region GetCommentById
        [HttpGet("GetCommentById/{commentId}")]
        public async Task<IActionResult> GetCommentById(long commentId)
        {
            var query = new GetCommentByIdQuery(commentId);
            var result = await _mediator.Send(query);
            return result != null ? Success(result) : null;
        }

        #endregion

        #region AddComment
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment(CommentDTO commentDto)
        {
            string functionName = "AddComment:Post:" + JsonConvert.SerializeObject(commentDto);
            Log.ForContext("Message", functionName)
                .ForContext("Error", "").Information(functionName);
            if (!ModelState.IsValid)
            {
                Log.ForContext("Message", functionName)
                    .ForContext("Error", "ModelStateNotValid").Error($"Error: ** {functionName}");
                return Error(new { info = "اطلاعات بدرستی وارد نشده است." });
            }

            var result = await _mediator.Send(commentDto);
            return result == ResultStatus.Success ? Success(result) : null;
        }

        #endregion


        #region GetAllCommentList
        [HttpGet("GetAllCommentList")]
        public async Task<IActionResult> GetAllCommentList()
        {
            var query = new GetAllCommentListQuery();
            var result = await _mediator.Send(query);
            return result == null ? null : new ObjectResult(result);
        }

        #endregion

        #region RemoveComment

        [HttpGet("RemoveComment/{id}")]
        public async Task<IActionResult> RemoveComment(long id)
        {
            var query = new RemoveCommentCommand(id);
            var result = await _mediator.Send(query);

            switch (result)
            {
                case ResultStatus.NotFound:
                    return Error(new { info = "اطلاعات بدرستی وارد نشده است." });
                case ResultStatus.Success:
                    return Success();
                case ResultStatus.Error:
                    return Error(new { info = "خطایی رخ داده است" });
                default:
                    return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion


    }
}