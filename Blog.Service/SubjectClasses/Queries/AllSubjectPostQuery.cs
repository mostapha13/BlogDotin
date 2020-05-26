using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.SubjectClasses;
using Blog.Domain.SubjectClasses.DTOs;
using MediatR;

namespace Blog.Service.SubjectClasses.Queries
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
