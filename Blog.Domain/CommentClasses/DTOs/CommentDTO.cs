using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Domain.CommentClasses.DTOs
{
   public class CommentDTO
    {

        #region Propertise


        [Display(Name = "پست")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        public string PostId { get; set; }


        [Display(Name = "متن")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        [MaxLength(1500, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]
        public string Text { get; set; }


        #endregion

    }
}
