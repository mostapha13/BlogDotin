using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Service.DTOs
{
   public class CommentListViewModel
    {
        public long Id { get; set; }

        public long PostId { get; set; }
        public string PostTitle { get; set; }

        public string Text { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
