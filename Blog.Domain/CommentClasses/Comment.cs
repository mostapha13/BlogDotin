using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Blog.Domain.BaseEntityClasses;
using Blog.Domain.PostClasses;

namespace Blog.Domain.CommentClasses
{
   public class Comment:BaseEntity
    {

        #region Propertise

        public long PostId { get; set; }
        public string Text { get; set; }

        #endregion



        #region Relations
      
        public virtual Post Post { get; set; }

        #endregion
    }
}
