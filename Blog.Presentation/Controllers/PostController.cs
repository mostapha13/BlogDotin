using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DataAccessWrite.Utilites.Result;
using Blog.Domain.Entites;
using Blog.Service.Read;
using Blog.Service.Write;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
   
    public class PostController : BaseController
    {
        #region Constructor
        private IPostRepositoryRead _read;
        private IPostRepositoryWrite _write;

        public PostController(IPostRepositoryRead read, IPostRepositoryWrite write)
        {
            _read = read;
            _write = write;
        }
        #endregion


        #region GetAllPost
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            try
            {
               
               
                return JsonStatus.Success( await _read.GetAllPost());
            }
            catch (Exception )
            {
                return JsonStatus.Error("خطایی رخ داده است");
            }
        }


        #endregion


        #region GetPostById

        [HttpGet("GetPostById/{postId}")]
        public async Task<IActionResult> GetPostById(long postId)
        {
            try
            {
                return JsonStatus.Success(await _read.GetPostById(postId));
            }
            catch (Exception)
            {
                return JsonStatus.Error("خطایی رخ داده است");
            }
        }


        #endregion


        #region GetPostBySubjectId

        [HttpGet("GetPostBySubjectId/{subjectId}")]
        public async Task<IActionResult> GetPostBySubjectId(long subjectId)
        {
            try
            {
                return JsonStatus.Success(await _read.GetPostBySubjectId(subjectId));
            }
            catch (Exception)
            {
                return JsonStatus.Error("خطایی رخ داده است");
            }
        }


        #endregion

        #region AddPost

        [HttpPost]
        public async Task<IActionResult> AddPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return JsonStatus.Error("اطلاعات بدرستی وارد نشده است.");
            }
            try
            {
                await _write.AddPost(post);
                await _write.Save();
                return JsonStatus.Success();
            }
            catch (Exception )
            {
                return JsonStatus.Error("خطایی رخ داده است");
            }
        }

        #endregion


        #region RemovePost

        [HttpPost]
        public async Task<IActionResult> RemovePost(Post post)
        {
            if (post == null)
            {
                return JsonStatus.Error("اطلاعات بدرستی وارد نشده است.");
            }

            try
            {
                 _write.RemovePost(post);
                await _write.Save();
                return JsonStatus.Success();
            }
            catch (Exception)
            {
                return JsonStatus.Error("خطایی رخ داده است");
            }
        }

        #endregion
    }
}