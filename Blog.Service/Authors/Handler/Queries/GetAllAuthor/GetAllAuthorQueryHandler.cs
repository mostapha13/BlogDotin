using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Authors;
using Blog.Domains.Authors.Commands;
using Blog.Domains.Authors.Queries;
using Blog.Domains.Authors.Queries.GetAllAuthor;
using MediatR;
using Serilog;

namespace Blog.Services.Authors.Handler.Queries.GetAllAuthor
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, IEnumerable<Author>>
    {

        #region Constructor

        private readonly IAuthorRepositoryQuery _read;
        private readonly IAuthorRepositoryCommand _write;

        public GetAllAuthorQueryHandler(IAuthorRepositoryQuery read, IAuthorRepositoryCommand write)
        {
            _read = read;
            _write = write;
        }

        #endregion


        #region Handle

        public async Task<IEnumerable<Author>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
         
            string functionName = "GetAllAuthor:Get";

            Log.ForContext("Message", functionName)
                .ForContext("Error", "").Information(functionName);

            return await _read.GetAllAuthor();

        } 
        #endregion
    }
}
