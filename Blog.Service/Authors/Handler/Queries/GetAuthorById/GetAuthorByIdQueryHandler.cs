using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domains.Authors;
using Blog.Domains.Authors.Commands;
using Blog.Domains.Authors.Queries;
using Blog.Domains.Authors.Queries.GetAuthorById;
using MediatR;
using Serilog;

namespace Blog.Services.Authors.Handler.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler:IRequestHandler<GetAuthorByIdQuery,Author>
    {
        #region Constructor
        private readonly IAuthorRepositoryQuery _read;
        private readonly IAuthorRepositoryCommand _write;
        
        public GetAuthorByIdQueryHandler(IAuthorRepositoryQuery read, IAuthorRepositoryCommand write)
        {
            _read = read;
            _write = write;
           
        }
        #endregion

        #region Handle

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            string functionName = "GetAuthorById:Get:" + request.Id;
            Log.ForContext("Message", functionName)
                .ForContext("Error", "").Information(functionName);

            var author = await _read.GetAuthorById(request.Id);

            return author is null ? null : author;
        } 

        #endregion
    }
}
