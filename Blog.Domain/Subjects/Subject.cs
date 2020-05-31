using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Blog.Domains.Base;
using Blog.Domains.Posts;

namespace Blog.Domains.Subjects
{
   public class Subject:BaseEntity
    {

        #region Propertise

    

        public string Title { get; set; }

        #endregion


        #region Relations

        public virtual List<Post> Posts { get; set; }

        #endregion


    }
}
