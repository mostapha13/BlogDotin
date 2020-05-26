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

        [Display(Name = "عنوان موضوع")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        [MaxLength(250, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]

        public string Title { get; set; }

        #endregion
    }
}
