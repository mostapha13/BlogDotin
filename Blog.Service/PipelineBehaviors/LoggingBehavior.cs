using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace Blog.Services.PipelineBehaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
         
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Log.ForContext("Message", request)
                .ForContext("Start", "").Information(request.ToString());

            var response = await next();

            Log.ForContext("Message", request)
                .ForContext("End", "").Information(request.ToString());


            return response;
        }
    }
}