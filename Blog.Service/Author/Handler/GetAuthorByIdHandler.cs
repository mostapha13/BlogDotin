using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.AuthorClasses;
using Blog.Domain.AuthorClasses.Commands;
using Blog.Domain.AuthorClasses.DTOs;
using Blog.Domain.AuthorClasses.Queries;
using MediatR;
using Serilog;

namespace Blog.Service.Author.Handler
{
    public class GetAuthorByIdHandler:IRequestHandler<GetAuthorByIdQuery,Domain.AuthorClasses.Author>
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

        #region Handle

        public async Task<Domain.AuthorClasses.Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
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
