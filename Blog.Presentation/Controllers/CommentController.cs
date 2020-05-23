using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.CommentClasses;
using Blog.Domain.CommentClasses.Commands;
using Blog.Domain.CommentClasses.DTOs;
using Blog.Domain.CommentClasses.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace Blog.Presentation.Controllers
{

    public class CommentController : BaseController
    {
        #region Constructor
        private readonly ICommentRepositoryQuery _read;
        private readonly ICommentRepositoryCommand _write;

        public CommentController(ICommentRepositoryQuery read, ICommentRepositoryCommand write)
        {
            _read = read;
            _write = write;
        }
        #endregion

        #region GetAllComment

        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            string functionName = "GetAllComment:Get:";
            Log.Information(functionName);
            try
            {
                return Success(await _read.GetAllComment());
            }
            catch (Exception e)
            {

                Log.Error($"Error: {e.Message} ** {functionName}");
                return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion


        #region GetCommentById
        [HttpGet("GetCommentById/{commentId}")]
        public async Task<IActionResult> GetCommentById(long commentId)
        {
            string functionName = "GetCommentById:Get:"+commentId;
            Log.Information(functionName);
            try
            {
                return Success(await _read.GetCommentById(commentId));
            }
            catch (Exception e)
            {
                Log.Error($"Error: {e.Message} ** {functionName}");
                return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion

        #region AddComment
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment(Domain.CommentClasses.DTOs.CommentDTO commentDto)
        {
            string functionName = "AddComment:Post:"+JsonConvert.SerializeObject(commentDto);
            Log.Information(functionName);
            if (!ModelState.IsValid)
            {
                Log.Error($"Error: ** {functionName}");
                return Error(new { info = "اطلاعات بدرستی وارد نشده است." });
            }


            try
            {

                Domain.CommentClasses.Comment comment = new Domain.CommentClasses.Comment()
                {
                    PostId = long.Parse(commentDto.PostId),
                    Text = commentDto.Text
                };
                await _write.AddComment(comment);
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


        #region GetAllCommentList
        [HttpGet("GetAllCommentList")]
        public async Task<IActionResult> GetAllCommentList()
        {
            string functionName = "GetAllCommentList:Get:";
            Log.Information(functionName);
            return new ObjectResult(await _read.GetAllCommentList());
        }

        #endregion

        #region RemoveComment

        [HttpGet("RemoveComment/{id}")]
        public async Task<IActionResult> RemoveComment(long id)
        {
            string functionName = "RemoveComment:Get:" + id;
            Log.Information(functionName);
            var comment =await _read.GetCommentById(id);
            if (comment == null)
            {
                Log.Error($"Error: ** {functionName}");
                return Error(new { info = "اطلاعات بدرستی وارد نشده است." });
            }
            try
            {
                _write.RemoveComment(comment);
                await _write.Save();
                return Success();
            }
            catch (Exception e)
            {
                Log.Error($"Error: {e.Message} ** {functionName}");
                return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion


    }
}