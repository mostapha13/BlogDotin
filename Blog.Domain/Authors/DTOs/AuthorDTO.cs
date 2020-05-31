using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Blog.Domains.Enums;
using MediatR;

namespace Blog.Domains.Authors.DTOs
{
   public class AuthorDTO:IRequest<ResultStatus>
    {
        #region Propertise


        public string FirstName { get; set; }
         
        public string LastName { get; set; }
         
        public string UserName { get; set; }
         
        public string Email { get; set; }

        #endregion

    }
}
