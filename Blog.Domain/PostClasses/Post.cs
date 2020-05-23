using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Blog.Domain.AuthorClasses;
using Blog.Domain.BaseEntityClasses;
using Blog.Domain.CommentClasses;
using Blog.Domain.SubjectClasses;

namespace Blog.Domain.PostClasses
{
   public class Post:BaseEntity
    {


        #region Propertise

 

        public string Title { get; set; }

 

        public long SubjectId { get; set; }

         

        public string Text { get; set; }



        public long AuthoId { get; set; }



        #endregion


        #region Relations

        [ForeignKey("AuthoId")]
        public virtual Author Author { get; set; }

        public virtual List<Comment> Comments { get; set; }


        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }


        #endregion

    }
}
