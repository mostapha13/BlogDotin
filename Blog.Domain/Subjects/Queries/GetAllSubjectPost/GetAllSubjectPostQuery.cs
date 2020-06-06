using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domains.Subjects.DTOs;
using MediatR;

namespace Blog.Domains.Subjects.Queries.GetAllSubjectPost
{
    public class GetAllSubjectPostQuery : IRequest<IEnumerable<AllSubjectDTO>>
    {
        public GetAllSubjectPostQuery(long id)
        {
            Id = id;
        }
        public long Id { get; set; }


    }
}
