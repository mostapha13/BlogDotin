﻿using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.Enum;
using MediatR;

namespace Blog.Domain.AuthorClasses.DTOs
{
   public class AuthorForEditDTO:IRequest<ResultStatus>
    {
        #region Propertise

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsDelete { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        #endregion


    }
}
