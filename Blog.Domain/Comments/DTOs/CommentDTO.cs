using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Blog.Domains.Enums;
using MediatR;

namespace Blog.Domains.Comments.DTOs
{
   public class CommentDTO:IRequest<ResultStatus>
    {

        #region Propertise


 
        public string PostId { get; set; }

 
        public string Text { get; set; }


        #endregion

    }
}
