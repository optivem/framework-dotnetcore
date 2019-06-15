﻿using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.NorthwindLite.Core.Application.Customers.Requests;
using Optivem.NorthwindLite.Core.Application.Customers.Responses;

namespace Optivem.NorthwindLite.Infrastructure.MediatR.Customers
{
    public class UpdateCustomerMediatorRequestHandler : MediatorRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        public UpdateCustomerMediatorRequestHandler(IUseCase<UpdateCustomerRequest, UpdateCustomerResponse> useCase) : base(useCase)
        {
        }
    }
}