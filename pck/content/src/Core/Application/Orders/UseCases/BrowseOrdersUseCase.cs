﻿using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mappers;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class BrowseOrdersUseCase : BrowseAggregatesUseCase<IOrderRepository, BrowseOrdersRequest, BrowseOrdersResponse, BrowseOrdersRecordResponse, Order, OrderIdentity, int>
    {
        public BrowseOrdersUseCase(IUseCaseMapper mapper, IOrderRepository repository) 
            : base(mapper, repository)
        {
        }
    }
}
