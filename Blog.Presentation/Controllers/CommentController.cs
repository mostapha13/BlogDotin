using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.CommentClasses;
using Blog.Domain.CommentClasses.Command;
using Blog.Domain.CommentClasses.DTOs;
using Blog.Domain.CommentClasses.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                return Success(await _read.GetAllComment());
            }
            catch (Exception)
            {
                return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion


        #region GetCommentById
        [HttpGet("GetCommentById/{commentId}")]
        public async Task<IActionResult> GetCommentById(long commentId)
        {
            try
            {
                return Success(await _read.GetCommentById(commentId));
            }
            catch (Exception)
            {
                return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion

        #region AddComment
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment(Domain.CommentClasses.DTOs.CommentDTO commentvm)
        {
            if (!ModelState.IsValid)
            {
                return Error(new { info = "اطلاعات بدرستی وارد نشده است." });
            }


            try
            {

                Domain.CommentClasses.Comment comment = new Domain.CommentClasses.Comment()
                {
                    PostId = long.Parse(commentvm.PostId),
                    Text = commentvm.Text
                };
                await _write.AddComment(comment);
                await _write.Save();
                return Success();
            }
            catch (Exception)
            {
                return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion


        #region GetAllCommentList
        [HttpGet("GetAllCommentList")]
        public async Task<IActionResult> GetAllCommentList()
        {
            return new ObjectResult(await _read.GetAllCommentList());
        }

        #endregion

        #region RemoveComment

        [HttpGet("RemoveComment/{id}")]
        public async Task<IActionResult> RemoveComment(long id)
        {
            var comment =await _read.GetCommentById(id);
            if (comment == null)
            {
                return Error(new { info = "اطلاعات بدرستی وارد نشده است." });
            }
            try
            {
                _write.RemoveComment(comment);
                await _write.Save();
                return Success();
            }
            catch (Exception)
            {
                return Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion


    }
}