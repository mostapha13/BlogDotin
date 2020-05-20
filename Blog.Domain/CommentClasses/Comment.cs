using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Blog.Domain.BaseEntityClasses;
using Blog.Domain.PostClasses;

namespace Blog.Domain.CommentClasses
{
   public class Comment:BaseEntity
    {

        #region Propertise



        [Display(Name = "پست")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        [MaxLength(250, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]

        public long PostId { get; set; }

        [Display(Name = "متن")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        [MaxLength(1500, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]

        public string Text { get; set; }

        #endregion



        #region Relations
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        #endregion
    }
}
