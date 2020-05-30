using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Blog.Domain.Enum;
using MediatR;

namespace Blog.Domain.CommentClasses.DTOs
{
   public class CommentDTO:IRequest<ResultStatus>
    {

        #region Propertise


 
        public string PostId { get; set; }

 
        public string Text { get; set; }


        #endregion

    }
}
