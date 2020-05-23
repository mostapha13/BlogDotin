using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Blog.Domain.BaseEntityClasses;
using Blog.Domain.PostClasses;

namespace Blog.Domain.AuthorClasses
{

   
    public class Author:BaseEntity
    {

        #region Propertise

        

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        #endregion


        #region Relations

        public virtual List<Post> Posts { get; set; }


        #endregion



    }
}
