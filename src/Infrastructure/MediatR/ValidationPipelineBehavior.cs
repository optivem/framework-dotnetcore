﻿using MediatR;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common;
using System.Threading;
using System.Threading.Tasks;
using IRequest = Optivem.Framework.Core.Common.IRequest;

namespace Optivem.Framework.Infrastructure.MediatR
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<MediatorRequest<TRequest, TResponse>, TResponse>
        where TRequest : Core.Common.IRequest<TResponse>
    {
        private IRequestValidationHandler<TRequest> _validationHandler;

        public ValidationPipelineBehavior(IRequestValidationHandler<TRequest> validationHandler)
        {
            _validationHandler = validationHandler;
        }

        public async Task<TResponse> Handle(MediatorRequest<TRequest, TResponse> request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            await _validationHandler.HandleAsync(request.Request);
            return await next();
        }
    }
}