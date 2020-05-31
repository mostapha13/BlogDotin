using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Blog.Domains.Base;
using Blog.Domains.Posts;


namespace Blog.Domains.Authors
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
