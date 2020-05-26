using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.SubjectClasses;
using Blog.Domain.SubjectClasses.Commands;
using Blog.Domain.SubjectClasses.DTOs;
using Blog.Domain.SubjectClasses.Queries;
using Blog.Service.SubjectClasses.Queries;
using MediatR;
using Serilog;

namespace Blog.Presentation.Handler.SubjectClasses
{
    public class AllSubjectPostHandler:IRequestHandler<AllSubjectPostQuery,IEnumerable<AllSubjectDTO>>
    {

        #region Constructor
        private readonly ISubjectRepositoryQuery _read;
        private readonly ISubjectRepositoryCommand _write;
       
        public AllSubjectPostHandler(ISubjectRepositoryQuery read, ISubjectRepositoryCommand write)
        {
            _read = read;
            _write = write;
            
        }
        #endregion
        #region Handle

        public async Task<IEnumerable<AllSubjectDTO>> Handle(AllSubjectPostQuery request, CancellationToken cancellationToken)
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
