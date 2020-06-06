using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Blog.Domains.Subjects.Queries.GetAllSubject
{
  public class GetAllSubjectQuery:IRequest<IEnumerable<Subject>>
    {
    }
}
