using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.AuthorClasses;
using MediatR;

namespace Blog.Service
{
    public class AuthorHandler : IRequestHandler<Author, bool>
    {
        public Task<bool> Handle(Author request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
