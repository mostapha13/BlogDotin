using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Blog.Domains.Enums;
using MediatR;

namespace Blog.Domains.Subjects.DTOs
{
   public class SubjectDTO:IRequest<ResultStatus>
    {

        #region Propertise

        

        public string Title { get; set; }

        #endregion
    }
}
