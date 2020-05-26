using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.SubjectClasses;
using Blog.Domain.SubjectClasses.Commands;
using Blog.Domain.SubjectClasses.Queries;
using Blog.Service.SubjectClasses.Queries;
using MediatR;
using Serilog;

namespace Blog.Presentation.Handler.SubjectClasses
{
    public class GetAllSubjectHandler:IRequestHandler<GetAllSubjectQuery,IEnumerable<Subject>>
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
