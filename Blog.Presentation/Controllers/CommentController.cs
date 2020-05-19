using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DataAccessWrite.DTOs.Comment;
using Blog.DataAccessWrite.Utilites.Result;
using Blog.Domain.Entites;
using Blog.Service.Read;
using Blog.Service.Write;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{

    public class CommentController : BaseController
    {
        #region Constructor
        private ICommentRepositoryRead _read;
        private ICommentRepositoryWrite _write;

        public CommentController(ICommentRepositoryRead read, ICommentRepositoryWrite write)
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
                return JsonStatus.Success(await _read.GetAllComment());
            }
            catch (Exception)
            {
                return JsonStatus.Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion


        #region GetCommentById
        [HttpGet("GetCommentById/{commentId}")]
        public async Task<IActionResult> GetCommentById(long commentId)
        {
            try
            {
                return JsonStatus.Success(await _read.GetCommentById(commentId));
            }
            catch (Exception)
            {
                return JsonStatus.Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion

        #region AddComment
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment(CommentViewModel commentvm)
        {
            if (!ModelState.IsValid)
            {
                return JsonStatus.Error(new { info = "اطلاعات بدرستی وارد نشده است." });
            }


            try
            {

                Comment comment = new Comment()
                {
                    PostId = long.Parse(commentvm.PostId),
                    Text = commentvm.Text
                };
                await _write.AddComment(comment);
                await _write.Save();
                return JsonStatus.Success();
            }
            catch (Exception)
            {
                return JsonStatus.Error(new { info = "خطایی رخ داده است" });
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

        [HttpPost]
        public async Task<IActionResult> RemoveComment(Comment comment)
        {
            if (comment == null)
            {
                return JsonStatus.Error(new { info = "اطلاعات بدرستی وارد نشده است." });
            }
            try
            {
                _write.RemoveComment(comment);
                await _write.Save();
                return JsonStatus.Success();
            }
            catch (Exception)
            {
                return JsonStatus.Error(new { info = "خطایی رخ داده است" });
            }
        }

        #endregion


    }
}