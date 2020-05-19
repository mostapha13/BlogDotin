using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.DataAccessWrite.DTOs.Post
{
   public class PostViewModel
    {


        #region Propertise

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        [MaxLength(250, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]
        public string Title { get; set; }


        [Display(Name = "نویسنده")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        public string AuthorId { get; set; }



        [Display(Name = "موضوع")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        public string SubjectId { get; set; }



        [Display(Name = "متن")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        public string Text { get; set; }






        #endregion

    }
}
