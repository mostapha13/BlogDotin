using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Domain.Entites
{
   public class Post:BaseEntity
    {


        #region Propertise

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        [MaxLength(250, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]

        public string Title { get; set; }

        [Display(Name = "موضوع")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        [MaxLength(250, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]

        public long SubjectId { get; set; }

        [Display(Name = "متن")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]

        public string Text { get; set; }



        public long AuthoId { get; set; }



        #endregion


        #region Relations

        [ForeignKey("AuthoId")]
        public virtual Author Author { get; set; }

        public virtual List<Comment> Comments { get; set; }


        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }


        #endregion

    }
}
