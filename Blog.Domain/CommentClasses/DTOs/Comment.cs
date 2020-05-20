using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.CommentClasses.DTOs
{
   public class Comment
    {
        public string PostId { get; set; }

        public string Text { get; set; }
    }
}
