using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Blog.Domain.Enum;
using MediatR;

namespace Blog.Domain.PostClasses.DTOs
{
   public class PostDTO:IRequest<ResultStatus>
    {


        #region Propertise

 
        public string Title { get; set; }
         
        public string AuthorId { get; set; }
         
        public string SubjectId { get; set; }
          
        public string Text { get; set; }

         

        #endregion

    }
}
