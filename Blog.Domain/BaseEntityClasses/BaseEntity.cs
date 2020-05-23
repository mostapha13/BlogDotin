using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MediatR;

namespace Blog.Domain.BaseEntityClasses
{
   public class BaseEntity:IRequest<bool>
    {

        #region Propertise

       [Key]
        public long Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

         public bool IsDelete { get; set; }

        #endregion


    }
}
