using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.PostClasses;
using Blog.Domain.PostClasses.Command;
using Blog.Domain.PostClasses.DTOs;
using Blog.Domain.PostClasses.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{
   
    public class PostController : BaseController
    {
        #region Constructor
        private readonly IPostRepositoryQuery _read;
        private readonly IPostRepositoryCommand _write;

        public PostController(IPostRepositoryQuery read, IPostRepositoryCommand write)
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
               
               
                return Success( await _read.GetAllPost());
            }
            catch (Exception )
            {
                return Error(new {info= "خطایی رخ داده است" });
            }
        }


        #endregion


        #region GetPostById

        [HttpGet("GetPostById/{postId}")]
        public async Task<IActionResult> GetPostById(long postId)
        {
            try
            {
                return Success(await _read.GetPostById(postId));
            }
            catch (Exception)
            {
                return Error(new{info= "خطایی رخ داده است" });
            }
        }


        #endregion


        #region GetPostBySubjectId

        [HttpGet("GetPostBySubjectId/{subjectId}")]
        public async Task<IActionResult> GetPostBySubjectId(long subjectId)
        {
            try
            {
                return Success(await _read.GetPostBySubjectId(subjectId));
            }
            catch (Exception)
            {
                return Error(new{info= "خطایی رخ داده است" });
            }
        }


        #endregion

        #region AddPost

        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost([FromBody] Domain.PostClasses.DTOs.Post postvm)
        {
            if (!ModelState.IsValid)
            {
                return Error(new{info= "اطلاعات بدرستی وارد نشده است." });
            }
            try
            {
                Domain.PostClasses.Post post=new Domain.PostClasses.Post()
                {
                    Title = postvm.Title,
                    AuthoId = long.Parse(postvm.AuthorId),
                    SubjectId = long.Parse(postvm.SubjectId),
                    Text = postvm.Text
                };

                await _write.AddPost(post);
                await _write.Save();
                return Success();
            }
            catch (Exception)
            {
                return Error(new{info= "خطایی رخ داده است" });
            }
        }

        #endregion

        #region GetPostForList
        [HttpGet("GetPostForList")]
        public async Task<IActionResult> GetPostForList()
        {
            return new ObjectResult(await _read.GetPostList());
        }

        #endregion


        #region RemovePost

        [HttpGet("RemovePost/{postId}")]
        public async Task<IActionResult> RemovePost(long postId)
        {
            var post =await _read.GetPostById(postId);
            if (post == null)
            {
                return Error(new{info= "کاربری یافت نشد." });
            }

            try
            {
                 _write.RemovePost(post);
                await _write.Save();
                return Success();
            }
            catch (Exception)
            {
                return Error(new{info= "خطایی رخ داده است" });
            }
        }

        #endregion

        #region GetPostForComboBox
        [HttpGet("GetPostForComboBox")]
        public async Task<IActionResult> GetPostForComboBox()
        {
            List<PostForCombobox> listPost=new List<PostForCombobox>();
            var posts =await _read.GetAllPost();

            foreach (var post in posts)
            {
                listPost.Add(new PostForCombobox()
                {
                    Id = post.Id,
                    Post =post.Title
                });
            }

            return new ObjectResult(listPost);
        }

        #endregion
    }
}