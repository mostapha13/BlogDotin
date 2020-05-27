using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Blog.Domain.Enum;
using MediatR;

namespace Blog.Domain.SubjectClasses.DTOs
{
   public class SubjectDTO:IRequest<ResultStatus>
    {

        #region Propertise

        

        public string Title { get; set; }

        #endregion
    }
}
