using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using MediatR;

namespace Blog.Domains.Comments.DTOs
{
   public class CommentDTO
    {

        #region Propertise

        public string PostId { get; set; }
        public string Text { get; set; }

        #endregion

    }
}
