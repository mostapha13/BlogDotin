using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Blog.Domain.BaseEntityClasses;
using Blog.Domain.PostClasses;

namespace Blog.Domain.SubjectClasses
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
