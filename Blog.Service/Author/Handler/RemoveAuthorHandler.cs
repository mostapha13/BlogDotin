﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.AuthorClasses;
using Blog.Domain.AuthorClasses.Commands;
using Blog.Domain.AuthorClasses.DTOs;
using Blog.Domain.AuthorClasses.Queries;
using Blog.Domain.Enum;
using MediatR;
using Serilog;

namespace Blog.Service.Author.Handler
{
    public class RemoveAuthorHandler : IRequestHandler<RemoveAuthorCommand, ResultStatus>
    {
        #region Constructor
        private readonly IAuthorRepositoryQuery _read;
        private readonly IAuthorRepositoryCommand _write;
       


        public RemoveAuthorHandler(IAuthorRepositoryQuery read, IAuthorRepositoryCommand write)
        {
            _read = read;
            _write = write;
          
        }
        #endregion

        #region 

        public async Task<ResultStatus> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            string functionName = "RemoveAuthor:Get:" + request.Id;

            var author = await _read.GetAuthorById(request.Id);
            if (author == null)
            {

                Log.ForContext("Message", functionName)
                    .ForContext("Error", "UserNotFound")
                    .Error($"Error: ** {functionName}");
                return ResultStatus.NotFound;
            }



            await _write.RemoveAuthor(author);
            await _write.Save();
            return ResultStatus.Success;


        }


        #endregion
    }
}