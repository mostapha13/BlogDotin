using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.SubjectClasses;
using Blog.Service.SubjectClasses.Queries;
using MediatR;

namespace Blog.Presentation.Handler.SubjectClasses
{
    public class GetAllSubjectHandler:IRequestHandler<GetAllSubjectQuery,IEnumerable<Subject>>
    {
        public async Task<IEnumerable<Subject>> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
