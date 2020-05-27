using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.SubjectClasses;
using Blog.Domain.SubjectClasses.Commands;
using Blog.Domain.SubjectClasses.DTOs;
using Blog.Domain.SubjectClasses.Queries;
using MediatR;
using Serilog;

namespace Blog.Service.Subject.Handler
{
    public class GetAllSubjectHandler:IRequestHandler<GetAllSubjectQuery,IEnumerable<Domain.SubjectClasses.Subject>>
    {
        #region Constructor
        private readonly ISubjectRepositoryQuery _read;
        private readonly ISubjectRepositoryCommand _write;

        public GetAllSubjectHandler(ISubjectRepositoryQuery read, ISubjectRepositoryCommand write)
        {
            _read = read;
            _write = write;
        }
        #endregion

        #region Handle

        public async Task<IEnumerable<Domain.SubjectClasses.Subject>> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
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
