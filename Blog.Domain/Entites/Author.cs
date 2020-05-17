using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Domain.Entites
{
  public  class Author:BaseEntity
    {

        #region Propertise

        [Display(Name = "نام")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        [MaxLength(250, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]

        public string FirstName { get; set; }


        [Display(Name = "نام خانوادگی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        [MaxLength(250, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]

        public string LastName { get; set; }


        [Display(Name = "نام کاربری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        [MaxLength(250, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]

        public string UserName { get; set; }


        [Display(Name = "ایمیل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است")]
        [MaxLength(500, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]

        public string Email { get; set; }

        #endregion


        #region Relations

        public virtual List<Post> Posts { get; set; }


        #endregion

    }
}
