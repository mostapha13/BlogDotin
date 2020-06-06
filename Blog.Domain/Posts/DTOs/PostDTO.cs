using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Blog.Domains.Enums;
using MediatR;

namespace Blog.Domains.Posts.DTOs
{
   public class PostDTO
    {


        #region Propertise

        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string SubjectId { get; set; }
        public string Text { get; set; }

        #endregion

    }
}
