using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Subjects.Commands;
using Blog.Domains.Subjects.DTOs;
using Blog.Domains.Subjects.Queries;
using Blog.Domains.Subjects.Queries.GetAllSubjectPost;
using MediatR;
using Serilog;

namespace Blog.Services.Subjects.Handler.Queries.GetAllSubjectPost
{
    public class GetAllSubjectPostQueryHandler:IRequestHandler<GetAllSubjectPostQuery,IEnumerable<AllSubjectDTO>>
    {

        #region Constructor
        private readonly ISubjectRepositoryQuery _read;
        private readonly ISubjectRepositoryCommand _write;
       
        public GetAllSubjectPostQueryHandler(ISubjectRepositoryQuery read, ISubjectRepositoryCommand write)
        {
            _read = read;
            _write = write;
            
        }
        #endregion
        #region Handle

        public async Task<IEnumerable<AllSubjectDTO>> Handle(GetAllSubjectPostQuery request, CancellationToken cancellationToken)
        {

            string functionName = "AllSubjectPost:Get:" + request.Id;
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);

            return await _read.GetAllSubjectPost(request.Id);

        } 
        #endregion
    }
}
