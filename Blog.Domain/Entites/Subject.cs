using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Domain.Entites
{
   public class Subject:BaseEntity
    {

        #region Propertise

        [Display(Name = "عنوان موضوع")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        [MaxLength(250, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]

        public string Title { get; set; }

        #endregion


        #region Relations

        public virtual List<Post> Posts { get; set; }

        #endregion


    }
}
