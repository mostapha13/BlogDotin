using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Blog.Domains.Base;
using Blog.Domains.Posts;

namespace Blog.Domains.Comments
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
