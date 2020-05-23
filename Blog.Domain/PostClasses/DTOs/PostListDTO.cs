using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.PostClasses.DTOs
{
   public class PostListDTO
    {

        public long Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public long SubjectId { get; set; }
        public string SubjectName { get; set; }

        public string Text { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public int CommentPost { get; set; }
       


    }
}
