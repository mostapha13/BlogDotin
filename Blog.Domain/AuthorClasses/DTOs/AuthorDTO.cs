using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Blog.Domain.Enum;
using MediatR;

namespace Blog.Domain.AuthorClasses.DTOs
{
   public class AuthorDTO:IRequest<ResultStatus>
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
        [EmailAddress(ErrorMessage = "فرمت ایمیل به درستی وارد شود")]
        public string Email { get; set; }

        #endregion

    }
}
