using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Domain.SubjectClasses.DTOs
{
   public class Subject
    {

        #region Propertise

        [Display(Name = "عنوان موضوع")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        [MaxLength(250, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]

        public string Title { get; set; }

        #endregion
    }
}
