using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.SubjectClasses;
using Blog.Domain.SubjectClasses.DTOs;
using MediatR;

namespace Blog.Domain.SubjectClasses.DTOs
{
   public class AllSubjectPostQuery:IRequest<IEnumerable<AllSubjectDTO>>
    {
        public long Id { get; set; }

        public AllSubjectPostQuery(long id)
        {
            Id = id;
        }
    }
}
