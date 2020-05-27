using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Blog.Domain.Enum;
using MediatR;

namespace Blog.Domain.AuthorClasses.DTOs
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
