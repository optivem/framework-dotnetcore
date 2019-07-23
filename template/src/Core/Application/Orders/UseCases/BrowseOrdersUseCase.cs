﻿using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders.Entities;
using Optivem.Template.Core.Domain.Orders.Repositories;
using Optivem.Template.Core.Domain.Orders.ValueObjects;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class BrowseOrdersUseCase : BrowseAggregatesUseCase<IOrderRepository, BrowseOrdersRequest, BrowseOrdersResponse, BrowseOrdersRecordResponse, Order, OrderIdentity, int>
    {
        public BrowseOrdersUseCase(IOrderRepository repository, ICollectionResponseMapper<Order, BrowseOrdersResponse> responseMapper) : base(repository, responseMapper)
        {
        }
    }
}