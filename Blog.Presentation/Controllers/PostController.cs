using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domains.Enums;
using Blog.Domains.Posts.Commands.AddPost;
using Blog.Domains.Posts.Commands.RemovePost;
using Blog.Domains.Posts.DTOs;
using Blog.Domains.Posts.Queries.GetAllPost;
using Blog.Domains.Posts.Queries.GetPostById;
using Blog.Domains.Posts.Queries.GetPostBySubjectId;
using Blog.Domains.Posts.Queries.GetPostForComboBox;
using Blog.Domains.Posts.Queries.GetPostForList;
using Blog.Presentation.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Presentation.Controllers
{
   
    [CustomAction]
    public class PostController : BaseController
    {
        #region Constructor
     
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
         
            _mediator = mediator;
        }
        #endregion


        #region GetAllPost
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            var query = new GetAllPostQuery();
            var result = await _mediator.Send(query);
            return result != null ? Success(result) : Error(new { info = "خطایی رخ داده است" });
        }


        #endregion


        #region GetPostById

        [HttpGet("GetPostById/{postId}")]
        public async Task<IActionResult> GetPostById(long postId)
        {
            var query = new GetPostByIdQuery(postId);
            var result = await _mediator.Send(query);

            return result != null ? Success(result) : Error(new { info = "خطایی رخ داده است" });
        }


        #endregion


        #region GetPostBySubjectId

        [HttpGet("GetPostBySubjectId/{subjectId}")]
        public async Task<IActionResult> GetPostBySubjectId(long subjectId)
        {
            var query = new GetPostBySubjectIdQuery(subjectId);
            var result = await _mediator.Send(query);
            return result != null ? Success(result) : Error(new { info = "خطایی رخ داده است" });
        }


        #endregion

        #region AddPost

        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost([FromBody] PostDTO postDto)
        {
         
            if (!ModelState.IsValid)
            {
                Log.ForContext("Message", "AddPost")
                    .ForContext("Error", "ModelStateNotFound")
                    .Error($"Error: ** AddPost");
                return Error(new { info = "اطلاعات بدرستی وارد نشده است." });
            }

            var result = await _mediator.Send(new AddPostCommand()
            {
                SubjectId = postDto.SubjectId,
                Text = postDto.Text,
                Title = postDto.Title,
                AuthorId = postDto.AuthorId
            });
            switch (result)
            {
                case ResultStatus.Success:
                    return Success();
                default:
                    return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion

        #region GetPostForList
        [HttpGet("GetPostForList")]
        public async Task<IActionResult> GetPostForList()
        {
            var query = new GetPostForListQuery();
            var result = await _mediator.Send(query);
            return result != null ? new ObjectResult(result) : null;
        }

        #endregion


        #region RemovePost

        [HttpGet("RemovePost/{postId}")]
        public async Task<IActionResult> RemovePost(long postId)
        {
            var query = new RemovePostCommand(postId);
            var result = await _mediator.Send(query);

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

        #region GetPostForComboBox
        [HttpGet("GetPostForComboBox")]
        public async Task<IActionResult> GetPostForComboBox()
        {
            var query = new GetPostForComboBoxQuery();
            var result = await _mediator.Send(query);

            return result != null ? new ObjectResult(result) : null;
        }

        #endregion
    }
}