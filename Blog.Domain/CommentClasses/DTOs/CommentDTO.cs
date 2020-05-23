using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.CommentClasses.DTOs
{
   public class CommentDTO
    {
        public string PostId { get; set; }

        public string Text { get; set; }
    }
}
