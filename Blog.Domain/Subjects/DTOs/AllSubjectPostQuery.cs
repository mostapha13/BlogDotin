using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Subjects.DTOs
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
