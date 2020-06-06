using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Subjects;
using Blog.Domains.Subjects.Commands;
using Blog.Domains.Subjects.DTOs;
using Blog.Domains.Subjects.Queries;
using Blog.Domains.Subjects.Queries.GetAllSubject;
using MediatR;
using Serilog;

namespace Blog.Services.Subjects.Handler.Queries.GetAllSubject
{
    public class GetAllSubjectQueryHandler:IRequestHandler<GetAllSubjectQuery,IEnumerable<Subject>>
    {
        #region Constructor
        private readonly ISubjectRepositoryQuery _read;
        private readonly ISubjectRepositoryCommand _write;

        public GetAllSubjectQueryHandler(ISubjectRepositoryQuery read, ISubjectRepositoryCommand write)
        {
            _read = read;
            _write = write;
        }
        #endregion

        #region Handle

        public async Task<IEnumerable<Subject>> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
        {

            string functionName = "GetAllSubject:Get:";
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);

            return await _read.GetAllSubject();

        } 
        #endregion
    }
}
