using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.AuthorClasses;
using Blog.Domain.AuthorClasses.Commands;
using Blog.Domain.AuthorClasses.Queries;
using Blog.Service.AuthorClasses.Queries;
using MediatR;
using Serilog;

namespace Blog.Presentation.Handler.AuthorClasses
{
    public class GetAuthorByIdHandler:IRequestHandler<GetAuthorByIdQuery,Author>
    {
        #region Constructor
        private readonly IAuthorRepositoryQuery _read;
        private readonly IAuthorRepositoryCommand _write;
        
        public GetAuthorByIdHandler(IAuthorRepositoryQuery read, IAuthorRepositoryCommand write)
        {
            _read = read;
            _write = write;
           
        }
        #endregion
        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            string functionName = "GetAuthorById:Get:" + request.Id;
            Log.ForContext("Message", functionName)
                .ForContext("Error", "").Information(functionName);

          var author=await _read.GetAuthorById(request.Id);

          return author is null ? null : author;
        }
    }
}
