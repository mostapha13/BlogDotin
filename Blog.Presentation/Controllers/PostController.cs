using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain.PostClasses;
using Blog.Domain.PostClasses.Commands;
using Blog.Domain.PostClasses.DTOs;
using Blog.Domain.PostClasses.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

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
            string functionName = "GetAllPost:Get:";
            Log.Information(functionName);
            try
            {
               
               
                return Success( await _read.GetAllPost());
            }
            catch (Exception e)
            {
                Log.Error($"Error: {e.Message} ** {functionName}");
                return Error(new {info= "خطایی رخ داده است" });
            }
        }


        #endregion


        #region GetPostById

        [HttpGet("GetPostById/{postId}")]
        public async Task<IActionResult> GetPostById(long postId)
        {
            string functionName = "GetPostById:Get:" + postId;
            Log.Information(functionName);
            try
            {
                return Success(await _read.GetPostById(postId));
            }
            catch (Exception e)
            {
                Log.Error($"Error:{e.Message} ** {functionName}");
                return Error(new{info= "خطایی رخ داده است" });
            }
        }


        #endregion


        #region GetPostBySubjectId

        [HttpGet("GetPostBySubjectId/{subjectId}")]
        public async Task<IActionResult> GetPostBySubjectId(long subjectId)
        {
            string functionName = "GetPostBySubjectId:Get:" + subjectId;
            Log.Information(functionName);

            try
            {
                return Success(await _read.GetPostBySubjectId(subjectId));
            }
            catch (Exception e)
            {
                Log.Error($"Error:{e.Message} ** {functionName}");
                return Error(new{info= "خطایی رخ داده است" });
            }
        }


        #endregion

        #region AddPost

        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost([FromBody] Domain.PostClasses.DTOs.PostDTO postDto)
        {
            string functionName = "AddPost:Post:" + JsonConvert.SerializeObject(postDto);
            Log.Information(functionName);
            if (!ModelState.IsValid)
            {
                Log.Error($"Error: ** {functionName}");
                return Error(new{info= "اطلاعات بدرستی وارد نشده است." });
            }
            try
            {
                Domain.PostClasses.Post post=new Domain.PostClasses.Post()
                {
                    Title = postDto.Title,
                    AuthoId = long.Parse(postDto.AuthorId),
                    SubjectId = long.Parse(postDto.SubjectId),
                    Text = postDto.Text
                };

                await _write.AddPost(post);
                await _write.Save();
                return Success();
            }
            catch (Exception e)
            {
                Log.Error($"Error:{e.Message} ** {functionName}");
                return Error(new{info= "خطایی رخ داده است" });
            }
        }

        #endregion

        #region GetPostForList
        [HttpGet("GetPostForList")]
        public async Task<IActionResult> GetPostForList()
        {
            string functionName = "GetPostForList:Get:";
            Log.Information(functionName);
            return new ObjectResult(await _read.GetPostList());
        }

        #endregion


        #region RemovePost

        [HttpGet("RemovePost/{postId}")]
        public async Task<IActionResult> RemovePost(long postId)
        {
            string functionName = "RemovePost:Get:"+postId;
            Log.Information(functionName);
            var post =await _read.GetPostById(postId);
            if (post == null)
            {
                Log.Error($"Error: ** {functionName}");
                return Error(new{info= "کاربری یافت نشد." });
            }

            try
            {
                 _write.RemovePost(post);
                await _write.Save();
                return Success();
            }
            catch (Exception e)
            {
                Log.Error($"Error:{e.Message} ** {functionName}");
                return Error(new{info= "خطایی رخ داده است" });
            }
        }

        #endregion

        #region GetPostForComboBox
        [HttpGet("GetPostForComboBox")]
        public async Task<IActionResult> GetPostForComboBox()
        {
            string functionName = "GetPostForComboBox:Get:";
            Log.Information(functionName);
            List<PostForComboboxDTO> listPost=new List<PostForComboboxDTO>();
            var posts =await _read.GetAllPost();

            foreach (var post in posts)
            {
                listPost.Add(new PostForComboboxDTO()
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