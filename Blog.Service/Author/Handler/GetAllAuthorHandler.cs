using System;
using System.Collections.Generic;
using System.Text;
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
    public class GetAllAuthorHandler : IRequestHandler<GetAllAuthorQuery, IEnumerable<Domain.AuthorClasses.Author>>
    {

        #region Constructor

        private readonly IAuthorRepositoryQuery _read;
        private readonly IAuthorRepositoryCommand _write;

        public GetAllAuthorHandler(IAuthorRepositoryQuery read, IAuthorRepositoryCommand write)
        {
            _read = read;
            _write = write;
        }

        #endregion


        #region Handle

        public async Task<IEnumerable<Domain.AuthorClasses.Author>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            string functionName = "GetAllAuthour:Get";

            Log.ForContext("Message", functionName)
                .ForContext("Error", "").Information(functionName);

            return await _read.GetAllAuthor();

        } 
        #endregion
    }
}
