﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Blog.Domains.Authors;
using Blog.Domains.Base;
using Blog.Domains.Comments;
using Blog.Domains.Subjects;

namespace Blog.Domains.Posts
{
   public class Post:BaseEntity
    {


        #region Propertise
         
        public string Title { get; set; }
         
        public long SubjectId { get; set; }
         
        public string Text { get; set; }

        public long AuthorId { get; set; }



        #endregion


        #region Relations

       
        public virtual Author Author { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual Subject Subject { get; set; }


        #endregion

    }
}
