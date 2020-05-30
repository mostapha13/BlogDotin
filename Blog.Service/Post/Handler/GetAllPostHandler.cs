﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.PostClasses;
using Blog.Domain.PostClasses.Commands;
using Blog.Domain.PostClasses.DTOs;
using Blog.Domain.PostClasses.Queries;
using MediatR;
using Serilog;

namespace Blog.Presentation.Handler.PostClasses
{
    public class GetAllPostHandler:IRequestHandler<GetAllPostQuery,IEnumerable<Post>>
    {
        #region Constructor
        private readonly IPostRepositoryQuery _read;
        private readonly IPostRepositoryCommand _write;

        public GetAllPostHandler(IPostRepositoryQuery read, IPostRepositoryCommand write)
        {
            _read = read;
            _write = write;
        }
        #endregion

        #region Handle

        public async Task<IEnumerable<Post>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {

            string functionName = "GetAllPost:Get:";
            Log.ForContext("Message", functionName)
                .ForContext("Error", "")
                .Information(functionName);



            return await _read.GetAllPost();

        } 
        #endregion
    }
}