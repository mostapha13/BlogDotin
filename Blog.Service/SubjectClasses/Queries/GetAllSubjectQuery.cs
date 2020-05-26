using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.SubjectClasses;
using MediatR;

namespace Blog.Service.SubjectClasses.Queries
{
  public class GetAllSubjectQuery:IRequest<IEnumerable<Subject>>
    {
    }
}
