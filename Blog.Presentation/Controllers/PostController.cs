using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.Enum;
using Blog.Domain.PostClasses;
using Blog.Domain.PostClasses.Commands;
using Blog.Domain.PostClasses.DTOs;
using Blog.Domain.PostClasses.Queries;
using Blog.Presentation.Filter;
using Blog.Service.PostClasses.Commands;
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
            string functionName = "AddPost:Post:" + JsonConvert.SerializeObject(postDto);
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);
            if (!ModelState.IsValid)
            {
                Log.ForContext("Message", functionName)
                    .ForContext("Error", "ModelStateNotFound")
                    .Error($"Error: ** {functionName}");
                return Error(new { info = "اطلاعات بدرستی وارد نشده است." });
            }

            var result = await _mediator.Send(postDto);
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