﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MediatR;

namespace Blog.Domains.Base
{
   public class BaseEntity:IRequest<bool>
    {

        #region Propertise

   
        public long Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

         public bool IsDelete { get; set; }

        #endregion


    }
}
